# PruebaTecnicaBackend

Versión de .NET 

net10.0



# Cómo correr el proyecto.


1. Clonar el repositorio --> git clone https://github.com/vgarcete98/PruebaTecnicaBackend.git

2. Restaurar dependencias --> dotnet restore

3. Ejecutar el proyecto --> dotnet run

4. El proyecto se levanta en los siguientes puertos :
https://localhost:7106
http://localhost:5106

Tambien estare integrando unb archivo postman con todas las configuraciones hechas para que el mismo se pueda importar y probar directamente
PruebaTecnicaBackend.postman_collection --> este es el nombre del archivo, tambien lo estare dejando por correo

# Cómo crear/aplicar migraciones SQLite (o cómo se crea la DB). 

1. Simplemente correr el proyecto, el mismo crea la base si es que no existe y en el mismo no debe existir ningun archivo con extension .db ni relacionados, o sea db-shm y db-wal
2. En el appsettings .json tener configurado el default connection que seria el nombre del archivo .db generado
{
    "ConnectionStrings": {
    "DefaultConnection": "Data Source=PruebaTecnicaBackend.db" --> Aqqui tiene que estar la localizacion del archivo de base de datos, en este caso esta en la raiz
    }
}

# sAPI Key de prueba y ejemplos de headers. 

La API Key se configura en appsettings.json:

{

  "X-API-KEY": "MI_API_KEY_SECRETA",

}

1. Ejemplo de request:
GET https://localhost:7106/users/1

2. Header:

X-API-KEY: MI_API_KEY_SECRETA



Aclarar qué quedó implementado y qué no (si algo faltó). 

Usuarios

| Función                | Estado          |
| ---------------------- | --------------- |
| Crear usuario          | ✔️ Implementado |
| Actualizar usuario     | ✔️ Implementado |
| Eliminar usuario       | ✔️ Implementado |
| Obtener usuario por ID | ✔️ Implementado |
| Listar usuarios        | ✔️ Implementado |


Direcciones del usuario

| Función                               | Estado          |
| ------------------------------------- | --------------- |
| Crear dirección                       | ✔️ Implementado |
| Actualizar dirección                  | ✔️ Implementado |
| Eliminar dirección                    | ✔️ Implementado |
| Obtener direcciones por ID de usuario | ✔️ Implementado |



Conversión de divisas
| Función                  | Estado          |
| ------------------------ | --------------- |
| Listar monedas           | ✔️ Implementado |
| Crear moneda             | ✔️ Implementado |
| Conversión entre monedas | ✔️ Implementado |




