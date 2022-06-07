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
('ExportTest1', '2021/01/01', 'Mike', null),
('ExportTest2', '2021/02/02', 'Peter', 'Current'),
('ExportTest3', '2021/03/03', 'olga', 'Current')



select * from historyExports



select id, [name], [dateTime], userName, cellName from historyExports



