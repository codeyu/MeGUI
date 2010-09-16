// ****************************************************************************
// 
// Copyright (C) 2005-2009  Doom9 & al
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MeGUI.core.gui
{
    public partial class AutoUpdateServerConfigWindow : Form
    {
        private string[][] serverLists;
        private string oldTitle = null;
        private int oldIndex = -1;

        public AutoUpdateServerConfigWindow()
        {
            InitializeComponent();
        }

        private void addServerButton_Click(object sender, EventArgs e)
        {
            string serverName = InputBox.Show(
                "Please enter the server address", 
                "Please enter the server address",
                "http://yourserver.org/path/to/update/folder/");
            if (serverName == null) return;
            serverName = serverName.Trim();
            if (!serverName.EndsWith("/"))
                serverName += "/";

            if (serverList.Items.Contains(serverName))
            {
                MessageBox.Show("Server already listed. Adding nothing", "Server already listed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!serverName.StartsWith("http://"))
            {
                MessageBox.Show("Only http servers are supported", "Server not http", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UpdateWindow oUpdateWindow = new UpdateWindow(MainForm.Instance, MainForm.Instance.Settings, true);
            if (oUpdateWindow.GetUpdateXML(false, serverName) != UpdateWindow.ErrorState.Successful)
            {
                if (MessageBox.Show("The server or the XML file is not available.\r\nShould it be added nevertheless?", "No connection to server", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes)
                    return;
            }
            serverList.Items.Add(serverName);
        }

        private void removeSelectedServersButton_Click(object sender, EventArgs e)
        {
            object[] items = new object[serverList.SelectedItems.Count];
            serverList.SelectedItems.CopyTo(items, 0);
            foreach (object o in items)
            {
                serverList.Items.Remove(o);
            }
        }

        public int ServerListIndex
        {
            get
            {
                return subList.SelectedIndex;
            }
            set
            {
                subList.SelectedIndex = value;
            }
        }

        public string[][] ServerList
        {
            get
            {
                subList_SelectedIndexChanged(null, null);
                return serverLists;
            }
            set
            {
                serverLists = value;
                oldIndex = -1;
                subList.Items.Clear();
                
                foreach (string[] sub in value)
                    subList.Items.Add(sub[0]);

                subList_SelectedIndexChanged(null, null);
            }
        }

        private string[] littleServerList
        {
            get
            {
                List<string> list = new List<string>();
                list.Add(oldTitle);
                foreach (string o in serverList.Items)
                    list.Add(o);
                return list.ToArray();
            }
            set
            {
                oldTitle = value[0];
                serverList.Items.Clear();
                serverList.Items.AddRange(value);
                serverList.Items.RemoveAt(0);
            }
        }

        private void subList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (oldIndex > -1)
                serverLists[oldIndex] = littleServerList;
            oldIndex = subList.SelectedIndex;
            if (oldIndex > -1) 
                littleServerList = serverLists[subList.SelectedIndex];
            if (subList.SelectedIndex < 2)
                addServerButton.Enabled = removeSelectedServersButton.Enabled = false;
            else
                addServerButton.Enabled = removeSelectedServersButton.Enabled = true;
        }
    }
}