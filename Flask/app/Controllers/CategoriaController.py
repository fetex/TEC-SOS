from app import app, db, ma
from flask import request,jsonify
from app.Models.CategoriaModel import CategoriaModel, CategoriaSchema


@app.route('/crearCategoria', methods=["POST"])
def crear_Category():
    req_data = CategoriaSchema().load(request.get_json())
    db.session.add(req_data)
    db.session.commit()
    return "OK", 201


@app.route('/listarCategorias', methods=["GET"])
def listar_Categoria():
    categorias = CategoriaModel.query.all()
    json = CategoriaSchema(many=True).dump(categorias)
    return jsonify(json)


@app.route('/categoria/<categoria_id>',methods=["GET"] )
def obtener_categoria(categoria_id):
    categoria = CategoriaModel.query.get(categoria_id)
    json = CategoriaSchema().dump(categoria)
    return jsonify(json)


@app.route('/actualizarCategoria/<categoria_id>',methods=["PUT"])
def actualizar_categoria(categoria_id):
    categoria = CategoriaModel.query.get(categoria_id)
    categoria.categoria = "Plomero"
    db.session.commit()
    return "OK"

@app.route('/eliminarCategoria/<categoria_id>',methods=["DELETE"])
def eliminar_categoriar(categoria_id):
    categoria = CategoriaModel.query.get(categoria_id)
    db.session.delete(categoria)
    db.session.commit()
    return "OK"

"Por nombre de categoria, traer a los tecnicos relacionados a esta"

# @app.route('/categoria-tecnico/<categoria>')
# def categoria_Tecnico(categoria):
    