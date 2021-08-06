namespace ChessOnConsole.board
{
    class Board
    {
        public int rows { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            pieces = new Piece[rows, columns];
        }

        public Piece piece(int row, int column)
        {
            return pieces[row, column];
        }

        public Piece piece(Position pos)
        {
            return pieces[pos.row, pos.column];
        }

        public bool pieceExists (Position pos)
        {
            validatePosition(pos);
            return piece(pos) != null;
        }

        public void placePiece(Piece piece, Position pos)
        {
            if (pieceExists(pos))
            {
                throw new BoardException("A piece is already at this position!");
            }
            pieces[pos.row, pos.column] = piece;
            piece.position = pos;
        }

        public bool validPosition(Position pos)
        {
            if (pos.row < 0 || pos.row >= rows || pos.column < 0 || pos.column >= columns)
            {
                return false;
            }
            return true;
        }

        public void validatePosition(Position pos)
        {
            if (!validPosition(pos))
            {
                throw new BoardException("Invalid Position!");
            }
        }
    }
}
