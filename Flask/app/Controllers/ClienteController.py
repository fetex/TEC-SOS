from app import app, db, ma
from flask import request,jsonify
from app.Models.ClienteModel import ClienteModel, ClienteSchema


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


@app.route('/actualizarCliente',methods=["PUT"])
def actualizar_cliente():
    req_data = request.get_json()
    cliente_id = req_data['cliente_id']
    nombre_cliente = req_data['cliente']
    update = ClienteModel.query.filter_by(cliente_id = cliente_id).first()
    update.cliente =  nombre_cliente
    db.session.commit()
    return "OK",202

@app.route('/eliminarCliente/<cliente_id>',methods=["DELETE"])
def eliminar_clienter(cliente_id):
    cliente = ClienteModel.query.get(cliente_id)
    db.session.delete(cliente)
    db.session.commit()
    return "OK", 200

"Por nombre de cliente, traer a los tecnicos relacionados a esta"

# @app.route('/cliente-tecnico/<cliente>')
# def cliente_Tecnico(cliente):
    