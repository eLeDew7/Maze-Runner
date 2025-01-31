using System;
using System.Collections.Generic;
using System.Text;
using Spectre.Console;

namespace MazeRunner{
    class Maze{
        int width; // ancho
        int height; // largo
         int[,] maze; // el laberinto
         static Random rand = new Random(); //numero aleatorio
        int[] dirx = { 0, 1, 0, -1 }; // direcciones del eje x
        int[] diry = { 1, 0, -1, 0 }; // direcciones del eje y

       public Maze(int width, int height) { // clase constructora del laberinto (Mismo nombre de la clase)
            this.width = width;
            this.height = height;
            maze = new int[width,height];
        }
        public void Generate()
        {
            MazeI();
            Backtrack(1, 1); // Comenzar dentro de los límites
            Borders();
            Points(35);
            Traps(5);
              Player p1 = Player.SelectCharacter();
              Player p2 = Player.SelectCharacter();
            Play.Game(p1, p2, height, width, maze);
             
        }
       private void MazeI() // Crea el laberinto con solo paredes
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    maze[i, j] = 1; // 1 representa una pared
                }
            }
        }
            private void Borders(){
         
        for (int i = 0; i < height; i++)
        {
            maze[i, 0] = 1;
            maze[i, width - 1] = 1;
        }
        for (int j = 0; j < width; j++)
        {
            maze[0, j] = 1;
            maze[height - 1, j] = 1;
        }
      
        maze[1, 0] = 0; // Entrada
        maze[height - 2, width - 1] = 0; // Salida
    }

        public static bool Bounds(int x, int y, int width, int height)
        {
            return x > 0 && x < height - 1 && y > 0 && y < width - 1; // comprueba si la posicion esta dentro de los limites permitidos
        }
        private void Shuffle(List<int> list){  // Toma una lista y mezcla aleatoriamente sus elementos
            for(int i = list.Count - 1; i > 0; i--) // de atras hacia delante para que cada elemento tenga la misma posibilidad de ser mezclado 
            {
                int j = rand.Next(i + 1); 
                int temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
        private void Backtrack(int x, int y)
        {
            maze[x, y] = 0; // 0 representa un camino

            List<int> directions = new List<int> { 0, 1, 2, 3 }; // La lista de direcciones que es mezclada para generar aleatoriedad
            Shuffle(directions);

           foreach (int direction in directions) 
            {
                int newx = x + dirx[direction] * 2;
                int newy = y + diry[direction] * 2;

                if (Bounds(newx, newy, width, height) && maze[newx, newy] == 1)
                {
                    maze[x + dirx[direction], y + diry[direction]] = 0; // Eliminar pared entre celdas
                    Backtrack(newx, newy);
                }
            }
        }
        private void Points(int n){
            for (int i = 0; i < n; i++)
            {
                int x, y;
                do
                {
                    x = rand.Next(1, height - 1);
                    y = rand.Next(1, width - 1);
                } while (maze[x, y] != 0); // Buscar una celda vacía
                maze[x, y] = 2; // 2 representa un coleccionable
            }
        }
        private void Traps(int n){
            for(int i = 0; i < n; i++){
                int x, y;
                do {
                    x = rand.Next(1, height - 1);
                    y = rand.Next(1, width - 1);
                } while(maze[x, y] != 0);
                maze[x, y] = 3;
                
            }
            for(int i = 0; i < n; i++){
                int x, y;
                do {
                    x = rand.Next(1, height - 1);
                    y = rand.Next(1, width - 1);
                } while(maze[x, y] != 0);
                maze[x, y] = 4;
        }
        for(int i = 0; i < n; i++){
                int x, y;
                do {
                    x = rand.Next(1, height - 1);
                    y = rand.Next(1, width - 1);
                } while(maze[x, y] != 0);
                maze[x, y] = 5;
         }
    }
}
}