using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake_game
{
    public class Player
    {
        public string name { get; }
        public int score { get; set; }
        private Random rnd;

        public Player(string name)
        {
            this.rnd = new Random();
            this.name = name;
            this.score = 0;
        }

        // Calculate new score of player
        public void PlayRound()
        {
            score += rnd.Next(1, 7);
            PrintRound();
        }

        public void PrintRound()
        {
            Console.WriteLine("Joueur : " + name + " son score est : " + score);
        }
    }
}
