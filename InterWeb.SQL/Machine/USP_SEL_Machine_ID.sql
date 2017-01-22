--USE [%INSTANCE%]

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[USP_SEL_Machine_ID]') AND objectproperty(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[USP_SEL_Machine_ID]
GO

CREATE PROCEDURE [dbo].[USP_SEL_Machine_ID]
		@ID_Machine int
   AS BEGIN

/*==========================================================================================================
Criada em                    : 10/11/2016
Autor                        : Luana Jordão
Sistema que utiliza          : ProdutoCredito
Descrição                    : Procedure do sistema de Credito por ID
Exemplo                      : Exec [USP_SEL_Machine_ID]

Última alteração em          : 00/00/0000
Autor da alteração           : Equipe Credito
Motivo da alteração          : Alteração periodica

==========================================================================================================*/

		SELECT 
				ID_Machine,
				--ID_MachineConfig,
				ID_Client,
				MachineName,
				MachineKey,
				CPUID,
				DiskID,
				MACID,
				IP,
				IPOut,
				HostName,
				DNS,
				ID_Status
		FROM TB_Machine 
		WHERE ID_Machine = @ID_Machine

   END
   
GO