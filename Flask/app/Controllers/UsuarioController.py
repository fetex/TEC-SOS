from app import app, db, ma
from flask import request,jsonify
from app.Models.UsuarioModel import UsuarioModel, UsuarioSchema


@app.route('/crearUsuario', methods=["POST"])
def crear_Usuario():
    req_data = UsuarioSchema().load(request.get_json())
    db.session.add(req_data)
    db.session.commit()
    return "OK", 201


@app.route('/listarUsuarios', methods=["GET"])
def listar_usuario():
    usuarios = UsuarioModel.query.all()
    json = UsuarioSchema(many=True).dump(usuarios)
    return jsonify(json),200


@app.route('/Usuario/<usuario_id>',methods=["GET"] )
def buscar_usuario(usuario_id):
    usuario = UsuarioModel.query.get(usuario_id)
    json = UsuarioSchema().dump(usuario)
    return jsonify(json),200


@app.route('/actualizarUsuario',methods=["PUT"])
def actualizar_usuario():
    req_data = request.get_json()
    usuario_id = req_data['usuario_id']
    password = req_data['password']
    email = req_data['email']
    update = UsuarioModel.query.filter_by(usuario_id = usuario_id).first()
    if (password != update.password):
        update.password =  password
        db.session.commit()
    if (email != update.email):
        update.email = email
        db.session.commit()
    return "OK",202

@app.route('/eliminarUsuario/<usuario_id>',methods=["DELETE"])
def eliminar_usuarior(usuario_id):
    usuario = UsuarioModel.query.get(usuario_id)
    db.session.delete(usuario)
    db.session.commit()
    return "OK", 200

"Por nombre de usuario, traer a los tecnicos relacionados a esta"

# @app.route('/usuario-tecnico/<usuario>')
# def usuario_Tecnico(usuario):
    