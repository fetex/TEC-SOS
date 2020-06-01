from app import db, ma
from marshmallow import post_load

class ServicioModel(db.Model):
    __tablename__ = 'Servicio'
    servicio_id = db.Column(db.Integer, primary_key = True)
    descripcion = db.Column(db.String(255), nullable = False)
    fecha = db.Column(db.String(30), nullable = False)
    estadoServicio_id = db.Column(db.Integer, db.ForeignKey('Estado_Servicio.estadoServicio_id'))
    tecnico_id = db.Column(db.Integer, db.ForeignKey('Tecnico.tecnico_id'))
    cliente_id = db.Column(db.Integer, db.ForeignKey('Cliente.cliente_id'))

class ServicioSchema(ma.SQLAlchemyAutoSchema):
    class Meta:
        model = ServicioModel
        include_fk = True

    @post_load
    def make_servicio(self, data, **kwargs):
        return ServicioModel(**data)