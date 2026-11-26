namespace FirstDungeonMap.App.UI;

public static class MapRenderer
{
    public static void Print(char[,] map, int playerX = -1, int playerY = -1)
    {
        for (int y = 0; y < map.GetLength(0); y++)
    {
        for (int x = 0; x < map.GetLength(1); x++)
        {
            if (x == playerX && y == playerY)
            {
                Console.Write('@');
            }
            else
            {
                Console.Write(map[y, x]);
            }
        }
        Console.WriteLine();
    }
        // TODO: renderuj mapę w konwencji map[y, x]. Gracz ma być nakładką.
        Console.WriteLine($"[Mapa {map.GetLength(1)} × {map.GetLength(0)} — uzupełnij renderowanie]");
    }

    public static void PrintLegend()
    {
        Console.WriteLine("Legenda: # ściana | . podłoga | @ gracz | > wyjście | $ skarb");
    }
}
