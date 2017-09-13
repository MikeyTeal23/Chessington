using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
            NeverMoved = true;
        }

        public bool NeverMoved { get; set; }
        public Player Player { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
            NeverMoved = false;
        }

        public List<Square> GetLateralMoves(Square currentPosition)
        {
            List<Square> moveList = new List<Square>();

            for (int row = 0; row < GameSettings.BoardSize; row++)
            {
                if (currentPosition.Row != row)
                {
                    moveList.Add(new Square(row, currentPosition.Col));
                }
            }
            for (int col = 0; col < GameSettings.BoardSize; col++)
            {
                if (currentPosition.Col != col)
                {
                    moveList.Add(new Square(currentPosition.Row, col));
                }
            }

            return moveList;
        }

        public List<Square> GetDiagonalMoves(Square currentPosition)
        {
            List<Square> moveList = new List<Square>();

            int row = currentPosition.Row;
            int col = currentPosition.Col;

            int lowerLimit = row < col ? -row : -col;
            int upperLimit = row < col ? GameSettings.BoardSize - col : GameSettings.BoardSize - row;

            for (int i = lowerLimit; i < upperLimit; i++)
            {
                if (currentPosition.Row + i != row || currentPosition.Col + i != col)
                {
                    moveList.Add(new Square(currentPosition.Row + i, currentPosition.Col + i));
                }
            }

            int total = row + col;

            for (int i = 0; i < total + 1; i++)
            {
                //yield return new Square(total - 7 + i, total - i);
                if (i > (total - GameSettings.BoardSize) && i < GameSettings.BoardSize && (row != i || total - i != col))
                {
                    moveList.Add(new Square(i, total - i));
                }
            }

            return moveList;
        }
    }
}