from app import db, ma
from marshmallow import post_load


class TelefonoModel(db.Model):
    __tablename__ = "Telefono"
    telefono_id = db.Column(db.Integer, primary_key = True)
    tipo = db.Column(db.String(25), nullable = False)
    numero = db.Column(db.String(11), nullable = False, unique= True)
    usuario_id = db.Column(db.Integer, db.ForeignKey('Usuario.usuario_id'))

class TelefonoSchema(ma.SQLAlchemyAutoSchema):
    class Meta:
        model = TelefonoModel
        include_fk = True
    
    @post_load
    def make_telefono(self, data, **kwargs):
        return TelefonoModel(**data)
