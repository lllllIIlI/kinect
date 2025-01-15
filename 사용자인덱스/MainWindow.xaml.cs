using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Kinect;

namespace KC03
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
                           Players(ImageParam, ImageBits, 
                                   ((KinectSensor)sender).DepthStream),
                                   ImageParam.Width * 4, 0);
            image1.Source = wb;
        }

        byte[] Players(DepthImageFrame PImage, short[] depthFrame, DepthImageStream depthstream) 
        {
            byte[] nPlayers = new byte[PImage.Width * PImage.Height * 4];

            for (int i16 = 0, i32 = 0; i16 < depthFrame.Length && i32 < nPlayers.Length;
                 i16++, i32 += 4)
            {
                int player = depthFrame[i16] & DepthImageFrame.PlayerIndexBitmask;

                SetRGB(nPlayers, i32, 0, 0, 0);
                if (player == 1) SetRGB(nPlayers, i32, 0xFF, 0x00, 0x00);
                if (player == 2) SetRGB(nPlayers, i32, 0xFF, 0x7F, 0x7F);
                if (player == 3) SetRGB(nPlayers, i32, 0x00, 0xFF, 0x00);
                if (player == 4) SetRGB(nPlayers, i32, 0x7F, 0xFF, 0x7F);
                if (player == 5) SetRGB(nPlayers, i32, 0x00, 0x00, 0xFF);
                if (player == 6) SetRGB(nPlayers, i32, 0x7F, 0x7F, 0xFF);
                if (player == 7) SetRGB(nPlayers, i32, 0xFF, 0xFF, 0x00);
                if (player == 8) SetRGB(nPlayers, i32, 0x00, 0xFF, 0xFF);
                if (player == 9) SetRGB(nPlayers, i32, 0xFF, 0x00, 0xFF);
            }

            return nPlayers;
        }

        void SetRGB(byte[] nPlayers, int nPos, byte r, byte g, byte b)
        {
            nPlayers[nPos + 2] = r;
            nPlayers[nPos + 1] = g;
            nPlayers[nPos + 0] = b; 
        }
    }
}
