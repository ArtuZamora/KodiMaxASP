USE KodiMax

CREATE TABLE Users
(
	ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Names varchar(70) NOT NULL,
	LastNames varchar(70) NOT NULL,
	Email varchar(100) NOT NULL,
	Cellphone char(9),
	Genre char(1) NOT NULL,
	Birthdate date NOT NULL,
	Username varchar(15) NOT NULL,
	Password varchar(20) NOT NULL,
	Type char(10) NOT NULL
)

CREATE TABLE Movie
(
	ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name varchar(70) NOT NULL,
	Duration time NOT NULL,
	Type char(12) NOT NULL,
	Image varchar(MAX) NOT NULL
)

CREATE TABLE Candy
(
	ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name varchar(50) NOT NULL,
	Type varchar(20) NOT NULL,
	Price money NOT NULL,
    Image varchar(MAX) NOT NULL
)