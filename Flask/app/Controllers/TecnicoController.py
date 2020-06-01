from app import app, db, ma
from flask import request,jsonify
from app.Models.TecnicoModel import TecnicoModel, TecnicoSchema

@app.route('/crearTecnico', methods=["POST"])
def crear_Tecnico():
    req_data = TecnicoSchema().load(request.get_json())
    db.session.add(req_data)
    db.session.commit()
    return "OK", 201


@app.route('/listarTecnicos', methods=["GET"])
def listar_Tecnico():
    Tecnicos = TecnicoModel.query.all()
    json = TecnicoSchema(many=True).dump(Tecnicos)
    return jsonify(json),200


@app.route('/Tecnico/<tecnico_id>',methods=["GET"] )
def buscar_Tecnico(tecnico_id):
    Tecnico = TecnicoModel.query.get(tecnico_id)
    json = TecnicoSchema().dump(Tecnico)
    return jsonify(json),200


@app.route('/actualizarTecnico',methods=["PUT"])
def actualizar_Tecnico():
    req_data = request.get_json()
    Tecnico_id = req_data['Tecnico_id']
    nombre_Tecnico = req_data['Tecnico']
    update = TecnicoModel.query.filter_by(tecnico_id = Tecnico_id).first()
    update.Tecnico =  nombre_Tecnico
    db.session.commit()
    return "OK",202

@app.route('/eliminarTecnico/<tecnico_id>',methods=["DELETE"])
def eliminar_Tecnico(tecnico_id):
    Tecnico = TecnicoModel.query.get(tecnico_id)
    db.session.delete(Tecnico)
    db.session.commit()
    return "OK", 200