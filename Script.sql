DROP DATABASE IF EXISTS Cantine; 
CREATE DATABASE Cantine DEFAULT CHARACTER SET utf8;
USE Cantine;

CREATE TABLE Menus(
   IdMenu INT AUTO_INCREMENT PRIMARY KEY,
   LibelleMenu VARCHAR(150) NOT NULL,
   Entree VARCHAR(150) NOT NULL,
   Plat VARCHAR(150) NOT NULL,
   Dessert VARCHAR(150) NOT NULL,
   Prix DECIMAL(15,2) NOT NULL
   
)ENGINE=InnoDB;

CREATE TABLE Eleves(
   IdUtilisateur INT AUTO_INCREMENT PRIMARY KEY,
   Nom VARCHAR(50) NOT NULL,
   Prenom VARCHAR(50) NOT NULL,
   Classe VARCHAR(50) NOT NULL,
   DateNaissance DATE,
   Adresse VARCHAR(200),
   Mail VARCHAR(150) NOT NULL
)ENGINE=InnoDB; 

CREATE TABLE TypePaiements(
   IdTypePaiement INT AUTO_INCREMENT PRIMARY KEY,
   LibelleTypePaiement VARCHAR(50) NOT NULL

)ENGINE=InnoDB;

CREATE TABLE Utilisateurs(
   IdUtilisateur INT AUTO_INCREMENT PRIMARY KEY,
   TypeUtilisateur INT NOT NULL,
   Login VARCHAR(50) NOT NULL,
   MotDePasse VARCHAR(50) NOT NULL

)ENGINE=InnoDB;


CREATE TABLE Reservations(
   IdReservation INT AUTO_INCREMENT PRIMARY KEY,
   DateReservation DATE NOT NULL,
   DateRepas DATE NOT NULL,
   IdUtilisateur INT NOT NULL

   
)ENGINE=InnoDB;

CREATE TABLE Reglements(
   IdReglement INT AUTO_INCREMENT PRIMARY KEY,
   IdUtilisateur INT,
   IdTypePaiement INT,
   IdReservation INT,
   DateReglement DATE NOT NULL
  
   
)ENGINE=InnoDB;

CREATE TABLE MenuDuJour(
   IdMenuDuJour INT AUTO_INCREMENT PRIMARY KEY,
   IdMenu INT ,
   DateDuJour DATE NOT NULL

)ENGINE=InnoDB;

CREATE TABLE ReservationsMenus(
   IdReservationMenu INT AUTO_INCREMENT PRIMARY KEY,
   IdMenu INT,
   IdReservation INT
  
  
 
)ENGINE=InnoDB;

ALTER TABLE Reservations
ADD CONSTRAINT FK_Reservations_Eleves FOREIGN KEY(IdUtilisateur) REFERENCES Eleves(IdUtilisateur);

ALTER TABLE Reglements
ADD CONSTRAINT FK_Reglements_Eleves FOREIGN KEY(IdUtilisateur) REFERENCES Eleves(IdUtilisateur),
ADD CONSTRAINT FK_Reglements_TypePaiements FOREIGN KEY(IdTypePaiement) REFERENCES TypePaiements(IdTypePaiement),
ADD CONSTRAINT FK_Reglements_Reservations FOREIGN KEY(IdReservation) REFERENCES Reservations(IdReservation);

ALTER TABLE MenuDuJour
ADD CONSTRAINT FK_MenuDuJour_Menus FOREIGN KEY(IdMenu) REFERENCES Menus(IdMenu);

ALTER TABLE ReservationsMenus
ADD CONSTRAINT FK_ReservationsMenus_Menus FOREIGN KEY(IdMenu) REFERENCES Menus(IdMenu),
ADD CONSTRAINT FK_ReservationsMenus_Reservations   FOREIGN KEY(IdReservation) REFERENCES Reservations(IdReservation);
