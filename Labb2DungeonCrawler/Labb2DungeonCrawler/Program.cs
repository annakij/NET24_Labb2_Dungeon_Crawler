
LevelData levelData = new();

GameLoop newGame = new(levelData);

levelData.Load("Levels/Level1.txt");

newGame.Run();


