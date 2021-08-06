using System;
using ChessOnConsole;
using ChessOnConsole.board;
using ChessOnConsole.chess;

namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessMatch match = new ChessMatch();

            while(!match.finished)
            {
                Console.Clear();
                Screen.printBoard(match.board);

                Console.Write("Origin: ");
                Position origin = Screen.readChessPosition().toPosition();

                Console.Write("Destiny: ");
                Position destiny = Screen.readChessPosition().toPosition();

                match.executeMove(origin, destiny);
            }


        }
    }
}
