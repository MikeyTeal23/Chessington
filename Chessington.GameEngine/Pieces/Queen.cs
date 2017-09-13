using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentPosition = board.FindPiece(this);

            //diagonal moves

            int row = currentPosition.Row;
            int col = currentPosition.Col;

            int lowerLimit = row < col ? -row : -col;
            int upperLimit = row < col ? 8 - col : 8 - row;

            for (int i = lowerLimit; i < upperLimit; i++)
            {
                if (currentPosition.Row + i != row || currentPosition.Col + i != col)
                {
                    yield return new Square(currentPosition.Row + i, currentPosition.Col + i);
                }
            }

            int total = row + col;

            for (int i = 0; i < total + 1; i++)
            {
                //yield return new Square(total - 7 + i, total - i);
                if (i > (total - 8) && i < 8 && (row != i || total - i != col))
                {
                    yield return new Square(i, total - i);
                }
            }

            //lateral moves

            for (int r = 0; r < 8; r++)
            {
                if (row != r)
                {
                    yield return new Square(r, col);
                }
            }
            for (int c = 0; c < 8; c++)
            {
                if (col != c)
                {
                    yield return new Square(row, c);
                }
            }

        }

        //public IEnumerable<Square> GetLateralMoves(Square currentPosition)
        //{
        //    int row = currentPosition.Row;
        //    int col = currentPosition.Col;

        //    for (int r = 0; r < 8; r++)
        //    {
        //        if (row != r)
        //        {
        //            yield return new Square(r, col);
        //        }
        //    }
        //    for (int c = 0; c < 8; c++)
        //    {
        //        if (col != c)
        //        {
        //            yield return new Square(row, c);
        //        }
        //    }

        //}

    }
}