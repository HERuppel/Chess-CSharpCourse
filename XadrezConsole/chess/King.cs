using ChessOnConsole.board;

namespace ChessOnConsole.chess
{
    class King : Piece
    {

        public King (Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "K";
        }

        private bool canMove(Position pos)
        {
            Piece piece = board.piece(pos);
            return piece == null || piece.color != color;
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

            return mat;
        }

    }
}
