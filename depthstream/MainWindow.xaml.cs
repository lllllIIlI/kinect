using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        KinectSensor nui = null;

        void intializeNui()
        {
            nui = KinectSensor.KinectSensors[0];
            nui.DepthStream.Enable();
            nui.DepthFrameReady += new EventHandler<DepthImageFrameReadyEventArgs>(nui_DepthFrameReady);
            nui.Start();
        }

        void nui_DepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
        {
            DepthImageFrame ImageParam = e.OpenDepthImageFrame();

            if (ImageParam == null) return;

            short[] ImageBits = new short[ImageParam.PixelDataLength];
            ImageParam.CopyPixelDataTo(ImageBits);


            BitmapSource src = null;
            src = BitmapSource.Create(ImageParam.Width,
                                        ImageParam.Height,
                                        96, 96,
                                        PixelFormats.Gray16,
                                        null,
                                        ImageBits,
                                        ImageParam.Width * ImageParam.BytesPerPixel);
            image1.Source = src;
        }
    }
}
