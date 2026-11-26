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

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                Console.Write(map[y, x]);
            }
            Console.WriteLine();
        }


        Console.WriteLine($"Mapa ma {map.GetLength(0)} wiersze i {map.GetLength(1)} kolumn.");
    }

    private static void Task2()
    {
        char[,] map = new char[7, 12];
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                bool isBorder = y == 0 || y == map.GetLength(0) - 1 || x == 0 || x == map.GetLength(1) - 1;
                map[y, x] = isBorder ? '#' : '.';
            }
        }

        MapRenderer.Print(map);
    }

    private static void Task3()
    {
        char[,] map = DungeonMap.Create(12, 7);

        map[1, 10] = '>';
        map[4, 8] = '$';
        map[2, 4] = '#';
        map[3, 4] = '#';
        map[4, 4] = '#';
        MapRenderer.Print(map);
        MapRenderer.PrintLegend();
    }

    private static void Task4()
    {
        char[,] map = DungeonMap.CreateSample();
        // TODO: wyświetl '@' jako nakładkę, nie zapisując go do mapy.     
        MapRenderer.Print(map, PlayerX, PlayerY);
        Console.WriteLine($"Znajdujesz sie na polu {PlayerX}, {PlayerY}");

        MapRenderer.Print(map, 10, 1);
        Console.WriteLine($"Wartosc tablicy na wyjsciu z mapy: '{map[1, 10]}'");
    }

    private static void Task5()
    {
        char[,] map = DungeonMap.CreateSample();
        int[,] coordinates = { { 2, 2 }, { 0, 0 }, { 20, 3 }, { 10, 5 } };

        for (int i = 0; i < coordinates.GetLength(0); i++)
        {
            int x = coordinates[i, 0];
            int y = coordinates[i, 1];
            Console.WriteLine($"{x}, {y} -> {DungeonMap.IsInside(map, x, y)}, dostępne: {DungeonMap.IsWalkable(map, x, y)}");
        }
    }

    private static void Task6()
    {
        char[,] map = DungeonMap.CreateSample();
        MapRenderer.Print(map, PlayerX, PlayerY);
        int wall = DungeonMap.CountSymbol(map, '#');
        int floor = DungeonMap.CountSymbol(map, '.');
        int exit = DungeonMap.CountSymbol(map, '>');
        int treasure = DungeonMap.CountSymbol(map, '$');
        int totalstructures = wall + floor + exit + treasure;

        Console.WriteLine($"Rozmiar mapy: {map.GetLength(1)} x {map.GetLength(0)} = {map.Length}");
        Console.WriteLine($"Sciany: {wall}");
        Console.WriteLine($"Podloga: {floor}");
        Console.WriteLine($"Skarb: {treasure}");


        if (DungeonMap.TryFindSymbol(map, '>', out int exitX, out int exitY))
        {
            Console.WriteLine($"Wyjscie: {exit} na polu {exitX}, {exitY}");
        }
        else
        {
            Console.WriteLine($"Wyjscie: {exit} nie znaleziono");

            bool isExitMissing = DungeonMap.TryFindSymbol(map, '!', out int missingX, out int missingY);
        }
    }

    private static void Task7()
    {
        char[,] map = DungeonMap.CreateSample();
        // TODO: zaprojektuj własną mapę projektu.
        MapRenderer.Print(map, PlayerX, PlayerY);
        MapRenderer.PrintLegend();
    }
}
