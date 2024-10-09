
class Rat : Enemy
{
    private Random random = new();
    public string Name { get; set; }
    
    public Rat (LevelData levelData, int x, int y) : base(levelData, x, y, 'r', ConsoleColor.Red)
    {
        Name = "Rat";
        Health = 10;
        AttackDice = new Dice(1, 6, 3);
        DefenceDice = new Dice(1, 6, 1);
    }
    public override void Update(Player player, Enemy enemy)
    {

    int moveX = position.X;
    int moveY = position.Y;

    Console.SetCursorPosition(moveX, moveY);
    Console.Write(" ");

    switch (random.Next(1, 5))
    {
        case 1:
            moveY--;
            break;
        case 2:
            moveY++;
            break;
        case 3:
            moveX--;
            break;    
        case 4:
            moveX++;
            break;
    }

    if (GetCollision(moveX, moveY) == null)
    {
        position.X = moveX;
        position.Y = moveY;
    }
    if (GetCollision(moveX, moveY) == player) 
    {   
        EnemyAttack(enemy, player);
    }
    }

    private LevelElement GetCollision(int x, int y)
    {
        foreach (var element in levelData.Elements)
        {
            if (element.position.X == x && element.position.Y == y)
                return element;
        }
        return null;
    }

    public void EnemyAttack(Enemy enemy, Player player)
    {
        
        int playerAttack = player.AttackDice.Throw() - enemy.DefenceDice.Throw();
        int enemyAttack = enemy.AttackDice.Throw() - player.DefenceDice.Throw();
        Console.SetCursorPosition(0, 2);

        if (enemyAttack > 0)
        {
            player.Health -= enemyAttack;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"The rat successfully backstabbed you and caused {enemyAttack} damage!".PadRight(Console.BufferWidth));
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("The rat tried to backstab you but your defence was too high!".PadRight(Console.BufferWidth));
        }

        if (playerAttack > 0 && enemyAttack > 0)
        {
            enemy.Health -= playerAttack;
            Console.ForegroundColor = ConsoleColor.DarkMagenta; 
            Console.WriteLine($"You lunged back and caused {playerAttack} damage!".PadRight(Console.BufferWidth));
        }

        Console.ResetColor();
    }
    
}

