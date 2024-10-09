
class GameLoop
{
    private LevelData levelData;
    private bool IsVisible;

    public GameLoop( LevelData levelData)
    {
        this.levelData = levelData;
    }

    public void Run()
    {
        Player player = levelData.StartPlayer;
        Console.CursorVisible = false;
        int turn = 0;
        Console.Clear();
    
         while (player.Health > 0)
        {
            PlayerStatusHeader(turn);

            foreach (var element in levelData.Elements)
            {
                if ( player.position.DistanceTo(element.position) < 5 && element is Wall)
                {
                    element.Draw();
                    IsVisible = true;
                }
                if ( player.position.DistanceTo(element.position) < 5 && element is Enemy)
                {
                    element.Draw();
                }
                if ( element is Player)
                {
                    element.Draw();
                }
            }

            if (Console.KeyAvailable)
            {

                int moveX = player.position.X;
                int moveY = player.position.Y;

                Console.SetCursorPosition(moveX, moveY);
                Console.Write(" ");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        moveY--;
                        break;
                    case ConsoleKey.DownArrow:
                        moveY++;
                        break;
                    case ConsoleKey.LeftArrow: 
                        moveX--;
                        break;
                    case ConsoleKey.RightArrow:
                        moveX++;
                        break;
                    case ConsoleKey.Escape:
                        return;
                }
                
                LevelElement collision = GetCollision(moveX, moveY);

                if (collision == null)
                {
                    player.position.X = moveX;
                    player.position.Y = moveY;
                    turn++;
                }
                
                for (int i = levelData.Elements.Count - 1; i >= 0; i--)
                {
                    if (levelData.Elements[i] is Enemy enemy)
                    {
                        enemy.Update(player, enemy);

                        if (GetCollision(enemy.position.X, enemy.position.Y) == player)
                        {
                            EnemyAttack(enemy, player);
                        }

                        // Kontrollera efter EnemyAttack ifall fienden dog
                        if (enemy.Health < 0)
                        {
                            levelData.Elements.RemoveAt(i); // Ta bort fienden från listan
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("Enemy defeated and removed from level.".PadRight(Console.BufferWidth));
                        }
                    }
}


                if (collision is Enemy collisionEnemy)
                {
                    PlayerAttack(collisionEnemy, player);
                } 
            }     
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

    public void PlayerStatusHeader(int turn)
    {
        Player player = levelData.StartPlayer;
        string status = $"Player: You      -     Health: {player.Health}     -     Turn: {turn}   ";
        Console.SetCursorPosition(0, 1);
        Console.WriteLine(status);
    }

    public void PlayerAttack(Enemy enemy, Player player)
    {   
        int playerAttack = player.AttackDice.Throw() - enemy.DefenceDice.Throw();
        int enemyAttack = enemy.AttackDice.Throw() - player.DefenceDice.Throw();
        Console.SetCursorPosition(0, 2);

        if (playerAttack > 0)
        {
            enemy.Health -= playerAttack;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"The enemy suffered {playerAttack} damage!".PadRight(Console.BufferWidth));
        }
                    
        if (enemy.Health < 0)
        {
            levelData.Elements.Remove(enemy);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("The enemy plunged to death and dissapeared into the void.".PadRight(Console.BufferWidth));
        }

        else if (enemyAttack > 0 && enemy.Health > 0)
        {
            player.Health -= enemyAttack;
            Console.ForegroundColor = ConsoleColor.DarkRed; 
            Console.WriteLine($"Ouch! You suffered {enemyAttack} damage!".PadRight(Console.BufferWidth));
        }
        
        Console.ResetColor();
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
            Console.WriteLine($"The enemy successfully backstabbed you and caused {enemyAttack} damage!".PadRight(Console.BufferWidth));
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("The enemy tried to backstab you but your defence was too high!".PadRight(Console.BufferWidth));
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

