using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Kinect;

namespace KC04
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
                GetRGB(ImageParam, ImageBits, nui.DepthStream), ImageParam.Width * 4, 0);

            image1.Source = wb;
        }

        byte[] GetRGB(DepthImageFrame PImage, short[] depthFrame, DepthImageStream depthstream) 
        {
            byte[] rgbs = new byte[PImage.Width * PImage.Height * 4];

            for (int i16 = 0, i32 = 0; i16 < depthFrame.Length && i32 < rgbs.Length;
                 i16++, i32 += 4)
            {
                int nDistance = depthFrame[i16] >> DepthImageFrame.PlayerIndexBitmaskWidth;
                SetRGB(rgbs, i32, 0x00, 0x00, 0x00);

                if (nDistance > 3500) SetRGB(rgbs, i32, 0xFF, 0xFF, 0xFF);
                else if (nDistance > 3000) SetRGB(rgbs, i32, 0xFF, 0x00, 0x00);
                else if (nDistance > 2500) SetRGB(rgbs, i32, 0x00, 0xFF, 0x00);
                else if (nDistance > 2000) SetRGB(rgbs, i32, 0x00, 0x00, 0xFF);
                else if (nDistance > 1500) SetRGB(rgbs, i32, 0xFF, 0xFF, 0x00);
                else if (nDistance > 1000) SetRGB(rgbs, i32, 0x00, 0xFF, 0xFF);
                else if (nDistance > 800) SetRGB(rgbs, i32, 0xFF, 0x00, 0xFF);
                else if (nDistance > 0) SetRGB(rgbs, i32, 0x7F, 0x00, 0x00);
            }

            return rgbs;
        }

        void SetRGB(byte[] nPlayers, int nPos, byte r, byte g, byte b)
        {
            nPlayers[nPos + 2] = r;
            nPlayers[nPos + 1] = g;
            nPlayers[nPos + 0] = b; 
        }
    }
}
