CREATE DATABASE trabajos_tecnicos;
USE trabajos_tecnicos;

#Tabla Direccion
CREATE TABLE IF NOT EXISTS direccion(
direccion_id int NOT NULL AUTO_INCREMENT,
direccion varchar(50) NOT NULL,
complemento varchar(50),
comentario tinytext,
CONSTRAINT PK_Direccion PRIMARY KEY (direccion_id));

#Tabla Telefono
CREATE TABLE IF NOT EXISTS tipotelefono(
tipoTelefono_id int NOT NULL AUTO_INCREMENT,
tipo varchar(25) NOT NULL,
CONSTRAINT PK_Telefono PRIMARY KEY (tipoTelefono_id));

#Tabla Perfil
CREATE TABLE IF NOT EXISTS perfil(
perfil_id int NOT NULL AUTO_INCREMENT,
nombre_perfil varchar(50) NOT NULL,
CONSTRAINT PK_Perfil PRIMARY KEY (perfil_id));

#Tabla Categoria
CREATE TABLE IF NOT EXISTS categoria(
categoria_id int NOT NULL AUTO_INCREMENT,
categoria varchar(50) NOT NULL,
CONSTRAINT PK_Categoria PRIMARY KEY (categoria_id));

#Tabla Estado Trabajo
CREATE TABLE IF NOT EXISTS estadotrabajo(
estadoTrabajo_id int NOT NULL AUTO_INCREMENT,
estado varchar(50) NOT NULL,
CONSTRAINT PK_EstadoTrabajo PRIMARY KEY (estadoTrabajo_id));

#Tabla Trabajo
CREATE TABLE IF NOT EXISTS trabajo(
trabajo_id int NOT NULL AUTO_INCREMENT,
titulo varchar(50) NOT NULL,
descripcion tinytext NOT NULL,
fecha datetime,
estadotrabajo_id1 int,
direccion_id1 int,
CONSTRAINT PK_trabajo PRIMARY KEY (trabajo_id),
FOREIGN KEY (estadotrabajo_id1) REFERENCES estadotrabajo(estadoTrabajo_id),
FOREIGN KEY (direccion_id1) REFERENCES direccion(direccion_id));

#Tabla Usuario
CREATE TABLE IF NOT EXISTS usuario(
usuario_id int NOT NULL AUTO_INCREMENT,
nombre varchar(50) NOT NULL,
email varchar(50) NOT NULL UNIQUE,
perfil_id1 int,
CONSTRAINT PK_usuario PRIMARY KEY (usuario_id),
FOREIGN KEY (perfil_id1) REFERENCES perfil(perfil_id));

/*Tabla UsuarioTelefono
Dos llaves foraneas:
	- usuario
    - tipo
*/
CREATE TABLE IF NOT EXISTS usuariotelefono(
usuario_id1 int,
tipotelefono_id1 int,
numero varchar(10),
FOREIGN KEY (usuario_id1) REFERENCES usuario(usuario_id),
FOREIGN KEY (tipotelefono_id1) REFERENCES tipotelefono(tipoTelefono_id));

/*Tabla UsuarioDireccion
Dos llaves foraneas:
	- usuario
    - direccion
*/
CREATE TABLE IF NOT EXISTS usuariodireccion(
usuario_id2 int,
direccion_id2 int,
favorito bool NOT NULL default'0',
FOREIGN KEY (usuario_id2) REFERENCES usuario(usuario_id),
FOREIGN KEY (direccion_id2) REFERENCES direccion(direccion_id));

/*Tabla Propietario
Dos llaves foraneas:
	- usuario
    - trabajo
*/
CREATE TABLE IF NOT EXISTS propietario(
usuario_id3 int NOT NULL,
trabajo_id1 int NOT NULL,
FOREIGN KEY (usuario_id3) REFERENCES usuario(usuario_id),
FOREIGN KEY (trabajo_id1) REFERENCES trabajo(trabajo_id));

/*Tabla Tecnico
Dos llaves foraneas:
	- usuario
    - trabajo
*/
CREATE TABLE IF NOT EXISTS tecnico(
usuario_id4 int,
trabajo_id2 int,
fecha datetime,
FOREIGN KEY (usuario_id4) REFERENCES usuario(usuario_id),
FOREIGN KEY (TRABAJO_id2) REFERENCES trabajo(trabajo_id));

/*Tabla TrabajoCategoria
Dos llaves foraneas:
	- trabajo
    - categoria
*/
CREATE TABLE IF NOT EXISTS trabajocategoria(
trabajo_id3 int,
categoria_id1 int,
FOREIGN KEY (trabajo_id3) REFERENCES trabajo(trabajo_id),
FOREIGN KEY (categoria_id1) REFERENCES categoria(categoria_id)
);