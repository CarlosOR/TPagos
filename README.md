# TPagos


El api cuenta con una arquitectura orientada a capas, cuenta con una estructura jerárquica la cual contiene 4 capas principales las cuales están enumeradas Presentación, Aplicación, Dominio y Persistencia (en ese orden).

- Presentación: contiene todos los controladores y parte de los filter que se van a usar.
- Aplicación: Contiene parte de la lógica del negocio, su función es estructurar los datos para que lleguen lo más limpios a la cama de Dominio, así como ejecutar los procesos necesarios que se requieren.
- Dominio: Contiene otra parte de la lógica del negocio, su función es insertar, actualizar, consultar o eliminar datos basado en la lógica de la capa de aplicación, no obstante, en esta capa se maneja la lógica de la base de datos (como se deben guardar los datos y si requiere completar otras tablas)
- Persistencia: Contiene la configuración para la conexión a la base de datos, implementa el patrón repository para dar acceso limitado a la BD.

Las otras capas que acompañan la solución como Modelos, Resolver, Transversal y Test, son capas que proporcionaran configuración o modelos en las diferentes capas.

- Modelos: Contiene los modelos tanto Dtos como las entidades de la base de datos.
- Resolver: Realiza la configuración de la inyección de dependencias, también se usa para agregar otras configuraciones típicas del startup, como Swagger, Automapper, resolver el contexto, resolver cualquier otra librería
- Transversal: Cuenta con implementaciones que sirven para todo el proyecto, en esta se encuentra el control de excepciones y la configuración para obtener los datos del appsettings
- Test: XUnit, en este irán las pruebas correspondientes al proyecto (aún falta agregar, solo está la configuración)

En la capa de presentación (API) se encuentra una carpeta llamada Filters en ella habrá una clase llamada ResultFilterAttribute:

```sh
public class ResultFilterAttribute : ActionFilterAttribute
```
Esta hereda de una clase llamada ActionFilterAttribute e implementa un método 'OnActionExecuted' esta sirve para encapsular la petición de respuesta y modificarla en caso de ser necesario, esto comunmente se usa para evitar repetir código con una clase genérica que siempre se devuelve en los controladores, en este caso se intercepta la petición de salida y se le aplica el modelo estándar que se requiera.

Otro filter que se usa es el de excepciones 

```sh
public class ControlExceptionFilterAttribute : ExceptionFilterAttribute
```

Este se encuentra en la capa transversal en el proyecto 'ExceptionsHandling', este filtro permite capturar las excepciones y modificar su respuesta, esto es muy util para evitar mostrar contenido sensible de la aplicación cuando esta estalla, por otro lado, también sirve para agregar mensajes en caso de que se quieran agregar códigos de error.

En la capa Models hay una carpeta llamada Mapper esta tendrá una clase en la cual está configurado un mapeo

```sh
public class GeneralMapper: Profile
```

Esto es bastante util para no pasar DTOs a la capa de dominio, ya que es una mala práctica pasar información que no corresponde al de las entidades de la BD a la capa de dominio, por lo tanto el automapper se usa en la capa de aplicación.


Se trato de realizar una implementación para poder ejecutar la aplicación con la BD en memoria, sin embargo, no se alcanzó a implementar. Algunos rastros de ella están marcados en la clase PersistenciaResolver

```sh
public static class PersistenceResolver
```


#Usar el API

Para usar el api en la capa de persistencia existe una carpeta llamada SqlResources, buscaremos el siguiente archivo

```sh
SqlResources -> Sql -> InitialMigration.sql
```
En este archivo estará la creación de la base de datos y la inserción de otro. (Se iban a crear migraciones, pero por cuestión de tiempo no fue posible)
- Una vez se cree la base de datos se modifica el archivo la cadena de conexión en el appsettings.Development.
- Hecho esto se corre la aplicación y se abre Swagger para realizar las pruebas


