IF NOT EXISTS(SELECT * FROM SYS.FOREIGN_KEYS WHERE OBJECT_NAME(parent_object_id) = 'TB_Machine' AND NAME = 'FK_Machine_Status')
	ALTER TABLE [dbo].[TB_Machine]  WITH CHECK ADD  CONSTRAINT [FK_Machine_Status] FOREIGN KEY([ID_Status])
	REFERENCES [dbo].[TB_Status] ([ID_Status])