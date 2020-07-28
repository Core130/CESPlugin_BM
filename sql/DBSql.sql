IF NOT EXISTS (SELECT 1 FROM sysobjects WHERE NAME = N'Bama_NCInvbasdoc' AND xtype = 'U')
CREATE TABLE Bama_NCInvbasdoc
(
	ID INT IDENTITY(1,1),
	pk_invbasdoc VARCHAR(100),
	pk_invmandoc VARCHAR(100),
	invcode VARCHAR(100),
	invname VARCHAR(100),
	invshortname VARCHAR(100),
	invspec VARCHAR(100),
	invtype VARCHAR(100),
	pk_measdoc VARCHAR(100),
	ts DATETIME,
	DModify DATETIME,
	iState INT
)

IF NOT EXISTS (SELECT 1 FROM sysobjects WHERE NAME = N'Bama_NCTariffItem' AND xtype = 'U')
CREATE TABLE Bama_NCTariffItem
(
	ID INT IDENTITY(1,1),
	cinventoryid VARCHAR(100),
	nprice1 DECIMAL(18,2),	
	ts DATETIME,
	DModify DATETIME,
	iState INT
)

IF NOT EXISTS (SELECT 1 FROM sysobjects WHERE NAME = N'Bama_NCMeasdoc' AND xtype = 'U')
CREATE TABLE Bama_NCMeasdoc
(
	ID INT IDENTITY(1,1),
	pk_measdoc VARCHAR(100),
	measname VARCHAR(100),
	shortname VARCHAR(100),	
	ts DATETIME,
	DModify DATETIME,
	iState INT
)

IF NOT EXISTS (SELECT 1 FROM Bama_NCTime WHERE syName IN ('NCInvbasdoc','NCTariffItem','NCMeasdoc'))
INSERT INTO Bama_NCTime(sytime, syName, remark)
SELECT GETDATE(),'NCInvbasdoc','商品档案'
UNION
SELECT '2000-01-01','NCTariffItem','计量单位'
UNION
SELECT GETDATE(),'NCMeasdoc','商品价格'
GO