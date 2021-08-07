using System;
using ChessOnConsole.board;

namespace ChessOnConsole.chess
{
    class ChessMatch
    {
        public Board board { get; private set; }
        public int round { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finished { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            round = 1;
            currentPlayer = Color.White;
            finished = false;
            placePieces();
        }

        public void executeMove(Position origin, Position destiny)
        {
            Piece piece = board.takePiece(origin);
            piece.incrementMoves();
            Piece capturedPiece = board.takePiece(destiny);
            board.placePiece(piece, destiny);
        }

        public void makeAPlay(Position origin, Position destiny)
        {
            executeMove(origin, destiny);
            round++;

            switchPlayer();
        }

        public void validateOrigin(Position pos)
        {
            if (board.piece(pos) == null)
            {
                throw new BoardException("There is no piece at the chosen origin position!");
            }
            if (currentPlayer != board.piece(pos).color) {
                throw new BoardException("The chosen origin piece is not yours!");
            }
            if (!board.piece(pos).existPossibleMoves())
            {
                throw new BoardException("There are no possible moves for the chosen origin piece!");
            }

        }

        public void validateDestiny(Position origin, Position destiny)
        {
            if (!board.piece(origin).canMoveTo(destiny))
            {
                throw new BoardException("Invalid destiny!");
            }
        }

        private void switchPlayer()
        {
            if (currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            }
            else
            {
                currentPlayer = Color.White;
            }
        }

        private void placePieces()
        {
            board.placePiece(new Rook(board, Color.White), new ChessPosition('c', 1).toPosition());
            board.placePiece(new Rook(board, Color.White), new ChessPosition('c', 2).toPosition());
            board.placePiece(new Rook(board, Color.White), new ChessPosition('d', 2).toPosition());
            board.placePiece(new Rook(board, Color.White), new ChessPosition('e', 2).toPosition());
            board.placePiece(new Rook(board, Color.White), new ChessPosition('e', 1).toPosition());
            board.placePiece(new King(board, Color.White), new ChessPosition('d', 1).toPosition());

            board.placePiece(new Rook(board, Color.Black), new ChessPosition('c', 7).toPosition());
            board.placePiece(new Rook(board, Color.Black), new ChessPosition('c', 8).toPosition());
            board.placePiece(new Rook(board, Color.Black), new ChessPosition('d', 7).toPosition());
            board.placePiece(new Rook(board, Color.Black), new ChessPosition('e', 7).toPosition());
            board.placePiece(new Rook(board, Color.Black), new ChessPosition('e', 8).toPosition());
            board.placePiece(new King(board, Color.Black), new ChessPosition('d', 8).toPosition());
        }
    }
}
