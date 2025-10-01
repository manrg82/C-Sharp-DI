class Program
{
    private int limit = 8;
    static void printArray(bool[][] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr[i].Length; j++)
            {
                if (!arr[i][j])
                {
                    Console.Write("X");
                }
                else
                {
                    Console.Write("O");
                }
            }
            Console.WriteLine();
        }
    }
    static void callMenu(bool[][] arr, int posx, int posy)
    {
        printArray(arr);
        Boolean exit = false;
        if (exit) return;
        Console.WriteLine("Elige una opción:");
        Console.WriteLine("d. Mover a la Derecha");
        Console.WriteLine("w. Mover hacia arriba");
        Console.WriteLine("s. Mover hacia abajo");
        Console.WriteLine("a. Mover a la Izquierda");
        Console.WriteLine("5. Salir");

        char option = Console.ReadKey().KeyChar;
        Console.WriteLine();
        switch (option)
        {
            case 'd': // Incrementar Y por 1
                if (posy < 3)
                {
                    arr[posx][posy] = false;
                    posy++;
                    arr[posx][posy] = true;
                }
                else
                {
                    Console.WriteLine("Fuera de los límites");
                }
                callMenu(arr, posx, posy);
                break;
            case 's': // Incrementar X por 1
                if (posx < 3)
                {
                    arr[posx][posy] = false;
                    posx++;
                    arr[posx][posy] = true;
                }
                else
                {
                    Console.WriteLine("Fuera de los límites");
                }
                callMenu(arr, posx, posy);
                break;
            case 'a': // Decrementar Y por 1
                if (posy > 0)
                {
                    arr[posx][posy] = false;
                    posy--;
                    arr[posx][posy] = true;
                }
                else
                {
                    Console.WriteLine("Fuera de los límites");
                }
                callMenu(arr, posx, posy);
                break;
            case 'w': // Decrementar X por 1
                if (posx > 0)
                {
                    arr[posx][posy] = false;
                    posx--;
                    arr[posx][posy] = true;
                }
                else
                {
                    Console.WriteLine("Fuera de los límites");
                }
                callMenu(arr, posx, posy);
                break;
            case '5':
                exit = true;
                break;
            default:
                Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                break;
        }
    }

    static void Main(string[] args)
    {
        bool[][] arr = new bool[4][];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = new bool[4];
        }
        arr[0][0] = true;
        int posx = 0;
        int posy = 0;
        callMenu(arr, posx, posy);
    }
}