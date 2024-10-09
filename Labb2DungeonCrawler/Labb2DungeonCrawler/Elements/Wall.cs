class Wall : LevelElement
{

    public Wall(LevelData levelData, int x, int y) : base(levelData, x, y, '#', ConsoleColor.Gray)
    {
        position.X = x;
        position.Y = y;
    }  
        
}

