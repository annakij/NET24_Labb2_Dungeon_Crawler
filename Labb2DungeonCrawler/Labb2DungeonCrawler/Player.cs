
class Player : LevelElement
{
    private LevelData levelData;
    public string Name { get; set; }
    public int Health { get; set; }
    public Dice AttackDice { get; set; }
    public Dice DefenceDice { get; set; }
    public Player(LevelData levelData, int x, int y) : base(levelData, x, y, '@', ConsoleColor.Blue)
    {
        Name = "Player";
        Health = 100;
        AttackDice = new Dice( 2, 6, 3 );
        DefenceDice = new Dice( 1, 6, 1 );
    }

}

