﻿// ****************************************************************************
// 
// Copyright (C) 2005-2016 Doom9 & al
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
using System.Text;

using MeGUI.core.util;

namespace MeGUI.packages.video.x265
{
    class x265SettingsHandler
    {
        private x265Settings _xs;
        private LogItem _log;
        
        public x265SettingsHandler(x265Settings xs, LogItem log)
		{
            _xs = xs;
            _log = log;
        }

        /// <summary>
        /// Calculates --sar value
        /// </summary>
        /// <returns>the --sar value</returns>
        public int getSar(Dar? d, int hRes, int vRes, out string CustomSarValue, string CustomSarValueInput)
        {
            string strCustomValue;
            CustomSarValue = String.Empty;
            if (String.IsNullOrEmpty(CustomSarValueInput) && extractCustomCommand("sar", out strCustomValue))
            {
                switch (strCustomValue.ToLowerInvariant())
                {
                    case "1:1": _xs.SampleAR = 1; break;
                    case "4:3": _xs.SampleAR = 2; break;
                    case "8:9": _xs.SampleAR = 3; break;
                    case "10:11": _xs.SampleAR = 4; break;
                    case "12:11": _xs.SampleAR = 5; break;
                    case "16:11": _xs.SampleAR = 6; break;
                    case "32:27": _xs.SampleAR = 7; break;
                    case "40:33": _xs.SampleAR = 8; break;
                    case "64:45": _xs.SampleAR = 9; break;
                    default:
                        CustomSarValue = strCustomValue;
                        _xs.SampleAR = 0; break;
                }
            }

            if (d.HasValue && _xs.SampleAR == 0 && 
                String.IsNullOrEmpty(CustomSarValue) && String.IsNullOrEmpty(CustomSarValueInput))
            {
                Sar s = d.Value.ToSar(hRes, vRes);
                switch (s.X + ":" + s.Y)
                {
                    case "1:1": _xs.SampleAR = 1; break;
                    case "4:3": _xs.SampleAR = 2; break;
                    case "8:9": _xs.SampleAR = 3; break;
                    case "10:11": _xs.SampleAR = 4; break;
                    case "12:11": _xs.SampleAR = 5; break;
                    case "16:11": _xs.SampleAR = 6; break;
                    case "32:27": _xs.SampleAR = 7; break;
                    case "40:33": _xs.SampleAR = 8; break;
                    case "64:45": _xs.SampleAR = 9; break;
                    default: CustomSarValue = s.X + ":" + s.Y; break;
                }
            }

            return _xs.SampleAR;
        }

        /// <summary>
        /// returns the value for the selected command in the custom command line 
        /// and removes the command from the custom command line
        /// </summary>
        /// <param name="strCommandToExtract">the command to extract without --</param>
        /// <param name="strCommandValue">the value of the command</param>
        /// <returns>true if the command can be found</returns>
        private bool extractCustomCommand(string strCommandToExtract, out string strCommandValue)
        {
            String strNewCommandLine = "";
            bool bFound = false;
            strCommandValue = String.Empty;

            foreach (String strCommand in System.Text.RegularExpressions.Regex.Split(_xs.CustomEncoderOptions, "--"))
            {
                if (strCommand.Trim().ToLowerInvariant().StartsWith(strCommandToExtract.ToLowerInvariant()))
                {
                    strCommandValue = strCommand.Substring(strCommandToExtract.Length).Trim();
                    bFound = true;
                }
                else
                {
                    if (!String.IsNullOrEmpty(strCommand.Trim()))
                        strNewCommandLine += " --" + strCommand.Trim();
                }
            }

            _xs.CustomEncoderOptions = strNewCommandLine.Trim();
            return bFound;
        }

        /// <summary>
        /// returns the custom command line 
        /// </summary>
        /// <returns>the custom command line</returns>
        public string getCustomCommandLine()
        {
            return _xs.CustomEncoderOptions;
        }
    }
}