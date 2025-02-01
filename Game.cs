using System.Collections.Generic;
using System;
using System.Text;
namespace MazeRunner{
    class Play{
  public static void Game(Player p1, Player p2, int height, int width, int[,] maze){
            
            int p1X = 1, p1Y = 0;
            int p2X = height - 2, p2Y = width - 1;
            int tPoints = 35;

            int p1Score = 0;
            int p2Score = 0;
            int maxg1 = p1.goal;
            int maxg2 = p2.goal;
            int cd1 = p1.cooldown;
            int cd2 = p2.cooldown;
            int pcount1 = 0;
            int pcount2 = 0;
            int pp1X = 0;
            int pp1Y = 0;
            int pp2X = 0;
            int pp2Y = 0;
            string icon1 = p1.icon;
            string icon2 = p2.icon;
            //int g1 = 0;
            //int g2 = 0;


            Player cPlayer = p1;
            int movesLeft = cPlayer.moves;
            


            while(true){
              

              Console.Clear();
              Show.Maze(p1X, p1Y, p2X, p2Y, maze, height, width, icon1, icon2);

              Console.WriteLine($"Es el turno del {(cPlayer == p1 ? "Jugador 1" : "Jugador 2")}");
              Console.WriteLine($"Puntos recolectados: {cPlayer.points}, quedan {TruepointC(cPlayer.goal , cPlayer.points)}");
              Console.WriteLine($"Movimientos restantes: {movesLeft}");
              Console.WriteLine($"Pulse H para activar la habilidad");
              Console.WriteLine($"Cooldown: {cPlayer.cooldown} turnos");
              
              ConsoleKey key = Console.ReadKey(true).Key;
              

              int newX = (cPlayer == p1 ? p1X : p2X);
              int newY = (cPlayer == p1 ? p1Y : p2Y);

              if(key == ConsoleKey.H && cPlayer.cooldown == 0){
                  if(cPlayer.iden == 0){
                    cPlayer.ghost = cPlayer.Skill(0);
                    if(cPlayer == p1){
                      cPlayer.cooldown = cd1;
                    }
                    else{
                    cPlayer.cooldown = cd2;
                    } 
                  }
                  else if(cPlayer.iden == 1){
                    cPlayer.shark = cPlayer.Skill(1);
                    if(cPlayer == p1){
                      cPlayer.cooldown = cd1;
                    }
                    else{
                      cPlayer.cooldown = cd2;
                    }
                  }
                  else if(cPlayer.iden == 2){
                    cPlayer.hunger = cPlayer.Skill(2);
                    if(cPlayer == p1){
                      cPlayer.cooldown = cd1;
                    }
                    else{
                      cPlayer.cooldown = cd2;
                    }
                  }
                  else if(cPlayer.iden == 3){
                    if(cPlayer == p1){
                      cPlayer.cooldown = cd1;
                      if(pcount1 == 0){
                        maze[p1X, p1Y] = 6;
                      pcount1 = 1;
                      pp1X = p1X;
                      pp1Y = p1Y;
                      }
                      else{
                        newX = pp1X;
                        newY = pp1Y;
                        maze[pp1X, pp1Y] = 0;
                        pcount1 = 0;
                      }
                      
                    }
                    else if(cPlayer == p2){
                      cPlayer.cooldown = cd2;
                      if(pcount2 == 0){
                      maze[p2X, p2Y] = 6;
                      pcount2 = 1;
                      pp2X = p2X;
                      pp2Y = p2Y;
                      }
                    else{
                    newX = pp2X;
                    newY = pp2Y;
                    maze[pp2X, pp2Y] = 0;
                    pcount2 = 0;
                    } 
                     
                    }
                  }
                  else if(cPlayer.iden == 4){
                    if(cPlayer == p1){
                      int x = p2X;
                      p2X = newX;
                      int y = p2Y;
                      p2Y = newY;
                      newX = x;
                      newY = y;

                      cPlayer.cooldown = cd1;
                    }
                    else{
                      int x = p1X;
                      p1X = newX;
                      int y = p1Y;
                      p1Y = newY;
                      newX = x;
                      newY = y;
                      cPlayer.cooldown = cd2;
                    }
                  }
                  else if(cPlayer.iden == 5){
                    if(cPlayer == p1){
                      cPlayer.cooldown = cd1;
                        maze[p1X, p1Y] = 7;
                      }
                      else{
                        cPlayer.cooldown = cd2;
                        maze[p2X, p2Y] = 8;
                      }
                      
                    }
                  }
              
              else if (key == ConsoleKey.W && cPlayer.shark == 0) newX--;

              else if (key == ConsoleKey.W && cPlayer.shark == 1){
                while(Maze.Bounds(newX, newY, width, height) && maze[newX, newY] != 1 && maze[newX, newY] != 3 && maze[newX, newY] != 4 && maze[newX, newY] != 5){
                  newX--;
                }
                cPlayer.shark = 0; 
                 if (cPlayer == p1)
                    {
                        p1X = newX;
                        p1Y = newY;
                        
                    }
                    else
                    {
                        p2X = newX;
                        p2Y = newY;
                         
                    }
              }

              else if (key == ConsoleKey.S && cPlayer.shark == 0) newX++;

              else if (key == ConsoleKey.S && cPlayer.shark == 1){
                while(Maze.Bounds(newX, newY, width, height) && maze[newX, newY] != 1 && maze[newX, newY] != 3 && maze[newX, newY] != 4 && maze[newX, newY] != 5){
                  newX++;
                }
                cPlayer.shark = 0;
                 if (cPlayer == p1)
                    {
                        p1X = newX;
                        p1Y = newY;
                        
                    }
                    else
                    {
                        p2X = newX;
                        p2Y = newY; 
                         
                    }
              }
              else if (key == ConsoleKey.A && cPlayer.shark == 0) newY--;

              else if (key == ConsoleKey.A && cPlayer.shark == 1){
                while(Maze.Bounds(newX, newY, width, height) && maze[newX, newY] != 1 && maze[newX, newY] != 3 && maze[newX, newY] != 4 && maze[newX, newY] != 5){
                  newY--;
                }
                cPlayer.shark = 0;
                 if (cPlayer == p1)
                    {
                        p1X = newX;
                        p1Y = newY;
                        
                    }
                    else
                    {
                        p2X = newX;
                        p2Y = newY;
                         
                    }
              }
              else if (key == ConsoleKey.D && cPlayer.shark == 0) newY++;
              else if (key == ConsoleKey.W && cPlayer.shark == 1){
                while(Maze.Bounds(newX, newY, width, height) && maze[newX, newY] != 1 && maze[newX, newY] != 3 && maze[newX, newY] != 4 && maze[newX, newY] != 5){
                  newY++;
                }
                cPlayer.shark = 0;
                 if (cPlayer == p1)
                    {
                        p1X = newX;
                        p1Y = newY;
                        
                    }
                    else
                    {
                        p2X = newX;
                        p2Y = newY;
                         
                    }
              }

               if (Maze.Bounds(newX, newY, width, height) && maze[newX, newY] != 1 && cPlayer.ghost == 0)
                {
                  

                    if (maze[newX, newY] == 2) // Coleccionable encontrado
                    {
                        if (cPlayer == p1){
                          cPlayer.points++;
                          
                          } 
                        else{
                          p2.points++;
                        } 

                        maze[newX, newY] = 0;
                        tPoints--;
                    }
                    else if(maze[newX, newY] == 3 ){
                      if(cPlayer.hunger == 0){
                      if (cPlayer == p1){
                          cPlayer.points-=3;
                          }
                         
                        else{
                          p2.points-=3;
                          }
                         

                        maze[newX, newY] = 0;
                      }
                      else if(cPlayer.hunger == 1){
                        if (cPlayer == p1){
                          p2.points-=5;
                        }
                        else{
                          p1.points-=5;
                        }
                        maze[newX, newY] = 0;
                        cPlayer.hunger = 0;
                      }
                    }
                    else if(maze[newX, newY] == 4){
                      if(cPlayer.hunger == 0){
                      if(cPlayer == p1){
                        cd1+= 2;
                      } 
                      else{
                        cd2+= 2;
                      }
                        maze[newX, newY] = 0;
                      }
                      else if(cPlayer.hunger == 1){
                        maze[newX, newY] = 0;
                        cPlayer.hunger = 0;
                        cPlayer.points -= 1;
                      }
                    }
                    else if(maze[newX, newY] == 5){
                      if(cPlayer.hunger == 0){     
                        if(cPlayer == p1){
                        maze[newX, newY] = 0;
                        newX = 1;
                        newY = 0;
                        }
                        else{
                          maze[newX, newY] = 0;
                        newX = height - 2;
                        newY = width - 1;
                        }
                      }
                      else if(cPlayer.hunger == 1){
                        maze[newX, newY] = 0;
                        cPlayer.hunger = 0; 
                        cPlayer.points -= 1;
                      }
                    }
                    else if(maze[newX, newY] == 7){
                      if(cPlayer == p1){
                        movesLeft++;
                      }
                      else{
                        if(movesLeft > 0){
                        movesLeft--;
                        }
                      }
                    }
                    else if(maze[newX, newY] == 8){
                      if(cPlayer == p2){
                        movesLeft++;
                      }
                      else{
                        if(movesLeft > 0){
                        movesLeft--;
                        }
                      }
                    }
                     

                    if (cPlayer == p1)
                    {
                        p1X = newX;
                        p1Y = newY;
                        
                    }
                    else
                    {
                        p2X = newX;
                        p2Y = newY;
                         
                    }

                    movesLeft--;
                   
                if (movesLeft == 0)
                {
                  if(cPlayer == p1){
                  if(p1.cooldown > 0){
                          p1.cooldown--;
                        }
                }
                else{
                  if(p2.cooldown > 0){
                    p2.cooldown--;
                  }
                }
                    movesLeft = cPlayer.moves;
                    cPlayer = cPlayer == p1 ? p2 : p1;
                 
                }
                 if(tPoints > 0){
                 if (p1X == height - 2 && p1Y == width - 2 && p1.points >= p1.goal)
                {
                    Console.Clear();
                    Show.Maze(p1X, p1Y, p2X, p2Y, maze, height, width, icon1, icon2);
                    Console.WriteLine($"{p1.Name} ha ganado! 🎉");
                    break;
                }
                else if (p2X == 1 && p2Y == 1 && p2.points >= p2.goal)
                {
                    Console.Clear();
                    Show.Maze(p1X, p1Y, p2X, p2Y, maze, height, width, icon1, icon2);
                    Console.WriteLine($"{p2.Name} ha ganado! 🎉");
                    break;
                }
                }
                else if(tPoints == 0){
                  if(PW(p1.points , p2.points) == 2){
                    Console.Clear();
                    Show.Maze(p1X, p1Y, p2X, p2Y, maze, height, width, icon1, icon2);
                    Console.WriteLine($"Es un empate!");
                    break;
                  }
                  else if(PW(p1.points , p2.points) == 1){
                    Console.Clear();
                    Show.Maze(p1X, p1Y, p2X, p2Y, maze, height, width, icon1, icon2);
                    Console.WriteLine($"{p1.Name} ha ganado! 🎉");
                    break;
                  }
                  else if(PW(p1.points , p2.points) == 0){
                    Console.Clear();
                    Show.Maze(p1X, p1Y, p2X, p2Y, maze, height, width, icon1, icon2);
                    Console.WriteLine($"{p2.Name} ha ganado! 🎉");
                    break;
                  }
                }



                }
                else if(cPlayer.ghost == 1 && Maze.Bounds(newX, newY, width, height) && ((newX != 1 || newX != 0) && (newY != 1 || newY != 0)  ) ){
                  if(maze[newX, newY] == 1){
                    cPlayer.ghost = 0;
                  }
                  if (maze[newX, newY] == 2) // Coleccionable encontrado
                    {
                        if (cPlayer == p1){
                          cPlayer.points++;
                          
                          } 
                        else{
                          p2.points++;
                        } 

                        maze[newX, newY] = 0;
                        tPoints--;
                    }
                    else if(maze[newX, newY] == 3){
                      if (cPlayer == p1){
                          cPlayer.points-=3;
                          }
                         
                        else{
                          p2.points-=3;
                          }
                         

                        maze[newX, newY] = 0;
                    }
                    else if(maze[newX, newY] == 4){
                      if(cPlayer == p1){
                        cd1+= 2;
                      } 
                      else{
                        cd2+= 2;
                      }

                        maze[newX, newY] = 0;
                    }
                    else if(maze[newX, newY] == 5){     
                        if(cPlayer == p1){
                        maze[newX, newY] = 0;
                        newX = 1;
                        newY = 0;
                        }
                        else{
                          maze[newX, newY] = 0;
                        newX = height - 2;
                        newY = width - 1;
                        }
                        
                    }
                    else if(maze[newX, newY] == 7){
                      if(cPlayer == p1){
                        movesLeft++;
                      }
                      else{
                        if(movesLeft > 0){
                        movesLeft--;
                        }
                      }
                    }
                    else if(maze[newX, newY] == 8){
                      if(cPlayer == p2){
                        movesLeft++;
                      }
                      else{
                        if(movesLeft > 0){
                        movesLeft--;
                        }
                      }
                    }
                    
                     

                    if (cPlayer == p1)
                    {
                        p1X = newX;
                        p1Y = newY;
                        
                    }
                    else
                    {
                        p2X = newX;
                        p2Y = newY;
                    }

                    movesLeft--;
                   
                if (movesLeft == 0)
                {
                  if(cPlayer == p1){
                  if(p1.cooldown > 0){
                          p1.cooldown--;
                        }
                }
                else{
                  if(p2.cooldown > 0){
                    p2.cooldown--;
                  }
                }

                    movesLeft = cPlayer.moves;
                    cPlayer = cPlayer == p1 ? p2 : p1;
                  
                }
                if(tPoints > 0){
                 if (p1X == height - 2 && p1Y == width - 2 && p1.points >= p1.goal)
                {
                    Console.Clear();
                    Show.Maze(p1X, p1Y, p2X, p2Y, maze, height, width, icon1, icon2);
                    Console.WriteLine($"{p1.Name} ha ganado! 🎉");
                    break;
                }
                else if (p2X == 1 && p2Y == 1 && p2.points >= p2.goal)
                {
                    Console.Clear();
                    Show.Maze(p1X, p1Y, p2X, p2Y, maze, height, width, icon1, icon2);
                    Console.WriteLine($"{p2.Name} ha ganado! 🎉");
                    break;
                }
                }
                else if(tPoints == 0){
                  if(PW(p1.points , p2.points) == 2){
                    Console.Clear();
                    Show.Maze(p1X, p1Y, p2X, p2Y, maze, height, width, icon1, icon2);
                    Console.WriteLine($"Es un empate!");
                    break;
                  }
                  else if(PW(p1.points , p2.points) == 1){
                    Console.Clear();
                    Show.Maze(p1X, p1Y, p2X, p2Y, maze, height, width, icon1, icon2);
                    Console.WriteLine($"{p1.Name} ha ganado! 🎉");
                    break;
                  }
                  else if(PW(p1.points , p2.points) == 0){
                    Console.Clear();
                    Show.Maze(p1X, p1Y, p2X, p2Y, maze, height, width, icon1, icon2);
                    Console.WriteLine($"{p2.Name} ha ganado! 🎉");
                    break;
                  }
                }
                }
                
                  
            
        }
  }
        private static int TruepointC(int goal, int points){
          if(goal - points < 0){
            return 0;
          }
          else{
            return goal - points;
          }
    }
    private static int PW(int x, int y){
      if(x == y){
        return 2;
      }
      else if(Math.Max(x , y) == x){
        return 1;
      }
      else{
        return 0;
      }
    }
  }
    
}
