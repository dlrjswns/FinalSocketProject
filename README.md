<h1 align="center">Chat_By_Rating_to_C#</h1>

## 프로젝트 소개
이 프로젝트는 등급별 다양한 서비스를 제공받을 수 있는 채팅 프로그램입니다.

클라이언트는 일반 사용자와 관리자로 나눠 구현하였습니다.

유저들은 미션을 수행해 등업하여 더 많은 기능을 사용해볼 수 있습니다.

등급은 새싹이, 초보자, 고인물 순으로 구성하였으면 고인물로 갈수록 더 많고 좋은 정보들을 받을 수 있습니다.

## 기능 제공
1. **[새싹이], [초보자], [고인물]** **등업기능을 통한 서비스 제공**
2. **운영진 일반 사용자에 따라 다른 기능 제공**
3. **알림, 날짜 포맷, 욕설 필터 기능 제공**
4. **현재 접속자 조회, 전체 및 개인 공지 메세지, 도움말, 접속자 알림, 사용자 강퇴기능 제공**

**[ 프로토콜 설계 ]**

### NormalClient

| Request | Response | 설명 |
| --- | --- | --- |
| ID:nameID: | ID:nameID: | 서버에 사용자의 접속을 알림 |
| LV:nameID:B: | Success_ToBeginner: | 서버에 사용자의 [초보자] 등업요청 |
| LV:nameID:M: | Success_ToMaster: | 서버에 사용자의 [고인물] 등업요청 |
| BR:nameID:전체메세지: | BR:nameID:필터링메세지: | 서버에 접속한 모든 사용자에게 메세지 |
| TO:nameID:받는사용자ID:메세지: | TO:필터링메세지: | 특정 사용자에 메세지 전송 |
| WHO:nameID: | WHO:fromID:점속한 사용자 수: | 서버에 현재 접속한 사용자 수 조회 요청 |
| HELP:nameID: | HELP:nameID: | 사용자전용 프로토콜 도움말 요청 |

### ManagerClient

| Request | Response | 설명 |
| --- | --- | --- |
| M_ID:nameID: | M_ID:nameID: | 서버에 운영진의 접속을 알림 |
| M_BR:nameID:전체메세지: | M_BR:nameID:전체메세지: | 서버에 접속한 모든 사용자에게 메세지 |
| M_TO:nameID:받는사용자의ID:메세지: | M_TO:nameID:받는사용자의ID:메세지: | 특정 사용자에 메세지 전송 |
| M_GM:nameID:S or B or M:메세지:  | M_GM:nameID:S or B or M:메세지:  | 특정 그룹에 속한 사용자들에 메세지 전송 |
| M_BANNED:nameID:벤할사용자ID | M_BANNED:nameID:벤할사용자ID | 서버에 특정 일반 사용자를 강퇴요청 |
| M_WHO:nameID: | M_WHO:연결된 클라이언트ID들 | 서버에 연결된 모든 사용자 ID 조회요청 |
| M_HELP:nameID: | M_HELP:nameID: | 관리자전용 프로토콜 도움말 요청 |

### Server

| Request | Response | 설명 |
| --- | --- | --- |
| Server:서버공지메세지 | - | 접속한 모든 사용자들에게 서버공지 알림 |

## Interface
### 일반사용자 인터페이스
![유저인터페이스](https://github.com/dlrjswns/FinalSocketProject/assets/39263235/f2555e92-72e5-4c9e-9f16-8fd3f149c116)

### 관리자 인터페이스
![관리자인터페이스](https://github.com/dlrjswns/FinalSocketProject/assets/39263235/42470796-af0f-40f9-8026-b18d18749509)

### 서버 인터페이스
![서버인터페이스](https://github.com/dlrjswns/FinalSocketProject/assets/39263235/6474007d-d6c6-4f9a-b8aa-ddca3c379995)


