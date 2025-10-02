using System;

    public class Util
    {
        public Util()
        {
        }
        static int checkEnd(int hp, int poc)
        {
            if (hp >= 5 && poc >= 5)
            {
                return 1;
            }
            else if (hp < 0)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
        static void printArray(bool[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (!arr[i][j])
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write("M");
                    }
                }
                Console.WriteLine();
            }
        }/*
    static void printArray(int[][] arr)
    {
        Console.Clear();
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr[i].Length; j++)
            {
                if (arr[i][j]==0)
                {
                    Console.Write("0 ");
                }
                else if(arr[i][j]==1)
                {
                    Console.Write("1 ");
                }
                else if(arr[i][j]==2)
                {
                    Console.Write("2 ");
                }
            }
            Console.WriteLine();
        }
    }*/
        static int checkPosHp(int hp, int pos)
        {
            switch (pos)
            {
                case 0:
                    return hp -= 1;
                    break;
                case 1:
                    return hp += 1;
                    break;
                case 2:
                    return hp;
                    break;
            }
            return -1;
        }
        static int checkPosmlPoc(int mlPoc, int pos)
        {
            switch (pos)
            {
                case 0:
                    return mlPoc;
                    break;
                case 1:
                    return mlPoc;
                    break;
                case 2:
                    return mlPoc += 2;
                    break;
            }
            return -1;
        }
        public static void callMenu(bool[][] arrBool, int[][] arrInt, int posx, int posy, int hp, int mlPoc)
        {
            printArray(arrBool);
            Console.WriteLine("Tienes " + hp + " vidas y " + mlPoc + "ml de poción.");
            if (checkEnd(hp, mlPoc) == 1 && posx == 7 && posy == 7)
            {
                Console.WriteLine("Has ganado!");
                return;
            }
            else if (checkEnd(hp, mlPoc) == 2)
            {
                Console.WriteLine("Has perdido por falta de vida!");
                return;
            }
            else if (checkEnd(hp, mlPoc) == 0)
            {
                Console.WriteLine("Sigues con vida!");
            }

            int limit = 8;

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
                    if (posy < limit - 1)
                    {
                        arrBool[posx][posy] = false;
                        posy++;
                        arrBool[posx][posy] = true;
                    }
                    else
                    {
                        Console.WriteLine("Fuera de los límites");
                    }
                    hp = checkPosHp(hp, arrInt[posx][posy]);
                    mlPoc = checkPosmlPoc(mlPoc, arrInt[posx][posy]);

                    break;
                case 's': // Incrementar X por 1
                    if (posx < limit - 1)
                    {
                        arrBool[posx][posy] = false;
                        posx++;
                        arrBool[posx][posy] = true;
                    }
                    else
                    {
                        Console.WriteLine("Fuera de los límites");
                    }
                    hp = checkPosHp(hp, arrInt[posx][posy]);
                    mlPoc = checkPosmlPoc(mlPoc, arrInt[posx][posy]);
                    break;
                case 'a': // Decrementar Y por 1
                    if (posy > 0)
                    {
                        arrBool[posx][posy] = false;
                        posy--;
                        arrBool[posx][posy] = true;
                    }
                    else
                    {
                        Console.WriteLine("Fuera de los límites");
                    }
                    hp = checkPosHp(hp, arrInt[posx][posy]);
                    mlPoc = checkPosmlPoc(mlPoc, arrInt[posx][posy]);
                    break;
                case 'w': // Decrementar X por 1
                    if (posx > 0)
                    {
                        arrBool[posx][posy] = false;
                        posx--;
                        arrBool[posx][posy] = true;
                    }
                    else
                    {
                        Console.WriteLine("Fuera de los límites");
                    }
                    hp = checkPosHp(hp, arrInt[posx][posy]);
                    mlPoc = checkPosmlPoc(mlPoc, arrInt[posx][posy]);
                    break;
                case '5':
                    Console.WriteLine("Adiós!");
                    return;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    break;
            }
            callMenu(arrBool, arrInt, posx, posy, hp, mlPoc);
        }
    }
