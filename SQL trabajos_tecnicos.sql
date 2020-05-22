CREATE DATABASE IF NOT EXISTS trabajos_tecnicos;
USE trabajos_tecnicos;

#Tabla Direccion
CREATE TABLE IF NOT EXISTS direccion(
direccion_id int NOT NULL AUTO_INCREMENT,
direccion varchar(50) NOT NULL,
complemento varchar(50),
indicacion tinytext,
CONSTRAINT PK_Direccion PRIMARY KEY (direccion_id));

#Tabla Categoria
CREATE TABLE IF NOT EXISTS categoria(
categoria_id int NOT NULL AUTO_INCREMENT,
categoria varchar(50) NOT NULL,
CONSTRAINT PK_Categoria PRIMARY KEY (categoria_id));

#Tabla Estado servicio
CREATE TABLE IF NOT EXISTS estadoservicio(
estadoServicio_id int NOT NULL AUTO_INCREMENT,
estado varchar(50) NOT NULL,
CONSTRAINT PK_EstadoServicio PRIMARY KEY (estadoServicio_id));

#Tabla Usuario
CREATE TABLE IF NOT EXISTS usuario(
usuario_id int NOT NULL AUTO_INCREMENT,
nombre varchar(50) NOT NULL,
email varchar(50) NOT NULL UNIQUE,
CONSTRAINT PK_usuario PRIMARY KEY (usuario_id));

#Tabla Telefono
CREATE TABLE IF NOT EXISTS telefono(
telefono_id int NOT NULL AUTO_INCREMENT,
tipo varchar(25) NOT NULL,
numero varchar(15) NOT NULL,
usuario_id4 int,
CONSTRAINT PK_Telefono PRIMARY KEY (telefono_id),
FOREIGN KEY (usuario_id4) REFERENCES usuario(usuario_id));

#Tabla cliente
CREATE TABLE IF NOT EXISTS cliente(
cliente_id int NOT NULL AUTO_INCREMENT,
direccion_id1 int,
usuario_id1 int,
CONSTRAINT PK_cliente PRIMARY KEY (cliente_id),
FOREIGN KEY (direccion_id1) REFERENCES direccion(direccion_id),
FOREIGN KEY (usuario_id1) REFERENCES usuario(usuario_id));

#Tabla tecnico
CREATE TABLE IF NOT EXISTS tecnico(
tecnico_id int NOT NULL AUTO_INCREMENT,
calificacion float,
usuario_id2 int,
categoria_id1 int,
CONSTRAINT PK_tecnico PRIMARY KEY (tecnico_id),
FOREIGN KEY (usuario_id2) REFERENCES usuario(usuario_id),
FOREIGN KEY (categoria_id1) REFERENCES categoria(categoria_id));

#Tabla servicios
CREATE TABLE IF NOT EXISTS servicio(
servicio_id int NOT NULL AUTO_INCREMENT,
descripcion tinytext NOT NULL,
fecha datetime,
estadoServicio_id1 int,
cliente_id1 int,
tecnico_id1 int,
CONSTRAINT PK_trabajo PRIMARY KEY (servicio_id),
FOREIGN KEY (estadoServicio_id1) REFERENCES estadoservicio(estadoServicio_id),
FOREIGN KEY (cliente_id1) REFERENCES cliente(cliente_id),
FOREIGN KEY (tecnico_id1) REFERENCES tecnico(tecnico_id));

/*
CREATE TABLE IF NOT EXISTS mensajes(
mensaje_id int NOT NULL AUTO_INCREMENT,
usuario_id5 int NOT NULL,
usuario_id6 int NOT NULL,
contenido tinytext,
CONSTRAINT PK_mensajes PRIMARY KEY(mensaje_id),
FOREIGN KEY (usuario_id5) REFERENCES usuario(usuario_id),
FOREIGN KEY (usuario_id6) REFERENCES usuario(usuario_id));
*/