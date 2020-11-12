-- phpMyAdmin SQL Dump
-- version 4.6.6
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:50980
-- Generation Time: Nov 12, 2020 at 03:00 PM
-- Server version: 5.7.9
-- PHP Version: 5.6.40

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `localdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `area`
--

CREATE TABLE `area` (
  `id` int(11) NOT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  `estado` bit(1) DEFAULT b'1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `area`
--

INSERT INTO `area` (`id`, `nombre`, `estado`) VALUES
(1, 'Sangrado', b'1'),
(2, 'Problemas respiratorios', b'1'),
(3, 'Cambios en el estado mental', b'1'),
(4, 'Dolor torácico', b'1'),
(5, 'Asfixia', b'1'),
(6, 'Expectoración o vómito con sangre', b'1'),
(7, 'Desmayo o pérdida del conocimiento', b'1');

-- --------------------------------------------------------

--
-- Table structure for table `empleado`
--

CREATE TABLE `empleado` (
  `id_empleado` int(11) NOT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  `ap_paterno` varchar(50) DEFAULT NULL,
  `ap_materno` varchar(50) DEFAULT NULL,
  `correo` varchar(50) DEFAULT NULL,
  `num_cel` int(11) DEFAULT NULL,
  `num_cuenta` varchar(18) DEFAULT NULL,
  `Direccion` text
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `empleado`
--

INSERT INTO `empleado` (`id_empleado`, `nombre`, `ap_paterno`, `ap_materno`, `correo`, `num_cel`, `num_cuenta`, `Direccion`) VALUES
(1, 'Obed', 'Martinez', 'Gonzalez', 'obednoe22@gmail.com', NULL, NULL, NULL),
(2, 'Alfredo', 'Mendez', 'asddasad', 'alfredo@gmail.com', NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `login`
--

CREATE TABLE `login` (
  `id` int(11) NOT NULL,
  `nombre_usuario` varchar(50) DEFAULT NULL,
  `password` varchar(250) DEFAULT NULL,
  `id_empleado` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `login`
--

INSERT INTO `login` (`id`, `nombre_usuario`, `password`, `id_empleado`) VALUES
(1, 'obednoe22@gmail.com', 'CAEDAAB50360270FC6DD9E002F0604F251EA0BBF0EECFF7CB8DFA0E6990899A5', 1),
(2, 'alfredo@gmail.com', 'ce2a31e87fa7fe7f28fc8783f19f9da3b84a0552066a11d213fad29994039f7d', 2);

-- --------------------------------------------------------

--
-- Table structure for table `queja`
--

CREATE TABLE `queja` (
  `id` int(11) NOT NULL,
  `id_cita` int(11) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `id_tipo_queja` int(11) DEFAULT NULL,
  `descripcion` text,
  `token` varchar(255) DEFAULT NULL,
  `estado` bit(1) DEFAULT b'1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `queja`
--

INSERT INTO `queja` (`id`, `id_cita`, `email`, `id_tipo_queja`, `descripcion`, `token`, `estado`) VALUES
(1, 2, 'obednoe22@gmail.com', 1, 'dssadadsdsadsadsadsaddddddddddddddddddddddddddd', '1643e1c2c7e340724a2c7e4c92e91a89cda797690634f8aa2ad399290de2bebc', b'1'),
(2, 2, 'coco_ulises@hotmail.com', 3, 'son groseras UnU xDDDDDDDDDDDD', 'b01640cc75546066907911478f2f77e895d1615a8624ca457724bbc811070195', b'1');

-- --------------------------------------------------------

--
-- Table structure for table `queja_empleado`
--

CREATE TABLE `queja_empleado` (
  `id` int(11) NOT NULL,
  `id_queja` int(11) DEFAULT NULL,
  `id_empleado` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `sugerencia`
--

CREATE TABLE `sugerencia` (
  `id` int(11) NOT NULL,
  `email` varchar(50) DEFAULT NULL,
  `descripcion` text,
  `token` varchar(255) DEFAULT NULL,
  `estado` bit(1) DEFAULT b'1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `sugerencia`
--

INSERT INTO `sugerencia` (`id`, `email`, `descripcion`, `token`, `estado`) VALUES
(1, 'coco_ulises@hotmail.com', 'son ustedes jajajajaja xDDDDDDDDDDD', '08423c54a9aa9037f2bbb2f0aff08575fb2ba99601fe52b3c45a434827faa248', b'1');

-- --------------------------------------------------------

--
-- Table structure for table `sugerencia_empleado`
--

CREATE TABLE `sugerencia_empleado` (
  `id` int(11) NOT NULL,
  `id_sugerencia` int(11) DEFAULT NULL,
  `id_empleado` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tipo_queja`
