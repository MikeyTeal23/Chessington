using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentPosition = board.FindPiece(this);
            List<Square> availableMoves = GetKingMoves(currentPosition);

            foreach (Square move in availableMoves)
            {
                yield return move;
            }
        }
    }
}