namespace FirstDungeonMap.Core.Maps;

public static class DungeonMap
{
    
    public static char[,] Create(int width, int height)
    {
            if (width < 3 || height < 3)
        {
            throw new ArgumentOutOfRangeException(
                nameof(width),
                "Wymiary mapy (width oraz height) muszą wynosić co najmniej 3.");
        }
            char[,] map = new char[height, width];

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (y == 0 || y == height - 1 || x == 0 || x == width - 1)
                {
                 map[y, x] = '#';
                }
                else
                {
                    map[y, x] = '.';
                }
            }
        // TODO: zbuduj podłogę i ściany na krawędziach.
           
        }
         return map;
    }

    public static char[,] CreateSample()
    {
        char[,] map = new char[7, 12];
        map[1, 10] = '>';
        map[3, 4] = '#';
        map[3, 5] = '#';
        map[4, 8] = '$';
        return map;
    }

    public static bool IsInside(char[,] map, int x, int y)
    {
        int height = map.GetLength(0);
        int width = map.GetLength(1);
        // TODO: sprawdź cztery granice przed odczytem map[y, x].
        return x >= 0 && x < width && y >= 0 && y < height;
    }

    public static bool IsWalkable(char[,] map, int x, int y)
    {
        // TODO: pole jest dostępne, gdy leży na mapie i nie jest ścianą.
        return IsInside(map, x, y) && map[y, x] != '#';
    }

    public static int CountSymbol(char[,] map, char symbol)
    {
        // TODO: policz wystąpienia symbolu na całej mapie.
        return 0;
    }

    public static bool TryFindSymbol(char[,] map, char symbol, out int foundX, out int foundY)
    {
        // TODO: zwróć współrzędne pierwszego wystąpienia.
        foundX = -1;
        foundY = -1;
        return false;
    }
}
