
namespace Snake
{
    public class Player
    {
        public string name;
        public int score;
        public Dice dice;

        public Player(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name is null");
            this.name = name;
            this.score = 0;
            this.dice = new Dice(1, 7);
        }

        // Calculate new score of player
        public void PlayRound()
        {
            score += dice.RollDice();

            Console.WriteLine(RoundToString());
        }

        public string RoundToString()
        {
            return "Joueur : " + name + " son score est : " + score;
        }
    }
}
