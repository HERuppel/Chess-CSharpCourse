using System;
using ChessOnConsole.board;
using System.Collections.Generic;

namespace ChessOnConsole.chess
{
    class ChessMatch
    {
        public Board board { get; private set; }
        public int round { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;
        public bool check { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            round = 1;
            currentPlayer = Color.White;
            finished = false;
            check = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            placePieces();
        }

        public Piece executeMove(Position origin, Position destiny)
        {
            Piece piece = board.takePiece(origin);
            piece.incrementMoves();
            Piece capturedPiece = board.takePiece(destiny);
            board.placePiece(piece, destiny);

            if (capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }

            return capturedPiece;
        }

        public void undoMove(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece p = board.takePiece(destiny);
            p.decrementMoves();

            if (capturedPiece != null)
            {
                board.placePiece(capturedPiece, destiny);
                captured.Remove(capturedPiece);
            }
            board.placePiece(p, origin);
        }

        public void makeAPlay(Position origin, Position destiny)
        {
            Piece capturedPiece = executeMove(origin, destiny);

            if (isInCheck(currentPlayer))
            {
                undoMove(origin, destiny, capturedPiece);
                throw new BoardException("You cannot put yourself in check!");
            }

            if (isInCheck(adversary(currentPlayer)))
            {
                check = true;
            } else
            {
                check = false;
            }

            if (testCheckMate(adversary(currentPlayer)))
            {
                finished = true;
            }

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

        public HashSet<Piece> capturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();

            foreach(Piece p in captured)
            {
                if (p.color == color)
                {
                    aux.Add(p);
                }
            }
            return aux;
        }

        private Color adversary(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            } else
            {
                return Color.White;
            }
            
        }

        private Piece king(Color color)
        {
            foreach(Piece p in inGamePieces(color))
            {
                if (p is King)
                {
                    return p;
                }
            }
            return null;
        }

        public bool isInCheck(Color color)
        {
            Piece k = king(color);

            if (k == null)
            {
                throw new BoardException("There is no " + color + " king!");
            }

            foreach(Piece p in inGamePieces(adversary(color)))
            {
                bool[,] mat = p.possibleMoves();

                if (mat[k.position.row, k.position.column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool testCheckMate(Color color)
        {
            if (!isInCheck(color))
            {
                return false;
            }

            foreach(Piece p in inGamePieces(color))
            {
                bool[,] mat = p.possibleMoves();

                for (int i = 0; i < board.rows; i++)
                {
                    for (int j = 0; j < board.columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = p.position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = executeMove(origin, destiny);
                            bool testCheck = isInCheck(color);
                            undoMove(origin, destiny, capturedPiece);

                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public HashSet<Piece> inGamePieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();

            foreach(Piece p in pieces)
            {
                if (p.color == color)
                {
                    aux.Add(p);
                }
            }
            aux.ExceptWith(capturedPieces(color));
            return aux;
        }

        public void placeNewPiece(char column, int row, Piece piece)
        {
            board.placePiece(piece, new ChessPosition(column, row).toPosition());
            pieces.Add(piece);
        }

        private void placePieces()
        {
            placeNewPiece('c', 1, new Rook(board, Color.White));
            placeNewPiece('c', 2, new Rook(board, Color.White));
            placeNewPiece('d', 2, new Rook(board, Color.White));
            placeNewPiece('e', 2, new Rook(board, Color.White));
            placeNewPiece('e', 1, new Rook(board, Color.White));
            placeNewPiece('d', 1, new King(board, Color.White));

            placeNewPiece('c', 7, new Rook(board, Color.Black));
            placeNewPiece('c', 8, new Rook(board, Color.Black));
            placeNewPiece('d', 7, new Rook(board, Color.Black));
            placeNewPiece('e', 7, new Rook(board, Color.Black));
            placeNewPiece('e', 8, new Rook(board, Color.Black));
            placeNewPiece('d', 8, new King(board, Color.Black));

        }
    }
}
