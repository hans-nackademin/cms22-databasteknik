--TA BORT TABELLER
DROP TABLE ContactPersons
DROP TABLE Addresses

--SKAPA TABELLER
CREATE TABLE Addresses (
	Id int not null identity primary key,
	StreetName nvarchar(50) not null,
	StreetNumber smallint null,
	PostalCode char(5) not null,
	City nvarchar(30) not null
)
GO

CREATE TABLE ContactPersons (
	Id int not null identity primary key,
	FirstName nvarchar(20) not null,
	LastName nvarchar(30) not null,
	Email varchar(100) null,
	Phone char(13) null,
	AddressId int not null references Addresses (Id)
)
