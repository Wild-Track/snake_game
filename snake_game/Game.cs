
namespace Snake
{
	public class Game
	{
		public Player[] players { get; set; }
        public Player currentPlayer;
		public Player? winner = null;
		// Turn of player, can be 0 or 1
		public int playerTurn;
		public bool gameEnded = false;
		public int[] bonus = { 10, 20, 30, 40, 42 };

        public Game(Player p1, Player p2)
		{
			players = new Player[2];
			this.players[0] = p1;
			this.players[1] = p2;
			this.playerTurn = 0;
			currentPlayer = players[playerTurn];

			// Check players passed as an argument
            CheckPlayers(players);
		}

		private void CheckPlayers(Player[] players)
		{
			foreach (Player player in players)
			{
				if (player == null)
					throw new ArgumentNullException("Le player est vide");
				else if (player.score != 0)
					throw new CustomCheatingPlayerException(string.Format("ALERTE tricherie, le player : {0} est un tricheur", player.name));
			}
		}

		public void LoopGame()
		{
			do
			{
				currentPlayer.PlayRound();
				UpdateGameStatus();
			} while (!gameEnded);

			Win();
		}

		public void UpdateGameStatus()
		{
			if (currentPlayer.score > 50)
				currentPlayer.score = 25;
			else if (bonus.Contains(currentPlayer.score))
				return;
			else if (currentPlayer.score == 50)
			{
				gameEnded = true;
				winner = currentPlayer;
				return;
			}
			ChangeTurn();
		}

		public int ChangeTurn()
		{
            playerTurn = (playerTurn + 1) % 2;
			currentPlayer = players[playerTurn];
            return playerTurn;
        }

		public void Win()
		{
			if (winner == null)
				throw new ArgumentNullException();
			Console.WriteLine(string.Format("Le joueur : {0} à gagné", winner.name));
        }

		public class CustomCheatingPlayerException : Exception
		{
			public CustomCheatingPlayerException(string message) : base(message) { }
		}
	}
}
