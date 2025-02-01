using System;
using System.Collections.Generic;
using System.Text;
namespace MazeRunner{
class Player{
    public string Name { get; set; }
    public string icon { get; set; }
    public int moves { get; set; }
    public int cooldown { get; set; }
    public int goal { get; set; }
    public int points { get; set; }
    public int ghost {get; set; }
    public int shark {get; set; }
    public int hunger { get; set; }
    public int iden { get; set; }   

    public Player(string name, int movesPerTurn, int id, int go, int cd, string i)
        {
            Name = name;
            icon = i;
            moves = movesPerTurn;
            points = 0;
            goal = go;
            iden = id;
            ghost = 0;
            hunger = 0;
            shark = 0;
            cooldown = cd;
        }
    public int Skill(int id){
        if(id == 0 || id == 2 || id == 1){
             return 1;
        }
        else{
            return 0;
        }
    }
     public static Player SelectCharacter()
        {
            Console.WriteLine("1. Ghost Devil");
            Console.WriteLine("2. Shark Devil");
            Console.WriteLine("3. Hunger Devil");
            Console.WriteLine("4. WormHole Devil");
            Console.WriteLine("5. Space Devil");
            Console.WriteLine("6. Spider Devil");
            Console.WriteLine("Selecciona el número de tu personaje:");

            int choice = int.Parse(Console.ReadLine());
            return choice switch
            {
                1 => new Player("Ghost Devil", 9, 0, 14, 2, "👻"),
                2 => new Player("Shark Devil", 6, 1, 12, 4, "🦈"),
                3 => new Player("Hunger Devil", 8, 2, 12, 3, "🐽"),
                4 => new Player("WormHole Devil", 8, 3, 14, 3, "🐛"),
                5 => new Player("Space Devil", 8, 4, 12, 4, "👾"),
                6 => new Player("Spider Devil", 7, 5, 12, 1, "🕷 "),
                _ => new Player("Ghost Devil", 9, 0, 14, 2, "👻"),
            };
}
}
}
