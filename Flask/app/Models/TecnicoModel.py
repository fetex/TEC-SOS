from app import db, ma
from marshmallow import post_load
from app.Models.ServicioModel import ServicioModel

class TecnicoModel(db.Model):
    __tablename__ = 'Tecnico'
    tecnico_id = db.Column(db.Integer, primary_key = True)
    calificacion = db.Column(db.String(4), default="0.00")
    descripcion = db.Column(db.String(255))
    usuario_id = db.Column(db.Integer, db.ForeignKey('Usuario.usuario_id'), nullable = False )
    categoria_id = db.Column(db.Integer, db.ForeignKey('Categoria.categoria_id'), nullable = False)
    servicio = db.relationship('ServicioModel', backref = 'Tecnico', lazy = 'dynamic')

class TecnicoSchema(ma.SQLAlchemyAutoSchema):
    class Meta:
        model = TecnicoModel
        include_fk = True

    @post_load
    def make_tecnico(self, data, **kwargs):
        return TecnicoModel(**data)