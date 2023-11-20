-- phpMyAdmin SQL Dump
-- version 4.2.7.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: 14 Nov 2023 pada 15.27
-- Versi Server: 5.5.39
-- PHP Version: 5.4.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `tabel leaderboard`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `leaderboard`
--

CREATE TABLE IF NOT EXISTS `leaderboard` (
`Id` int(11) NOT NULL,
  `Skor` int(100) NOT NULL,
  `Nama` varchar(100) NOT NULL
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Dumping data untuk tabel `leaderboard`
--

INSERT INTO `leaderboard` (`Id`, `Skor`, `Nama`) VALUES
(1, 100000, 'Maulana'),
(2, 110000, 'Yanto'),
(3, 200000, 'Yantini');

-- --------------------------------------------------------

--
-- Struktur dari tabel `urutan`
--

CREATE TABLE IF NOT EXISTS `urutan` (
`Id` int(11) NOT NULL,
  `Nama` varchar(100) NOT NULL,
  `Skor` int(100) NOT NULL
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=76 ;

--
-- Dumping data untuk tabel `urutan`
--

INSERT INTO `urutan` (`Id`, `Nama`, `Skor`) VALUES
(39, 'yantono', 300),
(40, 'lalla', 300),
(41, 'nnn', 0),
(42, 'nnn', 0),
(43, 'mmm', 50),
(44, 'kkk', 100),
(45, 'Budi', 200),
(46, 'Rijal', 250),
(47, 'Budiono Siregar', 300),
(48, 'Nani Kore', 200),
(49, 'Nani Kore', 200),
(50, 'simontok', 250),
(51, 'sidik jari', 300),
(52, 'Maulana', 200),
(53, 'Naruto', 200),
(54, 'Naruto', 200),
(55, 'Maulana', 250),
(56, 'nani kore', 500),
(57, 'nani kore', 500),
(58, 'Maulana', 200),
(59, 'samsul', 950),
(60, 'Jumawa', 1000),
(61, '', 0),
(62, '', 0),
(63, '', 0),
(64, '', 0),
(65, '', 0),
(66, '', 0),
(67, '', 0),
(68, '', 0),
(69, '', 0),
(70, '', 0),
(71, '', 0),
(72, '', 0),
(73, '', 0),
(74, '', 0),
(75, 'naruto', 1150);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `leaderboard`
--
ALTER TABLE `leaderboard`
 ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `urutan`
--
ALTER TABLE `urutan`
 ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `leaderboard`
--
ALTER TABLE `leaderboard`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `urutan`
--
ALTER TABLE `urutan`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=76;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
