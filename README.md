# NAWD(NAVER Webtoon Downloader)
## Overview
NAWD은(는) C#으로 작성된 네이버 웹툰 다운로더입니다.

 * CUI 환경에서만 사용이 가능합니다.
 * 네이버 웹툰에서 무료로 제공되는 화수만 다운로드가 가능합니다.
 * .NET Framework 4.7.1을(를) 타겟으로 개발되어 멀티 플랫폼 지원이 되지 않습니다.

## Introduction
NAWD은(는) c#의 HttpWebRequest와(과) HttpWebResponse 클래스를 이용하여 네이버 웹툰에서 특정 만화의 정보를 불러온 후 이미지만을 추출하여 다운로드 합니다. NAWD에는 두가지 작동 모드가 있으며, 두 모드에 대한 세부 설명은 아래와 같습니다.
 * __자동 처리 모드(Automatic Process)__ : 사용자로부터 입력 받은 만화 ID, 시작 화수, 종료 화수 정보를 바탕으로 모든 다운로드 작업을 자동으로 처리합니다.
 * __수동 처리 모드(Manual Process)__ : 사용자로부터 시작 화수와 종료 화수만을 입력받은 채 각 화수에 대한 HTML 파일을 수동으로 지정해주는 모드입니다.
 
## License
NAWD의 모든 소스코드는 공개되어 있으며 MIT 라이선스 하에 누구나 자유롭게 사용할 수 있습니다.

## Contact
본 레포지토리의 소스 코드에 대한 문의사항이나 릴리즈 된 프로그램에 대한 버그 정보를 제공하시려면 GitHub Issues(이)나 아래의 이메일을 이용해주시기 바랍니다.

 * E-Mail : junimiso04@naver.com
