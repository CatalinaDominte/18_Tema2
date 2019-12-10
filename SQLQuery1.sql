CREATE DATABASE HomeworkWeek09
USE [HomeworkWeek09]
GO
CREATE TABLE [Publisher](
    [PublisherId] [int] NOT NULL,
    [Name] [varchar](50) NULL,
    CONSTRAINT [pk_publisher] PRIMARY KEY CLUSTERED
    (
        [PublisherId] ASC
    ) WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)



CREATE TABLE [Book](
       [BookId] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
       [Title] [varchar](50) NULL,
       [PublisherId] [int] NULL,
       [Year] [int] NULL,
       [Price] [decimal](18, 0) NULL
       )
GO
ALTER TABLE [Book]  WITH CHECK ADD  CONSTRAINT [fk_book_publisherid] FOREIGN KEY([PublisherId])
REFERENCES [Publisher] ([PublisherId])
ON DELETE CASCADE
GO
ALTER TABLE [Book] CHECK CONSTRAINT [fk_book_publisherid]
GO

INSERT INTO  [Publisher] ([PublisherId],[Name])
VALUES
(1, 'Libris'),
(2, 'Rao'),
(3,'Humanitas');

INSERT INTO [Book] ([Title],[PublisherId],[Year],[Price])
VALUES
('The White Queen', 1, 2012, 58),
('The Lady of the River', 1, 2010, 54),
('Chernobyl Prayer', 2, 2016, 48),
('The Boleyn Inheritance ', 2, 2009, 55),
('The Last Tudor', 3, 2010, 102),
('Papillon', 3, 2008, 32),
('Jane Eyre', 1, 2001, 42),
('Call Me By Your Name', 3, 2007, 89),
('The Japanese Lover', 2, 2015, 106),
('Peace Like a River', 3, 2018, 45),
('Remembering Shanghai', 1, 2004, 96);

select [PublisherId] from [Publisher]
--Number of rows from the Publisher table (Execute scalar)
SELECT COUNT([PublisherId]) FROM [Publisher]
--Top 10 publishers(Id, Name)(SQL Data Reader)
SELECT TOP 10 [PublisherId], [Name] FROM [Publisher] 
--Number of books for each publisher (Publisher Name, Number of Books)
SELECT  [Name], COUNT([BookId])
FROM [Publisher] 
 LEFT JOIN [Book] ON [Publisher].[PublisherId]=[Book].[PublisherId]
GROUP BY [Name]
--The total price for books for a publisher
SELECT  [Name], SUM([Price])
FROM [Publisher] 
 LEFT JOIN [Book] ON [Publisher].[PublisherId]=[Book].[PublisherId]
GROUP BY [Name]

--Update a book (read id from console) 
INSERT INTO [Book] ([Title],[PublisherId],[Year],[Price])
VALUES
('Jane Eyre', 2, 1999, 35);
SELECT [BookId] FROM [Book] WHERE [Title]='The Lady of the River';
DELETE FROM [Book] WHERE [Title]='The Lady of the River';
SELECT* FROM [Book]
select [Title] from [Book] where [Year]=2010 
select [Title] from [Book] where [Year]=max([Year])
select max([Year]) as x, [Title]  from [Book]
group by [Title]
select top 10* from [Book]
Select count([PublisherId]) from [Publisher]