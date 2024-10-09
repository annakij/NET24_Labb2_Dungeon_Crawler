class Snake : Enemy
{
    public string Name { get; set;}

    public Snake (LevelData levelData, int x, int y) : base(levelData, x, y, 's', ConsoleColor.Green)
    {
        Name = "Snake";
        Health = 25;
        AttackDice = new Dice(1, 6, 3);
        DefenceDice = new Dice(1, 6, 1);
    }
    public override void Update(Player player, Enemy enemy)
    {
        int moveX = position.X;
        int moveY = position.Y;

        Console.SetCursorPosition(moveX, moveY);
        Console.Write(" ");

        double distance = position.DistanceTo(player.position);

        if (distance < 2)
        {
            if (moveX < player.position.X)
            {
                moveX--;
            }
            else 
            {
                moveX++;
            }
            if (moveY < player.position.Y)
            {
                moveY--;
            }
            else
            {
                moveY++;
            }

        }

        if (GetCollission(moveX, moveY) == null) // ändra till GetCollision här?
        {
            position.X = moveX;
            position.Y = moveY;
        }
        if (GetCollission(moveX, moveY) == player)   
        {
            EnemyAttack(enemy, player);
        }  
    }

    public LevelElement GetCollission(int moveX, int moveY)
    {
        foreach (var element in levelData.Elements)
        {
            if (element.position.X == moveX && element.position.Y == moveY)
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
            Console.WriteLine($"The snake successfully bit you and caused {enemyAttack} damage!".PadRight(Console.BufferWidth));
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("The snake tried to bite you but your defence was too high!".PadRight(Console.BufferWidth));
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

