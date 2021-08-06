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
            try
            {
                Board board = new Board(8, 8);
                board.placePiece(new Rook(board, Color.Black), new Position(0, 0));
                board.placePiece(new Rook(board, Color.Black), new Position(1, 3));
                board.placePiece(new King(board, Color.Black), new Position(2, 4));

                Screen.printBoard(board);
            }
            catch (BoardException err)
            {
                Console.WriteLine(err);
            }

        }
    }
}
