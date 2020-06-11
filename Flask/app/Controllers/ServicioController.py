from datetime import datetime
from app import app, db, ma
from flask import request,jsonify
from app.Models.ServicioModel import ServicioModel, ServicioSchema


@app.route('/crearServicio', methods=["POST"])
def crear_servicio():
    req_data = request.get_json()
    req_data['fecha'] = str(datetime.now()) 
    req_data = ServicioSchema().load(req_data)
    db.session.add(req_data)
    db.session.commit()
    return "OK", 201


@app.route('/listarservicios', methods=["GET"])
def listar_servicio():
    servicios = ServicioModel.query.all()
    json = ServicioSchema(many=True).dump(servicios)
    return jsonify(json),200


@app.route('/servicio/<servicio_id>',methods=["GET"] )
def buscar_servicio(servicio_id):
    servicio = ServicioModel.query.get(servicio_id)
    json = ServicioSchema().dump(servicio)
    return jsonify(json),200


@app.route('/actualizarservicio',methods=["PUT"])
def actualizar_servicio():
    req_data = request.get_json()
    servicio_id = req_data['servicio_id']
    nombre_servicio = req_data['servicio']
    update = ServicioModel.query.filter_by(servicio_id = servicio_id).first()
    update.servicio =  nombre_servicio
    db.session.commit()
    return "OK",202

@app.route('/eliminarservicio/<servicio_id>',methods=["DELETE"])
def eliminar_servicio(servicio_id):
    servicio = ServicioModel.query.get(servicio_id)
    db.session.delete(servicio)
    db.session.commit()
    return "OK", 200