using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Board
    {
        private readonly Piece[,] pieces = new Piece[8, 8];
        private readonly Dictionary<Player, Position> pawnSkipPositions = new Dictionary<Player, Position>
        {
            { Player.White, null },
            { Player.Black, null }
        };
        public Piece this[int row, int col]
        {
            get { return pieces[row, col]; }
            set { pieces[row, col] = value; }
        }

        public Piece this[Position pos]
        {
            get { return this[pos.Row, pos.Column]; }
            set { this[pos.Row, pos.Column] = value; }
        }
        public Position GetPawnSkipPosition(Player player)
        {
            return pawnSkipPositions[player];
        }
        public void SetPawnSkipPosition(Player player, Position pos)
        {
            pawnSkipPositions[player] = pos;
        }

        public static Board Initial()
        {
            Board board = new Board();
            board.AddStartPieces();
            return board;
        }

        private void AddStartPieces()
        {
            this[0, 0] = new Rook(Player.Black);
            this[0, 1] = new Rook(Player.Black);
            this[0, 2] = new Rook(Player.Black);
            this[0, 3] = new Rook(Player.Black);
            this[0, 4] = new Rook(Player.Black);
            this[0, 5] = new Rook(Player.Black);
            this[0, 6] = new Rook(Player.Black);
            this[0, 7] = new Rook(Player.Black);

            this[7, 0] = new Rook(Player.Black);
            this[7, 1] = new Rook(Player.Black);
            this[7, 2] = new Rook(Player.Black);
            this[7, 3] = new Rook(Player.Black);
            this[7, 4] = new Rook(Player.Black);
            this[7, 5] = new Rook(Player.Black);
            this[7, 6] = new Rook(Player.Black);
            this[7, 7] = new Rook(Player.Black);

            for (int c = 0; c < 8; c++) // "HAHAAAA C++" - Cody
            {
                this[1, c] = new Rook(Player.Black);
                this[6, c] = new Rook(Player.White);
            }
        }
        public static bool IsInside(Position pos)
        {
            return pos.Row >= 0 && pos.Row < 8 && pos.Column >= 0 && pos.Column < 8;
        }

        public bool IsEmpty(Position pos)
        {
            return this[pos] == null;
        }
    }
}
