using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Kinect;
using System.IO;
using System.Configuration;
using Microsoft.Win32;

namespace KC05
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
                GetPlayer(ImageParam, ImageBits, nui.DepthStream, 0), ImageParam.Width * 4, 0);

            image1.Source = wb;

            wb1 = new WriteableBitmap(ImageParam.Width,
                                      ImageParam.Height, 
                                      96, 96,
                                      PixelFormats.Bgr32,
                                      null);

            wb2 = new WriteableBitmap(ImageParam.Width,
                                      ImageParam.Height,
                                      96, 96,
                                      PixelFormats.Bgr32,
                                      null);
            wb3 = new WriteableBitmap(ImageParam.Width,
                                      ImageParam.Height,
                                      96, 96,
                                      PixelFormats.Bgr32,
                                      null);

            Int32Rect iRect = new Int32Rect(0, 0, ImageParam.Width, ImageParam.Height);

            wb1.WritePixels(iRect, GetPlayer(ImageParam, ImageBits, nui.DepthStream, 1),
                                    ImageParam.Width * 4, 0);
            wb3.WritePixels(iRect, GetPlayer(ImageParam, ImageBits, nui.DepthStream, 1),
                                   ImageParam.Width * 4, 0);
            wb3.WritePixels(iRect, GetPlayer(ImageParam, ImageBits, nui.DepthStream, 1),
                                   ImageParam.Width * 4, 0);
        }

        WriteableBitmap wb1 = null;
        WriteableBitmap wb2 = null;
        WriteableBitmap wb3 = null;

        byte[] GetPlayer(DepthImageFrame PImage, short[] depthFrame, DepthImageStream depthstream, int nSel)
        {
            byte[] playerCoded = new byte[PImage.Width * PImage.Height * 4];

            byte[] cColorR = { 0x00, 0x00, 0xFF };
            byte[] cColorG = { 0x00, 0xFF, 0x00 };
            byte[] cColorB = { 0xFF, 0x00, 0x00 };
            long[] ICount = { 0, 0, 0 };

            for (int i16 = 0, i32 = 0; i16 < depthFrame.Length && i32 < playerCoded.Length;
                 i16++, i32 += 4)
            {
                int player = depthFrame[i16] & DepthImageFrame.PlayerIndexBitmask;
                SetRGB(playerCoded, i32, 0x00, 0x00, 0x00);

                for (int j = 0; j < 3; j++)
                {
                    if (player == j + 1)
                    {
                        if (nSel == 0 || player == nSel)
                        {
                            SetRGB(playerCoded, i32, cColorR[j], cColorG[j], cColorB[j]);
                            ICount[j] += 1;
                        }
                        break;
                    }
                }

                if (nSel == 0)
                {
                    textBlock1.Text = string.Format("P1픽셀수 : {0}", ICount[0]);
                    textBlock2.Text = string.Format("P2픽셀수 : {0}", ICount[1]);
                    textBlock3.Text = string.Format("P3픽셀수 : {0}", ICount[2]);
                }
                return playerCoded;
            }

            void SetRGB(byte[] nPlayers, int nPos, byte r, byte g, byte b)
            {
                nPlayers[nPos + 2] = r;
                nPlayers[nPos + 1] = g;
                nPlayers[nPos + 0] = b;
            }

            void SavePng(WriteableBitmap src, String strFilename)
            {
                BitmapEncoder encoder = null;
                encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(src));
                FileStream stream = new FileStream(strFilename,
                                                   FileMode.Create, FileAccess.Write);
                encoder.Save(stream);
                stream.Close();
            }

            void OpenFile(String strFilename)
            {
                System.Diagnostics.Process exe = new System.Diagnostics.Process();
                exe.StartInfo.FileName = strFilename;
                exe.Start();
            }

            private void button1_Click(object sender, RoutedEventArgs e)
            {
                SavePng(wb1, "c:\\Temp\\p1.png");
                SavePng(wb2, "c:\\Temp\\p2.png");
                SavePng(wb3, "c:\\Temp\\p3.png");
                OpenFile(wb1, "c:\\Temp\\p1.png");
                OpenFile(wb2, "c:\\Temp\\p2.png");
                OpenFile(wb3, "c:\\Temp\\p3.png");
            }
        }
    }
}
