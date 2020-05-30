from app import app, db, ma
from flask import request,jsonify
from app.Models.TelefonoModel import TelefonoModel, TelefonoSchema


@app.route('/CrearTelefono', methods=['POST'])
def Creat_Telefono():
    data = TelefonoSchema().load(request.get_json)
    db.session.add(data)
    db.session.commit
    return "OK", 201

@app.route('/listar_telefonos', methods=["GET"])
def listar_telefono():
    data = TelefonoModel.query.all()
    json = TelefonoSchema(many=True).dump(data)
    return jsonify(json),200


@app.route('/telefono/<telefono_id>',methods=["GET"] )
def buscar_telefono(telefono_id):
    data = TelefonoModel.query.get(telefono_id)
    json = TelefonoSchema().dump(data)
    return jsonify(json),200


@app.route('/actualizarCategoria',methods=["PUT"])
def actualizar_telefono():
    req_data = request.get_json()
    telefono_id = req_data['telefono_id']
    nombre_telefono = req_data['telefono']
    update = TelefonoModel.query.filter_by(telefono_id = telefono_id).first()
    update.telefono =  nombre_telefono
    db.session.commit()
    return "OK",202

@app.route('/eliminarCategoria/<telefono_id>',methods=["DELETE"])
def eliminar_telefonor(telefono_id):
    data = TelefonoModel.query.get(telefono_id)
    db.session.delete(data)
    db.session.commit()
    return "OK", 200