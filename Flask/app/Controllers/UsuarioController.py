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


@app.route('/usuario/<usuario_id>',methods=["GET"] )
def buscar_usuario(usuario_id):
    usuario = UsuarioModel.query.get(usuario_id)
    json = UsuarioSchema().dump(usuario)
    return jsonify(json),200


@app.route('/actualizarUsuario',methods=["PUT"])
def actualizar_usuario():
    req_data = request.get_json()
    usuario_id = req_data['usuario_id']
    username = req_data['username']
    update = UsuarioModel.query.filter_by(usuario_id = usuario_id).first()
    update.username = username
    db.session.commit()
    return "OK",202

@app.route('/cambiarContrasena', methods=["PUT"])
def cambiarContrasena():
    req_data = request.get_json()
    usuario_id = req_data['usuario_id']
    newPassword = req_data['password']
    update = UsuarioModel.query.filter_by(usuario_id = usuario_id).first()
    if(update.password != newPassword):
        update.password = newPassword
        db.session.commit()
        return "Contrasena ha sido cambiada", 202
    else:
        return "Elija una contrasena distinta a la anterior", 200

@app.route('/eliminarUsuario/<usuario_id>',methods=["DELETE"])
def eliminar_usuarior(usuario_id):
    usuario = UsuarioModel.query.get(usuario_id)
    db.session.delete(usuario)
    db.session.commit()
    return "OK", 200

"Por nombre de usuario, traer a los tecnicos relacionados a esta"

# @app.route('/usuario-tecnico/<usuario>')
# def usuario_Tecnico(usuario):
    