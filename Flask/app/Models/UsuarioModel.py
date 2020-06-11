from app import db, ma
from app.Models.ClienteModel import ClienteModel
from app.Models.TelefonoModel import TelefonoModel
from app.Models.TecnicoModel import TecnicoModel
from marshmallow import post_load



class UsuarioModel(db.Model):
    __tablename__ = "Usuario"
    usuario_id = db.Column(db.Integer, primary_key = True)
    username = db.Column(db.String(50), nullable = False)
    email = db.Column(db.String(50), nullable = False, unique = True)
    password = db.Column(db.String(20), nullable = False)
    cliente = db.relationship('ClienteModel', backref ='Usuario', lazy ='dynamic')
    tecnico = db.relationship('TecnicoModel', backref = 'Usuario', lazy = 'dynamic')
    telefono = db.relationship('TelefonoModel', backref = 'Usuario', lazy = 'dynamic')

class UsuarioSchema(ma.SQLAlchemyAutoSchema):
    class Meta:
        model = UsuarioModel

    @post_load
    def make_Usuario(self, data, **kwargs):
        return UsuarioModel(**data)

