--USE [%INSTANCE%]

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[USP_SEL_Status]') AND objectproperty(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[USP_SEL_Status]
GO

CREATE PROCEDURE [dbo].[USP_SEL_Status]
   AS BEGIN

/*==========================================================================================================
Criada em                    : 10/11/2016
Autor                        : Rafael Souza
Sistema que utiliza          : ProdutoCredito
Descri��o                    : Procedure de Sele��o da Tabela TB_Status
Exemplo                      : Exec [USP_SEL_Status]

�ltima altera��o em          : 00/00/0000
Autor da altera��o           : Equipe Credito
Motivo da altera��o          : Altera��o periodica

==========================================================================================================*/

		SELECT 
			ID_Status, 
			StatusName
		FROM TB_Status
   END
   
GO