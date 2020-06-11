from app import db, ma
from marshmallow import post_load
from app.Models.DireccionModel import DireccionModel
from app.Models.ServicioModel import ServicioModel

class ClienteModel(db.Model):
    __tablename__ = "Cliente"
    cliente_id = db.Column(db.Integer, primary_key = True)
    usuario_id = db.Column(db.Integer, db.ForeignKey('Usuario.usuario_id'), nullable = False)
    direccion = db.relationship('DireccionModel', backref = 'Cliente', lazy = 'dynamic')
    servicio = db.relationship('ServicioModel', backref = 'Cliente', lazy = 'dynamic')

class ClienteSchema(ma.SQLAlchemyAutoSchema):
    class Meta:
        model = ClienteModel
        include_fk = True

    @post_load
    def make_cliente(self, data, **kwargs):
        return ClienteModel(**data)