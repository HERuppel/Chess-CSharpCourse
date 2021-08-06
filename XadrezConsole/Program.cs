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
            Board board = new Board(8, 8);

            board.placePiece(new Rook(board, Color.Black), new Position(0, 0));
            board.placePiece(new Rook(board, Color.Black), new Position(0, 7));


            Screen.printBoard(board);

        }
    }
}
