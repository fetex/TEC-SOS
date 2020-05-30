from app import db, ma
from app.Models.TecnicoModel import TecnicoModel
from marshmallow import post_load

class CategoriaModel(db.Model):
    __tablename__ = "Categoria"
    categoria_id = db.Column(db.Integer, primary_key = True)
    categoria = db.Column(db.String(30), unique = True)
    tecnico = db.relationship('TecnicoModel', backref = 'Categoria', lazy = 'dynamic')

class CategoriaSchema(ma.SQLAlchemyAutoSchema):
    class Meta:
        model = CategoriaModel

    @post_load
    def make_categoria(self,data,**kwargs):
        return CategoriaModel(**data)