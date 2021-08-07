using System;
using ChessOnConsole.board;

namespace ChessOnConsole.chess
{
    class Bishop : Piece
    {

        public Bishop(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "B";
        }

        private bool canMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[board.rows, board.columns];
            Position pos = new Position(0, 0);

            //NW 
            pos.defineValues(position.row - 1, position.column - 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;

                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.defineValues(pos.row - 1, pos.column - 1);
            }

            //NE 
            pos.defineValues(position.row - 1, position.column + 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;

                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.defineValues(pos.row - 1, pos.column + 1);
            }

            //SE 
            pos.defineValues(position.row + 1, position.column + 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;

                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.defineValues(pos.row + 1, pos.column + 1);
            }

            //SW 
            pos.defineValues(position.row + 1, position.column - 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;

                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.defineValues(pos.row + 1, pos.column - 1);
            }

            return mat;
        }
    }
}
