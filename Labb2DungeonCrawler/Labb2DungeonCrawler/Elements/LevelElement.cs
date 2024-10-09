

abstract class LevelElement
{
    public Position position;
    protected char Element { get; set; }
    protected ConsoleColor Color { get; set; }

    protected LevelData levelData;

    public LevelElement(LevelData levelData, int x, int y, char element, ConsoleColor color)
    {
        this.levelData = levelData;
        this.position = new Position(x, y);
        Element = element;
        Color = color;
    }

    public void Draw()
    {
        Console.SetCursorPosition(position.X, position.Y);
        Console.ForegroundColor = Color; 
        Console.Write(Element); 
        Console.ResetColor(); 
    }

}

