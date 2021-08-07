using ChessOnConsole.board;

namespace ChessOnConsole.chess
{
    class King : Piece
    {
        private ChessMatch match;
        public King (Board board, Color color, ChessMatch match) : base(board, color) {
            this.match = match;
        }

        public override string ToString()
        {
            return "K";
        }

        private bool canMove(Position pos)
        {
            Piece piece = board.piece(pos);
            return piece == null || piece.color != color;
        }

        private bool testRookToRook(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p is Rook && p.color == color && p.movesQuantity == 0;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            //up
            pos.defineValues(position.row - 1, position.column);

            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
            }

            //NE
            pos.defineValues(position.row - 1, position.column + 1);

            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            //right
            pos.defineValues(position.row, position.column + 1);

            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            //SE
            pos.defineValues(position.row + 1, position.column + 1);

            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            //down
            pos.defineValues(position.row + 1, position.column);

            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            //SW
            pos.defineValues(position.row + 1, position.column -1);

            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            //left
            pos.defineValues(position.row, position.column - 1);

            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            //NW
            pos.defineValues(position.row - 1, position.column - 1);

            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            //#Special move = small Rook
            if (movesQuantity == 0 && !match.check)
            {
                Position posR1 = new Position(position.row, position.column + 3);
                if(testRookToRook(posR1))
                {
                    Position p1 = new Position(position.row, position.column + 1);
                    Position p2 = new Position(position.row, position.column + 2);

                    if (board.piece(p1) == null && board.piece(p2) == null)
                    {
                        mat[position.row, position.column + 2] = true;
                    }
                }
            }

            //#Special move = Rook
            if (movesQuantity == 0 && !match.check)
            {
                Position posR2 = new Position(position.row, position.column - 4);
                if (testRookToRook(posR2))
                {
                    Position p1 = new Position(position.row, position.column - 1);
                    Position p2 = new Position(position.row, position.column - 2);
                    Position p3 = new Position(position.row, position.column - 3);

                    if (board.piece(p1) == null && board.piece(p2) == null && board.piece(p3) == null)
                    {
                        mat[position.row, position.column - 2] = true;
                    }
                }
            }

            return mat;
        }

    }
}
