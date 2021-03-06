using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MeGUI
{
    public partial class AdaptiveMuxWindow : baseMuxWindow
    {
        private MuxProvider muxProvider;
        private JobUtil jobUtil;
        private bool minimizedMode = false;
        private MuxableType knownVideoType;
        private MuxableType[] knownAudioTypes;
        public AdaptiveMuxWindow(MainForm mainForm)
        {
            InitializeComponent();
            jobUtil = new JobUtil(mainForm);
            muxProvider = mainForm.MuxProvider;
        }

        protected override void fileUpdated()
        {
            updatePossibleContainers();
        }

        private void containerFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.muxedOutput.Text = Path.ChangeExtension(this.muxedOutput.Text, (this.containerFormat.SelectedItem as OutputType).Extension);
        }

        private void getTypes(out AudioEncoderType[] aCodec, out MuxableType[] audioTypes, out MuxableType[] subtitleTypes)
        {
            List<MuxableType> audioTypesList = new List<MuxableType>();
            List<MuxableType> subTypesList = new List<MuxableType>();
            List<AudioEncoderType> audioCodecList = new List<AudioEncoderType>();

            int counter = 0;
            foreach (SubStream stream in audioStreams)
            {
                if (minimizedMode && knownAudioTypes.Length > counter)
                {
                    audioCodecList.Add((AudioEncoderType)knownAudioTypes[counter].codec);
                }
                else
                {
                    MuxableType audioType = VideoUtil.guessAudioMuxableType(stream.path, true);
                    if (audioType != null)
                    {
                        audioTypesList.Add(audioType);
                    }
                }
                counter++;
            }
            foreach (SubStream stream in subtitleStreams)
            {
                SubtitleType subtitleType = VideoUtil.guessSubtitleType(stream.path);
                if (subtitleType != null)
                {
                    subTypesList.Add(new MuxableType(subtitleType, null));
                }
            }
            audioTypes = audioTypesList.ToArray();
            subtitleTypes = subTypesList.ToArray();
            aCodec = audioCodecList.ToArray();
        }

        private void getStreams(out SubStream[] audioStreams, out SubStream[] subtitleStreams)
        {
            List<SubStream> audioStreamsList = new List<SubStream>();
            List<SubStream> subtitleStreamList = new List<SubStream>();
            foreach (SubStream stream in this.audioStreams)
            {
                if (!string.IsNullOrEmpty(stream.path))
                    audioStreamsList.Add(stream);
            }
            foreach (SubStream stream in this.subtitleStreams)
            {
                if (!string.IsNullOrEmpty(stream.path))
                    subtitleStreamList.Add(stream);
            }
            audioStreams = audioStreamsList.ToArray();
            subtitleStreams = subtitleStreamList.ToArray();
        }

        protected override void checkIO()
        {
            base.checkIO();
            if (!(containerFormat.SelectedItem is ContainerType))
                muxButton.DialogResult = DialogResult.None;
        }

        private void updatePossibleContainers()
        {
            MuxableType videoType;
            if (minimizedMode)
                videoType = knownVideoType;
            else
                videoType = VideoUtil.guessVideoMuxableType(videoInput.Text, true);

            if (videoType == null)
            {
                this.containerFormat.Items.Clear();
                this.containerFormat.Items.AddRange(muxProvider.GetSupportedContainers().ToArray());
                this.containerFormat.SelectedIndex = 0;
                return;
            }

            MuxableType[] audioTypes;
            MuxableType[] subTypes;
            AudioEncoderType[] audioCodecs;
            getTypes(out audioCodecs, out audioTypes, out subTypes);

            List<MuxableType> allTypes = new List<MuxableType>();
            allTypes.Add(videoType);
            allTypes.AddRange(audioTypes);
            allTypes.AddRange(subTypes);

            List<ContainerType> supportedOutputTypes;

            if (minimizedMode)
            {
                supportedOutputTypes = this.muxProvider.GetSupportedContainers(null, audioCodecs,
                    allTypes.ToArray());
            }
            else
            {
                supportedOutputTypes = this.muxProvider.GetSupportedContainers(allTypes.ToArray());
            }

            ContainerType lastSelectedFileType = null;
            if (containerFormat.SelectedItem is ContainerType)
                lastSelectedFileType = containerFormat.SelectedItem as ContainerType;

            if (supportedOutputTypes.Count > 0)
            {
                this.containerFormat.Items.Clear();
                this.containerFormat.Items.AddRange(supportedOutputTypes.ToArray());
                this.containerFormat.SelectedIndex = 0;
                if (lastSelectedFileType != null && containerFormat.Items.Contains(lastSelectedFileType))
                    containerFormat.SelectedItem = lastSelectedFileType;
            }
            else
            {
                this.containerFormat.Items.Clear();
                MessageBox.Show("No muxer can be found that supports this input configuration", "Muxing impossible", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public MuxJob[] Jobs
        {
            get
            {
                if (minimizedMode)
                    throw new Exception("Jobs property not accessible in minimized mode");
                double framerate = -1;
                if (this.muxFPS.SelectedIndex != -1)
                    framerate = Double.Parse(muxFPS.Text);

                VideoStream myVideo = new VideoStream();
                myVideo.Input = "";
                myVideo.Output = videoInput.Text;
                myVideo.NumberOfFrames = 1000; // Just a guess, since we have no way of actually knowing
                myVideo.Framerate = framerate;
                myVideo.VideoType = VideoUtil.guessVideoMuxableType(videoInput.Text, true);
                myVideo.Settings = new x264Settings();
                myVideo.Settings.NbBframes = 0;

                MuxableType[] audioTypes;
                MuxableType[] subtitleTypes;
                AudioEncoderType[] audioCodecs;
                SubStream[] audioStreams, subtitleStreams;
                getTypes(out audioCodecs, out audioTypes, out subtitleTypes);
                getStreams(out audioStreams, out subtitleStreams);

                int splitSize = -1;
                if (enableSplit.Checked)
                {
                    if (!int.TryParse(this.splitSize.Text, out splitSize))
                        splitSize = -1;
                }
                MuxableType chapterInputType = null;
                if (!String.IsNullOrEmpty(chaptersInput.Text))
                {
                    ChapterType type = VideoUtil.guessChapterType(chaptersInput.Text);
                    if (type != null)
                        chapterInputType = new MuxableType(type, null);
                }

                return jobUtil.GenerateMuxJobs(myVideo, audioStreams, audioTypes, subtitleStreams,
                    subtitleTypes, chaptersInput.Text, chapterInputType, (containerFormat.SelectedItem as ContainerType), muxedOutput.Text, splitSize);
            }
        }
        /// <summary>
        /// sets the GUI to a minimal mode allowing to configure audio track languages, configure subtitles, and chapters
        /// the rest of the options are deactivated
        /// </summary>
        /// <param name="videoInput">the video input</param>
        /// <param name="framerate">the framerate of the video input</param>
        /// <param name="audioStreams">the audio streams whose languages have to be assigned</param>
        /// <param name="output">the output file</param>
        /// <param name="splitSize">the output split size</param>
        public void setMinimizedMode(string videoInput, MuxableType videoType, double framerate, SubStream[] audioStreams, MuxableType[] audioTypes, string output,
            int splitSize, ContainerType cft)
        {
            minimizedMode = true;
            knownVideoType = videoType;
            knownAudioTypes = audioTypes;
            videoGroupbox.Enabled = false;
            this.videoInput.Text = videoInput;
            int fpsIndex = muxFPS.Items.IndexOf(framerate);
            if (fpsIndex != -1)
                muxFPS.SelectedIndex = fpsIndex;
            if (audioStreams.Length == 1) // 1 stream predefined
            {
                preconfigured = new bool[] { true, false };
                this.audioStreams[0] = audioStreams[0];
                audioInputOpenButton.Enabled = false;
                removeAudioTrackButton.Enabled = false;
                this.audioDelay.Enabled = false;
                audioInput.Text = audioStreams[0].path;
            }
            else if (audioStreams.Length == 2) // both streams are defined, disable audio opening facilities
            {
                preconfigured = new bool[] { true, true };
                this.audioStreams = audioStreams;
                removeAudioTrackButton.Enabled = false;
                audioInput.Text = audioStreams[0].path;
                audioInputOpenButton.Enabled = false;
                removeAudioTrackButton.Enabled = false;
                this.audioDelay.Enabled = false;
            }
            else // no audio tracks predefined
            {
                preconfigured = new bool[] { false, false };
            }
            muxedOutput.Text = output;
            this.splitSize.Text = splitSize.ToString();
            if (splitSize > 0)
                enableSplit.Checked = true;
            this.muxButton.Text = "Go";
            updatePossibleContainers();
            if (this.containerFormat.Items.Contains(cft))
                containerFormat.SelectedItem = cft;
            checkIO();
        }
        #region filters
        public override string AudioFilter
        {
            get
            {
                return VideoUtil.GenerateCombinedFilter(ContainerManager.AudioTypes.ValuesArray);
            }
        }
        public override string ChaptersFilter
        {
            get
            {
                return "Chapter files (*.txt)|*.txt";
            }
        }
        public override string OutputFilter
        {
            get
            {
                if (containerFormat.SelectedItem is ContainerType)
                {
                    return (containerFormat.SelectedItem as ContainerType).OutputFilterString;
                }
                else
                    return "";
            }
        }
        public override string SubtitleFilter
        {
            get
            {
                return VideoUtil.GenerateCombinedFilter(ContainerManager.SubtitleTypes.ValuesArray);
            }
        }
        public override string VideoInputFilter
        {
            get
            {
                return VideoUtil.GenerateCombinedFilter(ContainerManager.VideoTypes.ValuesArray);
            }
        }
        #endregion

        public void getAdditionalStreams(out SubStream[] audio, out SubStream[] subtitles, out string chapters, out string output, out ContainerType cot)
        {
            cot = (containerFormat.SelectedItem as ContainerType);
            output = muxedOutput.Text;
            base.getAdditionalStreams(out audio, out subtitles, out chapters);
        }
    }
}