--

CREATE TABLE `tipo_queja` (
  `id` int(11) NOT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  `estado` bit(1) DEFAULT b'1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tipo_queja`
--

INSERT INTO `tipo_queja` (`id`, `nombre`, `estado`) VALUES
(1, 'Administrativa', b'1'),
(2, 'Catering', b'1'),
(3, 'Enfermería', b'1'),
(4, 'Intendencia ', b'1'),
(5, 'Seguridad', b'1'),
(6, 'Laboratorio clínico ', b'1'),
(7, 'Farmacia', b'1'),
(8, 'Recepción', b'1'),
(9, 'Sistemas', b'1'),
(10, 'Rayos X ', b'1'),
(11, 'Archivo', b'1'),
(12, 'Medicina Preventiva ', b'1'),
(13, 'Áreas médicas ', b'1'),
(14, 'Urgencias', b'1'),
(15, 'Medicina general', b'1');

-- --------------------------------------------------------

--
-- Table structure for table `urgencia`
--

CREATE TABLE `urgencia` (
  `id` int(11) NOT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  `ap_paterno` varchar(50) DEFAULT NULL,
  `ap_materno` varchar(50) DEFAULT NULL,
  `telefono` int(11) DEFAULT NULL,
  `telefonoF` int(11) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `fecha_nac` date DEFAULT NULL,
  `nss` int(11) DEFAULT NULL,
  `descripcion` text,
  `token` varchar(255) DEFAULT NULL,
  `atendido` bit(1) NOT NULL DEFAULT b'1',
  `estado` bit(1) NOT NULL DEFAULT b'1',
  `id_area` int(11) DEFAULT NULL,
  `fechaCita` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `urgencia`
--

INSERT INTO `urgencia` (`id`, `nombre`, `ap_paterno`, `ap_materno`, `telefono`, `telefonoF`, `email`, `fecha_nac`, `nss`, `descripcion`, `token`, `atendido`, `estado`, `id_area`, `fechaCita`) VALUES
(1, 'Obed Noe', 'Gonzalez', 'dasasassa', 123456778, NULL, 'obednoe22@gmail.com', '2020-11-01', 123456, 'adssadadssaddasdsadasddsa', '7ea750e7c4fb70dcf699f5ead410c40066e4111121e9b9e9f6687f9aec1a3e4d', b'1', b'1', 1, '2020-11-19'),
(2, 'ulises', 'Manriquez ', 'Romero ', 1234567861, 1234567891, 'coco_ulises@hotmail.com', '1995-04-19', 12543678, 'suele ser explosivo con sus compañeros', 'ab90fcef43fe43dce16f5baf45572cbaa00bf7ca132927e44e6eaa6c5f87fb18', b'1', b'1', 3, '2020-11-16');

-- --------------------------------------------------------

--
-- Table structure for table `urgencias_empleado`
--

CREATE TABLE `urgencias_empleado` (
  `id` int(11) NOT NULL,
  `id_urgencia` int(11) DEFAULT NULL,
  `id_empleado` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `area`
--
ALTER TABLE `area`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `empleado`
--
ALTER TABLE `empleado`
  ADD PRIMARY KEY (`id_empleado`);

--
-- Indexes for table `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`id`),
  ADD KEY `login_empleado` (`id_empleado`);

--
-- Indexes for table `queja`
--
ALTER TABLE `queja`
  ADD PRIMARY KEY (`id`),
  ADD KEY `queja_tipo` (`id_tipo_queja`),
  ADD KEY `queja_urgencia` (`id_cita`);

--
-- Indexes for table `queja_empleado`
--
ALTER TABLE `queja_empleado`
  ADD PRIMARY KEY (`id`),
  ADD KEY `queja_empleado_empleado` (`id_empleado`),
  ADD KEY `queja_empleado_queja` (`id_queja`);

--
-- Indexes for table `sugerencia`
--
ALTER TABLE `sugerencia`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `sugerencia_empleado`
--
ALTER TABLE `sugerencia_empleado`
  ADD PRIMARY KEY (`id`),
  ADD KEY `sugerencia_empleado_empleado` (`id_empleado`),
  ADD KEY `sugerencia_empleado_sugerencia` (`id_sugerencia`);

--
-- Indexes for table `tipo_queja`
--
ALTER TABLE `tipo_queja`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `urgencia`
--
ALTER TABLE `urgencia`
  ADD PRIMARY KEY (`id`),
  ADD KEY `urgencia_area` (`id_area`);

--
-- Indexes for table `urgencias_empleado`
--
ALTER TABLE `urgencias_empleado`
  ADD PRIMARY KEY (`id`),
  ADD KEY `tabla_empleado` (`id_empleado`),
  ADD KEY `tabla_urgencia` (`id_urgencia`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `area`
--
ALTER TABLE `area`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT for table `empleado`
--
ALTER TABLE `empleado`
  MODIFY `id_empleado` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `login`
--
ALTER TABLE `login`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `queja`
--
ALTER TABLE `queja`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `queja_empleado`
--
ALTER TABLE `queja_empleado`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `sugerencia`
--
ALTER TABLE `sugerencia`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `sugerencia_empleado`
--
ALTER TABLE `sugerencia_empleado`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `tipo_queja`
--
ALTER TABLE `tipo_queja`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;
--
-- AUTO_INCREMENT for table `urgencia`
--
ALTER TABLE `urgencia`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `urgencias_empleado`
--
ALTER TABLE `urgencias_empleado`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `login`
--
ALTER TABLE `login`
  ADD CONSTRAINT `login_empleado` FOREIGN KEY (`id_empleado`) REFERENCES `empleado` (`id_empleado`);

--
-- Constraints for table `queja`
--
ALTER TABLE `queja`
  ADD CONSTRAINT `queja_tipo` FOREIGN KEY (`id_tipo_queja`) REFERENCES `tipo_queja` (`id`),
  ADD CONSTRAINT `queja_urgencia` FOREIGN KEY (`id_cita`) REFERENCES `urgencia` (`id`);

--
-- Constraints for table `queja_empleado`
--
ALTER TABLE `queja_empleado`
  ADD CONSTRAINT `queja_empleado_empleado` FOREIGN KEY (`id_empleado`) REFERENCES `empleado` (`id_empleado`),
  ADD CONSTRAINT `queja_empleado_queja` FOREIGN KEY (`id_queja`) REFERENCES `queja` (`id`);

--
-- Constraints for table `sugerencia_empleado`
--
ALTER TABLE `sugerencia_empleado`
  ADD CONSTRAINT `sugerencia_empleado_empleado` FOREIGN KEY (`id_empleado`) REFERENCES `empleado` (`id_empleado`),
  ADD CONSTRAINT `sugerencia_empleado_sugerencia` FOREIGN KEY (`id_sugerencia`) REFERENCES `sugerencia` (`id`);

--
-- Constraints for table `urgencia`
--
ALTER TABLE `urgencia`
  ADD CONSTRAINT `urgencia_area` FOREIGN KEY (`id_area`) REFERENCES `area` (`id`);

--
-- Constraints for table `urgencias_empleado`
--
ALTER TABLE `urgencias_empleado`
  ADD CONSTRAINT `tabla_empleado` FOREIGN KEY (`id_empleado`) REFERENCES `empleado` (`id_empleado`),
  ADD CONSTRAINT `tabla_urgencia` FOREIGN KEY (`id_urgencia`) REFERENCES `urgencia` (`id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
