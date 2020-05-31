from app import app, db, ma
from flask import request,jsonify
from app.Models.TelefonoModel import TelefonoModel, TelefonoSchema


@app.route('/CrearTelefono', methods=['POST'])
def Crear_Telefono():
    req_data = TelefonoSchema().load(request.get_json())
    db.session.add(req_data)
    db.session.commit()
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


@app.route('/actualizarTelefono',methods=["PUT"])
def actualizar_telefono():
    req_data = request.get_json()
    telefono_id = req_data['telefono_id']
    numero_telefono = req_data['numero']
    update = TelefonoModel.query.filter_by(telefono_id = telefono_id).first()
    update.numero =  numero_telefono
    db.session.commit()
    return "OK",202

@app.route('/eliminarTelefono/<telefono_id>',methods=["DELETE"])
def eliminar_telefonor(telefono_id):
    data = TelefonoModel.query.get(telefono_id)
    db.session.delete(data)
    db.session.commit()
    return "OK", 200