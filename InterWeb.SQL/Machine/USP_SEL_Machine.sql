--USE [%INSTANCE%]

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[USP_SEL_Machine]') AND objectproperty(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[USP_SEL_Machine]
GO

CREATE PROCEDURE [dbo].[USP_SEL_Machine]
   AS BEGIN

/*==========================================================================================================
Criada em                    : 10/11/2016
Autor                        : Luana Jordão
Sistema que utiliza          : ProdutoCredito
Descrição                    : Procedure do sistema de Credito
Exemplo                      : Exec [USP_SEL_Machine]

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


   END
   
GO