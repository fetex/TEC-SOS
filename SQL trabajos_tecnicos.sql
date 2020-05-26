CREATE DATABASE IF NOT EXISTS TECSOS;
USE TECSOS;

#Tabla Categoria
CREATE TABLE IF NOT EXISTS categoria(
ID_Categoria int NOT NULL AUTO_INCREMENT,
categoria varchar(50) NOT NULL,
CONSTRAINT PK_Categoria PRIMARY KEY (ID_Categoria));

#Tabla Estado servicio
CREATE TABLE IF NOT EXISTS estadoservicio(
ID_EstadoServicio int NOT NULL AUTO_INCREMENT,
estado varchar(50) NOT NULL,
CONSTRAINT PK_EstadoServicio PRIMARY KEY (ID_EstadoServicio));

#Tabla Usuario
CREATE TABLE IF NOT EXISTS usuario(
ID_Usuario int NOT NULL AUTO_INCREMENT,
nombre varchar(50) NOT NULL,
email varchar(50) NOT NULL UNIQUE,
CONSTRAINT PK_usuario PRIMARY KEY (ID_Usuario));

#Tabla Telefono
CREATE TABLE IF NOT EXISTS telefono(
ID_Telefono int NOT NULL AUTO_INCREMENT,
tipo varchar(25) NOT NULL,
numero varchar(15) NOT NULL,
ID_Usuario int,
CONSTRAINT PK_Telefono PRIMARY KEY (ID_Telefono),
FOREIGN KEY (ID_Usuario) REFERENCES usuario(ID_Usuario));

#Tabla cliente
CREATE TABLE IF NOT EXISTS cliente(
ID_Cliente int NOT NULL AUTO_INCREMENT,
ID_Usuario int,
CONSTRAINT PK_cliente PRIMARY KEY (ID_Cliente),
FOREIGN KEY (ID_Usuario) REFERENCES usuario(ID_Usuario));

#Tabla Direccion
CREATE TABLE IF NOT EXISTS direccion(
direccion_id int NOT NULL AUTO_INCREMENT,
direccion varchar(50) NOT NULL,
complemento varchar(50),
indicacion tinytext,
ID_Usuario int ,
CONSTRAINT PK_Direccion PRIMARY KEY (direccion_id),
FOREIGN KEY (ID_Usuario) REFERENCES usuario(ID_Usuario));

#Tabla tecnico
CREATE TABLE IF NOT EXISTS tecnico(
ID_Tecnico int NOT NULL AUTO_INCREMENT,
calificacion float,
ID_Usuario int,
ID_Categoria int,
CONSTRAINT PK_tecnico PRIMARY KEY (ID_Tecnico),
FOREIGN KEY (ID_Usuario) REFERENCES usuario(ID_Usuario),
FOREIGN KEY (ID_Categoria) REFERENCES categoria(ID_Categoria));

#Tabla servicios
CREATE TABLE IF NOT EXISTS servicio(
servicio_id int NOT NULL AUTO_INCREMENT,
descripcion tinytext NOT NULL,
fecha datetime,
ID_EstadoServicio int,
ID_Cliente int,
ID_Tecnico int,
CONSTRAINT PK_trabajo PRIMARY KEY (servicio_id),
FOREIGN KEY (ID_EstadoServicio) REFERENCES estadoservicio(ID_EstadoServicio),
FOREIGN KEY (ID_Cliente) REFERENCES cliente(ID_Cliente),
FOREIGN KEY (ID_Tecnico) REFERENCES tecnico(ID_Tecnico));


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