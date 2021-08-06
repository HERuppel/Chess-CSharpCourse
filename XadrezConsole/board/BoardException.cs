using System;

namespace ChessOnConsole.board
{
    class BoardException : Exception
    {
        public BoardException(string msg) : base(msg) { }
    }
}
