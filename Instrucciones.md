## Instrucciones de ejecución del proyecto

FrontEnd en angular

+ Tener instalado en el equipo el gestor de paquetes npm (https://nodejs.org/en/download/)
+ Abrir el proyecto en visual studio code para ejecutar un terminal o ejecutar directamente
+ Ejecutar sobre la carpeta del proyecto la instrucción npm install
+ Es posible que algún paquete haya que instalarlo manualmente con npm install {paquete a instalar}

BackEnd en .net core

+ Tener instalado en el equipo alguna versión de visual studio (como visual studio community 2019) con las características de aplicaciones web instalada
+ Instalar los paquetes nugets con las dependencias de los dos proyectos principales (excluyendo el de bbdd)
+ Ejecutar el proyecto para debugar

Base de datos

+ En el proyecto en .net core existe un proyecto con el script sql para ejecutar, debe existir la base de datos con el nombre PruebaPlayaSenatorDataBase en el sistema y ejecutar el script sobre dicha bbdd
+ Sustituir en el proyecto principal de .net core la cadena de conexión por las credenciales válidas para acceder a dicha bbdd (debe estar habilitada la conexión tcp con credenciales válidas (usuario y contraseña, no local con autenticación de windows) a sql server)
