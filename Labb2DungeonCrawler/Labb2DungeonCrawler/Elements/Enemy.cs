
abstract class Enemy : LevelElement
{

    public int Health { get; set; }
    public Dice AttackDice { get; set; }
    public Dice DefenceDice { get; set; }
    public abstract void Update(Player player, Enemy enemy);

    public Enemy(LevelData levelData, int x, int y, char element, ConsoleColor color) : base(levelData, x, y, element, color)
    {
        
    }
}

