using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentPosition = board.FindPiece(this);

            for (int row = 0; row < 8; row++)
            {
                yield return new Square(row, currentPosition.Col);
            }
            for (int col = 0; col < 8; col++)
            {
                yield return new Square(currentPosition.Row, col);
            }
        }
    }
}