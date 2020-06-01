from app import app, db, ma
from flask import request,jsonify
from app.Models.EstadoServicioModel import EstadoServicioModel, EstadoServicioSchema


@app.route('/crearEstadoServicio', methods=["POST"])
def crear_EstadoServicio():
    req_data = EstadoServicioSchema().load(request.get_json())
    db.session.add(req_data)
    db.session.commit()
    return "OK", 201


@app.route('/listarEstadoServicio', methods=["GET"])
def listar_estadoServicio():
    estadoServicios = EstadoServicioModel.query.all()
    json = EstadoServicioSchema(many=True).dump(estadoServicios)
    return jsonify(json),200


@app.route('/actualizarEstadoServicio',methods=["PUT"])
def actualizar_estadoServicio():
    req_data = request.get_json()
    estadoServicio_id = req_data['estadoServicio_id']
    estado = req_data['estado']
    update = EstadoServicioModel.query.filter_by(estadoServicio_id = estadoServicio_id).first()
    update.estado =  estado
    db.session.commit()
    return "OK",202