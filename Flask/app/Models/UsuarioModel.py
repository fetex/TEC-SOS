from app import db, ma
from app.Models.ClienteModel import ClienteModel
from app.Models.TelefonoModel import TelefonoModel
from app.Models.TecnicoModel import TecnicoModel

class UsuarioModel(db.Model):
    __tablename__ = "Usuario"
    usuario_id = db.Column(db.Integer, primary_key = True)
    nombre = db.Column(db.String(50), nullable = False)
    email = db.Column(db.String(50), nullable = False, unique = True)
    cliente = db.relationship('ClienteModel', backref ='Usuario', lazy ='dynamic')
    tecnico = db.relationship('TecnicoModel', backref = 'Usuario', lazy = 'dynamic')
    telefono = db.relationship('TelefonoModel', backref = 'Usuario', lazy = 'dynamic')

class UsuarioSchema(ma.SQLAlchemyAutoSchema):
    class Meta:
        modelo = UsuarioModel