using System;
using System.Collections.Generic;
using System.Text;
namespace MazeRunner{
  public class Show{
    public static void Maze(int p1X, int p1Y, int p2X, int p2Y, int[,] maze, int height, int width, string icon1, string icon2){
      Console.OutputEncoding = System.Text.Encoding.UTF8;
      StringBuilder buffer = new StringBuilder();
      for (int i = 0; i < height; i++)
        {
          for (int j = 0; j < width; j++)
            {
              if (i == p1X && j == p1Y)
                    {
                        buffer.Append(icon1); // Jugador 1
                    }
                    else if (i == p2X && j == p2Y)
                    {
                        buffer.Append(icon2); // Jugador 2
                    }
                    else if (maze[i, j] == 1)
                    {
                        buffer.Append("██"); // Paredes
                    }
                    else if((i == height - 2 && j == width - 2) || i == 1 && j == 1){
                      buffer.Append("✅");
                    }
                    else if (maze[i, j] == 0) // Caminos
                    {
                      buffer.Append("  ");
                    }
                    else if (maze[i, j] == 2) // Puntos
                    {
                      buffer.Append("💙");
                    }
                    else if (maze[i, j] == 3) // Bomba 1
                    {
                      buffer.Append("⚠ ");
                    }
                    else if (maze[i, j] == 4) // Bomba 2
                    {
                      buffer.Append("¶ ");
                    }
                    else if (maze[i, j] == 5) // Bomba 3
                    {
                      buffer.Append("Φ ");
                    }
                    else if (maze[i, j] == 6)
                    {
                      buffer.Append("P ");
                    }
                    else if (maze[i, j] == 7)
                    {
                      buffer.Append("▒▒");
                    }
                    else if (maze[i, j] == 8)
                    {
                      buffer.Append("▓▓");
                    }
            }
          buffer.AppendLine();
        }
        Console.Clear();
        Console.Write(buffer.ToString());
    }
  }
}
