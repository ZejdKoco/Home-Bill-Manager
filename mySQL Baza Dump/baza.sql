CREATE DATABASE  IF NOT EXISTS `billmanager` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `billmanager`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: billmanager
-- ------------------------------------------------------
-- Server version	5.7.21-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `racuni`
--

DROP TABLE IF EXISTS `racuni`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `racuni` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `naziv` varchar(50) NOT NULL,
  `iznos` double NOT NULL,
  `datum` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `racuni`
--

LOCK TABLES `racuni` WRITE;
/*!40000 ALTER TABLE `racuni` DISABLE KEYS */;
INSERT INTO `racuni` VALUES (8,'Voda',15,'2018-11-16 00:00:00'),(9,'Struja',5,'2018-11-16 00:00:00'),(10,'Internet',55,'2018-11-16 00:00:00'),(11,'Struja',39,'2018-11-16 00:00:00');
/*!40000 ALTER TABLE `racuni` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `racuni_AFTER_DELETE` AFTER DELETE ON `racuni` FOR EACH ROW BEGIN
INSERT into billmanager.racuni_arhiva(id, naziv, iznos, datum)
VALUES(OLD.id, OLD.naziv, OLD.iznos, OLD.datum);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `racuni_arhiva`
--

DROP TABLE IF EXISTS `racuni_arhiva`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `racuni_arhiva` (
  `id` int(11) NOT NULL,
  `naziv` varchar(45) NOT NULL,
  `iznos` double NOT NULL,
  `datum` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `racuni_arhiva`
--

LOCK TABLES `racuni_arhiva` WRITE;
/*!40000 ALTER TABLE `racuni_arhiva` DISABLE KEYS */;
INSERT INTO `racuni_arhiva` VALUES (1,'Struja',21,'2018-03-02 00:00:00'),(2,'Voda',45,'2018-03-08 00:00:00'),(3,'Internet',55,'2018-03-08 00:00:00'),(4,'Voda',65,'2018-03-08 00:00:00'),(5,'Struja',26,'2018-05-06 00:00:00'),(6,'Internet',45,'2018-08-27 00:00:00'),(7,'Struja',15,'2018-11-16 00:00:00'),(12,'Telemach',40,'2018-11-16 00:00:00');
/*!40000 ALTER TABLE `racuni_arhiva` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vrsta_racuna`
--

DROP TABLE IF EXISTS `vrsta_racuna`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vrsta_racuna` (
  `naziv` varchar(50) NOT NULL,
  PRIMARY KEY (`naziv`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vrsta_racuna`
--

LOCK TABLES `vrsta_racuna` WRITE;
/*!40000 ALTER TABLE `vrsta_racuna` DISABLE KEYS */;
INSERT INTO `vrsta_racuna` VALUES ('Internet'),('Plin'),('RAD'),('Struja'),('Voda');
/*!40000 ALTER TABLE `vrsta_racuna` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'billmanager'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-04-15 12:53:30
