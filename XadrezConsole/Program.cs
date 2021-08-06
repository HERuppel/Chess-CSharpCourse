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

                Console.WriteLine();
                Console.Write("Origin: ");
                Position origin = Screen.readChessPosition().toPosition();

                bool[,] possiblePositions = match.board.piece(origin).possibleMoves();

                Console.Clear();
                Screen.printBoard(match.board, possiblePositions);

                Console.WriteLine();
                Console.Write("Destiny: ");
                Position destiny = Screen.readChessPosition().toPosition();

                match.executeMove(origin, destiny);
            }


        }
    }
}
