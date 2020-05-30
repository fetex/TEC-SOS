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
    return jsonify(json),200


@app.route('/categoria/<categoria_id>',methods=["GET"] )
def buscar_categoria(categoria_id):
    categoria = CategoriaModel.query.get(categoria_id)
    json = CategoriaSchema().dump(categoria)
    return jsonify(json)


@app.route('/actualizarCategoria',methods=["PUT"])
def actualizar_categoria():
    req_data = request.get_json()
    categoria_id = req_data['categoria_id']
    nombre_categoria = req_data['categoria']
    update = CategoriaModel.query.filter_by(categoria_id = categoria_id).first()
    update.categoria =  nombre_categoria
    db.session.commit()
    return "OK",202

@app.route('/eliminarCategoria/<categoria_id>',methods=["DELETE"])
def eliminar_categoriar(categoria_id):
    categoria = CategoriaModel.query.get(categoria_id)
    db.session.delete(categoria)
    db.session.commit()
    return "OK", 200

"Por nombre de categoria, traer a los tecnicos relacionados a esta"

# @app.route('/categoria-tecnico/<categoria>')
# def categoria_Tecnico(categoria):
    