namespace MeGUI
{
    partial class VideoEncodingComponent
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.videoOutputLabel = new System.Windows.Forms.Label();
            this.videoInputLabel = new System.Windows.Forms.Label();
            this.queueVideoButton = new System.Windows.Forms.Button();
            this.addAnalysisPass = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.editZonesButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.fileType = new System.Windows.Forms.ComboBox();
            this.videopreview = new System.Windows.Forms.Button();
            this.addPrerenderJob = new System.Windows.Forms.CheckBox();
            this.videoProfile = new MeGUI.core.gui.ConfigableProfilesControl();
            this.videoInput = new MeGUI.FileBar();
            this.videoOutput = new MeGUI.FileBar();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // videoOutputLabel
            // 
            this.videoOutputLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.videoOutputLabel.AutoSize = true;
            this.videoOutputLabel.Location = new System.Drawing.Point(3, 37);
            this.videoOutputLabel.Name = "videoOutputLabel";
            this.videoOutputLabel.Size = new System.Drawing.Size(127, 13);
            this.videoOutputLabel.TabIndex = 2;
            this.videoOutputLabel.Text = "Video Output";
            // 
            // videoInputLabel
            // 
            this.videoInputLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.videoInputLabel.AutoSize = true;
            this.videoInputLabel.Location = new System.Drawing.Point(3, 8);
            this.videoInputLabel.Name = "videoInputLabel";
            this.videoInputLabel.Size = new System.Drawing.Size(127, 13);
            this.videoInputLabel.TabIndex = 0;
            this.videoInputLabel.Text = "AviSynth Script";
            // 
            // queueVideoButton
            // 
            this.queueVideoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.queueVideoButton.AutoSize = true;
            this.queueVideoButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.queueVideoButton.Location = new System.Drawing.Point(420, 121);
            this.queueVideoButton.Name = "queueVideoButton";
            this.queueVideoButton.Size = new System.Drawing.Size(61, 23);
            this.queueVideoButton.TabIndex = 11;
            this.queueVideoButton.Text = "Queue";
            this.queueVideoButton.Click += new System.EventHandler(this.queueVideoButton_Click);
            // 
            // addAnalysisPass
            // 
            this.addAnalysisPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.addAnalysisPass.AutoSize = true;
            this.addAnalysisPass.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addAnalysisPass.Location = new System.Drawing.Point(278, 121);
            this.addAnalysisPass.Name = "addAnalysisPass";
            this.addAnalysisPass.Size = new System.Drawing.Size(136, 23);
            this.addAnalysisPass.TabIndex = 9;
            this.addAnalysisPass.Text = "Queue Analysis Pass";
            this.addAnalysisPass.UseVisualStyleBackColor = true;
            this.addAnalysisPass.Click += new System.EventHandler(this.addAnalysisPass_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 168);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Video encoding";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.videoInputLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.queueVideoButton, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.editZonesButton, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.videoOutputLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.videoProfile, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.videoInput, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.videoOutput, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.fileType, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.videopreview, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.addAnalysisPass, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.addPrerenderJob, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(484, 149);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "File format";
            // 
            // editZonesButton
            // 
            this.editZonesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.editZonesButton.AutoSize = true;
            this.editZonesButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.editZonesButton.Location = new System.Drawing.Point(423, 90);
            this.editZonesButton.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.editZonesButton.Name = "editZonesButton";
            this.editZonesButton.Size = new System.Drawing.Size(55, 23);
            this.editZonesButton.TabIndex = 13;
            this.editZonesButton.Text = "Zones";
            this.editZonesButton.UseVisualStyleBackColor = true;
            this.editZonesButton.Click += new System.EventHandler(this.editZonesButton_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Encoder settings";
            // 
            // fileType
            // 
            this.fileType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.fileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fileType.Location = new System.Drawing.Point(136, 91);
            this.fileType.Name = "fileType";
            this.fileType.Size = new System.Drawing.Size(136, 21);
            this.fileType.TabIndex = 14;
            this.fileType.SelectedIndexChanged += new System.EventHandler(this.fileType_SelectedIndexChanged);
            // 
            // videopreview
            // 
            this.videopreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.videopreview.AutoSize = true;
            this.videopreview.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.videopreview.Location = new System.Drawing.Point(136, 121);
            this.videopreview.Name = "videopreview";
            this.videopreview.Size = new System.Drawing.Size(136, 23);
            this.videopreview.TabIndex = 16;
            this.videopreview.Text = "Reopen Video Preview";
            this.videopreview.UseVisualStyleBackColor = true;
            this.videopreview.Click += new System.EventHandler(this.videopreview_Click);
            // 
            // addPrerenderJob
            // 
            this.addPrerenderJob.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.addPrerenderJob.AutoSize = true;
            this.addPrerenderJob.Location = new System.Drawing.Point(3, 124);
            this.addPrerenderJob.Name = "addPrerenderJob";
            this.addPrerenderJob.Size = new System.Drawing.Size(127, 17);
            this.addPrerenderJob.TabIndex = 17;
            this.addPrerenderJob.Text = "Add pre-rendering job";
            this.addPrerenderJob.UseVisualStyleBackColor = true;
            // 
            // videoProfile
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.videoProfile, 3);
            this.videoProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoProfile.Location = new System.Drawing.Point(136, 61);
            this.videoProfile.Name = "videoProfile";
            this.videoProfile.ProfileSet = "Video";
            this.videoProfile.Size = new System.Drawing.Size(345, 23);
            this.videoProfile.TabIndex = 12;
            this.videoProfile.SelectedProfileChanged += new System.EventHandler(this.videoProfile_SelectedProfileChanged);
            // 
            // videoInput
            // 
            this.videoInput.AllowDrop = true;
            this.tableLayoutPanel1.SetColumnSpan(this.videoInput, 3);
            this.videoInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoInput.Filename = "";
            this.videoInput.Filter = "AviSynth files (*.avs)|*.avs|All files (*.*)|*.*";
            this.videoInput.FilterIndex = 0;
            this.videoInput.FolderMode = false;
            this.videoInput.Location = new System.Drawing.Point(136, 3);
            this.videoInput.Name = "videoInput";
            this.videoInput.ReadOnly = true;
            this.videoInput.SaveMode = false;
            this.videoInput.Size = new System.Drawing.Size(345, 23);
            this.videoInput.TabIndex = 1;
            this.videoInput.Title = "Open AviSynth script";
            this.videoInput.FileSelected += new MeGUI.FileBarEventHandler(this.videoInput_FileSelected);
            // 
            // videoOutput
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.videoOutput, 3);
            this.videoOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoOutput.Filename = "";
            this.videoOutput.Filter = null;
            this.videoOutput.FilterIndex = 0;
            this.videoOutput.FolderMode = false;
            this.videoOutput.Location = new System.Drawing.Point(136, 32);
            this.videoOutput.Name = "videoOutput";
            this.videoOutput.ReadOnly = false;
            this.videoOutput.SaveMode = true;
            this.videoOutput.Size = new System.Drawing.Size(345, 23);
            this.videoOutput.TabIndex = 3;
            this.videoOutput.Title = "Enter name of output";
            this.videoOutput.FileSelected += new MeGUI.FileBarEventHandler(this.videoOutput_FileSelected);
            // 
            // VideoEncodingComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "VideoEncodingComponent";
            this.Size = new System.Drawing.Size(490, 168);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label videoOutputLabel;
        private System.Windows.Forms.Label videoInputLabel;
        private System.Windows.Forms.Button queueVideoButton;
        private System.Windows.Forms.Button addAnalysisPass;
        private FileBar videoInput;
        private FileBar videoOutput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private MeGUI.core.gui.ConfigableProfilesControl videoProfile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button editZonesButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox fileType;
        private System.Windows.Forms.Button videopreview;
        private System.Windows.Forms.CheckBox addPrerenderJob;

    }
}
