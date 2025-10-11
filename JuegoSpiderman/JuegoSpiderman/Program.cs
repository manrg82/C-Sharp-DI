using System;

public class Game
{
    public Game()
    {
    }

    public static void Main(string[] args)
    {
        Board bd = new Board(5);//dificultad va de 1-5 mayor a menor
        bd.generateBoards();
        bd.printArray(bd.getDisplayBoard());
        bd.startGame();
    }
}
