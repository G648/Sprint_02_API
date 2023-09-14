USE inlock_games_codeFirst_manha;

INSERT INTO Estudio (IdEstudio, Nome) 
VALUES (NEWID(), 'NYStudios'), (NEWID(), 'RockstarGames');

SELECT * FROM Estudio;

INSERT INTO Jogo
VALUES 
(NEWID(), 'Red Dead', 'Jogo muito bacanaaa', '2020-09-20', 1.99, '69A5BC26-2F6F-4254-AD94-2CDE7C31F053'),
(NEWID(), 'Avatar', 'Jogo Hardcoreeee', '2018-08-13', 1.99, '7B02B4EC-83FE-4059-A95F-44D5E2C67184');

SELECT * FROM Jogo;

INSERT INTO TiposUsuario (IdTipoUsuario, Titulo)
VALUES (NEWID(), 'Administrador'), (NEWID(), 'Comum');

SELECT * FROM TiposUsuario;

INSERT INTO Usuario (IdUsuario, Email, Senha, IdTipoUsuario)
VALUES 
(NEWID(), 'admin@admin.com', 'admin', 'D7B8413B-18FB-4B10-A699-0234BA2B3B6D'),
(NEWID(), 'comum@comum.com', 'comum', 'C1C69563-CA9B-40C3-8829-6F919AF172EE');

SELECT * FROM Usuario;