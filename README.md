# Kinect 
kinect를 이용한 원격 몸무게 측정

![Image](https://github.com/user-attachments/assets/b38e7d14-60fc-4619-b749-e27639dcd2e3)


## 개발 환경
<div>
<img src="https://img.shields.io/badge/-C%23-23239120?style=flat&logo=Csharp&logoColor=white">                <!-- 배지 안 나옴(shields.io에 C#, Visual Studio 배지가 없다) --!>
<img src="https://img.shields.io/badge/Visual Studio-5C2D91?style=flat&logo=Visual Studio&logoColor=white"/>
</div>
<br>

Kinect 개발 Tool Download
- Kinect for Windows SDK v1.8
- Kinect for Windows Developer Toolkit v1.8
  
Setting
- 시작 > 모든 프로그램 > Kinect for Windows SDK v1.8 > Kinect Studio 1.8.0 실행
- 시작 > 모든 프로그램 > Kinect for Windows SDK v1.8 > Developer Toolkit Browser v1.8.0(Kinect) 실행


## DepthStream
- 영상의 모양을 인식하고 크기와 거리정보를 포함하여 프로그램에 응용, 사용 할 수 있도록 정보를 제공.
- DepthImageStream 클래스로 지정된 DepthStream 이라는 필드 사용.


### DepthImageStream 클래스
|멤버|기능|
|--------------|---------------------|
|Format|뎁스 데이터를 위한 포맷을 가져오거나 지정|
|MaxDepth|최대 뎁스 값|
|MinDepth|최소 뎁스 값|
|NominalDiagonalFieldOfView|뎁스 카메라에서 뷰의 명목상 대각선 필드|
|NominalFocalLengtInPixels|뎁스 카메라의 명목상 초점 길이|
|NominalHorizontalFieldOfView|뎁스 카메라에서 뷰의 수평선 필드|
|NominalInverseFocalLengthInPixels|뎁스 카메라에서 역 초점 길이|
|NominalVerticalFieldOfView|뎁스 카메라에서 뷰의 명목상 수직선 필드|
|Range|뎁스 데이터의 범위를 가져오거나 지정|
|TooFarDepth|가장 멀리 떨어진 최고의 뎁스 값|
|TooNearDepth|가장 가까이 있는 최대 뎁스 값|
|UnknownDepth|실제 뎁스를 알 수 없을 때 사용된 뎁스 값|
|Enable|센서에서 뎁스 데이터를 사용. 작동 시작|
|OpenNextFrame|뎁스스트림 안에서 다음 프레임 가져옴|

### PixelFormats 클래스
|멤버|기능|
|--------------|---------------------|
|Bgr101010|32BPP 를 사용하는 sRGB형식, 파랑, 녹색, 빨강에는 10BPP가 할당|
|Bgr24|24BPP 를 사용하는 sRGB형식, 파랑, 녹색, 빨강에는 8BPP가 할당|
|Bgr32|32BPP 의 sRGB형식, 파랑, 녹색, 빨강에는 8BPP가 할당|
|Bgr555|16BPP 를 사용하는 sRGB형식, 파랑, 녹색, 빨강에는 5BPP가 할당|
|Bgr565|16BPP 를 사용하는 sRGB형식, 파랑, 녹색, 빨강에는 5BPP, 6BPP, 5BPP가 할당|
|Bgra32|32BPP 를 사용하는 sRGB형식, 파랑, 녹색, 빨강에는 8BPP가 할당|
|BlackWhite|픽셀당 1비트 데이터를 검정 또는 흰색으로 표시|
|Cmyk32|32BPP 를 표시하는 Cmyk32 픽셀 형식, 녹청, 자홍, 노랑, 검정에 8BPP 씩 할당|
|Gray16|65536가지의 회색조를 표현할 수 있는 16BPP 회색조 채널을 표시하는 형식. 감마값 1.0|
|Gray2|4가지의 회색조를 표현할 수 있는 2BPP 회색조 채널을 표시하는 Gray2 픽셀 형식|
|Gray32Float|40억가지 이상의 회색조를 표현할 수 있는 32BPP 회색조 채널을 표시. 감마값 1.0|
|Gray4|16가지의 회색조를 표현할 수 있는 4BPP 회색조 채널을 표시하는 Gray4 픽셀 형식|
|Gray8|256가지의 회색조를 표현할 수 있는 8BPP 회색조 체널을 표시하는 Gray8 픽셀 형식|
|Indexed1|2가지 색으로 색상이 지정된 비트맵을 지정하는 픽셀 형식|
|Indexed2|4가지 색으로 색상이 지정된 비트맵을 지정하는 픽셀 형식|
|Indexed4|16가지 색으로 색상이 지정된 비트맵을 지정하는 픽셀 형식|
|Indexed8|256가지 색으로 색상이 지정된 비트맵을 지정하는 픽셀 형식|
|Pbgra32|32BPP를 사용하는 sRGB형식. 파랑, 녹색, 빨강, 알파에는 8BPP가 할당. 각 색 채널에는 알파 값이 미리 곱해짐|
|Prgba 128float|128BPP를 사용하는 sRGB형식. 파랑, 녹색, 빨강, 알파에는 32BPP가 할당. 각 색 채널에는 알파 값이 미리 곱해짐. 감마값 1.0|
|Prgba64|64BPP를 사용하는 sRGB형식. 파랑, 녹색, 빨강, 알파에는 32BPP가 할당. 각 색 채널에는 알파 값이 미리 곱해짐. 감마값 1.0|
|Rgb 128Float|128BPP를 사용하는 sRGB형식. 파랑, 녹색, 빨강, 알파에는 32BPP씩 할당. 감마값 1.0|
|Rgb24|24BPP를 사용하는 sRGB형식. 파랑, 녹색, 빨강에는 8BPP씩 할당|
|Rgb48|48BPP를 사용하는 sRGB형식. 파랑, 녹색, 빨강에는 8BPP씩 할당. 감마값 1.0|
|Rgba 128Float|128BPP를 사용하는 sRGB형식. 각 색 채널에는 32BPP씩 할당. 감마값 1.0|
|Rgba64|64BPP를 사용하는 sRGB형식. 파랑, 녹색, 빨강, 알파에는 16BPP씩 할당. 감마값 1.0|
|Cmyk32|32BPP 를 표시하는 Cmyk32 픽셀 형식, 녹청, 자홍, 노랑, 검정에 8BPP 씩 할당|
|Gray16|65536가지의 회색조를 표현할 수 있는 16BPP 회색조 채널을 표시하는 형식. 감마값 1.0|
|Gray2|4가지의 회색조를 표현할 수 있는 2BPP 회색조 채널을 표시하는 Gray2 픽셀 형식|
|Gray32Float|40억가지 이상의 회색조를 표현할 수 있는 32BPP 회색조 채널을 표시. 감마값 1.0|
|Gray4|16가지의 회색조를 표현할 수 있는 4BPP 회색조 채널을 표시하는 Gray4 픽셀 형식|
|Gray8|256가지의 회색조를 표현할 수 있는 8BPP 회색조 체널을 표시하는 Gray8 픽셀 형식|
|Indexed1|2가지 색으로 색상이 지정된 비트맵을 지정하는 픽셀 형식|
|Indexed2|4가지 색으로 색상이 지정된 비트맵을 지정하는 픽셀 형식|
|Indexed4|16가지 색으로 색상이 지정된 비트맵을 지정하는 픽셀 형식|
|Indexed8|256가지 색으로 색상이 지정된 비트맵을 지정하는 픽셀 형식|
|Pbgra32|32BPP를 사용하는 sRGB형식. 파랑, 녹색, 빨강, 알파에는 8BPP가 할당. 각 색 채널에는 알파 값이 미리 곱해짐|
|Prgba 128float|128BPP를 사용하는 sRGB형식. 파랑, 녹색, 빨강, 알파에는 32BPP가 할당. 각 색 채널에는 알파 값이 미리 곱해짐. 감마값 1.0|
|Prgba64|64BPP를 사용하는 sRGB형식. 파랑, 녹색, 빨강, 알파에는 32BPP가 할당. 각 색 채널에는 알파 값이 미리 곱해짐. 감마값 1.0|
|Rgb 128Float|128BPP를 사용하는 sRGB형식. 파랑, 녹색, 빨강, 알파에는 32BPP씩 할당. 감마값 1.0|
|Rgb24|24BPP를 사용하는 sRGB형식. 파랑, 녹색, 빨강에는 8BPP씩 할당|
|Rgb48|48BPP를 사용하는 sRGB형식. 파랑, 녹색, 빨강에는 8BPP씩 할당. 감마값 1.0|
|Rgba 128Float|128BPP를 사용하는 sRGB형식. 각 색 채널에는 32BPP씩 할당. 감마값 1.0|
|Rgba64|64BPP를 사용하는 sRGB형식. 파랑, 녹색, 빨강, 알파에는 16BPP씩 할당. 감마값 1.0|

## 개발 과정
1. 뎁스스트림 테스트
2. 영상 모니터 출력
3. 사용자 인덱스 추출
4. 거리 측정 
5. 사용자 저장  ← 굳이 필요한가?
6. 면적 측정

## 개선사항 (kinect가 없어 정확한 측정 불가)
1. 키 측정 추가 → skeletonstream 사용 (정확 X - 상대적)
```
   // 키 계산 함수
        double CalculateHeight(CameraSpacePoint head, CameraSpacePoint foot)
        {
            double heightInMeters = Math.Abs(head.Y - foot.Y);
            return heightInMeters * 100; // 미터 -> 센티미터로 변환
        }
```

2. 정확도 개선 <br>
기존 코드 (면적 측정 - MainWindow.xaml.cs)
```
  if (IPixel > 0)
            {
                textBlock1.Text = string.Format("픽셀 : {0}", IPixel);
                textBlock2.Text = string.Format("거리 : {0}", IDist / IPixel);

                float weight = (IPixel * IDist) / 1000000000f;
                textBlock3.Text = string.Format("무게 : {0:0} kg", weight);
            }
```
![Image](https://github.com/user-attachments/assets/b0b1fce3-4fdd-4364-915a-78e0511ea6cc)

개선안
1. 거리 제한 (3m)
2. 사용자 전신이 안나오면 측정 X (etc. 사물에 사용자 신체 일부가 가려짐)
3. ~~결과를 보며 가중치 변경~~

```
bool fullBodyDetected = false;

void nui_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
{
    SkeletonFrame skeletonFrame = e.OpenSkeletonFrame();
    if (skeletonFrame == null) return;

    Skeleton[] skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
    skeletonFrame.CopySkeletonDataTo(skeletons);

    fullBodyDetected = false;

    foreach (Skeleton skeleton in skeletons)
    {
      if (skeleton.TrackingState == SkeletonTrackingState.Tracked)
      {
        // 상체와 하체가 모두 인식되었는지 확인
        if (skeleton.Joints[JointType.Head].TrackingState == JointTrackingState.Tracked &&
            skeleton.Joints[JointType.ShoulderCenter].TrackingState == JointTrackingState.Tracked &&
            skeleton.Joints[JointType.HipCenter].TrackingState == JointTrackingState.Tracked)
        {
          fullBodyDetected = true;
          break;
        }
      }
    }
}
```

GetPlayer() 에 조건 추가
```
if (player == nPlayer) // 해당 플레이어만 처리
{
    if (nDistance == 3000 && fullBodyDetected) // 정확히 3m이고 전신이 인식된 경우만 측정
    {
      IDist += nDistance;
      IPixel += 1;
      SetRGB(playerCoded, i32, 0xFF, 0xFF, 0xFF); // 흰색으로 픽셀 표시
    }
}
```
