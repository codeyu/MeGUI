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
using System.Collections;
using System.IO;

namespace MeGUI.core.util
{
    public sealed class IFOparser
    {
        private static uint ToInt32(byte[] bytes)
        {
            return (uint)((bytes[0] << 24) + (bytes[1] << 16) + (bytes[2] << 8) + bytes[3]);
        }

        private static short ToShort(byte[] bytes)
        {
            return ToInt16(bytes);
        }

        public static short ToInt16(byte[] bytes)
        {
            return (short)((bytes[0] << 8) + bytes[1]);
        }

        public static long ToFilePosition(byte[] bytes)
        {
            return ToInt32(bytes) * 0x800L;
        }

        public static byte[] GetFileBlock(string strFile, long pos, int count)
        {
            using (FileStream stream = new FileStream(strFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                byte[] buf = new byte[count];
                stream.Seek(pos, SeekOrigin.Begin);
                if (stream.Read(buf, 0, count) != count)
                    return buf;
                return buf;
            }
        }

        private static int AsHex(int val)
        {
            int ret;
            int.TryParse(string.Format("{0:X2}", val), out ret);
            return ret;
        }

        private static short? GetFrames(byte val)
        {
            int byte0_high = val >> 4;
            int byte0_low = val & 0x0F;
            if (byte0_high > 11)
                return (short)(((byte0_high - 12) * 10) + byte0_low);
            if ((byte0_high <= 3) || (byte0_high >= 8))
                return null;
            return (short)(((byte0_high - 4) * 10) + byte0_low);
        }

        public static long GetPCGIP_Position(string ifoFile)
        {
            return ToFilePosition(GetFileBlock(ifoFile, 0xCC, 4));
        }

        /// <summary>
        /// get number of PGCs
        /// </summary>
        /// <param name="ifoFile">name of the IFO file</param>
        /// <returns>number of PGS as integer</returns>
        public static int GetPGCCount(string ifoFile)
        {
            // get the PGC count in VTS_PGCI
            return GetPGCCount(ifoFile, GetPCGIP_Position(ifoFile));
        }

        /// <summary>
        /// get number of PGCs
        /// </summary>
        /// <param name="ifoFile">name of the IFO file</param>
        /// <param name="VTS_PGCI_Position">address of VTS_PGCI</param>
        /// <returns>number of PGS as integer</returns>
        public static int GetPGCCount(string ifoFile, long VTS_PGCI_Position)
        {
            return ToInt16(GetFileBlock(ifoFile, VTS_PGCI_Position, 2));
        }

        public static uint GetPGCOffset(string ifoFile, long pcgitPosition, int programChain)
        {
            return ToInt32(GetFileBlock(ifoFile, (pcgitPosition + (8 * programChain)) + 4, 4));
        }

        public static int GetNumberOfPrograms(string ifoFile, long pcgitPosition, uint chainOffset)
        {
            return GetFileBlock(ifoFile, (pcgitPosition + chainOffset) + 2, 1)[0];
        }

        public static TimeSpan? ReadTimeSpan(string ifoFile, long pcgitPosition, uint chainOffset, out double fps)
        {
            return ReadTimeSpan(GetFileBlock(ifoFile, (pcgitPosition + chainOffset) + 4, 4), out fps);
        }

        public static TimeSpan? ReadTimeSpan(byte[] playbackBytes, out double fps)
        {
            short? frames = GetFrames(playbackBytes[3]);
            int fpsMask = playbackBytes[3] >> 6;
            fps = fpsMask == 0x01 ? 25D : fpsMask == 0x03 ? (30D / 1.001D) : 0;
            if (frames == null)
                return null;

            try
            {
                int hours = AsHex(playbackBytes[0]);
                int minutes = AsHex(playbackBytes[1]);
                int seconds = AsHex(playbackBytes[2]);
                TimeSpan ret = new TimeSpan(hours, minutes, seconds);
                if (fps != 0)
                    ret = ret.Add(TimeSpan.FromSeconds((double)frames / fps));
                return ret;
            }
            catch { return null; }
        }

        /// <summary>
        /// get several Subtitles Informations from the IFO file
        /// </summary>
        /// <param name="fileName">name of the IFO file</param>
        /// <returns>several infos as String</returns>       
        public static string[] GetSubtitlesStreamsInfos(string FileName, int iPGC, bool bGetAllStreams)
        {
            byte[] buff = new byte[4];
            string[] subdesc = new string[0];
            string[] substreams = new string[0];

            try
            {
                // get the number of subpicture streams in VTS_VOBS
                int iSubtitleCount = ToInt16(GetFileBlock(FileName, 0x254, 2));
                if (iSubtitleCount > 32 || bGetAllStreams)
                    iSubtitleCount = 32; // force the max #. According to the specs 32 is the max value for subtitles streams.
                subdesc = new string[iSubtitleCount];

                FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                Stream sr = br.BaseStream;

                // go to the subpicture attributes of VTS_VOBS
                sr.Seek(0x256, SeekOrigin.Begin);
                for (int i = 0; i < iSubtitleCount; i++)
                {
                    // Presence (1 bit), Coding Mode (1bit), Short Language Code (2bits), Language Extension (1bit), Sub Picture Caption Type (1bit)

                    // ignore presence & coding mode and go to short language code
                    sr.Seek(0x2, SeekOrigin.Current);

                    // read short language code
                    br.Read(buff, 0, 2);

                    string ShortLangCode = String.Format("{0}{1}", (char)buff[0], (char)buff[1]);
                    subdesc[i] = LanguageSelectionContainer.LookupISOCode(ShortLangCode);
                    if (String.IsNullOrEmpty(subdesc[i]))
                        subdesc[i] = "unknown";

                    // Go to Code Extension
                    sr.Seek(1, SeekOrigin.Current);
                    buff[0] = br.ReadByte();

                    switch (buff[0] & 0x0F)
                    {
                        // from http://dvd.sourceforge.net/dvdinfo/sprm.html 
                        case 1: subdesc[i] += " - Caption"; break;
                        case 2: subdesc[i] += " - Caption (Large)"; break;
                        case 3: subdesc[i] += " - Caption for Children"; break;
                        case 5: subdesc[i] += " - Closed Caption"; break;
                        case 6: subdesc[i] += " - Closed Caption (Large)"; break;
                        case 7: subdesc[i] += " - Closed Caption for Children"; break;
                        case 9: subdesc[i] += " - Forced Caption"; break;
                        case 13: subdesc[i] += " - Director Comments"; break;
                        case 14: subdesc[i] += " - Director Comments (Large)"; break;
                        case 15: subdesc[i] += " - Director Comments for Children"; break;
                    }
                }

                // get VTS_PGCI
                long VTS_PGCI = GetPCGIP_Position(FileName);

                // find the VTS_PGC starting address of the requested PGC number in VTS_PGCI
                long VTS_PGC = VTS_PGCI + GetPGCOffset(FileName, VTS_PGCI, iPGC);

                // go to the Subpicture Stream Control in VTS_PGC of the requested PGC number
                sr.Seek(VTS_PGC + 0x1C, SeekOrigin.Begin);

                byte[] iCountType = new byte[4];
                for (int i = 0; i < 32; i++)
                {
                    // read subtitle info of stream i
                    br.Read(buff, 0, 4);

                    if (buff[0] < 128)
                        continue;

                    buff[0] -= 128;

                    if (buff[0] > 0)
                        iCountType[0]++;
                    if (buff[1] > 0)
                        iCountType[1]++;
                    if (buff[2] > 0)
                        iCountType[2]++;
                    if (buff[3] > 0)
                        iCountType[3]++;
                }

                // check how many different types are there & if therefore the type description has to be added
                int iDifferentTypes = 0;
                if (iCountType[0] > 0)
                    iDifferentTypes++;
                if (iCountType[1] > 0)
                    iDifferentTypes++;
                if (iCountType[2] > 0)
                    iDifferentTypes++;
                if (iCountType[3] > 0)
                    iDifferentTypes++;
                bool bAddTypes = iDifferentTypes > 0;
                if (bAddTypes)
                    for (int i = 0; i < subdesc.Length; i++)
                        if (!String.IsNullOrEmpty(subdesc[i]))
                            subdesc[i] += " (";

                // go to the Subpicture Stream Control in VTS_PGC of the requested PGC number
                sr.Seek(VTS_PGC + 0x1C, SeekOrigin.Begin);

                bool bStream0TypeAdded = false;
                substreams = new string[32];
                for (int i = 0; i < 32; i++)
                {
                    // read subtitle info of stream i
                    br.Read(buff, 0, 4);

                    if (buff[0] < 128)
                        continue;

                    buff[0] -= 128;

                    if (buff[0] > 0)
                        substreams[buff[0]] = "[" + String.Format("{0:00}", buff[0]) + "] - " + subdesc[i] + (bAddTypes ? "4:3)" : "");
                    if (buff[1] > 0)
                        substreams[buff[1]] = "[" + String.Format("{0:00}", buff[1]) + "] - " + subdesc[i] + (bAddTypes ? "Wide)" : "");
                    if (buff[2] > 0)
                        substreams[buff[2]] = "[" + String.Format("{0:00}", buff[2]) + "] - " + subdesc[i] + (bAddTypes ? "Letterbox)" : "");
                    if (buff[3] > 0)
                        substreams[buff[3]] = "[" + String.Format("{0:00}", buff[3]) + "] - " + subdesc[i] + (bAddTypes ? "Pan&Scan)" : "");

                    // as stream ID 0 is impossible to detect, we have to guess here
                    if (String.IsNullOrEmpty(substreams[0]))
                    {
                        if (buff[0] == 0 || buff[1] == 0 || buff[2] == 0 || buff[3] == 0)
                            substreams[0] = "[" + String.Format("{0:00}", buff[0]) + "] - " + subdesc[i];
                    }
                    else if (bAddTypes && !bStream0TypeAdded)
                    {
                        if (buff[0] > 0)
                            substreams[0] += "4:3)";
                        else if (buff[1] > 0)
                            substreams[0] += "Wide)";
                        else if (buff[2] > 0)
                            substreams[0] += "Letterbox)";
                        else if (buff[3] > 0)
                            substreams[0] += "Pan&Scan)";
                        bStream0TypeAdded = true;
                    }
                }

                if (bGetAllStreams)
                {
                    for (int i = 0; i < 32; i++)
                        if (String.IsNullOrEmpty(substreams[i]))
                            substreams[i] = "[" + String.Format("{0:00}", i) + "] - not detected";
                }
                else
                {
                    ArrayList arrList = new ArrayList();
                    foreach (string strItem in substreams)
                        if (!String.IsNullOrEmpty(strItem))
                            arrList.Add(strItem);
                    substreams = new string[arrList.Count];
                    for (int i = 0; i < arrList.Count; i++)
                        substreams[i] = arrList[i].ToString();
                }

                fs.Close();
            }
            catch (Exception ex)
            {
                LogItem _oLog = MainForm.Instance.Log.Info("IFOparser");
                _oLog.LogValue("Error parsing ifo file " + FileName, ex.Message, ImageType.Error);
            }
            return substreams;
        }

        /// <summary>
        /// get number of angles
        /// </summary>
        /// <param name="fileName">name of the IFO file</param>
        /// <param name="iPGCNumber">PGC number</param>
        /// <returns>number of angles</returns>
        public static int GetAngleCount(string FileName, int iPGCNumber)
        {
            byte[] buff = new byte[4];
            byte s = 0;
            int iAngleCount = 0;

            // find the VTS_PGC starting address of the requested PGC number in VTS_PGCI
            long VTS_PGCI = GetPCGIP_Position(FileName);
            long VTS_PGC = VTS_PGCI + GetPGCOffset(FileName, VTS_PGCI, iPGCNumber);

            try
            {
                FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                Stream sr = br.BaseStream;

                // go to the cell count in VTS_PGC of the requested PGC number
                sr.Seek(VTS_PGC + 0x03, SeekOrigin.Begin);
                int iCellCount = br.ReadByte();

                //find the cell playback information table start in VTS_PGC of the requested PGC number
                long VTS_PGC_CELL_START = VTS_PGC + ToInt16(GetFileBlock(FileName, VTS_PGC + 0xE8, 2));

                int iAngleCountTemp = 0;
                // cycle through all cell informations
                for (int i = 1; i <= iCellCount; i++)
                {
                    // go to the start of the table
                    sr.Seek(VTS_PGC_CELL_START + (i -1) * 0x18, SeekOrigin.Begin);
                    s = br.ReadByte();

                    var seamless = (s >> 0) & 1;
                    var stc = (s >> 1) & 1;
                    var interleaved = (s >> 2) & 1;
                    var seamless_playback = (s >> 3) & 1;
                    var block_type = (s >> 4) & 3;
                    var cell_type = (s >> 6) & 3;

                    // angle block found?
                    if (block_type != 1)
                        continue;

                    // bits: 00 = normal, 01 = first of angle block, 10 = middle of angle block, 11 = last of angle block
                    if (cell_type == 1)
                    {
                        //  first angle block
                        iAngleCountTemp = 1;
                    }
                    else if (cell_type == 2)
                    {
                        // middle of angle block
                        iAngleCountTemp++;
                    }
                    else if (cell_type == 3)
                    {
                        // last of angle block
                        iAngleCountTemp++;
                        if (iAngleCount == 0 || iAngleCount > iAngleCountTemp)
                            iAngleCount = iAngleCountTemp;
                    }
                }
                fs.Close();
            }
            catch (Exception ex)
            {
                LogItem _oLog = MainForm.Instance.Log.Info("IFOparser");
                _oLog.LogValue("Error parsing ifo file " + FileName, ex.Message, ImageType.Error);
            }
            return iAngleCount;
        }
    }
}