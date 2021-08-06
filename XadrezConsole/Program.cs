using System;
using ChessOnConsole;
using ChessOnConsole.chessboard;

namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Chessboard board = new Chessboard(8, 8);

            Screen.printBoard(board);
        }
    }
}
