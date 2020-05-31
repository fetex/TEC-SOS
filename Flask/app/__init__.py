from flask import Flask
from flask_sqlalchemy import SQLAlchemy
from flask_migrate import Migrate
from flask_marshmallow import Marshmallow


app = Flask(__name__)
app.config["SQLALCHEMY_DATABASE_URI"] = "mysql://admin:password@database-1.cbj0bzg5agt7.us-east-2.rds.amazonaws.com:3306/TECSOS"
db = SQLAlchemy(app)
migrate = Migrate(app,db)
ma = Marshmallow(app)

#Mapeo

from app.Controllers import Example
from app.Controllers import CategoriaController
from app.Controllers import TelefonoController


#flask db migrate -m ""
# flask db upgrade


#Migraciones
from app.Models import CategoriaModel
from app.Models import DireccionModel
from app.Models import EstadoServicioModel
from app.Models import UsuarioModel
from app.Models import TelefonoModel
from app.Models import ClienteModel
from app.Models import TecnicoModel
from app.Models import ServicioModel