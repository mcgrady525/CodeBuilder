USE DapperDemoDB;
GO


--user
SELECT * FROM dbo.t_sys_rights_user;

--create view
--CREATE VIEW v_GetUserByUserId
--AS
--SELECT * FROM dbo.t_sys_rights_user WHERE user_id= 'mcgrady';

--SELECT * FROM v_GetUserByUserId;

--create sp
--CREATE PROCEDURE sp_GetUserById
--AS
--begin
--	SELECT * FROM dbo.t_sys_rights_user WHERE id= 3;
--END

--EXEC dbo.sp_GetUserById;

--获取当前数据库的所有表，视图
--存储过程怎么获取？
SELECT TABLE_SCHEMA, TABLE_NAME, * from INFORMATION_SCHEMA.TABLES;


--dbo.v_GetUserByUserId
SELECT * FROM dbo.v_GetUserByUserId;



