using System;
using System.Collections.Generic;
using System.Text;

namespace MeGUI
{
    public class AC3Settings : AudioCodecSettings
    {
        public static readonly object[] SupportedBitrates = new object[] {64, 128, 160, 192, 224, 256, 288, 320, 352, 384, 448 };

        public AC3Settings()
            : base()
        {
            this.Bitrate = 256;
            this.Codec = AudioCodec.AC3;
            this.EncoderType = AudioEncoderType.FFAC3;
        }

        public override BitrateManagementMode BitrateMode
        {
            get
            {
                return BitrateManagementMode.CBR;
            }
            set
            {
                // Do Nothing
            }
        }

        public override int Bitrate
        {
            get
            {
                return NormalizeVar(base.Bitrate, SupportedBitrates);
            }
            set
            {
                base.Bitrate = value;
            }
        }

        internal static int NormalizeVar(int n, object[] SupportedBitrates)
        {
            int x = n;
            int d = int.MaxValue;
            foreach (int i in SupportedBitrates)
            {
                int d1 = Math.Abs(i - n);
                if (d1 <= d)
                {
                    x = i;
                    d = d1;
                }
            }
            return x;
        }
    }
}
