# pruebaFiltroClothing

ENDPOINTS

http://localhost:5150/Cargo
http://localhost:5150/Cliente
http://localhost:5150/Color
http://localhost:5150/Departamento
http://localhost:5150/DetalleOrden
http://localhost:5150/DetalleVenta
http://localhost:5150/Empleado
http://localhost:5150/Empresa
http://localhost:5150/Estado
http://localhost:5150/FormaPago
http://localhost:5150/Genero
http://localhost:5150/Insumo
http://localhost:5150/Inventario
http://localhost:5150/Orden
http://localhost:5150/Pais
http://localhost:5150/Prenda
http://localhost:5150/Proveedor
http://localhost:5150/Talla
http://localhost:5150/TipoEstado
http://localhost:5150/TipoPersona
http://localhost:5150/TipoProteccion
http://localhost:5150/Venta


TIPOS DE PETICION

GET , POST, GET /{id}, PUT /{id}, DELETE /{id}


EJEMPLO GET 

http://localhost:5150/Cargo

200
[
  {
    "id": 0,
    "descripcion": "string",
    "sueldoBase": 0
  }
]

400
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "additionalProp1": "string",
  "additionalProp2": "string",
  "additionalProp3": "string"
}

EJEMPLO POST

http://localhost:5150/Cargo

EJEMPLO PETICION VALUE

{
  "id": 0,
  "idCliente": 0,
  "nombreCliente": "string",
  "fechaRegistro": "2023-10-25T19:04:21.602Z",
  "idTipoPersona": 0,
  "idMunicipio": 0
}

RESPUESTA 201

{
  "id": 0,
  "idCliente": 0,
  "nombreCliente": "string",
  "fechaRegistro": "2023-10-25T19:04:21.604Z",
  "idTipoPersona": 0,
  "idMunicipio": 0
}

RESPUESTA 400
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "additionalProp1": "string",
  "additionalProp2": "string",
  "additionalProp3": "string"
}

EJEMPLO PUT

http://localhost:5150/Cargo

EJEMPLO PETICION VALUE

{
  "id": 0,
  "idCliente": 0,
  "nombreCliente": "string",
  "fechaRegistro": "2023-10-25T19:06:10.544Z",
  "idTipoPersona": 0,
  "idMunicipio": 0
}

RESPUESTA
200
{
  "id": 0,
  "idCliente": 0,
  "nombreCliente": "string",
  "fechaRegistro": "2023-10-25T19:06:10.544Z",
  "idTipoPersona": 0,
  "idMunicipio": 0
}

400
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "additionalProp1": "string",
  "additionalProp2": "string",
  "additionalProp3": "string"
}

404
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "additionalProp1": "string",
  "additionalProp2": "string",
  "additionalProp3": "string"
}


EJEMPLO DELETE

http://localhost:5150/Cargo

ENVIAR ID EN PETICION PARA BORRAR

RESPUESTA

200 	
Success

404

{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "additionalProp1": "string",
  "additionalProp2": "string",
  "additionalProp3": "string"
}