-- MySQL dump 10.13  Distrib 5.1.52, for redhat-linux-gnu (i386)
--
-- Host: localhost    Database: pb_world1
-- ------------------------------------------------------
-- Server version	5.1.52

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
-- Table structure for table `admins`
--

DROP TABLE IF EXISTS `admins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `admins` (
  `id` varchar(20) CHARACTER SET utf8 NOT NULL COMMENT 'id',
  `pwd` varchar(20) CHARACTER SET utf8 NOT NULL COMMENT 'password',
  `pin` int(10) unsigned NOT NULL COMMENT 'pin code',
  `phones` varchar(150) CHARACTER SET utf8 NOT NULL COMMENT 'list of phones for sms notification, separator '',''',
  `emails` varchar(150) NOT NULL COMMENT 'list of emails for email notification, separator '',''',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `cards`
--

DROP TABLE IF EXISTS `cards`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cards` (
  `card` varchar(20) NOT NULL,
  `price` int(10) unsigned NOT NULL,
  `activated` tinyint(1) NOT NULL DEFAULT '0',
  `user` varchar(20) NOT NULL,
  PRIMARY KEY (`card`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sessions`
--

DROP TABLE IF EXISTS `sessions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sessions` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `terminal` int(10) unsigned NOT NULL,
  `user` varchar(20) NOT NULL,
  `pages_printed` int(10) unsigned NOT NULL,
  `money_in` int(10) unsigned NOT NULL,
  `time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `page_cost` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=16198 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `terminals`
--

DROP TABLE IF EXISTS `terminals`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `terminals` (
  `id` int(10) unsigned NOT NULL,
  `name` varchar(45) NOT NULL,
  `admin` varchar(20) NOT NULL,
  `paper` smallint(5) unsigned NOT NULL,
  `money` smallint(5) unsigned NOT NULL,
  `banknotes` smallint(5) unsigned NOT NULL,
  `toner` smallint(6) NOT NULL,
  `errors` int(10) unsigned zerofill NOT NULL DEFAULT '0000000000',
  `last_ping` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `notify_online` tinyint(1) NOT NULL,
  `notify_paper_low` tinyint(1) NOT NULL,
  `notify_errors` int(10) unsigned NOT NULL,
  `notify_time` timestamp NOT NULL DEFAULT '1980-01-01 00:00:00',
  `ip_addr` varchar(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `user` varchar(20) NOT NULL,
  `password` varchar(45) NOT NULL,
  `money` float NOT NULL,
  `uni` varchar(10) DEFAULT 'kpi',
  PRIMARY KEY (`user`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2012-07-30 13:47:45
