# CAR SYSTEM – 차량검사 접수 관리

C# WinForms 기반 차량검사 접수 관리 시스템.  
수수료 계산, 암호화 저장, 검사대상 만료 조회 기능 포함.

## 주요 기능

- 4륜 / 이륜 검사 접수 입력 (AES-CBC 암호화 저장)
- 수수료 자동 입력 (검사종류 + 유종 기준)
- 유효만료일 표시 (검사주기 기준)
- 접수 목록 조회 및 CSV 내보내기
- 수수료 내역 조회
- 집계표 (월별 검사종류별 통계 + 인쇄)
- 검사대상 만료 목록 (D-90 ~ D+31 자동 조회)

## 기술 스택

- C# / .NET 9 / Windows Forms
- SQLite (Microsoft.Data.Sqlite)
- AES-CBC 암호화 (차량번호, 차주명, 연락처)

## 실행 방법

1. `CAR_SYSTEM.sln` 을 Visual Studio로 열기
2. NuGet 패키지 복원
3. F5 (빌드 및 실행)
4. 최초 실행 시 `app.db` 자동 생성

## 라이선스

[MIT License](LICENSE)
