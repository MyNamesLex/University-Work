-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 27, 2019 at 11:44 AM
-- Server version: 10.1.36-MariaDB
-- PHP Version: 5.6.38
SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";
/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
--
-- Database: `creditcard`
--
-- --------------------------------------------------------
--
-- Table structure for table `card`
--
CREATE TABLE `card` (
 `#` int(11) NOT NULL,
 `ccnum` varchar(255)NOT NULL,
 `expdate` date NOT NULL,
 `seccode` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
--
-- Dumping data for table `card`
--
INSERT INTO `card` (`#`, `ccnum`, `expdate`, `seccode`) VALUES
(1, 1234567891011123, '2020-06-18', 345);
--
-- Indexes for dumped tables
--
--
-- Indexes for table `card`
--
ALTER TABLE `card`
 ADD PRIMARY KEY (`#`);
COMMIT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;