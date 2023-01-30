using ChessBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessConsole.Chess
{
    internal class Pawn : Piece
    {
        public Pawn(Color color, Board board) : base(color, board)
        {

        }


        private bool CanMove(Position position)
        {
            Piece piece = Board.piece(position);
            return piece == null || piece.Color != Color;
        }


        private bool HasEnemy(Position position)
        {
            Piece piece = Board.piece(position);
            return piece!= null && piece.Color != Color;
        }

        private bool WithoutEnemy(Position position)
        {
            return Board.piece(position) == null;
        }


        public override bool[,] PossibleMoviments()
        {
            bool[,] matrix = new bool[Board.Lines, Board.Columns];
            Position position = new Position(0, 0);
            

            if (Color== Color.White)
            {
                position.ValuesDefinition(Position.Line - 1, Position.Column);
                if (Board.ValidPosition(position) && WithoutEnemy(position))
                {
                    matrix[position.Line, position.Column] = true;
                }
               
                position.ValuesDefinition(Position.Line - 2, Position.Column);
                if (Board.ValidPosition(position) && WithoutEnemy(position) && AmountMoviment == 0)
                {
                    matrix[position.Line, position.Column] = true;
                }
                
                position.ValuesDefinition(Position.Line - 1, Position.Column -1);
                if (Board.ValidPosition(position) && HasEnemy(position))
                {
                    matrix[position.Line, position.Column] = true;
                }
               
                position.ValuesDefinition(Position.Line - 1, Position.Column +1);
                if (Board.ValidPosition(position) && HasEnemy(position))
                {
                    matrix[position.Line, position.Column] = true;
                }

            }
            else
            {
                position.ValuesDefinition(Position.Line +1, Position.Column);
                if (Board.ValidPosition(position) && WithoutEnemy(position))
                {
                    matrix[position.Line, position.Column] = true;
                }

                position.ValuesDefinition(Position.Line + 2, Position.Column);
                if (Board.ValidPosition(position) && WithoutEnemy(position) && AmountMoviment == 0)
                {
                    matrix[position.Line, position.Column] = true;
                }

                position.ValuesDefinition(Position.Line + 1, Position.Column - 1);
                if (Board.ValidPosition(position) && HasEnemy(position))
                {
                    matrix[position.Line, position.Column] = true;
                }

                position.ValuesDefinition(Position.Line + 1, Position.Column + 1);
                if (Board.ValidPosition(position) && HasEnemy(position))
                {
                    matrix[position.Line, position.Column] = true;
                }
            }

            return matrix;
        }




        public override string ToString()
        {
            return "P";
        }
    }
}
