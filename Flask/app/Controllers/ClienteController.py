from app import app, db, ma
from flask import request,jsonify
from app.Models.ClienteModel import ClienteModel, ClienteSchema
from app.Models.DireccionModel import DireccionModel, DireccionSchema
from app.Models.ServicioModel import ServicioModel, ServicioSchema


@app.route('/crearCliente', methods=["POST"])
def crear_Cliente():
    req_data = ClienteSchema().load(request.get_json())
    db.session.add(req_data)
    db.session.commit()
    return "OK", 201


@app.route('/listarClientes', methods=["GET"])
def listar_cliente():
    clientes = ClienteModel.query.all()
    json = ClienteSchema(many=True).dump(clientes)
    return jsonify(json),200


@app.route('/cliente/<cliente_id>',methods=["GET"] )
def buscar_cliente(cliente_id):
    cliente = ClienteModel.query.get(cliente_id)
    json = ClienteSchema().dump(cliente)
    return jsonify(json),200

@app.route('/cliente/<cliente_id>/direcciones', methods=["GET"])
def listarDireccionesCliente(cliente_id):
    direcciones = DireccionModel.query.filter_by(cliente_id = cliente_id)
    json = DireccionSchema(many = True).dump(direcciones)
    return jsonify(json), 200

#Pendiete probar
@app.route('/cliente/<cliente_id>/servicios', methods=["GET"])
def listarServiciosCliente(cliente_id):
    servicios = ServicioModel.query.filter_by(cliente_id = cliente_id)
    json = ServicioSchema(many = True).dump(servicios)
    return jsonify(json), 200

@app.route('/eliminarCliente/<cliente_id>',methods=["DELETE"])
def eliminar_clienter(cliente_id):
    cliente = ClienteModel.query.get(cliente_id)
    db.session.delete(cliente)
    db.session.commit()
    return "OK", 200