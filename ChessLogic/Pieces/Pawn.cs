using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Pawn : Piece
    {
        public override PieceType Type => PieceType.Pawn;
        public override Player Color { get; }
        public Pawn(Player color) 
        {
            Color = color;
        }
        public override Piece Copy()
        {
            Pawn copy = new Pawn(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private static IEnumerable<Move> PromotionMoves(Position from,Position to)
        {
            yield return new PawnPromotion(from, to PieceType.Knight);
            yield return new PawnPromotion(from, to PieceType.Bishop);
            yield return new PawnPromotion(from, to PieceType.Rook);
            yield return new PawnPromotion(from, to PieceType.Queen);
        }
        
        private IEnumerable<Move> ForwardMoves(Position from,Board board)
        {
            Position oneMovePos = from + forward;
            if (CanMoveTo(oneMovePos, board))
            {
                if (oneMovePos.Row == 0 || oneMovePos.Row == 7)
                {
                    foreach (Move promMove in PromotionMoves(from, oneMovesPos))
                    {
                        yield return promMove;
                    }
                }
                else
                {
                    yield return new NormalMove(from, oneMovePos);
                }

                Position twoMovesPos = oneMovePos + forward;
                
                if (!HasMoved && CanMoveTo(twoMovesPos, board))
                {
                    yield return new NormalMove(from, twoMovesPos);
                }
            }
        }

        private IEnumerable<Move> DiagonalMoves(Position from, Board board)
        {
            foreach (Direction dir in new Direction[] { Direction.West, Direction.East })
            {
                Position to = from + forward + dir;
                if (CanCaptureAt(to,board))
                {
                    if (to.Row == 0 || to.Row == 7)
                    {
                        foreach (Move promMove in PromotionMoves(from, to))
                        {
                            yield return promMove;
                        }
                    }
                    else
                    {
                        yield return new NormalMove(from, to);
                    }
                }
            }
        }
    }
}
