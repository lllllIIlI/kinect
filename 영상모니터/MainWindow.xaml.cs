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

namespace KC01
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
            nui.ColorStream.Enable();
            nui.ColorFrameReady += new EventHandler<ColorImageFrameReadyEventArgs>
                                                            (nui_ColorFrameReady);

            nui.DepthStream.Enable();
            nui.DepthFrameReady += new EventHandler<DepthImageFrameReadyEventArgs>
                                                                (nui_DepthFrameReady);
            
            nui.SkeletonStream.Enable();
            nui.Start();
        }

        void nui_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            ColorImageFrame ImageParam = e.OpenColorImageFrame();

            if (ImageParam == null) return;

            byte[] ImageBits = new byte[ImageParam.PixelDataLength];
            ImageParam.CopyPixelDataTo(ImageBits);

            BitmapSource src = null;
            src = BitmapSource.Create(ImageParam.Width,
                                        ImageParam.Height,
                                        96, 96,
                                        PixelFormats.Bgr32,
                                        null,
                                        ImageBits,
                                        ImageParam.Width * ImageParam.BytesPerPixel);
            image1.Source = src;
        }

        void nui_DepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
        {
            DepthImageFrame ImageParam = e.OpenDepthImageFrame();

            if (ImageParam == null) return;

            short[] ImageBits = new short[ImageParam.PixelDataLength];
            ImageParam.CopyPixelDataTo(ImageBits);

            WriteableBitmap wb = null;
            wb = new WriteableBitmap(ImageParam.Width,
                                     ImageParam.Height,
                                     96, 96,
                                     PixelFormats.Bgr32,
                                     null);

            wb.WritePixels(new Int32Rect(0, 0, ImageParam.Width, ImageParam.Height),
                           Players(ImageParam, 
                                   ImageBits, 
                                   ((KinectSensor)sender).DepthStream),
                                   ImageParam.Width * 4, 
                                   0);
            image2.Source = wb;

            BitmapSource src = null;
            src = BitmapSource.Create(ImageParam.Width,
                                        ImageParam.Height,
                                        96, 96,
                                        PixelFormats.Gray16,
                                        null,
                                        ImageBits,
                                        ImageParam.Width * ImageParam.BytesPerPixel);
            image3.Source = src;
        }

        byte[] Players(DepthImageFrame PImage, short[] depthFrame, DepthImageStream depthstream) 
        {
            byte[] nPlayers = new byte[PImage.Width * PImage.Height * 4];

            for (int i16 = 0, i32 = 0; i16 < depthFrame.Length && i32 < nPlayers.Length;
                 i16++, i32 += 4)
            {
                int player = depthFrame[i16] & DepthImageFrame.PlayerIndexBitmask;

                if (player > 0)
                {
                    nPlayers[i32 + 2] = 255;
                    nPlayers[i32 + 1] = 255;
                    nPlayers[i32 + 0] = 255;
                }
            }
            return nPlayers;
        }
    }
}
