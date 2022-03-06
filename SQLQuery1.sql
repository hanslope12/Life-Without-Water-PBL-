CREATE DATABASE Highscores;
CREATE TABLE tblPlayers(Name VARCHAR(50), Password VARCHAR(50), playerNumber INT IDENTITY);
CREATE TABLE tblSessions(Difficulty INT, Score INT, playerNumber INT);

