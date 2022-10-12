using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake_game
{
    public class Game
    {
        public Player[] players { get; set; }
        // Turn of player, can be 0 or 1
        public int turn;

        public Game(Player p1, Player p2)
        {
            players = new Player[2];
            this.players[0] = p1;
            this.players[1] = p2;
            this.turn = 0;
        }

        public void LoopGame()
        {
            // Loop of the game
            do
            {
                Player player = players[turn];
                player.playRound();
                if (player.score > 50)
                    player.score = 25;

                // Change turn
                turn = (turn + 1) % 2;
            } while (players[turn].score != 50);

            Console.WriteLine("Le joueur : " + players[(turn + 1) % 2].name + " à gagné");
        }
    }
}
