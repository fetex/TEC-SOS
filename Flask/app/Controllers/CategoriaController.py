from app import app, db, ma
from flask import request
from app.Models.CategoriaModel import CategoriaModel, CategoriaSchema
from flask import jsonify

@app.route('/crearCategoria', methods=["POST"])
def crear_Category():
    categoria  = CategoriaModel(categoria = "Tecnico hidraulco")
    db.session.add(categoria)
    db.session.commit()
    return "OK"


@app.route('/listarCategorias', methods=["GET"])
def listar_Categoria():
    categorias = CategoriaModel.query.all()
    json = CategoriaSchema(many=True).dump(categorias)
    return jsonify(json)


@app.route('/categoria/<categoria_id>')
def obtener_categoria(categoria_id):
    categoria = CategoriaModel.query.get(categoria_id)
    json = CategoriaSchema().dump(categoria)
    return jsonify(json)


@app.route('/actualizarCategoria/<categoria_id>')
def actualizar_categoria(categoria_id):
    categoria = CategoriaModel.query.get(categoria_id)
    categoria.categoria = "Plomero"
    db.session.commit()
    return "OK"

@app.route('/eliminarCategoria/<categoria_id>')
def eliminar_categoriar(categoria_id):
    categoria = CategoriaModel.query.get(categoria_id)
    db.session.delete(categoria)
    db.session.commit()
    return "OK"