# Bienvenido a la solución del desafio técnico en .NET
Hola, gracias por tomarme en cuenta y también por la oportunidad para poder optar para una plaza
en su empresa :D

## ¿En que consiste el desafio?
>El presente desafio consiste en desarrollar una **REST API** básica en *.NET Core* que
>realice operaciones *CRUD* sobre un recurso simple <ins>(en mi caso serán, "Productos")</ins>

## Funciones de la API
1. La API fue desarrollada utilizando .NET Core en su versión _8_
2. El controlador implementa los siguientes endpoints:
   - GET /api/Products -> Obtiene todos los elementos de la lista
   - GET /api/Products/{id} -> Obtiene un elemento por su ID
   - POST /api/Products -> Crea un nuevo elemento
   - PUT /api/Products/{id} -> Actualiza un elemento por su ID
   - DELETE /api/Products/{id} -> Elimina un elemento por su ID
3. La API _no_ está conectada a ninguna base de datos para guardar información, la información está almacenada en una lista en memoria (List<Product>).

## Extras
1. Se implementó Swagger para la documentación de la API
   - Página principal
    ![Screenshot de la página principal de Swagger.](/assets/ssSwagger.png)
   - Testeando el endpoint GET
    ![Screenshot del método GET obteniendo los objetos almacenados en la lista.](/assets/ssSwaggerGet.png)
   - Testeando el endpoint DELETE
    ![Screenshot del método DELETE obteniendo mensaje de eliminación exitosa.](/assets/ssSwaggerDelete.png)
2. Se utilizó el patrón de diseño __Dependency Injection__ en el controlador.
3. Se incluyeron validaciones básicas en el modelo
   - Nombre del producto obligatorio
    ![Screenshot mostrando error al no ingresar el nombre del producto.](/assets/ssRequiredName.png)
   - Precio del producto mayor a 0 (cero)
    ![Screenshot mostrando error al ingresar precio menor a 0 (cero)](/assets/ssNoZeroPrice.png)

## Utilización de la API (En VisualStudioCode)
Para utilizar la API debes seguir los siguientes pasos:

> [!IMPORTANT]
> Para el correcto funcionamiento asegurate de tener instalado el SDK de .NET, te recomiendo seguir esta guía la cual es brindada por Microsoft: https://learn.microsoft.com/es-es/training/modules/install-configure-visual-studio-code/

1. Clonar el repositorio con el siguiente comando:
`git clone https://github.com/Andy117/simpleApiRestDesafioEy.git`
2. Debes abrir la términal y ejecutar los siguientes comandos:
   - Primero debes compilar el proyecto con: `dotenv build`
   - Luego ya puedes ejecutar el proyecto con: `dotenv run`
> [!TIP]
> También puedes utilizar _watch_ para que no tengas que reiniciar la aplicación de forma manual cuando realices un cambio, para ello ejecuta el siguiente comando: `dotenv watch -lp https` (recomiendo esta opción)
3. Ya puedes comenzar a utilizar la API :D
- Página principal de Swagger para la documentación
    ![Screenshot de la página principal de Swagger.](/assets/ssSwagger.png)