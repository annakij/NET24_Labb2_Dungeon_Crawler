

class LevelData
{
    private List<LevelElement> _elements = new List<LevelElement>();
    public List<LevelElement> Elements{ get { return _elements; } }
    public Player StartPlayer { get; private set; }

    public void Load(string filename)
    {
        using (StreamReader reader = new StreamReader(filename))
        { 
            int y = 5;
            
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                
                for ( int x = 0; x < line.Length; x++)
                {
                    char c = line[x];

                    if ( c == '#' )
                    {
                        Elements.Add(new Wall(this, x, y));
                    }
                    else if ( c == 'r' )
                    {
                        Elements.Add(new Rat(this, x, y));
                    }
                    else if ( c == 's' )
                    {
                        Elements.Add(new Snake(this, x, y));

                    }
                    else if (c == '@')
                    {
                        Player player = new Player(this, x, y);
                        StartPlayer = player;
                        Elements.Add(player);
                    }
                    else
                    {
                        continue;
                    }  
                }
                y++;
            }          
        }
    }
}

