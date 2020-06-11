from app import app, db, ma
from flask import request,jsonify
from app.Models.TecnicoModel import TecnicoModel, TecnicoSchema
from app.Models.ServicioModel import ServicioModel, ServicioSchema

@app.route('/crearTecnico', methods=["POST"])
def crear_Tecnico():
    req_data = TecnicoSchema().load(request.get_json())
    db.session.add(req_data)
    db.session.commit()
    return "OK", 201


@app.route('/listarTecnicos', methods=["GET"])
def listar_tecnico():
    data = TecnicoModel.query.all()
    json = TecnicoSchema(many=True).dump(data)
    return jsonify(json), 200


@app.route('/tecnico/<tecnico_id>',methods=["GET"] )
def buscar_tecnico(tecnico_id):
    data = TecnicoModel.query.get(tecnico_id)
    json = TecnicoSchema().dump(data)
    return jsonify(json),200


@app.route('/actualizarTecnico',methods=["PUT"])
def actualizar_tecnico():
    req_data = request.get_json()
    tecnico_id = req_data['tecnico_id']
    descripcion = req_data['descripcion']
    categoria_id = req_data['categoria_id']
    update = TecnicoModel.query.filter_by(tecnico_id = tecnico_id).first()
    update.descripcion =  descripcion
    update.categoria_id = categoria_id
    db.session.commit()
    return "OK",202

@app.route('/calificarTecnico', methods=["PUT"])
def Calificar_tecnico():
    req_data = request.get_json()
    tecnico_id = req_data['tecnico_id']
    nuevaCalificacion = req_data['calificacion']
    nuevaCalificacion = float(nuevaCalificacion)
    update = TecnicoModel.query.filter_by(tecnico_id = tecnico_id).first()
    calificacion = float(update.calificacion)
    update.calificacion = str((calificacion+nuevaCalificacion)/2)
    db.session.commit()
    return "OK", 202

@app.route('/eliminarTecnico/<tecnico_id>',methods=["DELETE"])
def eliminar_Tecnico(tecnico_id):
    Tecnico = TecnicoModel.query.get(tecnico_id)
    db.session.delete(Tecnico)
    db.session.commit()
    return "OK", 200

#Pendiente probar
@app.route('/tecnico/<tecnico_id>/servicios', methods=["GET"])
def listarServiciosTecnico(tecnico_id):
    servicios = ServicioModel.query.filter_by(tecnico_id = tecnico_id)
    json = ServicioSchema(many = True).dump(servicios)
    return jsonify(json), 200
