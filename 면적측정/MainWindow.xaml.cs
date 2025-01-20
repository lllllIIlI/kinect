using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Kinect;
using System.IO;
using System.Configuration;
using Microsoft.Win32;

namespace KC06
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeNui();
        }

        KinectSensor nui = null;

        void InitializeNui()
        {
            nui = KinectSensor.KinectSensors[0];
            nui.DepthStream.Enable(DepthImageFormat.Resolution320x240Fps30);
            nui.DepthFrameReady += new EventHandler<DepthImageFrameReadyEventArgs>
                                                                (nui_DepthFrameReady);
            nui.SkeletonStream.Enable();
            nui.Start();
        }
        void nui_DepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
        {
            DepthImageFrame ImageParam = e.OpenDepthImageFrame();

            if (ImageParam == null) return;

            short[] ImageBits = new short[ImageParam.PixelDataLength];
            ImageParam.CopyPixelDataTo(ImageBits);

            WriteableBitmap wb = new WriteableBitmap(ImageParam.Width,
                                                     ImageParam.Height,
                                                     96, 96,
                                                     PixelFormats.Bgr32,
                                                     null);

            wb.WritePixels(new Int32Rect(0, 0, ImageParam.Width, ImageParam.Height),
                GetPlayer(ImageParam, ImageBits, ((KinectSensor)sender).DepthStream), ImageParam.Width * 4, 0);

            image1.Source = wb;
        }
        byte[] GetPlayer(DepthImageFrame PImage, short[] depthFrame, DepthImageStream depthstream, int nSel)
        {
            byte[] playerCoded = new byte[PImage.Width * PImage.Height * 4];

            long IPixel = 0;
            long IDist = 0;
            int nPlyer = -1;

            for (int i16 = 0, i32 = 0; i16 < depthFrame.Length && i32 < playerCoded.Length;
                 i16++, i32 += 4)
            {
                int player = depthFrame[i16] & DepthImageFrame.PlayerIndexBitmask;
                int nDiistance = depthFrame[i16] >> DepthImageFrame.PlayerIndexBitmaskWidth;
                SetRGB(playerCoded, i32, 0x00, 0x00, 0x00);

                if (player > 0 && nPlayer <= 0) nPlayer = player;
                if (player == nplayer)
                {
                    if (nDistance < depthStream.TooFarDepth &&
                        nDiistance > depthStream.TooNearDepth)
                    {
                        IDist += nDistance;
                        IPixel += 1;
                        SetRGB(playerCoded, i32, 0xFF, 0xFF, 0xFF)
                    }
                }
            }

            if (IPixel > 0)
            {
                textblock1.Text = string.Format("픽셀 : {0}", IPixel);
                textblock2.Text = string.Format("거리 : {0}", IDist / IPixel);

                float weight = (IPixel * IDist) / 1000000000;
                textblock3.Text = string.Format("무게 : {0:0} kg", weight);
            }
            return playerCoded;

            void SetRGB(byte[] nPlayers, int nPos, byte r, byte g, byte b)
            {
                nPlayers[nPos + 2] = r;
                nPlayers[nPos + 1] = g;
                nPlayers[nPos + 0] = b;
            }
        }
    }
}
