-- phpMyAdmin SQL Dump
-- version 4.0.4.1
-- http://www.phpmyadmin.net
--
-- Client: 127.0.0.1
-- Généré le: Mer 18 Novembre 2015 à 12:16
-- Version du serveur: 5.6.11
-- Version de PHP: 5.5.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de données: `connectFinance`
--
CREATE DATABASE IF NOT EXISTS `connectFinance` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `connectFinance`;

-- --------------------------------------------------------

--
-- Structure de la table `images`
--

CREATE TABLE IF NOT EXISTS `images` (
  `idImage` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(40) NOT NULL,
  `taille` int(11) NOT NULL,
  `format` varchar(10) NOT NULL,
  `Proprietaire` int(11) NOT NULL,
  `image_blob` blob NOT NULL,
  PRIMARY KEY (`idImage`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `match`
--

CREATE TABLE IF NOT EXISTS `match` (
  `IdMatch` int(11) NOT NULL AUTO_INCREMENT,
  `idProjet` int(11) NOT NULL,
  `idInvestisseur` int(11) NOT NULL,
  `idEntrepreneur` int(11) NOT NULL,
  PRIMARY KEY (`IdMatch`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `match_tempo`
--

CREATE TABLE IF NOT EXISTS `match_tempo` (
  `IdMatchTempo` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`IdMatchTempo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `message_propriete`
--

CREATE TABLE IF NOT EXISTS `message_propriete` (
  `IdMessagePropriete` int(11) NOT NULL AUTO_INCREMENT,
  `Message` text NOT NULL,
  `Emetteur` varchar(40) NOT NULL,
  `Receveur` varchar(40) NOT NULL,
  PRIMARY KEY (`IdMessagePropriete`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `projet`
--

CREATE TABLE IF NOT EXISTS `projet` (
  `idProjet` int(11) NOT NULL AUTO_INCREMENT,
  `Nom` int(11) NOT NULL,
  `idUser` int(11) NOT NULL,
  `Proprietaire` varchar(40) NOT NULL,
  `dateProjet` date NOT NULL,
  `Montant` int(11) NOT NULL,
  `Description` text NOT NULL,
  `idSecteurActivite` int(11) NOT NULL,
  PRIMARY KEY (`idProjet`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `relation`
--

CREATE TABLE IF NOT EXISTS `relation` (
  `IdRelation` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`IdRelation`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `relation_en_attente`
--

CREATE TABLE IF NOT EXISTS `relation_en_attente` (
  `IdRelationAttente` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`IdRelationAttente`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `secteur_activite`
--

CREATE TABLE IF NOT EXISTS `secteur_activite` (
  `idSecteurActivite` int(11) NOT NULL AUTO_INCREMENT,
  `Nom` varchar(20) NOT NULL,
  PRIMARY KEY (`idSecteurActivite`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `idUser` int(11) NOT NULL AUTO_INCREMENT,
  `Nom` varchar(40) NOT NULL,
  `Prenom` varchar(40) NOT NULL,
  `Date_naissance` date NOT NULL,
  `Sexe` varchar(10) NOT NULL,
  `Telephonne` varchar(10) NOT NULL,
  `Pays` varchar(40) NOT NULL,
  `Ville` varchar(40) NOT NULL,
  `Adresse` varchar(40) NOT NULL,
  `Mot_passe` varchar(24) NOT NULL,
  `Pseudo` varchar(16) NOT NULL,
  `Mail` varchar(60) NOT NULL,
  PRIMARY KEY (`idUser`),
  UNIQUE KEY `Telephonne` (`Telephonne`,`Pseudo`,`Mail`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
