
--�������
IF NOT EXISTS (SELECT 1 FROM [Programs] WHERE PrgID='P_BM_01')
    INSERT INTO Programs (PrgID,Descr,Doc,Det,DocKey,CtrlName,bWorkFlow,Kind,IsDataRange,bInUse,
    bBasic,bAuthCtrl,ViewName,bDet,bImage,bCust,PluginName,STATUS,EffDate,CrtUser,CrtDate,UpdateDT,UpdateUser)
    VALUES('P_BM_01','�ϴ�Ӱ�񵥾��嵥',NULL,NULL,'DataNbr','P_BM_DocImageDetail',0,1,NULL,NULL,0,1,NULL,0
    ,0,0,NULL,NULL,GETDATE(),'admin',GETDATE(),GETDATE(),'admin')
GO

IF NOT EXISTS(SELECT 1 FROM DD_Field WHERE PrgID='P_BM_01' AND Kind='Doc' AND FieldName='CompanyName')
    INSERT INTO DD_Field(PrgID,TableName,Kind,FieldName,DisplayName,ForeignRelation,Descr,OutputDefault,bCondition,FieldType,FieldLength,DataFormat,ComputMode,
    ColumnWidth,bValueField,bTextField,bQueryField,MobDescr,bMobile,bSystem)
    VALUES('P_BM_01','P_BM_01','Doc','CompanyName','CompanyName',NULL,'������˾',1,1,'string','30',NULL,NULL,80,0,0,0,'������˾',1,1)
GO
 
IF NOT EXISTS(SELECT 1 FROM DD_Field WHERE PrgID='P_BM_01' AND Kind='Doc' AND FieldName='PrgName')
    INSERT INTO DD_Field(PrgID,TableName,Kind,FieldName,DisplayName,ForeignRelation,Descr,OutputDefault,bCondition,FieldType,FieldLength,DataFormat,ComputMode,
    ColumnWidth,bValueField,bTextField,bQueryField,MobDescr,bMobile,bSystem)
    VALUES('P_BM_01','P_BM_01','Doc','PrgName','PrgName',NULL,'��������',1,1,'string','30',NULL,NULL,140,0,0,0,'��������',1,1)
GO

IF NOT EXISTS(SELECT 1 FROM DD_Field WHERE PrgID='P_BM_01' AND Kind='Doc' AND FieldName='DataNbr')
    INSERT INTO DD_Field(PrgID,TableName,Kind,FieldName,DisplayName,ForeignRelation,Descr,OutputDefault,bCondition,FieldType,FieldLength,DataFormat,ComputMode,
    ColumnWidth,bValueField,bTextField,bQueryField,MobDescr,bMobile,bSystem)
    VALUES('P_BM_01','P_BM_01','Doc','DataNbr','DataNbr',NULL,'���ݺ�',1,1,'string','100',NULL,NULL,100,0,0,0,'���ݺ�',1,1)
GO
IF NOT EXISTS(SELECT 1 FROM DD_Field WHERE PrgID='P_BM_01' AND Kind='Doc' AND FieldName='DocDate')
    INSERT INTO DD_Field(PrgID,TableName,Kind,FieldName,DisplayName,ForeignRelation,Descr,OutputDefault,bCondition,FieldType,FieldLength,DataFormat,ComputMode,
    ColumnWidth,bValueField,bTextField,bQueryField,MobDescr,bMobile,bSystem)
    VALUES('P_BM_01','P_BM_01','Doc','DocDate','DocDate',NULL,'��������',1,1,'datetime',NULL,'yyyy-MM-dd',NULL,100,0,0,0,'��������',1,1)
GO

IF NOT EXISTS(SELECT 1 FROM DD_Field WHERE PrgID='P_BM_01' AND Kind='Doc' AND FieldName='TotalCost')
    INSERT INTO DD_Field(PrgID,TableName,Kind,FieldName,DisplayName,ForeignRelation,Descr,OutputDefault,bCondition,FieldType,FieldLength,DataFormat,ComputMode,
    ColumnWidth,bValueField,bTextField,bQueryField,MobDescr,bMobile,bSystem)
    VALUES('P_BM_01','P_BM_01','Doc','TotalCost','TotalCost',NULL,'���ݽ��',1,1,'decimal',NULL,'n',NULL,100,0,0,0,'���ݽ��',1,1)
