-- phpMyAdmin SQL Dump
-- version 5.0.3
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2021. Már 27. 19:47
-- Kiszolgáló verziója: 10.4.14-MariaDB
-- PHP verzió: 7.4.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `tablaenaplo`
--
CREATE DATABASE IF NOT EXISTS `tablaenaplo` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `tablaenaplo`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `diakok`
--

CREATE TABLE `diakok` (
  `ID` int(11) NOT NULL,
  `Nev` varchar(50) NOT NULL,
  `OsztalyID` int(11) DEFAULT NULL,
  `logined` tinyint(1) DEFAULT NULL,
  `regisztralt` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `diakok`
--

INSERT INTO `diakok` (`ID`, `Nev`, `OsztalyID`, `logined`, `regisztralt`) VALUES
(1, 'Kovács János', 2, 1, NULL),
(2, 'Kis Pista', 2, NULL, NULL),
(3, 'Kerek Ferenc', 6, 1, 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `hianyzasok`
--

CREATE TABLE `hianyzasok` (
  `ID` int(11) NOT NULL,
  `Datum` date NOT NULL,
  `TanarID` int(11) NOT NULL,
  `DiakID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `hianyzasok`
--

INSERT INTO `hianyzasok` (`ID`, `Datum`, `TanarID`, `DiakID`) VALUES
(1, '0000-00-00', 3, 2),
(2, '0000-00-00', 3, 3),
(3, '2021-05-11', 3, 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `jegyek`
--

CREATE TABLE `jegyek` (
  `ID` int(11) NOT NULL,
  `Datum` date NOT NULL,
  `TantargyID` int(11) NOT NULL,
  `TanarID` int(11) NOT NULL,
  `DiakID` int(11) NOT NULL,
  `Jegy` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `jegyek`
--

INSERT INTO `jegyek` (`ID`, `Datum`, `TantargyID`, `TanarID`, `DiakID`, `Jegy`) VALUES
(3, '0000-00-00', 6, 3, 2, 5),
(4, '0000-00-00', 6, 3, 3, 4),
(5, '0000-00-00', 6, 3, 3, 2),
(6, '0000-00-00', 6, 3, 1, 5),
(7, '2020-12-01', 5, 3, 2, 1),
(8, '0000-00-00', 6, 3, 2, 4),
(9, '0000-00-00', 6, 3, 3, 1),
(10, '2021-03-22', 6, 3, 2, 2),
(11, '2021-03-11', 5, 3, 3, 2),
(12, '2021-01-19', 6, 3, 3, 3),
(13, '2021-03-02', 5, 3, 3, 2),
(14, '2021-03-10', 5, 2, 3, 2),
(15, '0000-00-00', 7, 2, 2, 2),
(16, '2021-03-25', 9, 4, 3, 2),
(17, '2020-09-10', 4, 3, 3, 2);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `login`
--

CREATE TABLE `login` (
  `ID` int(11) NOT NULL,
  `DiakID` int(11) DEFAULT NULL,
  `TanarID` int(11) DEFAULT NULL,
  `RendszergazdaE` tinyint(1) DEFAULT NULL,
  `username` varchar(50) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `login`
--

INSERT INTO `login` (`ID`, `DiakID`, `TanarID`, `RendszergazdaE`, `username`, `password`) VALUES
(2, NULL, 1, NULL, 'testTeacherUser', 'KNyip7M7dBOtO84dWMJt1nnHmfE='),
(3, NULL, 3, NULL, 'testTeacherLogin', '7EyINtuWuKyoOBx8ZLsJW6RtXig='),
(4, NULL, 2, NULL, 'testTeacherLogin2', 'KJG6zu7xZS7mmClNoOcbp4oqQGQ='),
(5, NULL, 4, NULL, 'tesztAdminReg', '7EyINtuWuKyoOBx8ZLsJW6RtXig='),
(6, NULL, 5, NULL, 'tesztReg321', '7EyINtuWuKyoOBx8ZLsJW6RtXig='),
(8, 1, NULL, NULL, 'jancsika', 'asd123'),
(9, 2, NULL, NULL, 'pistike', 'yNDbutl2xP7Wrb1eDQGnK092LC8='),
(10, 3, NULL, NULL, 'ferike12', '912KUgCVy/jH8LPDpg/48K0aca8='),
(11, 3, NULL, NULL, 'testStudentLogin888', '7EyINtuWuKyoOBx8ZLsJW6RtXig=');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `osztalyok`
--

CREATE TABLE `osztalyok` (
  `ID` int(11) NOT NULL,
  `OsztalyNev` varchar(50) NOT NULL,
  `OsztalyfonokID` int(11) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `osztalyok`
--

INSERT INTO `osztalyok` (`ID`, `OsztalyNev`, `OsztalyfonokID`) VALUES
(1, '9.a', 5),
(2, '9.b', 3),
(6, '9.c', 1),
(9, '10.a', 2),
(11, '10.b', 3),
(12, '13.d', 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `tanarok`
--

CREATE TABLE `tanarok` (
  `ID` int(11) NOT NULL,
  `Nev` varchar(50) NOT NULL,
  `OsztalyfonokE` tinyint(1) DEFAULT NULL,
  `logined` tinyint(1) DEFAULT NULL,
  `regisztralt` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `tanarok`
--

INSERT INTO `tanarok` (`ID`, `Nev`, `OsztalyfonokE`, `logined`, `regisztralt`) VALUES
(1, 'Kerek Ferenc', 1, NULL, 1),
(2, 'Kis Géza', 1, NULL, 1),
(3, 'Szabó Árpád', 1, 0, 1),
(4, 'Kell végre egy teszt', 0, NULL, 1),
(5, 'Másik teszt', 0, NULL, 1),
(6, 'Harmadik teszt', 1, NULL, NULL);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `tanitja`
--

CREATE TABLE `tanitja` (
  `ID` int(11) NOT NULL,
  `TantargyID` int(11) NOT NULL,
  `TanarID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `tanitja`
--

INSERT INTO `tanitja` (`ID`, `TantargyID`, `TanarID`) VALUES
(1, 6, 1),
(2, 2, 2),
(3, 6, 3),
(4, 3, 4),
(5, 2, 5),
(6, 7, 6);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `tantargyak`
--

CREATE TABLE `tantargyak` (
  `ID` int(11) NOT NULL,
  `Nev` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `tantargyak`
--

INSERT INTO `tantargyak` (`ID`, `Nev`) VALUES
(1, 'Matematika'),
(2, 'Magyar irodalom'),
(3, 'Történelem'),
(4, 'Magyar nyelvtan'),
(5, 'Biológia'),
(6, 'Kémia'),
(7, 'Fizika'),
(8, 'Informatika'),
(9, 'Foglalkoztatás I.');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `uzenetek`
--

CREATE TABLE `uzenetek` (
  `ID` int(3) NOT NULL,
  `DiakID` int(3) NOT NULL,
  `TanarNev` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `uzenet` varchar(500) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `uzenetek`
--

INSERT INTO `uzenetek` (`ID`, `DiakID`, `TanarNev`, `uzenet`) VALUES
(1, 1, 'Kerek Ferenc', ''),
(2, 1, 'Kis Géza', 'teszt üzi'),
(3, 3, 'Harmadik teszt', 'Jónapot tanár úr! Az a gond, hogy valamit írnom kéne ide tesztelés céljából.');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `diakok`
--
ALTER TABLE `diakok`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `OsztalyID` (`OsztalyID`);

--
-- A tábla indexei `hianyzasok`
--
ALTER TABLE `hianyzasok`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `TanarID` (`TanarID`),
  ADD KEY `DiakID` (`DiakID`);

--
-- A tábla indexei `jegyek`
--
ALTER TABLE `jegyek`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `DiakID` (`DiakID`),
  ADD KEY `jegyek_ibfk_1` (`TantargyID`),
  ADD KEY `jegyek_ibfk_2` (`TanarID`);

--
-- A tábla indexei `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `diakFK` (`DiakID`),
  ADD KEY `tanarFK` (`TanarID`);

--
-- A tábla indexei `osztalyok`
--
ALTER TABLE `osztalyok`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `OsztalyfonokID` (`OsztalyfonokID`);

--
-- A tábla indexei `tanarok`
--
ALTER TABLE `tanarok`
  ADD PRIMARY KEY (`ID`);

--
-- A tábla indexei `tanitja`
--
ALTER TABLE `tanitja`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `TantargyID` (`TantargyID`),
  ADD KEY `TanarID` (`TanarID`);

--
-- A tábla indexei `tantargyak`
--
ALTER TABLE `tantargyak`
  ADD PRIMARY KEY (`ID`);

--
-- A tábla indexei `uzenetek`
--
ALTER TABLE `uzenetek`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `diakID_idegenKulcs` (`DiakID`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `diakok`
--
ALTER TABLE `diakok`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `hianyzasok`
--
ALTER TABLE `hianyzasok`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `jegyek`
--
ALTER TABLE `jegyek`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT a táblához `login`
--
ALTER TABLE `login`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT a táblához `osztalyok`
--
ALTER TABLE `osztalyok`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT a táblához `tanarok`
--
ALTER TABLE `tanarok`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT a táblához `tanitja`
--
ALTER TABLE `tanitja`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT a táblához `tantargyak`
--
ALTER TABLE `tantargyak`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT a táblához `uzenetek`
--
ALTER TABLE `uzenetek`
  MODIFY `ID` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `diakok`
--
ALTER TABLE `diakok`
  ADD CONSTRAINT `diakok_ibfk_1` FOREIGN KEY (`OsztalyID`) REFERENCES `osztalyok` (`ID`);

--
-- Megkötések a táblához `hianyzasok`
--
ALTER TABLE `hianyzasok`
  ADD CONSTRAINT `hianyzasok_ibfk_1` FOREIGN KEY (`TanarID`) REFERENCES `tanarok` (`ID`),
  ADD CONSTRAINT `hianyzasok_ibfk_2` FOREIGN KEY (`DiakID`) REFERENCES `diakok` (`ID`);

--
-- Megkötések a táblához `jegyek`
--
ALTER TABLE `jegyek`
  ADD CONSTRAINT `jegyek_ibfk_1` FOREIGN KEY (`TantargyID`) REFERENCES `tantargyak` (`ID`),
  ADD CONSTRAINT `jegyek_ibfk_2` FOREIGN KEY (`TanarID`) REFERENCES `tanarok` (`ID`),
  ADD CONSTRAINT `jegyek_ibfk_3` FOREIGN KEY (`DiakID`) REFERENCES `diakok` (`ID`);

--
-- Megkötések a táblához `login`
--
ALTER TABLE `login`
  ADD CONSTRAINT `diakFK` FOREIGN KEY (`DiakID`) REFERENCES `diakok` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `tanarFK` FOREIGN KEY (`TanarID`) REFERENCES `tanarok` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `osztalyok`
--
ALTER TABLE `osztalyok`
  ADD CONSTRAINT `osztalyok_ibfk_1` FOREIGN KEY (`OsztalyfonokID`) REFERENCES `tanarok` (`ID`);

--
-- Megkötések a táblához `tanitja`
--
ALTER TABLE `tanitja`
  ADD CONSTRAINT `tanitja_ibfk_1` FOREIGN KEY (`TantargyID`) REFERENCES `tantargyak` (`ID`),
  ADD CONSTRAINT `tanitja_ibfk_2` FOREIGN KEY (`TanarID`) REFERENCES `tanarok` (`ID`);

--
-- Megkötések a táblához `uzenetek`
--
ALTER TABLE `uzenetek`
  ADD CONSTRAINT `diakID_idegenKulcs` FOREIGN KEY (`DiakID`) REFERENCES `diakok` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
