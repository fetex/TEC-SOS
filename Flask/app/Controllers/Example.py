from app import app
from flask import request

#Rutas
@app.route('/')
def test():
    return "Hello World"

    #Con un parametro
@app.route('/param/<p1>')
def test2(p1):
    return str(p1)

    #Con queryParameters
@app.route('/qparam')
def test3(): 
    valor = request.args.get("p")
    return str(valor)

    #Retornar otro codigo http
@app.route('/status')
def test4():
    return "Recibido", 201

@app.route('/post', methods=["POST"])
def test5():
    print(request.get_json())
    return str(request.get_json())