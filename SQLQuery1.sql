IF NOT EXISTS (SELECT *
			   FROM sys.databases
			   WHERE name = 'TTest')
BEGIN
    CREATE DATABASE TTest
END
GO

USE TTest
GO

create table historyExports
(
	id int identity not null,
	[name] varchar(50) not null,
	[dateTime] SMALLDATETIME not null,
	userName varchar(50) not null,
	cellName varchar(50) null
)

insert into historyExports
values
('ExportTest1', '2022/03/01', 'Mike', null),
('ExportTest2', '2022/04/02', 'Peter', 'Current'),
('ExportTest3', '2022/05/03', 'olga', 'Current')

