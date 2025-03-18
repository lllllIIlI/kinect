# Kinect 
kinect를 이용한 원격 몸무게 측정

![Image](https://github.com/user-attachments/assets/b38e7d14-60fc-4619-b749-e27639dcd2e3)


## 개발 환경
<div>
<img src="https://img.shields.io/badge/-C%23-23239120?style=for-the-badg&logo=Csharp&logoColor=white">
<img src="https://img.shields.io/badge/Visual Studio-5C2D91?style=for-the-badg&logo=Visual Studio&logoColor=white"/>
</div>


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
