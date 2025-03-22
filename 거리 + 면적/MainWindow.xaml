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
            long totalDistance = 0;  // 거리의 총합
            long pixelCount = 0;  // 픽셀 수

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

                // 총 거리와 픽셀 수 업데이트
                totalDistance += nDistance;
                pixelCount++;
            }

            if (pixelCount > 0)
            {
                // 평균 거리 계산
                double averageDistance = totalDistance / (double)pixelCount;

                // 평균 거리 기반으로 대략적인 무게 추정 (단순화된 모델)
                double volume = averageDistance * pixelCount * 0.000001;  // 간단한 부피 추정
                double density = 1000;  // 평균 밀도 (kg/m³)
                double estimatedWeight = volume * density;  // 추정 무게 (kg)

                textblock3.Text = string.Format("추정 무게: {0:0.0} kg", estimatedWeight);
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
