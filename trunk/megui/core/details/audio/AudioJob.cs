// ****************************************************************************
// 
// Copyright (C) 2005  Doom9
// 
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
// 
// ****************************************************************************

using System;
using MeGUI.core.plugins.interfaces;
using System.Xml.Serialization;
using MeGUI.core.details;

namespace MeGUI
{
	/// <summary>
	/// Container object for audio encoding
	/// holds all the parameters relevant for aac encoding in besweet
	/// </summary>
	public class AudioJob : Job
	{
        public string CutFile;
		public AudioCodecSettings Settings;
        public int Delay;

        public AudioJob() : this(null, null, null, null, 0) { }

        public AudioJob(string input, string output, string cutfile, AudioCodecSettings settings, int delay)
            :base(input, output)
        {
            CutFile = cutfile;
            Settings = settings;
            Delay = delay;
        }

        public long SizeBytes;

        public TrackInfo TrackInfo;


        public MuxableType ToMuxableType()
        {
            return new MuxableType(Type, Settings.Codec);
        }

        public MuxStream ToMuxStream()
        {
            return new MuxStream(Output, TrackInfo, 0); 
            // no delay correction is required since the audio job will fix the delay
        }

		public override string CodecString
		{
			get
			{
                return Settings.getSettingsType();
			}
		}

        public override string EncodingMode
		{
			get
			{
                return "audio";
            }
		}

        [XmlIgnore]
        public AudioType Type
        {
            get
            {
                return VideoUtil.guessAudioType(Output);
            }
        }

        public BitrateManagementMode BitrateMode;
    }
}
