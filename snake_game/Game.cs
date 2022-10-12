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
        public int playerTurn;
        public Boolean gameEnded = false;
        public Player? winner = null;

        public Game(Player p1, Player p2)
        {
            players = new Player[2];
            this.players[0] = p1;
            this.players[1] = p2;
            this.playerTurn = 0;
        }

        public void LoopGame()
        {
            // Loop of the game
            do
            {
                Player player = players[playerTurn];
                player.PlayRound();
                if (player.score > 50)
                    player.score = 25;

                gameEnded = player.score == 50 ? true : false;

                if (gameEnded)
                    winner = player;
                else 
                    // Change playerTurn
                    playerTurn = (playerTurn + 1) % 2;

            } while (!gameEnded);

            Console.WriteLine("Le joueur : " + winner.name + " à gagné");
        }

    }
}
