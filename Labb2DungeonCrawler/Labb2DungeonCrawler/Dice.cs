class Dice
{
    private int numberOfDice;
    private int sidesPerDice;
    private int modifier;
    private Random random;
    public Dice(int numberOfDice, int sidesPerDice, int modifier)
    {
        this.numberOfDice = numberOfDice;
        this.sidesPerDice = sidesPerDice;
        this.modifier = modifier;
        this.random = new Random();
    }

    public int Throw()
    {
        sidesPerDice = 6;
        numberOfDice = random.Next(1, 4);
        modifier = random.Next(1, 7);
        int total = numberOfDice * sidesPerDice + modifier;

        return total;
    }

    public override string ToString()
    {
        return $"{numberOfDice}d{sidesPerDice} + {modifier} => {numberOfDice * sidesPerDice + modifier}";
    }

}

