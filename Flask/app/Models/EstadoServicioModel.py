from app import db, ma
from app.Models.ServicioModel import ServicioModel

class EstadoServicioModel(db.Model):
    __tablename__ = "Estado_Servicio"
    estadoServicio_id = db.Column(db.Integer, primary_key = True)
    estado = db.Column(db.String(30), nullable = False)
    servicio = db.relationship('ServicioModel', backref = 'Servicio', lazy = 'dynamic')

class EstadoServicioSchema(ma.SQLAlchemyAutoSchema):
    class Meta:
        model = EstadoServicioModel