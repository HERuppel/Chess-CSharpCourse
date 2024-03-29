﻿namespace ChessOnConsole.board
{
    abstract class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int movesQuantity { get; protected set; }
        public Board board { get; protected set; }

        public Piece (Board board, Color color)
        {
            position = null;
            this.board = board;
            this.color = color;
            movesQuantity = 0;
        }

        public void incrementMoves()
        {
            movesQuantity++;
        }

        public void decrementMoves()
        {
            movesQuantity--;
        }

        public bool existPossibleMoves()
        {
            bool[,] mat = possibleMoves();

            for(int i = 0; i < board.rows; i++)
            {
                for (int j = 0; j < board.columns; j++)
                {
                    if(mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool possibleMove(Position pos)
        {
            return possibleMoves()[pos.row, pos.column];
        }

        public abstract bool[,] possibleMoves();
    }
}
