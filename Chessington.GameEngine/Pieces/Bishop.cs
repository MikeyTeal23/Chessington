using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentPosition = board.FindPiece(this);
            List<Square> availableMoves = GetDiagonalMoves(currentPosition);

            foreach (Square move in availableMoves)
            {
                yield return move;
            }
        }
    }
}