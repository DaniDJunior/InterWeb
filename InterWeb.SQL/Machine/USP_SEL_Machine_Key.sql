--USE [%INSTANCE%]

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[USP_SEL_Machine_Key]') AND objectproperty(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[USP_SEL_Machine_Key]
GO

CREATE PROCEDURE [dbo].[USP_SEL_Machine_Key]
		@MachineKey varchar(30)
   AS BEGIN

/*==========================================================================================================
Criada em                    : 16/11/2016
Autor                        : Dorval Junior
Sistema que utiliza          : ProdutoCredito
Descrição                    : Procedure do sistema de Creditoo por Key
Exemplo                      : Exec [USP_SEL_Machine_Key] 'D5D1-CEC7-F644-E17A-134E'

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
		WHERE MachineKey = @MachineKey

   END
   
GO