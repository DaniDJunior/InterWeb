IF (SELECT COUNT(1) FROM TB_Status WHERE StatusName = 'Ativo') = 0
BEGIN
	INSERT INTO TB_Status (StatusName)
	VALUES ('Ativo')
END

IF (SELECT COUNT(1) FROM TB_Status WHERE StatusName = 'Inativo') = 0
BEGIN
	INSERT INTO TB_Status (StatusName)
	VALUES ('Inativo')
END

IF (SELECT COUNT(1) FROM TB_Status WHERE StatusName = 'Teste') = 0
BEGIN
	INSERT INTO TB_Status (StatusName)
	VALUES ('Teste')
END