from app import app, db, ma
from flask import request
from app.Models.CategoriaModel import CategoriaModel, CategoriaSchema

@app.route('/crearCategoria', methods=["POST"])
def crearCategoria():
    categoria  = CategoriaModel(categoria = "Tecnico hidraulco")
    db.session.add(categoria)
    db.commit()
    return "OK"