-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: catdog veterinaria
-- ------------------------------------------------------
-- Server version	8.0.26

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cita`
--

DROP TABLE IF EXISTS `cita`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cita` (
  `idCita` int NOT NULL AUTO_INCREMENT,
  `idClientes` int NOT NULL,
  `idMascotas` int NOT NULL,
  `Fecha` date NOT NULL,
  `Hora` time NOT NULL,
  `Estado` varchar(20) NOT NULL,
  `TipoServicio` varchar(100) NOT NULL,
  PRIMARY KEY (`idCita`),
  KEY `idClientes` (`idClientes`),
  KEY `idMascotas` (`idMascotas`),
  CONSTRAINT `cita_ibfk_1` FOREIGN KEY (`idClientes`) REFERENCES `clientes` (`idClientes`),
  CONSTRAINT `cita_ibfk_2` FOREIGN KEY (`idMascotas`) REFERENCES `mascotas` (`idMascotas`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cita`
--

LOCK TABLES `cita` WRITE;
/*!40000 ALTER TABLE `cita` DISABLE KEYS */;
INSERT INTO `cita` VALUES (1,1,1,'2024-11-10','10:00:00','Confirmada',''),(16,2,3,'2024-12-08','14:00:00','Confirmado','Cita Médica'),(17,2,3,'2024-11-29','15:00:00','Confirmado','Cita Médica'),(18,2,3,'2024-11-27','10:30:00','Confirmado','Cita Médica'),(19,2,3,'2024-11-27','10:30:00','Confirmado','Cita Médica'),(20,2,19,'2024-12-05','15:00:00','Confirmado','Compra de Alimentos');
/*!40000 ALTER TABLE `cita` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clientes`
--

DROP TABLE IF EXISTS `clientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clientes` (
  `idClientes` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `apellido` varchar(100) NOT NULL,
  `sexo` varchar(10) DEFAULT NULL,
  `telefono` varchar(15) DEFAULT NULL,
  `direccion` varchar(255) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`idClientes`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Aqui iran almacenados todos los clientes';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientes`
--

LOCK TABLES `clientes` WRITE;
/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
INSERT INTO `clientes` VALUES (1,'Juan','Pérez','Masculino','71185599','Col.Prados Altos','juan.perez@example.com'),(2,'Raul','Portillo','Masculino','71182188','Col. Clara Miranda Larga','raul.portillo@example.com'),(4,'Jessica','Alfaro','Femnino','99663333','Final Avenida Ramas','jessica.alfaro@hotmail.com'),(5,'Diego','Barillas','Masculino','77112288','Avenida Argentina','diego.barillas@gmail.com'),(6,'Carlos','Huezo','Masculino','88996666','Col. America Norte','carlos.huezoo@hotmail.com'),(7,'Andre','Castillo','Masculino','78785522','Col. Norte','andre.castillo@hotmail.com');
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `consultas`
--

DROP TABLE IF EXISTS `consultas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `consultas` (
  `idConsulta` int NOT NULL AUTO_INCREMENT,
  `idMascotas` int DEFAULT NULL,
  `sintomas` varchar(255) DEFAULT NULL,
  `descripcionConsulta` text,
  `indicaciones` text,
  PRIMARY KEY (`idConsulta`),
  KEY `idMascotas` (`idMascotas`),
  CONSTRAINT `consultas_ibfk_1` FOREIGN KEY (`idMascotas`) REFERENCES `mascotas` (`idMascotas`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `consultas`
--

LOCK TABLES `consultas` WRITE;
/*!40000 ALTER TABLE `consultas` DISABLE KEYS */;
INSERT INTO `consultas` VALUES (1,1,'calentura','La mascota presenta calentura de leve a grave','Darle a su mascota cada 12 horas pastillas y sino mejora regresar'),(2,2,'Sangrado','Presenta sangrado en la nariz por problemas de edad','Se mantedra en reposo por el momento y una pastilla analgesica para ver como reacciona en un tiempo de 5 horas, para poder dar un tratamiento mejor'),(3,10,'SobrePeso','El perro muestra signos de tener sobrepeso','Tener dieta estricta con respecto a lo que se le de que coma'),(4,19,'Parasitos','Presenta parasitos de 8cm de largo','Dar pastillas desparasitantes una hoy y despues a los 15 días'),(5,9,'Parasitos','Presenta parasitos','Pastillas antiparasitaria cada 15 dias por un mes'),(6,8,'Embarazada','Presenta un embarazo de 1 mes','Manterla con cuidado para poder tener bien los conejos');
/*!40000 ALTER TABLE `consultas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `facturacion`
--

DROP TABLE IF EXISTS `facturacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `facturacion` (
  `idFacturación` int NOT NULL AUTO_INCREMENT,
  `ServicioPrestado` varchar(255) NOT NULL,
  `MetododePago` varchar(255) NOT NULL,
  `MontoTotal` decimal(10,2) NOT NULL,
  PRIMARY KEY (`idFacturación`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='aqui se mostrara la facturacion que se ha hecho';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `facturacion`
--

LOCK TABLES `facturacion` WRITE;
/*!40000 ALTER TABLE `facturacion` DISABLE KEYS */;
INSERT INTO `facturacion` VALUES (1,'Cita Médica','Efectivo',120.40),(2,'Medicamentos','Tarjeta Débito',57.14),(3,'Compra de Accesorios','Efectivo',10.99),(4,'Cita Médica','Efectivo',9.99),(5,'Medicamentos','Efectivo',55.25),(6,'Compra de Alimentos','Tarjeta Débito',16.99),(7,'Cita Médica','Efectivo',10.00);
/*!40000 ALTER TABLE `facturacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `horarios`
--

DROP TABLE IF EXISTS `horarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `horarios` (
  `idHorario` int NOT NULL AUTO_INCREMENT,
  `Fecha` date NOT NULL,
  `Hora` time NOT NULL,
  `Disponible` tinyint(1) NOT NULL,
  PRIMARY KEY (`idHorario`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `horarios`
--

LOCK TABLES `horarios` WRITE;
/*!40000 ALTER TABLE `horarios` DISABLE KEYS */;
INSERT INTO `horarios` VALUES (1,'2024-11-12','10:30:00',1),(2,'2024-11-12','11:00:00',1),(3,'2024-11-12','11:30:00',1),(4,'2024-11-12','12:00:00',1),(5,'2024-11-12','12:30:00',1),(6,'2024-11-12','13:00:00',1),(7,'2024-11-12','13:30:00',1),(8,'2024-11-12','14:00:00',1),(9,'2024-11-12','14:30:00',1),(10,'2024-11-12','15:00:00',1);
/*!40000 ALTER TABLE `horarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inventario`
--

DROP TABLE IF EXISTS `inventario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `inventario` (
  `idInventario` int NOT NULL AUTO_INCREMENT,
  `Nombre Producto` varchar(255) NOT NULL,
  `Descripción` text,
  `Precio ($)` decimal(10,2) NOT NULL,
  `Cantidad en Stock` int NOT NULL,
  PRIMARY KEY (`idInventario`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Se mostrara el inventario que tenemos en tienda';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventario`
--

LOCK TABLES `inventario` WRITE;
/*!40000 ALTER TABLE `inventario` DISABLE KEYS */;
INSERT INTO `inventario` VALUES (1,'Bravecto Antiparasitario','Para perros de 20 a 40 kg Tableta de 1000mg',50.99,15),(2,'NexGard','Para perros de 10.1 a 25 kg',35.55,8),(3,'Canisan F Antihelmíntico','Para perros y gatos 10ml',10.99,14),(4,'Comederos para gatos y perros','Comederos para gatos y perros de 15cm de ancho',7.99,25),(5,'Quita Pelusa Marca CatDog','Cepillo quita pelusa de pelos de animales domesticos',5.95,20);
/*!40000 ALTER TABLE `inventario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mascotas`
--

DROP TABLE IF EXISTS `mascotas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mascotas` (
  `idMascotas` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `raza` varchar(100) NOT NULL,
  `especie` varchar(50) NOT NULL,
  `edad (meses)` int NOT NULL,
  `peso (kg)` decimal(5,2) NOT NULL,
  `fechaNacimiento` date NOT NULL,
  `castrado` tinyint(1) NOT NULL,
  `idClientes` int NOT NULL,
  PRIMARY KEY (`idMascotas`),
  KEY `idClientes` (`idClientes`),
  CONSTRAINT `mascotas_ibfk_1` FOREIGN KEY (`idClientes`) REFERENCES `clientes` (`idClientes`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Aqui iran los datos de las mascotas, asociados con los dueños (clientes)';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mascotas`
--

LOCK TABLES `mascotas` WRITE;
/*!40000 ALTER TABLE `mascotas` DISABLE KEYS */;
INSERT INTO `mascotas` VALUES (1,'michi','angora','gato',14,0.90,'2023-06-03',0,1),(2,'Mereleona','angora','gato',10,4.60,'2023-06-03',0,1),(3,'Cheto','Siames','gato',9,1.00,'2024-02-25',0,2),(7,'Leonardo','Auratus','Hamster',2,1.00,'2024-09-20',0,1),(8,'Mamalon','Belier','Conejo',5,2.55,'2024-06-07',1,4),(9,'Bruno','Pitbull','Perro',12,8.30,'2023-11-08',1,6),(10,'Kaiser','Pastor Alemán','Perro',12,7.80,'2023-11-08',1,5),(11,'Mango','Siames','Gato',12,7.00,'2023-11-09',1,2),(12,'Kripto','Pitbull','Perro',6,4.00,'2024-05-10',0,5),(19,'Roky','Australiano','Perico',6,0.90,'2024-05-12',0,2);
/*!40000 ALTER TABLE `mascotas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios` (
  `id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `rol` enum('Admin','Cliente','Veterinario') NOT NULL,
  `fecha_creacion` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `idClientes` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_idClientes_idx` (`idClientes`),
  CONSTRAINT `fk_idClientes` FOREIGN KEY (`idClientes`) REFERENCES `clientes` (`idClientes`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Esta tabla es para el inicio de sesion del LoginForm de VisualStudio';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (3,'MARIA','7777','Veterinario','2024-11-05 19:45:51',NULL),(4,'CARLOS','8899','Admin','2024-11-05 19:45:54',NULL),(5,'ANDRE','5558','Cliente','2024-11-05 19:45:54',7),(6,'MARIO','6363','Veterinario','2024-11-05 19:45:54',NULL),(10,'raul','1234','Veterinario','2024-11-05 19:49:15',2),(11,'MILTOM','4444','Cliente','2024-11-05 19:49:15',NULL),(12,'DIEGO','9393','Admin','2024-11-05 19:49:15',5);
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vacunas`
--

DROP TABLE IF EXISTS `vacunas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vacunas` (
  `idVacuna` int NOT NULL,
  `idMascotas` int NOT NULL,
  `nombreVacuna` varchar(100) NOT NULL,
  `fechaAplicacion` date NOT NULL,
  `proximaFechaAplicacion` date NOT NULL,
  PRIMARY KEY (`idVacuna`),
  KEY `idMascotas` (`idMascotas`),
  CONSTRAINT `vacunas_ibfk_1` FOREIGN KEY (`idMascotas`) REFERENCES `mascotas` (`idMascotas`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vacunas`
--

LOCK TABLES `vacunas` WRITE;
/*!40000 ALTER TABLE `vacunas` DISABLE KEYS */;
INSERT INTO `vacunas` VALUES (1,3,'AntiParasitario','2024-11-12','2025-06-12');
/*!40000 ALTER TABLE `vacunas` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-11-12 19:46:43
