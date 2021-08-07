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
                try
                {
                    Console.Clear();
                    Screen.printBoard(match.board);

                    Console.WriteLine();
                    Console.WriteLine("Round: " + match.round);
                    Console.WriteLine("Waiting for player " + match.currentPlayer);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.readChessPosition().toPosition();
                    match.validateOrigin(origin);

                    bool[,] possiblePositions = match.board.piece(origin).possibleMoves();

                    Console.Clear();
                    Screen.printBoard(match.board, possiblePositions);

                    Console.WriteLine();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.readChessPosition().toPosition();
                    match.validateDestiny(origin, destiny);

                    match.makeAPlay(origin, destiny);
                }
                catch (BoardException err)
                {
                    Console.WriteLine(err.Message);
                    Console.ReadLine();
                }
            }


        }
    }
}
