--USE [%INSTANCE%]

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[USP_SEL_Machine_ID_Client]') AND objectproperty(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[USP_SEL_Machine_ID_Client]
GO

CREATE PROCEDURE [dbo].[USP_SEL_Machine_ID_Client]
		@ID_Client int
   AS BEGIN

/*==========================================================================================================
Criada em                    : 10/11/2016
Autor                        : Luana Jordão
Sistema que utiliza          : ProdutoCredito
Descrição                    : Procedure do sistema de Credito por ID_Client
Exemplo                      : Exec [USP_SEL_Machine_ID_Client]

Última alteração em          : 00/00/0000
Autor da alteração           : Equipe Credito
Motivo da alteração          : Alteração periodica

==========================================================================================================*/

		SELECT 
				P.ID_Machine,
				--P.ID_MachineConfig,
				PC.MachineConfigName,
				P.ID_Client,
				P.MachineName,
				P.MachineKey,
				P.CPUID,
				P.DiskID,
				P.MACID,
				P.IP,
				P.IPOut,
				P.HostName,
				P.DNS,
				P.ID_Status
		FROM TB_Machine P
		INNER JOIN [dbo].[TB_MachineConfig] PC
			ON PC.ID_MachineConfig = P.ID_MachineConfig
		WHERE P.ID_Client = @ID_Client
		AND P.ID_Status = 1

   END
   
GO