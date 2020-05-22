from app import db, ma
from marshmallow import post_load

class DireccionModel(db.Model):
    __tablename__ = "Direccion"
    direccion_id = db.Column(db.Integer, primary_key = True)
    direccion = db.Column(db.String(50), nullable = False)
    complemento = db.Column(db.String(50))
    indicacion = db.Column(db.String(255))
    cliente_id = db.Column(db.Integer, db.ForeignKey('Cliente.cliente_id'))

class DireccionSchema(ma.SQLAlchemyAutoSchema):
    class Meta:
        model = DireccionModel
        include_fk = True
    
    @post_load
    def make_direccion(self, data, **kwargs):
        return DireccionModel(**data)