IF OBJECT_ID('TB_Machine', 'U') IS NULL
BEGIN
	CREATE TABLE TB_Machine
	(
		ID_Machine int IDENTITY(1,1) CONSTRAINT PK_Machine PRIMARY KEY,
		--ID_PrinterConfig int NOT NULL,
		ID_Client int NOT NULL,
		MachineName varchar(100) NOT NULL,
		MachineKey varchar(30) NOT NULL,
		CPUID varchar(100) NULL,
		DiskID varchar(100) NULL,
		MACID varchar(100) NULL,
		IP varchar(100) NULL,
		IPOut varchar(100) NULL,
		HostName varchar(200) NULL,
		DNS varchar(200) NULL,
		ID_Status int NOT NULL
	)
END