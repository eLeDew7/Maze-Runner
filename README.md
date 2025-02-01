# Maze-Runner
Hell.o Maze es un juego de exploracion de laberinto por turnos para 2 jugadores cuyo objetivo consiste en recolectar una cierta cantidad de almas coleccionables en el mapa antes de avanzar hasta la casilla de salida.

Para jugarlo es necesario:
1: Tener Visual Studio Code instalado, junto con el dotnet funcionando correctamente
2: Descargar los archivos del repositorio y tenerlos en la carpeta en la que se encuentre tu metodo Main
3: Incluir en el metodo Main los namespace System, System.Text y MazeRunner
using MazeRunner;(de esta forma)
4: Escribir en el codigo Main:
int width = 25;
int height = 25;
Maze maze = new Maze(width, height);
maze.Generate();
5: Escribir dotnet run en la consola para ejecutar



La tematica del juego gira alrededor de algunos demonios que se encuentran aburridos en el infierno y deciden hacer apuestas en base a quien puede recolectar almas humanas mas rapido. Los demonios estan inspirados en miedos humanos y sus habilidades reflejan su naturaleza

Para elegir tu personaje, debes introducir en la consola el numero del personaje deseado. Si no introduces una opcion valida, se te asignara el demonio fantasma de forma automatica.

Cada personaje posee una cantidad de movimientos por turno, una meta, que representa el numero de puntos necesarios para desbloquear la condicion de victoria, y una habilidad unica. La habilidad viene con un tiempo de enfriamiento (cooldown), que determina los turnos que debe esperar antes de volver a usarla.

El juego consta de 6 demonios jugables:
1: El demonio fantasma: Para ganar debe recolectar 14 almas humanas, puede moverse 9 veces por turno y su habilidad le permite atravesar una pared.
2: El demonio tiburon: Requiere de 12 almas, puede moverse 6 veces por turno y su habilidad le permite desplazarse en linea recta hasta chocar contra una trampa o pared.
3: El demonio del hambre: Requiere de 12 almas tambien, puede moverse 8 veces por turno y su habilidad le permite comerse una trampa ( a cambio de un punto si esta es de teletransportacion o cooldown, si esta trampa es del tipo bomba, su efecto se le aplica al rival, restandole 5 puntos.
4: El demonio de los agujeros de gusano: Debe llegar a 14 puntos, puede moverse 8 veces por turno y su habilidad le permite crear un portal en una ubicacion del mapa y volver a este punto mas tarde
5: El demonio del espacio: Requiere de 12 almas, puede moverse 8 veces y su habilidad le permite intercambiar posiciones con el rival.
6: El demonio spider: Su meta es 12, sus movimientos son 7 y su habilidad le permite crear telas en casillas del mapa, si el rival las pisa, pierde 1 movimiento extra, y si el jugador las pisa, no pierde ningun movimiento.

Al iniciar el juego, es el turno del jugador 1. Para controlar utilizas WASD en la forma clasica de direcciones, y la habilidad se activa con la letra H. En el mapa habran una serie de objetos:

1: Coleccionables(corazon azul): son las almas que debes recolectar
2: Trampa bomba(⚠): Le reduce 3 puntos al jugador que la pise
3: Trampa cooldown(¶): Aumenta el tiempo de enfriamiento por 2 de forma permanente
4: Trampa Teletransporte(Φ): Te devuelve a tu casilla de inicio.

Para ganar, hay 2 posibles condiciones:
1: Tienes la cantidad requerida de puntos de tu personaje, en cuyo caso debes ir a tu casilla de salida para ganar.
2: Si todos los corazones del mapa son recolectados, gana el jugador que haya recolectado mas puntos (esto abre la posibilidad de empate)
