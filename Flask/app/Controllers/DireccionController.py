from app import app, db, ma
from flask import request,jsonify
from app.Models.DireccionModel import DireccionModel, DireccionSchema


@app.route('/crearDireccion', methods=["POST"])
def crear_Direccion():
    req_data = DireccionSchema().load(request.get_json())
    db.session.add(req_data)
    db.session.commit()
    return "OK", 201


@app.route('/listarDirecciones', methods=["GET"])
def listar_direccion():
    direccions = DireccionModel.query.all()
    json = DireccionSchema(many=True).dump(direccions)
    return jsonify(json),200


@app.route('/direccion/<direccion_id>',methods=["GET"] )
def buscar_direccion(direccion_id):
    direccion = DireccionModel.query.get(direccion_id)
    json = DireccionSchema().dump(direccion)
    return jsonify(json),200


@app.route('/actualizarDireccion',methods=["PUT"])
def actualizar_direccion():
    req_data = request.get_json()
    direccion_id = req_data['direccion_id']
    direccion = req_data['direccion']
    barrio = req_data['barrio']
    update = DireccionModel.query.filter_by(direccion_id = direccion_id).first()
    update.direccion =  direccion
    update.barrio = barrio
    db.session.commit()
    return "OK",202

@app.route('/eliminarDireccion/<direccion_id>',methods=["DELETE"])
def eliminar_direccionr(direccion_id):
    direccion = DireccionModel.query.get(direccion_id)
    db.session.delete(direccion)
    db.session.commit()
    return "OK", 200

"Por nombre de direccion, traer a los tecnicos relacionados a esta"

# @app.route('/direccion-tecnico/<direccion>')
# def direccion_Tecnico(direccion):
    