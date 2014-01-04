﻿// ****************************************************************************
// 
// Copyright (C) 2005-2014 Doom9 & al
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

namespace MeGUI
{
    partial class ChapterCreator
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

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChapterCreator));
            this.chaptersGroupbox = new System.Windows.Forms.GroupBox();
            this.chapterName = new System.Windows.Forms.TextBox();
            this.chapterNameLabel = new System.Windows.Forms.Label();
            this.chapterListView = new System.Windows.Forms.ListView();
            this.timecodeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.startTime = new System.Windows.Forms.TextBox();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.addZoneButton = new System.Windows.Forms.Button();
            this.clearZonesButton = new System.Windows.Forms.Button();
            this.showVideoButton = new System.Windows.Forms.Button();
            this.removeZoneButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.gbInput = new System.Windows.Forms.GroupBox();
            this.lblMinimumTitleLength = new System.Windows.Forms.Label();
            this.minimumTitleLength = new System.Windows.Forms.NumericUpDown();
            this.btInput = new System.Windows.Forms.Button();
            this.input = new System.Windows.Forms.TextBox();
            this.rbFromFile = new System.Windows.Forms.RadioButton();
            this.rbFromDisk = new System.Windows.Forms.RadioButton();
            this.saveButton = new System.Windows.Forms.Button();
            this.closeOnQueue = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFPS = new System.Windows.Forms.Label();
            this.rbXML = new System.Windows.Forms.RadioButton();
            this.rbQPF = new System.Windows.Forms.RadioButton();
            this.rbTXT = new System.Windows.Forms.RadioButton();
            this.btOutput = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.TextBox();
            this.fpsChooser = new MeGUI.core.gui.FPSChooser();
            this.helpButton1 = new MeGUI.core.gui.HelpButton();
            this.chaptersGroupbox.SuspendLayout();
            this.gbInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimumTitleLength)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chaptersGroupbox
            // 
            this.chaptersGroupbox.Controls.Add(this.chapterName);
            this.chaptersGroupbox.Controls.Add(this.chapterNameLabel);
            this.chaptersGroupbox.Controls.Add(this.chapterListView);
            this.chaptersGroupbox.Controls.Add(this.startTime);
            this.chaptersGroupbox.Controls.Add(this.startTimeLabel);
            this.chaptersGroupbox.Controls.Add(this.addZoneButton);
            this.chaptersGroupbox.Controls.Add(this.clearZonesButton);
            this.chaptersGroupbox.Controls.Add(this.showVideoButton);
            this.chaptersGroupbox.Controls.Add(this.removeZoneButton);
            this.chaptersGroupbox.Location = new System.Drawing.Point(4, 86);
            this.chaptersGroupbox.Name = "chaptersGroupbox";
            this.chaptersGroupbox.Size = new System.Drawing.Size(458, 336);
            this.chaptersGroupbox.TabIndex = 23;
            this.chaptersGroupbox.TabStop = false;
            this.chaptersGroupbox.Text = " Chapters ";
            // 
            // chapterName
            // 
            this.chapterName.Location = new System.Drawing.Point(75, 305);
            this.chapterName.Name = "chapterName";
            this.chapterName.Size = new System.Drawing.Size(306, 21);
            this.chapterName.TabIndex = 38;
            this.chapterName.Text = "Chapter 01";
            this.chapterName.TextChanged += new System.EventHandler(this.chapterName_TextChanged);
            // 
            // chapterNameLabel
            // 
            this.chapterNameLabel.Location = new System.Drawing.Point(13, 308);
            this.chapterNameLabel.Name = "chapterNameLabel";
            this.chapterNameLabel.Size = new System.Drawing.Size(56, 17);
            this.chapterNameLabel.TabIndex = 37;
            this.chapterNameLabel.Text = "Name :";
            // 
            // chapterListView
            // 
            this.chapterListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.timecodeColumn,
            this.nameColumn});
            this.chapterListView.FullRowSelect = true;
            this.chapterListView.Location = new System.Drawing.Point(10, 24);
            this.chapterListView.Name = "chapterListView";
            this.chapterListView.Size = new System.Drawing.Size(372, 240);
            this.chapterListView.TabIndex = 36;
            this.chapterListView.UseCompatibleStateImageBehavior = false;
            this.chapterListView.View = System.Windows.Forms.View.Details;
            this.chapterListView.SelectedIndexChanged += new System.EventHandler(this.chapterListView_SelectedIndexChanged);
            // 
            // timecodeColumn
            // 
            this.timecodeColumn.Text = "Timecode";
            this.timecodeColumn.Width = 100;
            // 
            // nameColumn
            // 
            this.nameColumn.Text = "Name";
            this.nameColumn.Width = 250;
            // 
            // startTime
            // 
            this.startTime.Location = new System.Drawing.Point(75, 274);
            this.startTime.Name = "startTime";
            this.startTime.Size = new System.Drawing.Size(306, 21);
            this.startTime.TabIndex = 23;
            this.startTime.Text = "00:00:00.000";
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.Location = new System.Drawing.Point(13, 277);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(64, 16);
            this.startTimeLabel.TabIndex = 24;
            this.startTimeLabel.Text = "Start Time :";
            // 
            // addZoneButton
            // 
            this.addZoneButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addZoneButton.Location = new System.Drawing.Point(392, 23);
            this.addZoneButton.Name = "addZoneButton";
            this.addZoneButton.Size = new System.Drawing.Size(55, 23);
            this.addZoneButton.TabIndex = 33;
            this.addZoneButton.Text = "&Add";
            this.addZoneButton.Click += new System.EventHandler(this.addZoneButton_Click);
            // 
            // clearZonesButton
            // 
            this.clearZonesButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.clearZonesButton.Location = new System.Drawing.Point(392, 81);
            this.clearZonesButton.Name = "clearZonesButton";
            this.clearZonesButton.Size = new System.Drawing.Size(55, 23);
            this.clearZonesButton.TabIndex = 29;
            this.clearZonesButton.Text = "&Clear";
            this.clearZonesButton.Click += new System.EventHandler(this.clearZonesButton_Click);
            // 
            // showVideoButton
            // 
            this.showVideoButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.showVideoButton.Enabled = false;
            this.showVideoButton.Location = new System.Drawing.Point(392, 110);
            this.showVideoButton.Name = "showVideoButton";
            this.showVideoButton.Size = new System.Drawing.Size(55, 23);
            this.showVideoButton.TabIndex = 34;
            this.showVideoButton.Text = "&Preview";
            this.showVideoButton.Click += new System.EventHandler(this.showVideoButton_Click);
            // 
            // removeZoneButton
            // 
            this.removeZoneButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.removeZoneButton.Location = new System.Drawing.Point(392, 52);
            this.removeZoneButton.Name = "removeZoneButton";
            this.removeZoneButton.Size = new System.Drawing.Size(55, 23);
            this.removeZoneButton.TabIndex = 32;
            this.removeZoneButton.Text = "&Remove";
            this.removeZoneButton.Click += new System.EventHandler(this.removeZoneButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "txt";
            this.openFileDialog.Filter = "Blu-ray Playlist Files (*.mpls)|*.mpls|IFO Files (*.ifo)|*.ifo|Chapter Files (*.t" +
    "xt)|*.txt|All Files supported (*.ifo;*.txt;*.mpls)|*.ifo;*.mpls;*.txt";
            this.openFileDialog.FilterIndex = 4;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "txt";
            this.saveFileDialog.Filter = "Chapter Files (*.txt)|*.txt|Matroska Chapters files (*.xml)|*.xml|x264 qp Files (" +
    "*.qpf)|*.qpf|All supported Files (*.txt;*.xml;*.qpf)|*.txt;*.xml;*.qpf";
            this.saveFileDialog.FilterIndex = 4;
            // 
            // gbInput
            // 
            this.gbInput.Controls.Add(this.lblMinimumTitleLength);
            this.gbInput.Controls.Add(this.minimumTitleLength);
            this.gbInput.Controls.Add(this.btInput);
            this.gbInput.Controls.Add(this.input);
            this.gbInput.Controls.Add(this.rbFromFile);
            this.gbInput.Controls.Add(this.rbFromDisk);
            this.gbInput.Location = new System.Drawing.Point(4, 4);
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(458, 76);
            this.gbInput.TabIndex = 24;
            this.gbInput.TabStop = false;
            this.gbInput.Text = " Input ";
            // 
            // lblMinimumTitleLength
            // 
            this.lblMinimumTitleLength.AutoSize = true;
            this.lblMinimumTitleLength.Location = new System.Drawing.Point(219, 51);
            this.lblMinimumTitleLength.Name = "lblMinimumTitleLength";
            this.lblMinimumTitleLength.Size = new System.Drawing.Size(162, 13);
            this.lblMinimumTitleLength.TabIndex = 12;
            this.lblMinimumTitleLength.Text = "Minimum title length (in seconds)";
            // 
            // minimumTitleLength
            // 
            this.minimumTitleLength.Location = new System.Drawing.Point(393, 49);
            this.minimumTitleLength.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.minimumTitleLength.Name = "minimumTitleLength";
            this.minimumTitleLength.Size = new System.Drawing.Size(54, 21);
            this.minimumTitleLength.TabIndex = 11;
            this.minimumTitleLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.minimumTitleLength.Value = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.minimumTitleLength.ValueChanged += new System.EventHandler(this.minimumTitleLength_ValueChanged);
            // 
            // btInput
            // 
            this.btInput.Location = new System.Drawing.Point(392, 19);
            this.btInput.Name = "btInput";
            this.btInput.Size = new System.Drawing.Size(55, 23);
            this.btInput.TabIndex = 10;
            this.btInput.Text = "...";
            this.btInput.UseVisualStyleBackColor = true;
            this.btInput.Click += new System.EventHandler(this.btInput_Click);
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(16, 20);
            this.input.Name = "input";
            this.input.ReadOnly = true;
            this.input.Size = new System.Drawing.Size(365, 21);
            this.input.TabIndex = 9;
            // 
            // rbFromFile
            // 
            this.rbFromFile.AutoSize = true;
            this.rbFromFile.Checked = true;
            this.rbFromFile.Location = new System.Drawing.Point(16, 49);
            this.rbFromFile.Name = "rbFromFile";
            this.rbFromFile.Size = new System.Drawing.Size(68, 17);
            this.rbFromFile.TabIndex = 8;
            this.rbFromFile.TabStop = true;
            this.rbFromFile.Text = "From File";
            this.rbFromFile.UseVisualStyleBackColor = true;
            // 
            // rbFromDisk
            // 
            this.rbFromDisk.AutoSize = true;
            this.rbFromDisk.Location = new System.Drawing.Point(117, 49);
            this.rbFromDisk.Name = "rbFromDisk";
            this.rbFromDisk.Size = new System.Drawing.Size(71, 17);
            this.rbFromDisk.TabIndex = 7;
            this.rbFromDisk.Text = "From Disk";
            this.rbFromDisk.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(396, 519);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(55, 23);
            this.saveButton.TabIndex = 41;
            this.saveButton.Text = "&Save";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // closeOnQueue
            // 
            this.closeOnQueue.Checked = true;
            this.closeOnQueue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.closeOnQueue.Location = new System.Drawing.Point(313, 519);
            this.closeOnQueue.Name = "closeOnQueue";
            this.closeOnQueue.Size = new System.Drawing.Size(72, 24);
            this.closeOnQueue.TabIndex = 43;
            this.closeOnQueue.Text = "and close";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFPS);
            this.groupBox1.Controls.Add(this.fpsChooser);
            this.groupBox1.Controls.Add(this.rbXML);
            this.groupBox1.Controls.Add(this.rbQPF);
            this.groupBox1.Controls.Add(this.rbTXT);
            this.groupBox1.Controls.Add(this.btOutput);
            this.groupBox1.Controls.Add(this.output);
            this.groupBox1.Location = new System.Drawing.Point(4, 428);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 76);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Chapter Output File ";
            // 
            // lblFPS
            // 
            this.lblFPS.AutoSize = true;
            this.lblFPS.Location = new System.Drawing.Point(252, 22);
            this.lblFPS.Name = "lblFPS";
            this.lblFPS.Size = new System.Drawing.Size(25, 13);
            this.lblFPS.TabIndex = 15;
            this.lblFPS.Text = "FPS";
            this.lblFPS.Visible = false;
            // 
            // rbXML
            // 
            this.rbXML.AutoSize = true;
            this.rbXML.Location = new System.Drawing.Point(131, 21);
            this.rbXML.Name = "rbXML";
            this.rbXML.Size = new System.Drawing.Size(41, 17);
            this.rbXML.TabIndex = 13;
            this.rbXML.Text = "xml";
            this.rbXML.UseVisualStyleBackColor = true;
            this.rbXML.CheckedChanged += new System.EventHandler(this.rbXML_CheckedChanged);
            // 
            // rbQPF
            // 
            this.rbQPF.AutoSize = true;
            this.rbQPF.Location = new System.Drawing.Point(75, 21);
            this.rbQPF.Name = "rbQPF";
            this.rbQPF.Size = new System.Drawing.Size(41, 17);
            this.rbQPF.TabIndex = 12;
            this.rbQPF.Text = "qpf";
            this.rbQPF.UseVisualStyleBackColor = true;
            this.rbQPF.CheckedChanged += new System.EventHandler(this.rbQPF_CheckedChanged);
            // 
            // rbTXT
            // 
            this.rbTXT.AutoSize = true;
            this.rbTXT.Checked = true;
            this.rbTXT.Location = new System.Drawing.Point(18, 21);
            this.rbTXT.Name = "rbTXT";
            this.rbTXT.Size = new System.Drawing.Size(39, 17);
            this.rbTXT.TabIndex = 11;
            this.rbTXT.TabStop = true;
            this.rbTXT.Text = "txt";
            this.rbTXT.UseVisualStyleBackColor = true;
            this.rbTXT.CheckedChanged += new System.EventHandler(this.rbTXT_CheckedChanged);
            // 
            // btOutput
            // 
            this.btOutput.Location = new System.Drawing.Point(392, 48);
            this.btOutput.Name = "btOutput";
            this.btOutput.Size = new System.Drawing.Size(55, 23);
            this.btOutput.TabIndex = 10;
            this.btOutput.Text = "...";
            this.btOutput.UseVisualStyleBackColor = true;
            this.btOutput.Click += new System.EventHandler(this.btOutput_Click);
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(16, 49);
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(365, 21);
            this.output.TabIndex = 9;
            // 
            // fpsChooser
            // 
            this.fpsChooser.Location = new System.Drawing.Point(284, 14);
            this.fpsChooser.MaximumSize = new System.Drawing.Size(1000, 29);
            this.fpsChooser.MinimumSize = new System.Drawing.Size(64, 29);
            this.fpsChooser.Name = "fpsChooser";
            this.fpsChooser.NullString = null;
            this.fpsChooser.SelectedIndex = 0;
            this.fpsChooser.Size = new System.Drawing.Size(98, 29);
            this.fpsChooser.TabIndex = 14;
            this.fpsChooser.Visible = false;
            // 
            // helpButton1
            // 
            this.helpButton1.ArticleName = "Chapter Creator";
            this.helpButton1.AutoSize = true;
            this.helpButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.helpButton1.Location = new System.Drawing.Point(12, 519);
            this.helpButton1.Name = "helpButton1";
            this.helpButton1.Size = new System.Drawing.Size(38, 23);
            this.helpButton1.TabIndex = 42;
            // 
            // ChapterCreator
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(468, 554);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.closeOnQueue);
            this.Controls.Add(this.helpButton1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.gbInput);
            this.Controls.Add(this.chaptersGroupbox);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChapterCreator";
            this.Text = "MeGUI - Chapter Creator";
            this.Load += new System.EventHandler(this.ChapterCreator_Load);
            this.chaptersGroupbox.ResumeLayout(false);
            this.chaptersGroupbox.PerformLayout();
            this.gbInput.ResumeLayout(false);
            this.gbInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimumTitleLength)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.GroupBox chaptersGroupbox;
        private System.Windows.Forms.Button addZoneButton;
        private System.Windows.Forms.Button clearZonesButton;
        private System.Windows.Forms.Button showVideoButton;
        private System.Windows.Forms.Button removeZoneButton;
        private System.Windows.Forms.ColumnHeader timecodeColumn;
        private System.Windows.Forms.ColumnHeader nameColumn;
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.Label chapterNameLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox startTime;
        private System.Windows.Forms.TextBox chapterName;
        private System.Windows.Forms.ListView chapterListView;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.GroupBox gbInput;
        private System.Windows.Forms.RadioButton rbFromFile;
        private System.Windows.Forms.RadioButton rbFromDisk;
        private System.Windows.Forms.Button btInput;
        private System.Windows.Forms.TextBox input;
        private MeGUI.core.gui.HelpButton helpButton1;
        private System.Windows.Forms.CheckBox closeOnQueue;
        private System.Windows.Forms.Label lblMinimumTitleLength;
        private System.Windows.Forms.NumericUpDown minimumTitleLength;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btOutput;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.RadioButton rbXML;
        private System.Windows.Forms.RadioButton rbQPF;
        private System.Windows.Forms.RadioButton rbTXT;
        private core.gui.FPSChooser fpsChooser;
        private System.Windows.Forms.Label lblFPS;
    }
}