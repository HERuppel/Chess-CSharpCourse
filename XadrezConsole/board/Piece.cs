namespace ChessOnConsole.board
{
    class Piece
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
    }
}
