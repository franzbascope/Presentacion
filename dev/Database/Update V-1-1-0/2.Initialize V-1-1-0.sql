USE [micruberDB]
GO

DECLARE	@return_value int,
		@userId int

EXEC	@return_value = [dbo].[usp_seg_insertUsuario]
		@correo = N'admin@gmail.com',
		@password = N'admin',
		@nombre = N'Administrador',
		@userId = @userId OUTPUT

SELECT	@userId as N'@userId'

SELECT	'Return Value' = @return_value

GO
