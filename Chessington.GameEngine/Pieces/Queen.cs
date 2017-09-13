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

            List<Square> availableMoves = GetLateralMoves(currentPosition);
            availableMoves.AddRange(GetDiagonalMoves(currentPosition));

            foreach (Square move in availableMoves)
            {
                yield return move;
            }

        }
    }
}