IF OBJECT_ID('TB_Status','U') IS NULL
BEGIN 
	CREATE TABLE TB_Status
	(
		ID_Status		int IDENTITY(1,1) CONSTRAINT PK_Status PRIMARY KEY,
		StatusName		varchar(100) NOT NULL
	)
END