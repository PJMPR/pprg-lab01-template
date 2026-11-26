using FirstDungeonMap.App.UI;
using FirstDungeonMap.Core.Maps;

namespace FirstDungeonMap.App;

public static class Program
{
    private const int PlayerX = 2;
    private const int PlayerY = 2;

    public static void Main()
    {
        Console.WriteLine("=== PIERWSZA MAPA LOCHU ===");
        Console.WriteLine("Wybierz zadanie 1–7:");

        if (!int.TryParse(Console.ReadLine(), out int taskNumber) || taskNumber < 1 || taskNumber > 7)
        {
            Console.WriteLine("Niepoprawny numer zadania.");
            return;
        }

        switch (taskNumber)
        {
            case 1: Task1(); break;
            case 2: Task2(); break;
            case 3: Task3(); break;
            case 4: Task4(); break;
            case 5: Task5(); break;
            case 6: Task6(); break;
            case 7: Task7(); break;
        }
    }

    private static void Task1()
    {
        char[,] map =
        {
            { '#', '#', '#', '#', '#' },
            { '#', '.', '.', '>', '#' },
            { '#', '.', '.', '.', '#' },
            { '#', '#', '#', '#', '#' }
        };

        // TODO: wyświetl mapę wierszami za pomocą dwóch pętli.
        Console.WriteLine($"Mapa ma {map.GetLength(0)} wiersze i {map.GetLength(1)} kolumn.");
    
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                Console.Write(map[y, x]);
            }
            Console.WriteLine();
        }
    }

    

    private static void Task2()
    {

    const int width = 12;
    const int height = 7;
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

    }
    for (int y = 0; y < map.GetLength(0); y++)
    {
        for (int x = 0; x < map.GetLength(1); x++)
        {
            Console.Write(map[y, x]);
        }
        Console.WriteLine();
    }
    }

    private static void Task3()
    {
        char[,] map = DungeonMap.Create(12, 7);

        map[1, 10] = '>';

        map[4, 8] = '$';

        map[2, 3] = '#';
        map[3, 3] = '#';
        map[4, 3] = '#';
        // TODO: dodaj wyjście, skarb i przeszkody.
    MapRenderer.Print(map);
    Console.WriteLine("Legenda: # ściana | . podłoga | > wyjście | $ skarb");
    }

    private static void Task4()
    {
        char[,] map = DungeonMap.Create(12, 7);
        map[1, 10] = '>';
        map[4, 8] = '$';
        map[2, 3] = '#';
        map[3, 3] = '#';
        map[4, 3] = '#';
        // TODO: wyświetl '@' jako nakładkę, nie zapisując go do mapy.
        MapRenderer.Print(map, PlayerX, PlayerY);
        int playerX = 2;
        int playerY = 2;
        Console.WriteLine("=== Gracz na podłodze (2, 2) ===");
        MapRenderer.Print(map, playerX, playerY);
        Console.WriteLine($"Wartość w tablicy map[{playerY}, {playerX}]: '{map[playerY, playerX]}' (oczekiwano '.')");
        Console.WriteLine();

        playerX = 10;
        playerY = 1;
        Console.WriteLine("=== Gracz na wyjściu (10, 1) ===");
        MapRenderer.Print(map, playerX, playerY);
        Console.WriteLine($"Wartość w tablicy map[{playerY}, {playerX}]: '{map[playerY, playerX]}' (oczekiwano '>')");
    }

    private static void Task5()
    {
        char[,] map = DungeonMap.CreateSample();
        int[,] coordinates = { { 2, 2 }, { 0, 0 }, { 20, 3 }, { 10, 5 } };

    (int x, int y, string desc)[] testCases =
        {
            (2, 2, "podłoga"),
            (0, 0, "ściana (narożnik)"),
            (-1, 2, "ujemne x"),
            (2, -1, "ujemne y"),
            (12, 3, "x równe szerokości"),
            (3, 7, "y równe wysokości"),
            (10, 1, "wyjście")
        };
    foreach (var (x, y, desc) in testCases)
    {
        bool inside = DungeonMap.IsInside(map, x, y);
        bool walkable = DungeonMap.IsWalkable(map, x, y);
        Console.WriteLine($"({x,2}, {y,2}) [{desc,-18}] -> IsInside: {inside,-5} | IsWalkable: {walkable,-5}");
    }
    }

    private static void Task6()
    {
        char[,] map = DungeonMap.Create(12, 7);
        map[1, 10] = '>'; // Wyjście (10, 1)
        map[4, 8] = '$';  // Skarb (8, 4)
        map[2, 3] = '#';
    map[3, 3] = '#';
    map[4, 3] = '#';

    int width = map.GetLength(1);
    int height = map.GetLength(0);

    int walls = DungeonMap.CountSymbol(map, '#');
    int floors = DungeonMap.CountSymbol(map, '.');
    int treasures = DungeonMap.CountSymbol(map, '$');
    int exits = DungeonMap.CountSymbol(map, '>');

    Console.WriteLine($"Rozmiar: {width}x{height}");
    Console.WriteLine($"Ściany: {walls}");
    Console.WriteLine($"Podłoga: {floors}");
    Console.WriteLine($"Skarby: {treasures}");

    if (DungeonMap.TryFindSymbol(map, '>', out int exitX, out int exitY))
    {
        Console.WriteLine($"Wyjście: x={exitX}, y={exitY}");
    }
    else
    {
        Console.WriteLine("Wyjście: brak");
    }

    Console.WriteLine($"Suma liczników: {walls + floors + treasures + exits} (map.Length: {map.Length})");

    // Test wyszukiwania nieistniejącego symbolu '!'
    bool foundMissing = DungeonMap.TryFindSymbol(map, '!', out int missX, out int missY);
    Console.WriteLine($"Test brakującego '!': znaleziono={foundMissing}, x={missX}, y={missY}");
}

    private static void Task7()
    {
        char[,] map = DungeonMap.CreateSample();
        // TODO: zaprojektuj własną mapę projektu.
        MapRenderer.Print(map, PlayerX, PlayerY);
        MapRenderer.PrintLegend();
    }
}
