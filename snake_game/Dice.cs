
namespace Snake
{
    public class Dice
    {
        public int minimum;
        public int maximum;
        private Random? random;
        public int lastNumber;

        public Dice(int minimum, int maximum)
        {
            if (minimum >= maximum || minimum < 0 || maximum < 0)
                throw new ArgumentException("Please choose the correct bounds");
            this.minimum = minimum;
            this.maximum = maximum;
        }

        public int RollDice()
        {
            random = new Random();
            lastNumber = random.Next(minimum, maximum);
            return lastNumber;
        }
    }
}
