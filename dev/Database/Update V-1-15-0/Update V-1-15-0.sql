USE [micruberDB]
GO
alter table tbl_seg_usuario
add codigoNFC varchar(50)
/****** Object:  StoredProcedure [dbo].[usp_seg_updateNFC]    Script Date: 6/27/2019 12:11:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ETCHEVERRY-PC
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_seg_updateNFC]
	@correo varchar(50),
	@cNFC varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @logUs int
	DECLARE @exNFC int

	SELECT @logUs=usuarioId FROM tbl_seg_usuario WHERE @correo = correo

	if(isnull(@logUs,0) > 0)
		BEGIN
		SELECT top 1 @exNFC=usuarioId from tbl_seg_usuario WHERE codigoNFC = @cNFC
		if(isnull(@exNFC,0) = 0)
		BEGIN
			UPDATE [dbo].[tbl_seg_usuario]
			SET codigoNFC = @cNFC
			WHERE @logUs = usuarioId
		end
	end

END
GO

ALTER PROCEDURE [dbo].[usp_seg_getAllUsuarios]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT *
	  FROM [dbo].[tbl_seg_usuario] 
	   


END
GO
DELETE FROM [dbo].[tbl_Version]
GO

INSERT INTO [dbo].[tbl_Version]
           ([versionMayor]
           ,[versionMenor]
           ,[patch])
     VALUES
           (1
           ,15
           ,0)
GO