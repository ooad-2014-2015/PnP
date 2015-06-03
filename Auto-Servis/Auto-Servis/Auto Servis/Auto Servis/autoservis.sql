-- phpMyAdmin SQL Dump
-- version 3.3.9
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Jun 02, 2015 at 05:36 PM
-- Server version: 5.5.8
-- PHP Version: 5.3.5

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `autoservis`
--

-- --------------------------------------------------------

--
-- Table structure for table `dijelovi`
--

CREATE TABLE IF NOT EXISTS `dijelovi` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `naziv` varchar(30) CHARACTER SET utf8 NOT NULL,
  `cijena` double NOT NULL,
  `kolicina` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `dijelovi`
--

INSERT INTO `dijelovi` (`id`, `naziv`, `cijena`, `kolicina`) VALUES
(2, 'Remen', 200, 5),
(3, 'Alnaser', 150, 10);

-- --------------------------------------------------------

--
-- Table structure for table `izvjestaji`
--

CREATE TABLE IF NOT EXISTS `izvjestaji` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `datumZavrsetkaRadova` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Dumping data for table `izvjestaji`
--


-- --------------------------------------------------------

--
-- Table structure for table `mehanicari`
--

CREATE TABLE IF NOT EXISTS `mehanicari` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ime` varchar(30) CHARACTER SET utf8 NOT NULL,
  `prezime` varchar(30) CHARACTER SET utf8 NOT NULL,
  `tip` varchar(30) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `mehanicari`
--

INSERT INTO `mehanicari` (`id`, `ime`, `prezime`, `tip`) VALUES
(1, 'Vehid', 'Vehić', 'Lakirer');

-- --------------------------------------------------------

--
-- Table structure for table `popravke`
--

CREATE TABLE IF NOT EXISTS `popravke` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cijena` double NOT NULL,
  `tipPopravke` varchar(30) CHARACTER SET utf8 NOT NULL,
  `datumPrijemaZahtjeva` datetime NOT NULL,
  `vozilo_id` int(11) NOT NULL,
  `dijelovi` longtext CHARACTER SET utf8 NOT NULL,
  `datumZavrsetka` datetime NOT NULL,
  `mehanicar_id` int(11) NOT NULL,
  `zavrsena` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `vozilo_id` (`vozilo_id`),
  KEY `mehanicar_id` (`mehanicar_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=22 ;

--
-- Dumping data for table `popravke`
--

INSERT INTO `popravke` (`id`, `cijena`, `tipPopravke`, `datumPrijemaZahtjeva`, `vozilo_id`, `dijelovi`, `datumZavrsetka`, `mehanicar_id`, `zavrsena`) VALUES
(21, 200, 'Limarijska', '2015-05-16 00:00:00', 8, 'Naziv:Alnaser Cijena:150 Kolicina:1\n', '2015-06-07 00:00:00', 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `privatna_lica`
--

CREATE TABLE IF NOT EXISTS `privatna_lica` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ime` varchar(30) CHARACTER SET utf8 NOT NULL,
  `prezime` varchar(30) CHARACTER SET utf8 NOT NULL,
  `adresa` varchar(30) CHARACTER SET utf8 NOT NULL,
  `brojTelefona` int(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `privatna_lica`
--

INSERT INTO `privatna_lica` (`id`, `ime`, `prezime`, `adresa`, `brojTelefona`) VALUES
(2, 'Adi', 'Palavra', 'safasf', 518511),
(3, 'Mirzo', 'Palavra', 'Bajre Kaljanca 5', 63794555),
(4, 'Neko', 'Nekic', 'sdgsddgs', 33555555);

-- --------------------------------------------------------

--
-- Table structure for table `racuni`
--

CREATE TABLE IF NOT EXISTS `racuni` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ukupnaCijena` double NOT NULL,
  `datumIzdavanja` datetime NOT NULL,
  `popravka_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `popravka_id` (`popravka_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=30 ;

--
-- Dumping data for table `racuni`
--

INSERT INTO `racuni` (`id`, `ukupnaCijena`, `datumIzdavanja`, `popravka_id`) VALUES
(28, 350, '2015-05-31 16:25:18', 21),
(29, 350, '2015-06-02 19:14:19', 21);

-- --------------------------------------------------------

--
-- Table structure for table `sluzbena_lica`
--

CREATE TABLE IF NOT EXISTS `sluzbena_lica` (
  `idFirme` int(11) NOT NULL AUTO_INCREMENT,
  `nazivFirme` varchar(30) CHARACTER SET utf8 NOT NULL,
  `ime` varchar(30) CHARACTER SET utf8 NOT NULL,
  `prezime` varchar(30) CHARACTER SET utf8 NOT NULL,
  `adresa` varchar(30) CHARACTER SET utf8 NOT NULL,
  `brojTelefona` int(10) NOT NULL,
  PRIMARY KEY (`idFirme`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `sluzbena_lica`
--

INSERT INTO `sluzbena_lica` (`idFirme`, `nazivFirme`, `ime`, `prezime`, `adresa`, `brojTelefona`) VALUES
(2, 'Imtech', 'Mirnes', 'Peljto', 'sdgsdg352', 8419844);

-- --------------------------------------------------------

--
-- Table structure for table `vozila`
--

CREATE TABLE IF NOT EXISTS `vozila` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `brojTablica` varchar(7) CHARACTER SET utf8 NOT NULL,
  `godinaProizvodnje` datetime NOT NULL,
  `proizvodjac` varchar(50) CHARACTER SET utf8 NOT NULL,
  `vlasnik_privatni_id` int(11) DEFAULT NULL,
  `vlasnik_sluzbeni_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `vlasnik_privatni_id` (`vlasnik_privatni_id`),
  KEY `vlasnik_sluzbeni_id` (`vlasnik_sluzbeni_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=12 ;

--
-- Dumping data for table `vozila`
--

INSERT INTO `vozila` (`id`, `brojTablica`, `godinaProizvodnje`, `proizvodjac`, `vlasnik_privatni_id`, `vlasnik_sluzbeni_id`) VALUES
(8, 'A12B345', '2005-05-05 00:00:00', 'Audi', 2, NULL),
(9, 'F12G567', '0001-01-01 00:00:00', 'Volkswagen', NULL, 2),
(11, 'X98Z123', '2009-05-05 00:00:00', 'Seat', 4, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `zahtjevi`
--

CREATE TABLE IF NOT EXISTS `zahtjevi` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `datumPrijema` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Dumping data for table `zahtjevi`
--


--
-- Constraints for dumped tables
--

--
-- Constraints for table `popravke`
--
ALTER TABLE `popravke`
  ADD CONSTRAINT `popravke_ibfk_1` FOREIGN KEY (`vozilo_id`) REFERENCES `vozila` (`id`),
  ADD CONSTRAINT `popravke_ibfk_2` FOREIGN KEY (`mehanicar_id`) REFERENCES `mehanicari` (`id`);

--
-- Constraints for table `racuni`
--
ALTER TABLE `racuni`
  ADD CONSTRAINT `racuni_ibfk_1` FOREIGN KEY (`popravka_id`) REFERENCES `popravke` (`id`);

--
-- Constraints for table `vozila`
--
ALTER TABLE `vozila`
  ADD CONSTRAINT `vozila_ibfk_2` FOREIGN KEY (`vlasnik_privatni_id`) REFERENCES `privatna_lica` (`id`),
  ADD CONSTRAINT `vozila_ibfk_3` FOREIGN KEY (`vlasnik_sluzbeni_id`) REFERENCES `sluzbena_lica` (`idFirme`);
