--USE [%INSTANCE%]

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[USP_INS_UPD_Machine]') AND objectproperty(id, N'IsProcedure') = 1)
DROP PROCEDURE [USP_INS_UPD_Machine]
GO

CREATE PROCEDURE USP_INS_UPD_Machine
		@ID_Machine			int,
		--@ID_MachineConfig	int,
		@ID_Client			int,
		@MachineName		varchar(100),
		@MachineKey			varchar(30) ,
		@CPUID				varchar(100),
		@DiskID				varchar(100),
		@MACID				varchar(100),
		@IP					varchar(100),
		@IPOut				varchar(100),
		@HostName			varchar(200),
		@DNS				varchar(200),
		@ID_Status			int
   AS BEGIN
   
/*==========================================================================================================
Criada em                    : 10/11/2016
Autor                        : Luana Jordão
Sistema que utiliza          : ProdutoCredito
Descrição                    : Procedure do sistema de Credito
Exemplo                      : Exec [USP_INS_UPD_Machine]

Última alteração em          : 00/00/0000
Autor da alteração           : Equipe Credito
Motivo da alteração          : Alteração periódica
==========================================================================================================*/

	   IF @ID_Machine = 0 BEGIN

			INSERT INTO TB_Machine (
				--ID_MachineConfig	,
				ID_Client			,
				MachineName			,
				MachineKey			,
				CPUID				,
				DiskID				,
				MACID				,
				IP					,
				IPOut				,
				HostName			,
				DNS					,
				ID_Status			
			) VALUES (
				--@ID_MachineConfig	,
				@ID_Client			,
				@MachineName		,
				@MachineKey			,
				@CPUID				,
				@DiskID				,
				@MACID				,
				@IP					,
				@IPOut				,
				@HostName			,
				@DNS				,
				@ID_Status			
			)

			SET @ID_Machine =  @@IDENTITY
	
	   END ELSE BEGIN

			UPDATE TB_Machine SET 
				--ID_MachineConfig = @ID_MachineConfig,
				ID_Client = @ID_Client,
				MachineName = @MachineName,
				MachineKey = @MachineKey,
				CPUID = @CPUID,
				DiskID = @DiskID,
				MACID = MACID,
				IP = @IP,
				IPOut = @IPOut,
				HostName = @HostName,
				DNS = @DNS,
				ID_Status = @ID_Status			
			WHERE ID_Machine = @ID_Machine

	   END

		SELECT @ID_Machine

   END
   
GO