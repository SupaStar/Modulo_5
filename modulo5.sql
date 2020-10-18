-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 18-10-2020 a las 23:57:43
-- Versión del servidor: 10.3.16-MariaDB
-- Versión de PHP: 7.3.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `modulo5`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `area`
--

CREATE TABLE `area` (
  `id` int(11) NOT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  `estado` bit(1) DEFAULT b'1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `area`
--

INSERT INTO `area` (`id`, `nombre`, `estado`) VALUES
(1, 'Prueba1', b'1');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empleado`
--

CREATE TABLE `empleado` (
  `id_empleado` int(11) NOT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  `ap_paterno` varchar(50) DEFAULT NULL,
  `ap_materno` varchar(50) DEFAULT NULL,
  `correo` varchar(50) DEFAULT NULL,
  `num_cel` int(11) DEFAULT NULL,
  `num_cuenta` varchar(18) DEFAULT NULL,
  `Direccion` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `empleado`
--

INSERT INTO `empleado` (`id_empleado`, `nombre`, `ap_paterno`, `ap_materno`, `correo`, `num_cel`, `num_cuenta`, `Direccion`) VALUES
(1, 'Prueba1', 'asasdsa', 'asddasad', 'prueba@gmail.com', 123131, '12331231', 'saasddsa');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `login`
--

CREATE TABLE `login` (
  `id` int(11) NOT NULL,
  `nombre_usuario` varchar(50) DEFAULT NULL,
  `password` varchar(250) DEFAULT NULL,
  `id_empleado` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `login`
--

INSERT INTO `login` (`id`, `nombre_usuario`, `password`, `id_empleado`) VALUES
(1, 'obednoe22@gmail.com', 'caedaab50360270fc6dd9e002f0604f251ea0bbf0eecff7cb8dfa0e6990899a5', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `queja`
--

CREATE TABLE `queja` (
  `id` int(11) NOT NULL,
  `id_cita` int(11) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `id_tipo_queja` int(11) DEFAULT NULL,
  `descripcion` text DEFAULT NULL,
  `token` varchar(255) DEFAULT NULL,
  `estado` bit(1) DEFAULT b'1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `queja_empleado`
--

CREATE TABLE `queja_empleado` (
  `id` int(11) NOT NULL,
  `id_queja` int(11) DEFAULT NULL,
  `id_empleado` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sugerencia`
--

CREATE TABLE `sugerencia` (
  `id` int(11) NOT NULL,
  `email` varchar(50) DEFAULT NULL,
  `descripcion` text DEFAULT NULL,
  `token` varchar(255) DEFAULT NULL,
  `estado` bit(1) DEFAULT b'1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sugerencia_empleado`
--

CREATE TABLE `sugerencia_empleado` (
  `id` int(11) NOT NULL,
  `id_sugerencia` int(11) DEFAULT NULL,
  `id_empleado` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipo_queja`
--

CREATE TABLE `tipo_queja` (
  `id` int(11) NOT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  `estado` bit(1) DEFAULT b'1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `urgencia`
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
  `descripcion` text DEFAULT NULL,
  `token` varchar(255) DEFAULT NULL,
  `atendido` bit(1) NOT NULL DEFAULT b'1',
  `estado` bit(1) NOT NULL DEFAULT b'1',
  `id_area` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `urgencia`
--

INSERT INTO `urgencia` (`id`, `nombre`, `ap_paterno`, `ap_materno`, `telefono`, `telefonoF`, `email`, `fecha_nac`, `nss`, `descripcion`, `token`, `atendido`, `estado`, `id_area`) VALUES
(1, 'Obed Noe', 'Gonzalez', 'dasasassa', 2147483647, 2147483647, 'obednoe22@gmail.com', '2020-10-20', 12345678, 'aaaaaaaaa', NULL, b'1', b'0', 1),
(2, 'Obed Noe', 'Gonzalez', 'dasasassa', 2147483647, 2147483647, 'obednoe22@gmail.com', '2020-10-20', 12345678, 'AAAAAAAA', 'fe184bb51a88349b753fc06099d997d7c0c6ed15525410d6594109cfb8976152', b'1', b'1', 1),
(3, 'Obed Noe', 'Gonzalez', 'dasasassa', 2147483647, 2147483647, 'obednoe22@gmail.com', '2020-10-20', 45648789, 'aaaaaaaaaa', '65d9f3379df36b6e530d770545b117287327a090a7848c76c6fd069506731ee4', b'1', b'1', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `urgencias_empleado`
--

CREATE TABLE `urgencias_empleado` (
  `id` int(11) NOT NULL,
  `id_urgencia` int(11) DEFAULT NULL,
  `id_empleado` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `area`
--
ALTER TABLE `area`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `empleado`
--
ALTER TABLE `empleado`
  ADD PRIMARY KEY (`id_empleado`);

--
-- Indices de la tabla `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`id`),
  ADD KEY `login_empleado` (`id_empleado`);

--
-- Indices de la tabla `queja`
--
ALTER TABLE `queja`
  ADD PRIMARY KEY (`id`),
  ADD KEY `queja_urgencia` (`id_cita`),
  ADD KEY `queja_tipo` (`id_tipo_queja`);

--
-- Indices de la tabla `queja_empleado`
--
ALTER TABLE `queja_empleado`
  ADD PRIMARY KEY (`id`),
  ADD KEY `queja_empleado_empleado` (`id_empleado`),
  ADD KEY `queja_empleado_queja` (`id_queja`);

--
-- Indices de la tabla `sugerencia`
--
ALTER TABLE `sugerencia`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `sugerencia_empleado`
--
ALTER TABLE `sugerencia_empleado`
  ADD PRIMARY KEY (`id`),
  ADD KEY `sugerencia_empleado_empleado` (`id_empleado`),
  ADD KEY `sugerencia_empleado_sugerencia` (`id_sugerencia`);

--
-- Indices de la tabla `tipo_queja`
--
ALTER TABLE `tipo_queja`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `urgencia`
--
ALTER TABLE `urgencia`
  ADD PRIMARY KEY (`id`),
  ADD KEY `urgencia_area` (`id_area`);

--
-- Indices de la tabla `urgencias_empleado`
--
ALTER TABLE `urgencias_empleado`
  ADD PRIMARY KEY (`id`),
  ADD KEY `tabla_empleado` (`id_empleado`),
  ADD KEY `tabla_urgencia` (`id_urgencia`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `area`
--
ALTER TABLE `area`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `empleado`
--
ALTER TABLE `empleado`
  MODIFY `id_empleado` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `login`
--
ALTER TABLE `login`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `queja`
--
ALTER TABLE `queja`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `queja_empleado`
--
ALTER TABLE `queja_empleado`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `sugerencia`
--
ALTER TABLE `sugerencia`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `sugerencia_empleado`
--
ALTER TABLE `sugerencia_empleado`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tipo_queja`
--
ALTER TABLE `tipo_queja`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `urgencia`
--
ALTER TABLE `urgencia`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `urgencias_empleado`
--
ALTER TABLE `urgencias_empleado`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `login`
--
ALTER TABLE `login`
  ADD CONSTRAINT `login_empleado` FOREIGN KEY (`id_empleado`) REFERENCES `empleado` (`id_empleado`);

--
-- Filtros para la tabla `queja`
--
ALTER TABLE `queja`
  ADD CONSTRAINT `queja_tipo` FOREIGN KEY (`id_tipo_queja`) REFERENCES `tipo_queja` (`id`),
  ADD CONSTRAINT `queja_urgencia` FOREIGN KEY (`id_cita`) REFERENCES `urgencia` (`id`);

--
-- Filtros para la tabla `queja_empleado`
--
ALTER TABLE `queja_empleado`
  ADD CONSTRAINT `queja_empleado_empleado` FOREIGN KEY (`id_empleado`) REFERENCES `empleado` (`id_empleado`),
  ADD CONSTRAINT `queja_empleado_queja` FOREIGN KEY (`id_queja`) REFERENCES `queja` (`id`);

--
-- Filtros para la tabla `sugerencia_empleado`
--
ALTER TABLE `sugerencia_empleado`
  ADD CONSTRAINT `sugerencia_empleado_empleado` FOREIGN KEY (`id_empleado`) REFERENCES `empleado` (`id_empleado`),
  ADD CONSTRAINT `sugerencia_empleado_sugerencia` FOREIGN KEY (`id_sugerencia`) REFERENCES `sugerencia` (`id`);

--
-- Filtros para la tabla `urgencia`
--
ALTER TABLE `urgencia`
  ADD CONSTRAINT `urgencia_area` FOREIGN KEY (`id_area`) REFERENCES `area` (`id`);

--
-- Filtros para la tabla `urgencias_empleado`
--
ALTER TABLE `urgencias_empleado`
  ADD CONSTRAINT `tabla_empleado` FOREIGN KEY (`id_empleado`) REFERENCES `empleado` (`id_empleado`),
  ADD CONSTRAINT `tabla_urgencia` FOREIGN KEY (`id_urgencia`) REFERENCES `urgencia` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
