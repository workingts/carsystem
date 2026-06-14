CREATE TABLE IF NOT EXISTS 차주 (
    차주번호 INTEGER PRIMARY KEY AUTOINCREMENT,
    차주명 TEXT NOT NULL,
    연락처 TEXT NOT NULL,
    주소 TEXT
);

CREATE TABLE IF NOT EXISTS 접수 (
    접수번호 INTEGER PRIMARY KEY AUTOINCREMENT,
    차주번호 INTEGER,
    차량번호 TEXT NOT NULL,
    검사종류 TEXT NOT NULL,
    유종 TEXT NOT NULL,
    구동방식 TEXT,
    배출가스 TEXT,
    검사주기 TEXT,
    유효만료일 TEXT,
    접수일시 TEXT NOT NULL,
    검사완료일시 TEXT,
    수수료 INTEGER NOT NULL DEFAULT 0,
    결재구분 TEXT,
    검사결과 TEXT DEFAULT '보류',
    진행상태 TEXT DEFAULT '진행중',
    비고 TEXT,
    FOREIGN KEY (차주번호) REFERENCES 차주(차주번호)
);

CREATE TABLE IF NOT EXISTS 이륜접수 (
    접수번호 INTEGER PRIMARY KEY AUTOINCREMENT,
    차주번호 INTEGER,
    차량번호 TEXT NOT NULL,
    검사종류 TEXT NOT NULL DEFAULT '이륜차검사',
    구동방식 TEXT,
    배출가스 TEXT,
    검사주기 TEXT,
    유효만료일 TEXT,
    접수일시 TEXT NOT NULL,
    검사완료일시 TEXT,
    수수료 INTEGER NOT NULL DEFAULT 0,
    결재구분 TEXT,
    검사결과 TEXT DEFAULT '보류',
    진행상태 TEXT DEFAULT '진행중',
    비고 TEXT,
    FOREIGN KEY (차주번호) REFERENCES 차주(차주번호)
);

CREATE TABLE IF NOT EXISTS Admins (
    admin_id INTEGER PRIMARY KEY AUTOINCREMENT,
    username TEXT NOT NULL,
    password TEXT NOT NULL
);
