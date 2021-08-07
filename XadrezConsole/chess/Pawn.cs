using System;
using ChessOnConsole.board;

namespace ChessOnConsole.chess
{
    class Pawn : Piece
    {

        public Pawn(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "P";
        }

        private bool enemyExists(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p.color != color;
        }

        private bool free(Position pos)
        {
            return board.piece(pos) == null;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[board.rows, board.columns];
            Position pos = new Position(0, 0);

            if (color == Color.White)
            {
                pos.defineValues(position.row - 1, position.column);
                if (board.validPosition(pos) && free(pos))
                {
                    mat[pos.row, pos.column] = true;
                }

                pos.defineValues(position.row - 2, position.column);
                if (board.validPosition(pos) && free(pos) && movesQuantity == 0)
                {
                    mat[pos.row, pos.column] = true;
                }

                pos.defineValues(position.row - 1, position.column - 1);
                if (board.validPosition(pos) && enemyExists(pos))
                {
                    mat[pos.row, pos.column] = true;
                }

                pos.defineValues(position.row - 1, position.column + 1);
                if (board.validPosition(pos) && enemyExists(pos))
                {
                    mat[pos.row, pos.column] = true;
                }
            } else
            {
                pos.defineValues(position.row + 1, position.column);
                if (board.validPosition(pos) && free(pos))
                {
                    mat[pos.row, pos.column] = true;
                }

                pos.defineValues(position.row + 2, position.column);
                if (board.validPosition(pos) && free(pos) && movesQuantity == 0)
                {
                    mat[pos.row, pos.column] = true;
                }

                pos.defineValues(position.row + 1, position.column - 1);
                if (board.validPosition(pos) && enemyExists(pos))
                {
                    mat[pos.row, pos.column] = true;
                }

                pos.defineValues(position.row + 1, position.column + 1);
                if (board.validPosition(pos) && enemyExists(pos))
                {
                    mat[pos.row, pos.column] = true;
                }
            }

            return mat;
            
        }
    }
}
