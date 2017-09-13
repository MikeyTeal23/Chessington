using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            if (this.Player == 0)
            {
                Square currentPosition = board.FindPiece(this);
                yield return new Square(currentPosition.Row - 1, currentPosition.Col);
            }
            else
            {
                Square currentPosition = board.FindPiece(this);
                yield return new Square(currentPosition.Row + 1, currentPosition.Col);
            }

        }
    }
}