-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 16, 2026 at 08:56 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `pizzaarena`
--
CREATE DATABASE IF NOT EXISTS `pizzaarena` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `pizzaarena`;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetroleclaims`
--

CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetroles`
--

CREATE TABLE `aspnetroles` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `aspnetroles`
--

INSERT INTO `aspnetroles` (`Id`, `Name`, `NormalizedName`, `ConcurrencyStamp`) VALUES
('19946af4-5262-4d01-945c-6bb26fb4d000', 'Admin', 'ADMIN', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserclaims`
--

CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserlogins`
--

CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(255) NOT NULL,
  `ProviderKey` varchar(255) NOT NULL,
  `ProviderDisplayName` longtext DEFAULT NULL,
  `UserId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserroles`
--

CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `aspnetuserroles`
--

INSERT INTO `aspnetuserroles` (`UserId`, `RoleId`) VALUES
('874c998b-e962-4088-9906-47bbffcb9f9e', '19946af4-5262-4d01-945c-6bb26fb4d000');

-- --------------------------------------------------------

--
-- Table structure for table `aspnetusers`
--

CREATE TABLE `aspnetusers` (
  `Id` varchar(255) NOT NULL,
  `RegistrationDate` datetime(6) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext DEFAULT NULL,
  `SecurityStamp` longtext DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL,
  `PhoneNumber` longtext DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `aspnetusers`
--

INSERT INTO `aspnetusers` (`Id`, `RegistrationDate`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`) VALUES
('41c640ca-2164-4019-b2c0-5778f5e8ff66', '2026-04-16 20:40:56.026327', 'TeszterJanos', 'TESZTERJANOS', 'teszterjanos@gmail.com', 'TESZTERJANOS@GMAIL.COM', 0, 'AQAAAAIAAYagAAAAEHQGE49iDUnbfe768VUrJcKGtXcu1HtEDcnZa4zBC4dkW+VZoyKISuoTMPvf9dEWNQ==', 'YZES6U6VYRTXYLSXDWTQJ5FFRGP26SOL', '2211e966-5c66-434e-a918-1eefd3ced157', NULL, 0, 0, NULL, 1, 0),
('874c998b-e962-4088-9906-47bbffcb9f9e', '2026-04-16 20:35:05.241383', 'admin', 'ADMIN', 'pizzaarena@admin.com', 'PIZZAARENA@ADMIN.COM', 0, 'AQAAAAIAAYagAAAAEMe8cjWdkzHOAQOiGThcvQK3xITh9kvvQmMHjBj3/knxkUn4QnIF5963zOvs7Vv71w==', '3XNAABKOVFJAA73O6SZLBV2ND23OQPKO', 'e00fec3d-14cb-45d1-8061-4846892ec410', NULL, 0, 0, NULL, 1, 0),
('ff4e5b8e-d0e0-4248-898a-3cc1f9afffc2', '2026-04-16 20:43:11.401719', 'TeszterGergo', 'TESZTERGERGO', 'tesztergergo@gmail.com', 'TESZTERGERGO@GMAIL.COM', 0, 'AQAAAAIAAYagAAAAEESoSfCFhV5bTHw0GC9wJ0/VQwC8GV4gh3IL/losZo2mH0k1YDaD8WwGycKmUbgJRQ==', 'RWOHJ23RZRNFG6OSNNS7MQRM4MAPHNRT', 'b4915a61-f594-4b44-9fd2-2ef1f9989538', NULL, 0, 0, NULL, 1, 0);

-- --------------------------------------------------------

--
-- Table structure for table `aspnetusertokens`
--

CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Value` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE `categories` (
  `Id` int(11) NOT NULL,
  `Name` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`Id`, `Name`) VALUES
(3, 'Előételek'),
(4, 'Levesek'),
(5, 'Pizza'),
(7, 'Hamburgerek'),
(8, 'Tészták'),
(9, 'Grill Ételek'),
(10, 'Saláták'),
(11, 'Desszertek'),
(12, 'Üdítők'),
(13, 'Alkoholos italok'),
(14, 'Kávé és Tea');

-- --------------------------------------------------------

--
-- Table structure for table `chefspecials`
--

CREATE TABLE `chefspecials` (
  `Id` int(11) NOT NULL,
  `ProductId` int(11) NOT NULL,
  `CustomNote` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `chefspecials`
--

INSERT INTO `chefspecials` (`Id`, `ProductId`, `CustomNote`) VALUES
(3, 11, 'Nagyon finom, ízletes színvilág, incsiklandó.'),
(4, 16, 'Autentikus olasz recept alapján: krémes tojássárgája, pirított guanciale (tokaszalonna), frissen őrölt feketebors és bőséges Pecorino Romano sajt. Szigorúan tejszín nélkül!'),
(6, 23, 'Könnyű és krémes mascarpone krém, kávéba és egy leheletnyi Amaretto likőrbe áztatott babapiskóta rétegekkel. A tetején vastag, sötét holland kakaóporral borítva. Hagyományos recept, ahogy az olasz mamák készítik.');

-- --------------------------------------------------------

--
-- Table structure for table `globalsettings`
--

CREATE TABLE `globalsettings` (
  `Id` int(11) NOT NULL,
  `ContactEmail` longtext NOT NULL DEFAULT '',
  `DeliveryTime` longtext NOT NULL,
  `FacebookUrl` longtext NOT NULL,
  `InstagramUrl` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `globalsettings`
--

INSERT INTO `globalsettings` (`Id`, `ContactEmail`, `DeliveryTime`, `FacebookUrl`, `InstagramUrl`) VALUES
(1, 'PizzArena@gmail.com', '30', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `orders`
--

CREATE TABLE `orders` (
  `Id` int(11) NOT NULL,
  `CustomerName` longtext NOT NULL,
  `CustomerEmail` longtext NOT NULL,
  `CustomerPhone` longtext NOT NULL,
  `PostalCode` longtext NOT NULL,
  `City` longtext NOT NULL,
  `Street` longtext NOT NULL,
  `Other` longtext NOT NULL,
  `User_Id` varchar(255) NOT NULL,
  `OrderTime` datetime(6) NOT NULL,
  `Status` int(11) NOT NULL DEFAULT 0,
  `RestaurantId` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `orders`
--

INSERT INTO `orders` (`Id`, `CustomerName`, `CustomerEmail`, `CustomerPhone`, `PostalCode`, `City`, `Street`, `Other`, `User_Id`, `OrderTime`, `Status`, `RestaurantId`) VALUES
(1, 'Teszter János', 'teszterjanos@gmail.com', '+36123456789', '1234', 'Siófok', 'Tesztelő utca 6', '2/2', '41c640ca-2164-4019-b2c0-5778f5e8ff66', '2026-04-16 20:42:09.949820', 0, 4),
(2, 'Teszter Gergő', 'tesztergergo@gmail.com', '+36123456789', '1234', 'Miskolc', 'Jó utca 9', '1/2', 'ff4e5b8e-d0e0-4248-898a-3cc1f9afffc2', '2026-04-16 20:44:09.636139', 0, 2),
(3, 'Teszter Gergő', 'tesztergergo@gmail.com', '+36123456789', '1213', 'Budapest', 'Király utca 2', 'ne csöngess!', 'ff4e5b8e-d0e0-4248-898a-3cc1f9afffc2', '2026-04-16 20:46:03.326170', 0, 3);

-- --------------------------------------------------------

--
-- Table structure for table `order_items`
--

CREATE TABLE `order_items` (
  `Id` int(11) NOT NULL,
  `ItemPrice` int(11) NOT NULL,
  `Piece` int(11) NOT NULL,
  `Order_Id` int(11) NOT NULL,
  `Item_Id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `order_items`
--

INSERT INTO `order_items` (`Id`, `ItemPrice`, `Piece`, `Order_Id`, `Item_Id`) VALUES
(1, 1150, 3, 1, 9),
(2, 2100, 1, 1, 7),
(3, 3100, 2, 1, 14),
(4, 2450, 1, 1, 16),
(5, 790, 3, 2, 91),
(6, 490, 2, 2, 29),
(7, 890, 2, 2, 89),
(8, 590, 1, 2, 87),
(9, 750, 1, 2, 86),
(10, 1950, 11, 3, 6),
(11, 3100, 1, 3, 14),
(12, 2750, 1, 3, 13),
(13, 3450, 1, 3, 15),
(14, 1150, 1, 3, 9);

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `Id` int(11) NOT NULL,
  `Name` longtext NOT NULL,
  `Description` longtext NOT NULL,
  `Price` int(11) NOT NULL,
  `IsAvailable` tinyint(1) NOT NULL,
  `Image_Url` longtext NOT NULL,
  `CategoryId` int(11) NOT NULL,
  `RegTime` datetime(6) NOT NULL,
  `ModTime` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`Id`, `Name`, `Description`, `Price`, `IsAvailable`, `Image_Url`, `CategoryId`, `RegTime`, `ModTime`) VALUES
(5, 'Mediterrán Bruschetta', 'Pirított ciabatta szeletek, fokhagymás paradicsomraguval és bazsalikommal.', 1690, 1, 'https://cdn.pixabay.com/photo/2020/10/30/18/35/bruschetta-5699486_640.jpg', 3, '2026-03-31 09:51:10.665808', '2026-03-31 09:51:10.665811'),
(6, 'Rántott Mozzarella Rudak', 'Aranybarnára sült sajtos rudak (6 db), fűszeres áfonyalekvárral.', 1950, 1, 'https://cdn.pixabay.com/photo/2019/08/15/10/46/mozzarella-sticks-4407742_1280.jpg', 3, '2026-03-31 09:55:09.456056', '2026-03-31 09:55:09.456058'),
(7, 'Sajtos Quesadilla', 'Tortilla lapok közé zárt olvadt cheddar, jalapeno és tejfölös mártogatós.', 2100, 1, 'https://cdn.pixabay.com/photo/2023/12/02/13/18/quesadilla-8425644_1280.jpg', 3, '2026-03-31 09:58:12.686658', '2026-03-31 09:58:12.686660'),
(8, 'Tárkonyos Csirkeraguleves', 'Tejszínes, citromos raguleves zsenge zöldségekkel és gombával.', 1490, 1, 'https://cdn.pixabay.com/photo/2021/11/08/22/19/semolina-dumpling-soup-6780244_1280.jpg', 4, '2026-03-31 10:21:20.112162', '2026-03-31 10:21:20.112164'),
(9, 'Paradicsomleves (Betűtésztával)', 'Édeskés, sűrű paradicsomleves reszelt sajttal a tetején.', 1150, 1, 'https://cdn.pixabay.com/photo/2021/02/27/10/05/goulash-6054124_1280.jpg', 4, '2026-03-31 10:24:12.732308', '2026-03-31 10:24:12.732349'),
(10, 'Fokhagymakrémleves', 'Selymes krémleves pirított zsemlekockával és füstölt sajttal.', 1290, 1, 'https://cdn.pixabay.com/photo/2019/09/27/09/59/pumpkin-soup-4508015_1280.jpg', 4, '2026-03-31 10:26:23.271592', '2026-03-31 10:26:23.271594'),
(11, 'Margherita', 'Paradicsomszósz, mozzarella sajt, friss bazsalikom.', 2190, 1, 'https://cdn.pixabay.com/photo/2020/10/17/11/06/pizza-5661748_640.jpg', 5, '2026-03-31 10:27:03.611832', '2026-03-31 10:27:03.611835'),
(12, 'Songoku', 'Paradicsomszósz, sonka, gomba, kukorica, mozzarella.', 2590, 1, 'https://cdn.pixabay.com/photo/2020/10/17/11/06/pizza-5661748_640.jpg', 5, '2026-03-31 10:29:28.414722', '2026-03-31 10:29:28.414724'),
(13, 'Magyaros', 'Erős alap, kolbász, bacon, hagyma, hegyes erős paprika, mozzarella.', 2750, 1, 'https://cdn.pixabay.com/photo/2020/10/17/11/06/pizza-5661748_640.jpg', 5, '2026-03-31 10:31:14.679555', '2026-03-31 10:31:14.679557'),
(14, 'Classic Cheeseburger', '180g marhahús, cheddar, csemegeuborka, mustár, ketchup, házi buci.', 3100, 1, 'https://cdn.pixabay.com/photo/2016/01/22/20/23/burger-1156564_640.jpg', 7, '2026-03-31 10:32:54.426848', '2026-03-31 10:32:54.426852'),
(15, 'BBQ Bacon Burger', 'Marhahús, dupla bacon, hagymalekvár, BBQ szósz, cheddar sajt.', 3450, 1, 'https://cdn.pixabay.com/photo/2020/06/24/22/08/spicy-5337836_640.jpg', 7, '2026-03-31 10:33:44.989378', '2026-03-31 10:33:44.989379'),
(16, 'Spaghetti Carbonara', 'Tejszínes-tojásos mártás, pirított bacon, parmezán.', 2450, 1, 'https://cdn.pixabay.com/photo/2018/07/18/19/12/pasta-3547078_1280.jpg', 8, '2026-03-31 11:20:09.506699', '2026-04-15 20:20:30.639469'),
(17, 'Penne Arrabiata', 'Csípős paradicsomszósz, fokhagyma, olívabogyó, friss petrezselyem.', 2250, 1, 'https://cdn.pixabay.com/photo/2022/07/17/14/42/cooking-7327559_1280.jpg', 8, '2026-03-31 11:21:08.805465', '2026-04-15 20:21:11.329815'),
(18, 'Bolognai Lasagne', 'Kemencében sült réteges tészta darált marhahússal és sok sajttal.', 2890, 1, 'https://cdn.pixabay.com/photo/2016/02/04/03/22/lasagne-1178514_1280.jpg', 8, '2026-03-31 11:21:51.273025', '2026-04-15 20:22:28.640505'),
(19, 'BBQ Oldalas', 'Omlós sertésoldalas BBQ mártással, steak burgonyával.', 4200, 1, 'https://cdn.pixabay.com/photo/2015/09/18/15/07/bbq-pork-chops-945766_1280.jpg', 9, '2026-03-31 11:22:35.910330', '2026-04-15 20:33:53.677090'),
(20, 'Grillezett Csirkemell', 'Rozmaringos sült csirke, vegyes zöldsalátával és rizzsel.', 3150, 1, 'https://cdn.pixabay.com/photo/2021/07/22/03/35/chicken-6484332_1280.jpg', 9, '2026-03-31 11:23:31.693772', '2026-04-15 20:34:19.415772'),
(21, 'Cézár Saláta', 'Római saláta, csirkemell, kruton, parmezán, Cézár öntet.', 2650, 1, 'https://cdn.pixabay.com/photo/2016/08/30/00/02/caesar-salad-1629534_640.jpg', 10, '2026-03-31 11:24:29.665756', '2026-03-31 11:24:29.665759'),
(22, 'Görög Saláta', 'Paradicsom, uborka, hagyma, olívabogyó, feta sajt.', 2290, 1, 'https://cdn.pixabay.com/photo/2023/08/08/08/33/vegetables-8176731_1280.jpg', 10, '2026-03-31 11:25:04.670641', '2026-04-15 20:51:20.103280'),
(23, 'Házi Tiramisu', 'Kávés piskóta, mascarpone krém, holland kakaópor.', 1450, 1, 'https://cdn.pixabay.com/photo/2017/03/19/18/22/italian-food-2157243_1280.jpg', 11, '2026-03-31 11:27:10.787352', '2026-04-15 20:54:23.382069'),
(24, 'Coca-Cola (0.5l)', 'Klasszikus szénsavas üdítőital.', 550, 1, 'https://cdn.pixabay.com/photo/2014/09/26/19/51/drink-462776_1280.jpg', 12, '2026-03-31 11:27:49.189843', '2026-04-15 21:04:31.110845'),
(25, 'Fanta Narancs Zero', 'Narancs ízű szénsavmentes üdítőital.', 290, 1, 'https://turulmarket.hu/cdn/shop/files/59969273-Photoroom.png?v=1739488242&width=1500', 12, '2026-03-31 11:29:06.591439', '2026-04-15 21:06:28.922305'),
(26, 'Ásványvíz (0.5l)', 'Szénsavas vagy szénsavmentes természetes ásványvíz.', 400, 1, 'https://cdn.pixabay.com/photo/2020/03/15/17/54/water-4934455_1280.jpg', 12, '2026-03-31 11:30:22.543231', '2026-04-15 21:07:13.396223'),
(28, 'Száraz Vörösbor (0.1l)', 'Villányi minőségi száraz vörösbor.', 500, 1, 'https://cdn.pixabay.com/photo/2015/07/18/13/14/wine-850337_1280.jpg', 13, '2026-03-31 11:32:35.331704', '2026-04-15 21:12:33.193906'),
(29, 'Espresso', 'Erős, rövid feketekávé krémes habbal.', 490, 1, 'https://cdn.pixabay.com/photo/2018/01/31/09/57/coffee-3120750_640.jpg', 14, '2026-03-31 11:33:19.517643', '2026-03-31 11:33:19.517645'),
(30, 'Cappuccino', 'Espresso lágy tejhabbal és kakaóporral.', 650, 1, 'https://cdn.pixabay.com/photo/2015/06/24/01/15/coffee-819362_640.jpg', 14, '2026-03-31 11:33:52.617338', '2026-03-31 11:33:52.617341'),
(31, 'Nachos Sajtszósszal', 'Ropogós kukorica chips olvadt cheddar szósszal és jalapenóval.', 1890, 1, 'https://cdn.pixabay.com/photo/2020/11/14/04/32/nachos-5740734_1280.jpg', 3, '2026-04-15 18:35:22.379821', '2026-04-15 18:35:22.379823'),
(32, 'Csirkeszárnyak (6 db)', 'Fűszeres, ropogós csirkeszárnyak BBQ vagy csípős szósszal.', 2190, 1, 'https://cdn.pixabay.com/photo/2021/02/11/02/44/food-6004081_1280.jpg', 3, '2026-04-15 18:39:14.588745', '2026-04-15 18:39:14.588747'),
(33, 'Hagymakarikák', 'Aranybarnára sült hagymakarikák fokhagymás mártogatóssal.', 1490, 1, 'https://cdn.pixabay.com/photo/2015/04/22/16/07/fried-735004_1280.jpg', 3, '2026-04-15 18:40:11.609854', '2026-04-15 18:40:11.609856'),
(34, 'Rántott Camembert', 'Ropogós bundában sült camembert áfonyalekvárral.', 1990, 1, 'https://cdn.pixabay.com/photo/2021/11/25/08/56/slovakian-cuisine-6822945_1280.jpg', 3, '2026-04-15 18:41:10.623441', '2026-04-15 18:41:10.623443'),
(35, 'Mini Tavaszi Tekercsek', 'Zöldséges töltelékű ropogós tekercsek édes-chili szósszal.', 1790, 1, 'https://cdn.pixabay.com/photo/2021/11/01/15/52/spring-roll-6760871_1280.jpg', 3, '2026-04-15 18:42:08.171155', '2026-04-15 18:42:08.171157'),
(36, 'Jalapeno Poppers', 'Krémes sajttal töltött jalapeno paprikák bundában sütve.', 1990, 1, 'https://cdn.pixabay.com/photo/2019/03/27/14/12/appetizer-4085102_1280.jpg', 3, '2026-04-15 18:43:45.295272', '2026-04-15 18:43:45.319408'),
(37, 'Gulyásleves', 'Hagyományos magyar marhahúsleves zöldségekkel és paprikával.', 1790, 1, 'https://cdn.pixabay.com/photo/2021/02/27/10/05/goulash-6054124_1280.jpg', 4, '2026-04-15 18:44:32.209157', '2026-04-15 18:44:32.209159'),
(38, 'Húsleves Cérnametélttel', 'Klasszikus csirkehúsleves friss zöldségekkel és metélttel.', 1390, 1, 'https://cdn.pixabay.com/photo/2021/11/08/22/19/semolina-dumpling-soup-6780244_1280.jpg', 4, '2026-04-15 18:45:50.456533', '2026-04-16 13:07:53.814391'),
(39, 'Tökleves', 'Krémes tökleves pirított kenyérkockákkal.', 1690, 1, 'https://cdn.pixabay.com/photo/2019/09/27/09/59/pumpkin-soup-4508015_1280.jpg', 4, '2026-04-15 18:46:55.623988', '2026-04-15 18:46:55.623990'),
(40, 'Mexikói Babgulyás', 'Csípős, tartalmas babos-húsos leves mexikói fűszerekkel.', 1890, 1, 'https://cdn.pixabay.com/photo/2021/07/03/09/12/beans-6383380_1280.jpg', 4, '2026-04-15 18:47:41.419981', '2026-04-15 18:47:41.419983'),
(42, 'Quattro Formaggi', 'Mozzarella, gorgonzola, parmezán és edami sajt kombinációja.', 2790, 1, 'https://cdn.pixabay.com/photo/2020/01/27/12/56/cheese-4797173_640.jpg', 5, '2026-04-15 19:03:06.000000', '2026-04-15 19:03:06.000000'),
(43, 'Tonhalas Pizza', 'Tonhal, lilahagyma, paradicsomszósz és mozzarella.', 2690, 1, 'https://cdn.pixabay.com/photo/2020/10/17/11/06/pizza-5661748_640.jpg', 5, '2026-04-15 19:03:06.000000', '2026-04-15 19:03:06.000000'),
(44, 'BBQ Csirkés Pizza', 'Grillezett csirke, BBQ szósz, lilahagyma és sajt.', 2890, 1, 'https://cdn.pixabay.com/photo/2020/10/17/11/06/pizza-5661748_640.jpg', 5, '2026-04-15 19:03:06.000000', '2026-04-15 19:03:06.000000'),
(45, 'Vegetáriánus Pizza', 'Friss zöldségek, paradicsomszósz és mozzarella.', 2590, 1, 'https://cdn.pixabay.com/photo/2020/10/17/11/06/pizza-5661748_640.jpg', 5, '2026-04-15 19:03:06.000000', '2026-04-15 19:03:06.000000'),
(46, 'Pepperoni Pizza', 'Fűszeres pepperoni szalámi, paradicsomszósz, mozzarella.', 2790, 1, 'https://cdn.pixabay.com/photo/2020/04/01/16/34/pepperoni-4991789_640.jpg', 5, '2026-04-15 19:03:06.000000', '2026-04-15 19:03:06.000000'),
(47, 'Chicken Burger', 'Rántott csirkemell, saláta, paradicsom és majonéz.', 2950, 1, 'https://cdn.pixabay.com/photo/2021/07/28/05/57/vegan-6498367_1280.jpg', 7, '2026-04-15 19:03:06.000000', '2026-04-15 19:03:06.000000'),
(48, 'Dupla Sajtos Burger', 'Két marhahús pogácsa, dupla cheddar, hagyma és szószok.', 3790, 1, 'https://cdn.pixabay.com/photo/2022/08/29/17/45/burger-7419421_640.jpg', 7, '2026-04-15 19:03:06.000000', '2026-04-15 19:03:06.000000'),
(49, 'Jalapeno Burger', 'Marhahús, jalapeno, cheddar sajt és csípős szósz.', 3350, 1, 'https://cdn.pixabay.com/photo/2020/10/05/21/30/hamburger-5630800_640.jpg', 7, '2026-04-15 19:03:06.000000', '2026-04-15 19:03:06.000000'),
(50, 'Vega Burger', 'Növényi pogácsa, friss zöldségek és vegán szósz.', 2990, 1, 'https://cdn.pixabay.com/photo/2021/07/28/05/57/vegan-6498367_1280.jpg', 7, '2026-04-15 19:03:06.000000', '2026-04-15 19:03:06.000000'),
(51, 'Extra Spicy Burger', 'Csípős marhahúsos burger jalapenoval és erős szósszal.', 3390, 1, 'https://cdn.pixabay.com/photo/2020/06/24/22/08/spicy-5337836_640.jpg', 7, '2026-04-15 19:03:06.000000', '2026-04-15 19:03:06.000000'),
(52, 'Spaghetti Bolognese', 'Darált marhahúsos paradicsomszósz parmezánnal.', 2390, 1, 'https://cdn.pixabay.com/photo/2021/02/04/12/49/food-5981250_1280.jpg', 8, '2026-04-15 19:03:06.000000', '2026-04-15 20:22:14.358477'),
(53, 'Penne Alfredo', 'Krémes tejszínes szósz parmezánnal és fokhagymával.', 2550, 1, 'https://cdn.pixabay.com/photo/2021/04/06/14/45/pasta-6156595_1280.jpg', 8, '2026-04-15 19:03:06.000000', '2026-04-15 20:24:43.192615'),
(54, 'Gombás Tagliatelle', 'Tejszínes gombás szósz friss tésztával.', 2490, 1, 'https://cdn.pixabay.com/photo/2025/03/06/13/17/pasta-9450866_1280.jpg', 8, '2026-04-15 19:03:06.000000', '2026-04-15 20:25:23.320538'),
(55, 'Tonhalas Penne', 'Tonhalas-paradicsomos szósz olívabogyóval.', 2590, 1, 'https://cdn.pixabay.com/photo/2017/10/01/11/48/pasta-2805186_1280.jpg', 8, '2026-04-15 19:03:06.000000', '2026-04-15 20:27:31.310975'),
(56, 'Pesto Spaghetti', 'Bazsalikomos pesto szósszal és parmezánnal.', 2390, 1, 'https://cdn.pixabay.com/photo/2019/06/19/20/57/pesto-4285663_1280.jpg', 8, '2026-04-15 19:03:06.000000', '2026-04-15 20:30:54.408543'),
(57, 'Sertésszűz Steak', 'Fűszeres sertésszűz steak sült burgonyával.', 3990, 1, 'https://cdn.pixabay.com/photo/2017/03/23/19/57/asparagus-2169305_1280.jpg', 9, '2026-04-15 19:03:06.000000', '2026-04-15 20:34:55.298002'),
(58, 'Grill Tál (2 főre)', 'Válogatott grillezett húsok körettel és salátával.', 6990, 1, 'https://cdn.pixabay.com/photo/2022/05/05/06/05/mix-grill-platter-7175372_1280.jpg', 9, '2026-04-15 19:03:06.000000', '2026-04-15 20:35:21.831760'),
(59, 'Rántott Sertésszelet', 'Klasszikus rántott hús hasábburgonyával.', 2990, 1, 'https://cdn.pixabay.com/photo/2020/07/01/13/28/wiener-schnitzel-5359641_1280.jpg', 9, '2026-04-15 19:03:06.000000', '2026-04-15 19:03:06.000000'),
(60, 'Cordon Bleu', 'Sajttal és sonkával töltött rántott hús.', 3290, 1, 'https://cdn.pixabay.com/photo/2019/10/09/19/47/cordon-4538108_1280.jpg', 9, '2026-04-15 19:03:06.000000', '2026-04-15 20:35:49.027093'),
(61, 'Grillezett Lazac', 'Friss lazacfilé citrommal és zöldségekkel.', 4290, 1, 'https://cdn.pixabay.com/photo/2020/02/09/19/39/fish-4834348_1280.jpg', 9, '2026-04-15 19:03:06.000000', '2026-04-15 20:36:18.298533'),
(62, 'Fűszeres Csirkecomb', 'Sütőben sült csirkecomb fűszeres pácban.', 2890, 1, 'https://cdn.pixabay.com/photo/2021/07/20/16/02/dakbal-6481049_1280.jpg', 9, '2026-04-15 19:03:06.000000', '2026-04-15 20:36:39.767856'),
(63, 'Tonhal Saláta', 'Friss zöldségek tonhallal és citromos öntettel.', 2490, 1, 'https://cdn.pixabay.com/photo/2015/12/11/16/32/salad-1088411_1280.jpg', 10, '2026-04-15 19:03:06.000000', '2026-04-15 20:51:51.190164'),
(64, 'Caprese Saláta', 'Paradicsom, mozzarella, bazsalikom és olívaolaj.', 2190, 1, 'https://cdn.pixabay.com/photo/2018/08/29/09/21/dish-3639491_1280.jpg', 10, '2026-04-15 19:03:06.000000', '2026-04-15 20:52:15.870003'),
(65, 'Csirkés Fitness Saláta', 'Grillezett csirkemell friss salátával és joghurtos öntettel.', 2690, 1, 'https://cdn.pixabay.com/photo/2021/01/10/04/37/salad-5904093_1280.jpg', 10, '2026-04-15 19:03:06.000000', '2026-04-15 19:03:06.000000'),
(66, 'Avokádó Saláta', 'Avokádó, zöldségek és könnyű citromos öntet.', 2790, 1, 'https://cdn.pixabay.com/photo/2015/04/18/11/39/avocado-salad-728612_1280.jpg', 10, '2026-04-15 19:03:06.000000', '2026-04-15 20:53:23.383243'),
(67, 'Kerti Vegyes Saláta', 'Friss szezonális zöldségek balzsamecettel.', 1990, 1, 'https://cdn.pixabay.com/photo/2020/06/17/10/20/salad-5308953_1280.jpg', 10, '2026-04-15 19:03:06.000000', '2026-04-15 20:53:55.192841'),
(68, 'Baconös Cézár', 'Cézár saláta ropogós baconnel és parmezánnal.', 2890, 1, 'https://cdn.pixabay.com/photo/2020/07/01/13/26/caesar-salad-5359635_640.jpg', 10, '2026-04-15 19:03:06.000000', '2026-04-15 19:03:06.000000'),
(69, 'Csokoládé Szuflé', 'Lágy belsejű csokoládé sütemény vanília fagyival.', 1690, 1, 'https://cdn.pixabay.com/photo/2024/01/12/04/09/tiramisu-8503073_1280.jpg', 11, '2026-04-15 19:03:06.000000', '2026-04-15 19:03:06.000000'),
(70, 'Palacsinta (3 db)', 'Nutellás, lekváros vagy túrós töltelékkel.', 1490, 1, 'https://cdn.pixabay.com/photo/2014/12/22/16/50/pancake-577386_1280.jpg', 11, '2026-04-15 19:03:06.000000', '2026-04-15 19:03:06.000000'),
(71, 'Somlói Galuska', 'Piskóta, csokoládé, dió és tejszínhab rétegezve.', 1690, 1, 'https://cdn.pixabay.com/photo/2020/04/01/13/27/dumplings-4991224_1280.jpg', 11, '2026-04-15 19:03:06.000000', '2026-04-15 20:55:00.081114'),
(72, 'Cheesecake', 'Krémes sajttorta gyümölcsöntettel.', 1790, 1, 'https://cdn.pixabay.com/photo/2021/02/06/15/11/blueberry-cheesecake-5988438_640.jpg', 11, '2026-04-15 19:03:06.000000', '2026-04-15 19:03:06.000000'),
(73, 'Brownie Fagyival', 'Csokoládés brownie vanília fagyival.', 1790, 1, 'https://cdn.pixabay.com/photo/2015/03/11/12/42/chocolate-brownies-668624_1280.jpg', 11, '2026-04-15 19:03:06.000000', '2026-04-15 20:56:40.606011'),
(74, 'Gyümölcssaláta', 'Friss szezonális gyümölcsök keveréke.', 1390, 1, 'https://cdn.pixabay.com/photo/2021/01/10/04/37/salad-5904093_1280.jpg', 10, '2026-04-15 19:03:06.000000', '2026-04-15 20:56:03.030361'),
(75, 'Sprite (0.5l)', 'Szénsavas citrom-lime ízű üdítőital.', 550, 1, 'https://www.coca-cola.com/content/dam/onexp/hu/hu/home-image/brands/sprite/new-images/REN2302-00180_BIC_SP_PETBTL_500ml__FR_W_Closed_5449000308719.png/width2674.png', 12, '2026-04-15 19:03:06.000000', '2026-04-15 21:08:55.116405'),
(76, 'Ice Tea (0.5l)', 'Barack vagy citrom ízű frissítő ital.', 490, 1, 'https://cdn.pixabay.com/photo/2021/02/12/00/22/drinks-6006808_1280.jpg', 12, '2026-04-15 19:03:06.000000', '2026-04-15 21:09:25.138636'),
(77, 'Narancslé', '100%-os narancslé.', 650, 1, 'https://cdn.pixabay.com/photo/2016/08/23/15/52/fresh-orange-juice-1614822_1280.jpg', 12, '2026-04-15 19:03:06.000000', '2026-04-15 21:09:44.414119'),
(78, 'Almalé', '100%-os almalé.', 650, 1, 'https://cdn.pixabay.com/photo/2020/07/01/12/28/juice-5359490_1280.jpg', 12, '2026-04-15 19:03:06.000000', '2026-04-15 21:10:50.675723'),
(79, 'Limonádé', 'Friss citromos limonádé jéggel.', 790, 1, 'https://cdn.pixabay.com/photo/2020/06/14/14/44/drink-5298126_1280.jpg', 12, '2026-04-15 19:03:06.000000', '2026-04-15 19:03:06.000000'),
(80, 'Dreher (0.5l)', 'Magyar világos sör.', 750, 1, 'https://cdn.pixabay.com/photo/2018/05/06/08/49/beer-3378136_1280.jpg', 13, '2026-04-15 19:03:06.000000', '2026-04-15 19:03:06.000000'),
(81, 'Borsodi (0.5l)', 'Klasszikus világos sör.', 690, 1, 'https://cdn.pixabay.com/photo/2015/06/24/13/31/beer-820011_1280.jpg', 13, '2026-04-15 19:03:06.000000', '2026-04-15 21:13:16.869903'),
(82, 'Fehérbor (0.1l)', 'Száraz fehérbor könnyed ízvilággal.', 500, 1, 'https://cdn.pixabay.com/photo/2014/08/26/19/19/wine-428316_1280.jpg', 13, '2026-04-15 19:03:06.000000', '2026-04-15 21:13:44.793105'),
(83, 'Rosé (0.1l)', 'Gyümölcsös rosé bor.', 500, 1, 'https://cdn.pixabay.com/photo/2016/07/26/16/16/wine-1543170_640.jpg', 13, '2026-04-15 19:03:06.000000', '2026-04-15 19:03:06.000000'),
(84, 'Fröccs (0.3l)', 'Bor és szóda frissítő keveréke.', 600, 1, 'https://cdn.pixabay.com/photo/2018/08/15/15/53/cocktail-3608357_1280.jpg', 13, '2026-04-15 19:03:06.000000', '2026-04-15 21:14:32.216096'),
(85, 'Aperol Spritz', 'Narancsos koktél proseccóval és szódával.', 1890, 1, 'https://cdn.pixabay.com/photo/2014/03/30/13/31/aperol-spritz-301434_1280.jpg', 13, '2026-04-15 19:03:06.000000', '2026-04-15 21:14:56.915649'),
(86, 'Latte', 'Espresso sok tejjel és lágy tejhabbal.', 750, 1, 'https://cdn.pixabay.com/photo/2018/01/31/09/57/coffee-3120750_640.jpg', 14, '2026-04-15 19:03:06.000000', '2026-04-15 19:03:06.000000'),
(87, 'Americano', 'Hosszabb, hígabb feketekávé.', 590, 1, 'https://cdn.pixabay.com/photo/2015/06/24/01/15/coffee-819362_640.jpg', 14, '2026-04-15 19:03:06.000000', '2026-04-15 19:03:06.000000'),
(88, 'Flat White', 'Erősebb kávé selymes tejhabbal.', 790, 1, 'https://cdn.pixabay.com/photo/2017/09/04/18/39/coffee-2714970_1280.jpg', 14, '2026-04-15 19:03:06.000000', '2026-04-15 19:03:06.000000'),
(89, 'Jegeskávé', 'Hideg kávé jéggel és tejjel.', 890, 1, 'https://cdn.pixabay.com/photo/2017/09/04/18/39/coffee-2714970_1280.jpg', 14, '2026-04-15 19:03:06.000000', '2026-04-15 19:03:06.000000'),
(90, 'Forró Tea', 'Fekete, zöld vagy gyümölcs tea.', 550, 1, 'https://cdn.pixabay.com/photo/2018/03/01/09/51/tea-3190241_1280.jpg', 14, '2026-04-15 19:03:06.000000', '2026-04-15 19:03:06.000000'),
(91, 'Chai Latte', 'Fűszeres tejes ital indiai stílusban.', 790, 1, 'https://cdn.pixabay.com/photo/2016/09/21/22/00/tea-1685847_640.jpg', 14, '2026-04-15 19:03:06.000000', '2026-04-15 19:03:06.000000'),
(92, 'Heineken (0.5l)', 'Világos sör üvegben.', 850, 1, 'https://cdn.pixabay.com/photo/2020/05/20/11/38/beverage-5196021_1280.jpg', 13, '2026-04-15 19:00:32.556636', '2026-04-15 21:03:57.967324'),
(93, 'Prosciutto Pizza', 'Paradicsomszósz, sonka, mozzarella.', 2590, 1, 'https://cdn.pixabay.com/photo/2020/01/27/12/56/cheese-4797173_640.jpg', 5, '2026-04-15 19:05:15.000000', '2026-04-15 19:05:15.000000'),
(94, 'Funghi Pizza', 'Paradicsomszósz, gomba, mozzarella.', 2490, 1, 'https://cdn.pixabay.com/photo/2022/07/23/21/51/pizza-7340648_640.jpg', 5, '2026-04-15 19:05:15.000000', '2026-04-15 19:05:15.000000'),
(95, 'Capricciosa Pizza', 'Sonka, gomba, articsóka, olívabogyó.', 2790, 1, 'https://cdn.pixabay.com/photo/2022/06/04/03/41/pizza-7241179_640.jpg', 5, '2026-04-15 19:05:15.000000', '2026-04-15 19:05:15.000000'),
(96, 'Diavola Pizza', 'Csípős szalámi, chili, mozzarella.', 2790, 1, 'https://cdn.pixabay.com/photo/2020/04/01/16/34/pepperoni-4991789_640.jpg', 5, '2026-04-15 19:05:15.000000', '2026-04-15 19:05:15.000000'),
(97, 'Quattro Stagioni', 'Négyféle feltét: sonka, gomba, articsóka, olívabogyó.', 2890, 1, 'https://cdn.pixabay.com/photo/2022/06/04/03/41/pizza-7241179_640.jpg', 5, '2026-04-15 19:05:15.000000', '2026-04-15 19:05:15.000000'),
(98, 'Mexikói Pizza', 'Darált hús, kukorica, jalapeno, csípős szósz.', 2890, 1, 'https://cdn.pixabay.com/photo/2020/10/17/11/06/pizza-5661748_640.jpg', 5, '2026-04-15 19:05:15.000000', '2026-04-15 19:05:15.000000'),
(99, 'BBQ Marhahúsos Pizza', 'Marhahús, BBQ szósz, hagyma, mozzarella.', 2990, 1, 'https://cdn.pixabay.com/photo/2022/06/04/03/41/pizza-7241179_640.jpg', 5, '2026-04-15 19:05:15.000000', '2026-04-15 19:05:15.000000'),
(100, 'Tenger Gyümölcsei Pizza', 'Rák, tintahal, fokhagyma, paradicsomszósz.', 3290, 1, 'https://cdn.pixabay.com/photo/2017/08/06/06/43/pizza-2589575_640.jpg', 5, '2026-04-15 19:05:15.000000', '2026-04-15 19:05:15.000000'),
(101, 'Szalámis Pizza', 'Szalámi, paradicsomszósz, mozzarella.', 2690, 1, 'https://cdn.pixabay.com/photo/2020/04/01/16/34/pepperoni-4991789_640.jpg', 5, '2026-04-15 19:05:15.000000', '2026-04-15 19:05:15.000000'),
(102, 'Húsimádó Pizza', 'Sonka, bacon, kolbász, szalámi.', 3090, 1, 'https://cdn.pixabay.com/photo/2020/10/17/11/06/pizza-5661748_640.jpg', 5, '2026-04-15 19:05:15.000000', '2026-04-15 19:05:15.000000'),
(103, 'Spenótos Pizza', 'Spenót, fokhagyma, mozzarella.', 2590, 1, 'https://cdn.pixabay.com/photo/2014/05/18/11/25/pizza-346985_1280.jpg', 5, '2026-04-15 19:05:15.000000', '2026-04-15 19:05:15.000000'),
(104, 'Gorgonzolás Pizza', 'Gorgonzola, dió, mozzarella.', 2890, 1, 'https://cdn.pixabay.com/photo/2014/05/28/11/38/pizza-356412_640.jpg', 5, '2026-04-15 19:05:15.000000', '2026-04-15 19:05:15.000000'),
(105, 'Csirkés-Kukoricás Pizza', 'Csirke, kukorica, mozzarella.', 2690, 1, 'https://cdn.pixabay.com/photo/2017/12/10/14/47/pizza-3010062_640.jpg', 5, '2026-04-15 19:05:15.000000', '2026-04-15 19:05:15.000000'),
(106, 'Tojásos Pizza', 'Sonka, tojás, mozzarella.', 2590, 1, 'https://cdn.pixabay.com/photo/2017/12/10/14/47/pizza-3010062_640.jpg', 5, '2026-04-15 19:05:15.000000', '2026-04-15 19:05:15.000000'),
(107, 'Kolbászos Pizza', 'Magyar kolbász, hagyma, paprika.', 2790, 1, 'https://cdn.pixabay.com/photo/2021/07/26/19/57/pizza-6495112_640.jpg', 5, '2026-04-15 19:05:15.000000', '2026-04-15 19:05:15.000000'),
(108, 'Erdei Gombás Pizza', 'Vegyes erdei gombák, fokhagyma.', 2790, 1, 'https://cdn.pixabay.com/photo/2022/07/23/21/51/pizza-7340648_640.jpg', 5, '2026-04-15 19:05:15.000000', '2026-04-15 19:05:15.000000'),
(109, 'Ricottás Pizza', 'Ricotta, spenót, mozzarella.', 2690, 1, 'https://cdn.pixabay.com/photo/2014/10/08/21/34/vegetable-pizza-480794_640.jpg', 5, '2026-04-15 19:05:15.000000', '2026-04-15 19:05:15.000000'),
(110, 'Sajtkrémes Pizza', 'Krémes sajtszósz, cheddar, mozzarella.', 2790, 1, 'https://cdn.pixabay.com/photo/2020/01/27/12/56/cheese-4797173_640.jpg', 5, '2026-04-15 19:05:15.000000', '2026-04-15 19:05:15.000000'),
(111, 'Sonkás-Kukoricás Pizza', 'Sonka, kukorica, mozzarella.', 2590, 1, 'https://cdn.pixabay.com/photo/2017/12/10/14/47/pizza-3010062_640.jpg', 5, '2026-04-15 19:05:15.000000', '2026-04-15 19:05:15.000000'),
(112, 'Baconös Pizza', 'Bacon, hagyma, BBQ szósz.', 2890, 1, 'https://cdn.pixabay.com/photo/2022/06/04/03/41/pizza-7241179_640.jpg', 5, '2026-04-15 19:05:15.000000', '2026-04-15 19:05:15.000000'),
(113, 'Kecskesajtos Pizza', 'Kecskesajt, méz, dió.', 3090, 1, 'https://cdn.pixabay.com/photo/2014/05/28/11/38/pizza-356412_640.jpg', 5, '2026-04-15 19:05:15.000000', '2026-04-15 19:05:15.000000'),
(114, 'Triplasajtos Pizza', 'Mozzarella, cheddar, parmezán.', 2790, 1, 'https://cdn.pixabay.com/photo/2020/01/27/12/56/cheese-4797173_640.jpg', 5, '2026-04-15 19:05:15.000000', '2026-04-15 19:05:15.000000'),
(115, 'Zöldséges Deluxe Pizza', 'Cukkini, padlizsán, paprika.', 2690, 1, 'https://cdn.pixabay.com/photo/2019/10/06/03/52/vegetarisch-4529225_640.jpg', 5, '2026-04-15 19:05:15.000000', '2026-04-15 19:05:15.000000'),
(116, 'BBQ Bacon Pizza', 'Bacon, BBQ szósz, hagyma, mozzarella.', 2990, 1, 'https://cdn.pixabay.com/photo/2020/10/17/11/06/pizza-5661748_640.jpg', 5, '2026-04-15 19:05:15.000000', '2026-04-15 19:05:15.000000'),
(117, 'Hawaii Pizza', 'Paradicsomszósz, sonka, ananász, mozzarella sajt.', 2490, 1, 'https://cdn.pixabay.com/photo/2020/08/19/14/43/pizza-5501073_1280.jpg', 5, '2026-04-15 19:09:52.579892', '2026-04-15 19:09:52.579894');

-- --------------------------------------------------------

--
-- Table structure for table `restaurants`
--

CREATE TABLE `restaurants` (
  `Id` int(11) NOT NULL,
  `Name` longtext NOT NULL,
  `Description` longtext NOT NULL,
  `ImageUrl` longtext NOT NULL,
  `OpeningHours` longtext NOT NULL,
  `Address` longtext NOT NULL,
  `ContactPhone` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `restaurants`
--

INSERT INTO `restaurants` (`Id`, `Name`, `Description`, `ImageUrl`, `OpeningHours`, `Address`, `ContactPhone`) VALUES
(2, 'Pizzarena Miskolc Central', 'A hálózat első és legnagyobb étterme, ahol minden kezdődött. Modern, indusztriális belső tér, látványkonyha fatüzelésű kemencével és hangulatos terasz a sétálóutca szívében. Ideális családi vacsorákhoz és nagyobb baráti társaságoknak.', 'https://images.unsplash.com/photo-1578474846511-04ba529f0b88?q=80&w=687&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', '11:00 - 22:00', '3525 Miskolc, Városház tér 8.', '+36702891737'),
(3, 'Pizzarena Budapest - Gozsdu Courtyard', 'A fővárosi pörgés központjában várunk! Itt a gyorsaságon és a prémium minőségen van a hangsúly. Tökéletes választás egy gyors ebédre a munka szünetében, vagy alapozásként a budapesti éjszaka előtt. Itt a Séf ajánlatai mellett \"slice bar\" (szelet bár) is üzemel.', 'https://plus.unsplash.com/premium_photo-1670984939096-f3cfd48c7408?q=80&w=687&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', '10:00-23:00', '1075 Budapest, Király utca 13.', ''),
(4, 'Pizzarena Siófok Marina', 'Közvetlenül a Balaton-parton, a vitorláskikötő mellett! Ez az egységünk a \"Beach-Vibe\" jegyében született: világos, fapadlós terasz, kényelmes babzsákfotelek és koktélbár. Itt a Séf ajánlatai mellett kifejezetten könnyű, nyári salátákat és hideg olasz desszerteket is kínálunk a strandolók számára.', 'https://images.unsplash.com/photo-1551632436-cbf8dd35adfa?q=80&w=1471&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', '9:00-19:00', '8600 Siófok, Petőfi sétány 3.', '');

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20260126150809_User', '8.0.23'),
('20260126182018_AllModelsCreated', '8.0.23'),
('20260126182303_AllModelsCreated2', '8.0.23'),
('20260317081749_RestaurantNameToContactEmail', '8.0.23'),
('20260403152340_OrderStatusEsRestaurantContactPhone', '8.0.23'),
('20260403160538_AddRestaurantPlaceToOrder', '8.0.23');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`);

--
-- Indexes for table `aspnetroles`
--
ALTER TABLE `aspnetroles`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `RoleNameIndex` (`NormalizedName`);

--
-- Indexes for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetUserClaims_UserId` (`UserId`);

--
-- Indexes for table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  ADD KEY `IX_AspNetUserLogins_UserId` (`UserId`);

--
-- Indexes for table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `IX_AspNetUserRoles_RoleId` (`RoleId`);

--
-- Indexes for table `aspnetusers`
--
ALTER TABLE `aspnetusers`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  ADD KEY `EmailIndex` (`NormalizedEmail`);

--
-- Indexes for table `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD PRIMARY KEY (`UserId`,`LoginProvider`,`Name`);

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `chefspecials`
--
ALTER TABLE `chefspecials`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_chefSpecials_ProductId` (`ProductId`);

--
-- Indexes for table `globalsettings`
--
ALTER TABLE `globalsettings`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_orders_User_Id` (`User_Id`),
  ADD KEY `IX_orders_RestaurantId` (`RestaurantId`);

--
-- Indexes for table `order_items`
--
ALTER TABLE `order_items`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_order_items_Item_Id` (`Item_Id`),
  ADD KEY `IX_order_items_Order_Id` (`Order_Id`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_products_CategoryId` (`CategoryId`);

--
-- Indexes for table `restaurants`
--
ALTER TABLE `restaurants`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `categories`
--
ALTER TABLE `categories`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `chefspecials`
--
ALTER TABLE `chefspecials`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `globalsettings`
--
ALTER TABLE `globalsettings`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `orders`
--
ALTER TABLE `orders`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `order_items`
--
ALTER TABLE `order_items`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=118;

--
-- AUTO_INCREMENT for table `restaurants`
--
ALTER TABLE `restaurants`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `chefspecials`
--
ALTER TABLE `chefspecials`
  ADD CONSTRAINT `FK_chefSpecials_products_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `products` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `FK_orders_AspNetUsers_User_Id` FOREIGN KEY (`User_Id`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_orders_restaurants_RestaurantId` FOREIGN KEY (`RestaurantId`) REFERENCES `restaurants` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `order_items`
--
ALTER TABLE `order_items`
  ADD CONSTRAINT `FK_order_items_orders_Order_Id` FOREIGN KEY (`Order_Id`) REFERENCES `orders` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_order_items_products_Item_Id` FOREIGN KEY (`Item_Id`) REFERENCES `products` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `products`
--
ALTER TABLE `products`
  ADD CONSTRAINT `FK_products_categories_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `categories` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
