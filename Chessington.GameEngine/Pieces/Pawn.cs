using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {

        public Pawn(Player player)
            : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentPosition = board.FindPiece(this);

            yield return StandardPawnMove(currentPosition);
            if (NeverMoved)
            {
                yield return FirstPawnMove(currentPosition);
            }
        }

        private Square StandardPawnMove(Square currentPosition)
        {
            if (Player == 0)
            {
                return new Square(currentPosition.Row - 1, currentPosition.Col);
            }
            else
            {
                return new Square(currentPosition.Row + 1, currentPosition.Col);
            }
        }

        
        private Square FirstPawnMove(Square currentPosition)
        {
            if (Player == 0)
            {
                return new Square(currentPosition.Row - 2, currentPosition.Col);
            }
            else
            {
                return new Square(currentPosition.Row + 2, currentPosition.Col);
            }
        }
    }
}