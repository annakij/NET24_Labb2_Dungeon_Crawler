# NET24_Labb2_Dungeon_Crawler

This is the second submitted project made through my education as a .NET developer in C#.

General instruction of the project:

A dungeon crawler is a type of role-playing game that involves players exploring labyrinth areas, known as dungeons, where they fight enemies and search for treasure. In this laboration, we build a somewhat simplified version of such a game in the form of a console application.

The game genre roguelike is usually based on so-called procedural generation, which is a method of generating random paths using algorithms. Since the focus of this lab is to be object-oriented programming, I have opted out of that part and instead created a ready-made path that you receive in the form of a text file.

The file represents a "dungeon" with two different kinds of monsters ("rats" & "snakes") deployed, and also has a predefined starting position for the player. Your task will be to write code that reads the file and splits into different objects (walls, players and enemies) in C# that independently keep track of their own data (e.g. position, color, health) and methods (e.g. .eg to move, or attack).
