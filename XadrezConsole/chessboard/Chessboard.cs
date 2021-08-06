namespace ChessOnConsole.chessboard
{
    class Chessboard
    {
        public int rows { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public Chessboard(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            pieces = new Piece[rows, columns];
        }
    }
}