GO
IF NOT EXISTS(SELECT 1 FROM DD_Field WHERE PrgID='P_BM_01' AND Kind='Doc' AND FieldName='ImgCrtDate')
    INSERT INTO DD_Field(PrgID,TableName,Kind,FieldName,DisplayName,ForeignRelation,Descr,OutputDefault,bCondition,FieldType,FieldLength,DataFormat,ComputMode,
    ColumnWidth,bValueField,bTextField,bQueryField,MobDescr,bMobile,bSystem)
    VALUES('P_BM_01','P_BM_01','Doc','ImgCrtDate','ImgCrtDate',NULL,'Ӱ���ϴ�ʱ��',1,1,'datetime',NULL,'yyyy-MM-dd HH:mm',NULL,100,0,0,0,'Ӱ���ϴ�ʱ��',1,1)
GO
IF NOT EXISTS(SELECT 1 FROM DD_Field WHERE PrgID='P_BM_01' AND Kind='Doc' AND FieldName='ID')
    INSERT INTO DD_Field(PrgID,TableName,Kind,FieldName,DisplayName,ForeignRelation,Descr,OutputDefault,bCondition,FieldType,FieldLength,DataFormat,ComputMode,
    ColumnWidth,bValueField,bTextField,bQueryField,MobDescr,bMobile,bSystem)
    VALUES('P_BM_01','P_BM_01','Doc','ID','ID',NULL,'ID',1,1,'int',NULL,NULL,NULL,100,0,0,0,'ID',1,1)
GO
IF NOT EXISTS(SELECT 1 FROM DD_Field WHERE PrgID='P_BM_01' AND Kind='Doc' AND FieldName='DocStatus')
    INSERT INTO DD_Field(PrgID,TableName,Kind,FieldName,DisplayName,ForeignRelation,Descr,OutputDefault,bCondition,FieldType,FieldLength,DataFormat,ComputMode,
    ColumnWidth,bValueField,bTextField,bQueryField,MobDescr,bMobile,bSystem)
    VALUES('P_BM_01','P_BM_01','Doc','DocStatus','DocStatus',NULL,'����״̬',1,1,'string','100',NULL,NULL,100,0,0,0,'����״̬',1,1)
GO



IF NOT EXISTS(select *  FROM LANGUAGE WHERE Code='p_bm_01')
INSERT INTO LANGUAGE(Code,TChinese,Chinese)
VALUES('p_bm_01','�ϴ�Ӱ�񵥾��嵥','�ϴ�Ӱ�񵥾��嵥')
GO

IF NOT EXISTS(select *  FROM LANGUAGE WHERE Code='p_bm_01_docimagedetail_ledger')
INSERT INTO LANGUAGE(Code,TChinese,Chinese)
VALUES('p_bm_01_docimagedetail_ledger','�ϴ�Ӱ�񵥾��嵥','�ϴ�Ӱ�񵥾��嵥')
GO

--�û�Ĭ�Ͻ���
IF NOT EXISTS(SELECT 1 FROM UserConfig WHERE UserID='all' AND PrgID='P_BM_01')
INSERT INTO UserConfig(UserID,PrgID,DisplayFields,FilterFields,EffDate,Status,CrtUser,CrtDate,UpdateUser,UpdateDT,Remark,CrtUserName,UpdateUserName) 
VALUES ('all','P_BM_01','CompanyName,PrgName,DataNbr,DocDate,TotalCost,ImgCrtDate,ID,DocStatus',NULL,NULL,'Draft','admin',GETDATE(),'admin',GETDATE(),NULL,'ϵͳ����Ա','ϵͳ����Ա')
GO

IF NOT EXISTS(SELECT * FROM Menu WHERE MenuName='P_BM_01')
INSERT INTO Menu(MenuName,Text,ParentMenu,Url,OrderBy,CrtDate,CrtUser,UpdateDT,UpdateUser,bCust,bParentMenu,Kind)
VALUES('P_BM_01','�ϴ�Ӱ�񵥾��嵥','Report03','P_BM_DocImageDetail/Index',8,GETDATE(),'admin',GETDATE(),'admin',0,0,1)
GO