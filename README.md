### Kinect 개발 Tool Download
- Kinect for Windows SDK v1.8
- Kinect for Windows Developer Toolkit v1.8

### Setting
- 시작 > 모든 프로그램 > Kinect for Windows SDK v1.8 > Kinect Studio 1.8.0 실행
- 시작 > 모든 프로그램 > Kinect for Windows SDK v1.8 > Developer Toolkit Browser v1.8.0(Kinect) 실행

#### DepthStream
- 영상의 모양을 인식하고 크기와 거리정보를 포함하여 프로그램에 응용, 사용 할 수 있도록 정보를 제공.
- DepthImageStream 클래스로 지정된 DepthStream 이라는 필드 사용.

DepthImageStream 클래스
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
