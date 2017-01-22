--USE [%INSTANCE%]

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[USP_INS_UPD_Status]') AND objectproperty(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[USP_INS_UPD_Status]
GO

CREATE PROCEDURE [dbo].[USP_INS_UPD_Status]
	 @ID_Status		INT
	,@StatusName	varchar(100)
   AS BEGIN

/*==========================================================================================================
Criada em                    : 10/11/2016
Autor                        : Dorval Junior
Sistema que utiliza          : ProdutoCredito
Descri��o                    : Procedute de Inser��o e Update da Tabela TB_Status
Exemplo                      : Exec [USP_INS_UPD_Status]

�ltima altera��o em          : 
Autor da altera��o           : 
Motivo da altera��o          : 

==========================================================================================================*/

	   IF @ID_Status = 0 BEGIN

			INSERT INTO [dbo].[TB_Status] (
				 [StatusName]
			) VALUES (
				 @StatusName
			)			

			SET @ID_Status =  @@IDENTITY
	
	   END ELSE BEGIN

			UPDATE [dbo].[TB_Status] SET 
				 [StatusName]	= @StatusName
			WHERE [ID_Status] = @ID_Status

	   END

		SELECT @ID_Status

   END
   
GO