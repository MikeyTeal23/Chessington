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
            List<Square> availableMoves = StandardPawnMove(currentPosition);

            if (NeverMoved)
            {
                availableMoves.AddRange(FirstPawnMove(currentPosition));
            }

            List<Square> unblockedMoves = GetUnblockedAvailableMoves(availableMoves, board);

            foreach (Square move in unblockedMoves)
            {
                yield return move;
            }
        }

        private List<Square> StandardPawnMove(Square currentPosition)
        {
            List<Square> moveList = new List<Square>();

            if (Player == 0)
            {
                moveList.Add(new Square(currentPosition.Row - 1, currentPosition.Col));
            }
            else
            {
                moveList.Add(new Square(currentPosition.Row + 1, currentPosition.Col));
            }

            return moveList;
        }
        private List<Square> FirstPawnMove(Square currentPosition)
        {
            List<Square> moveList = new List<Square>();

            if (Player == 0)
            {
                moveList.Add(new Square(currentPosition.Row - 2, currentPosition.Col));
            }
            else
            {
                moveList.Add(new Square(currentPosition.Row + 2, currentPosition.Col));
            }

            return moveList;
        }

        private List<Square> GetUnblockedAvailableMoves(List<Square> availableMoves, Board board)
        {
            List<Square> unblockedMoves = new List<Square>();

            foreach (Square move in availableMoves)
            {
                if (board.GetPiece(move) == null)
                {
                    unblockedMoves.Add(move);
                }
                else
                {
                    break;
                }
            }

            return unblockedMoves;
        }
    }
}