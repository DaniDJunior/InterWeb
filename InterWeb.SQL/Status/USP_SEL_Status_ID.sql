--USE [%INSTANCE%]

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[USP_SEL_Status_ID]') AND objectproperty(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[USP_SEL_Status_ID]
GO

CREATE PROCEDURE [dbo].[USP_SEL_Status_ID]
	@ID_Status int
   AS BEGIN

/*==========================================================================================================
Criada em                    : 10/11/2016
Autor                        : Rafael Souza
Sistema que utiliza          : ProdutoCredito
Descrição                    : Procedure de Seleção da Tabela TB_Status por ID
Exemplo                      : Exec [USP_SEL_Status_ID]

Última alteração em          : 00/00/0000
Autor da alteração           : Equipe Credito
Motivo da alteração          : Alteração periodica

==========================================================================================================*/

		SELECT 
			ID_Status, 
			StatusName
		FROM TB_Status
		WHERE ID_Status = @ID_Status
   END
   
GO