-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : lun. 02 mai 2022 à 17:27
-- Version du serveur :  5.7.31
-- Version de PHP : 7.3.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `projetcsharp`
--

-- --------------------------------------------------------

--
-- Structure de la table `client`
--

DROP TABLE IF EXISTS `client`;
CREATE TABLE IF NOT EXISTS `client` (
  `numcli` varchar(10) NOT NULL,
  `Nom` varchar(50) NOT NULL,
  `ville` varchar(50) NOT NULL,
  `telephone` varchar(10) NOT NULL,
  PRIMARY KEY (`numcli`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `client`
--

INSERT INTO `client` (`numcli`, `Nom`, `ville`, `telephone`) VALUES
('CLT003', 'randria', 'androy', '034588966'),
('CLT005', 'Rija', 'Fianara', '0345669784'),
('CLT006', 'itema', 'tana', '0341440014'),
('CLT008', 'ytema', 'Diego', '0341440014'),
('CLT009', 'rakoto', 'tana', '0341440018');

-- --------------------------------------------------------

--
-- Structure de la table `commande`
--

DROP TABLE IF EXISTS `commande`;
CREATE TABLE IF NOT EXISTS `commande` (
  `numcli` varchar(10) NOT NULL,
  `libelle` varchar(50) NOT NULL,
  `qte_com` int(20) NOT NULL,
  `date` date NOT NULL,
  `time` time(6) NOT NULL,
  PRIMARY KEY (`numcli`,`libelle`,`date`,`time`) USING BTREE
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `commande`
--

INSERT INTO `commande` (`numcli`, `libelle`, `qte_com`, `date`, `time`) VALUES
('CLT005', 'ovy', 5, '2022-04-28', '10:10:45.000000'),
('CLT003', 'tsako', 45, '2022-04-20', '13:50:42.000000'),
('CLT008', 'vary', 12, '2022-04-25', '18:55:27.000000'),
('CLT006', 'vary', 42, '2022-04-21', '10:08:27.000000'),
('CLT003', 'vary', 1, '2022-04-21', '10:10:24.000000'),
('CLT003', 'tsako', 75, '2022-04-21', '10:13:10.000000'),
('CLT003', 'tsako', 44, '2022-04-22', '20:18:00.000000'),
('CLT003', 'tsako', 6, '2022-04-22', '20:29:58.000000'),
('CLT006', 'tsako', 9, '2022-04-22', '20:33:35.000000'),
('CLT003', 'tsako', 9, '2022-04-22', '20:38:02.000000'),
('CLT003', 'tsako', 8, '2022-04-25', '14:42:53.000000'),
('CLT003', 'anana', 40, '2022-04-25', '18:42:32.000000');

-- --------------------------------------------------------

--
-- Structure de la table `facture`
--

DROP TABLE IF EXISTS `facture`;
CREATE TABLE IF NOT EXISTS `facture` (
  `idfact` varchar(20) NOT NULL,
  `numcli` varchar(20) NOT NULL,
  `date` date NOT NULL,
  PRIMARY KEY (`idfact`,`numcli`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `facture`
--

INSERT INTO `facture` (`idfact`, `numcli`, `date`) VALUES
('000008', 'CLT006', '2022-04-25'),
('000001', 'CLT007', '2022-04-25'),
('000008', 'CLT003', '2022-04-25'),
('000009', 'CLT003', '2022-04-27'),
('000010', 'CLT007', '2022-04-27'),
('000011', 'CLT003', '2022-04-28'),
('000012', 'CLT003', '2022-04-28'),
('000013', 'CLT003', '2022-04-28'),
('000014', 'CLT003', '2022-04-28');

-- --------------------------------------------------------

--
-- Structure de la table `produit`
--

DROP TABLE IF EXISTS `produit`;
CREATE TABLE IF NOT EXISTS `produit` (
  `codepro` varchar(10) NOT NULL,
  `libelle` varchar(50) NOT NULL,
  `pu` int(20) NOT NULL,
  `quantite` int(10) NOT NULL,
  PRIMARY KEY (`codepro`)
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `produit`
--

INSERT INTO `produit` (`codepro`, `libelle`, `pu`, `quantite`) VALUES
('PDT003', 'tsako', 2000, 10),
('PDT002', 'vary', 2500, 136),
('PDT004', 'ovy', 1800, 1),
('PDT005', 'anana', 500, 25),
('PDT006', 'akondro', 1200, 50);

-- --------------------------------------------------------

--
-- Structure de la table `utilisateur`
--

DROP TABLE IF EXISTS `utilisateur`;
CREATE TABLE IF NOT EXISTS `utilisateur` (
  `iduser` varchar(10) NOT NULL,
  `nom` varchar(50) NOT NULL,
  `mail` varchar(50) NOT NULL,
  `mdp` varchar(200) NOT NULL,
  `status` varchar(10) NOT NULL,
  PRIMARY KEY (`iduser`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `utilisateur`
--

INSERT INTO `utilisateur` (`iduser`, `nom`, `mail`, `mdp`, `status`) VALUES
('USR008', 'simple', 'aantsivaniaina@mail.com', '0000D50000D50000D50000D50000D50000D50000D50000D50000D50000D50000D50000D50000D50000D50000D50000D5', 'user'),
('USR007', 'admin', 'admin@mail.com', '0000F90000F90000F90000F90000F90000F90000F90000F90000F90000F90000F90000F90000F90000F90000F90000F9', 'admin'),
('USR006', 'admin', 'admin@gmail.com', '000004000004000004000004000004000004000004000004000004000004000004000004000004000004000004000004', 'admin'),
('USR005', 'fifaliana', 'fifa@mail.com', '0000D50000D50000D50000D50000D50000D50000D50000D50000D50000D50000D50000D50000D50000D50000D50000D5', 'admin'),
('USR004', 'moi', 'moiaussi@mail.com', '0000D50000D50000D50000D50000D50000D50000D50000D50000D50000D50000D50000D50000D50000D50000D50000D5', 'user'),
('USR003', 'stephan', 'stephan@mail.com', '0000F90000F90000F90000F90000F90000F90000F90000F90000F90000F90000F90000F90000F90000F90000F90000F9', 'admin'),
('USR001', 'aina', 'aina@mail.to', '000010000010000010000010000010000010000010000010000010000010000010000010000010000010000010000010', 'user'),
('USR002', 'rasta', 'rasta@mail.com', '0000F90000F90000F90000F90000F90000F90000F90000F90000F90000F90000F90000F90000F90000F90000F90000F9', 'user');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
