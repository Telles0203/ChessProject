using ChessBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessConsole.Chess
{
    class Queen : Piece
    {
        public Queen(Color color, Board board) : base(color, board)
        {

        }


        private bool CanMove(Position position)
        {
            Piece piece = Board.piece(position);
            return piece == null || piece.Color != Color;
        }





        public override bool[,] PossibleMoviments()
        {
            bool[,] matrix = new bool[Board.Lines, Board.Columns];
            Position position = new Position(0, 0);

            //Cima direita
            position.ValuesDefinition(Position.Line - 1, Position.Column + 1);

            while (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (Board.piece(position) != null && Board.piece(position).Color != Color)
                {
                    break;
                }
                position.ValuesDefinition(position.Line - 1, position.Column + 1);
            }

            //Baixo direita
            position.ValuesDefinition(Position.Line + 1, Position.Column + 1);

            while (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (Board.piece(position) != null && Board.piece(position).Color != Color)
                {
                    break;
                }
                position.ValuesDefinition(position.Line + 1, position.Column + 1);
            }



            //Baixo esquerda
            position.ValuesDefinition(Position.Line + 1, Position.Column - 1);

            while (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (Board.piece(position) != null && Board.piece(position).Color != Color)
                {
                    break;
                }
                position.ValuesDefinition(position.Line + 1, position.Column - 1);
            }

            //cima esquerda
            position.ValuesDefinition(Position.Line - 1, Position.Column - 1);

            while (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (Board.piece(position) != null && Board.piece(position).Color != Color)
                {
                    break;
                }
                position.ValuesDefinition(position.Line - 1, position.Column - 1);
            }
            //Cima
            position.ValuesDefinition(Position.Line - 1, Position.Column);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (Board.piece(position) != null && Board.piece(position).Color != Color)
                {
                    break;
                }
                position.Line = position.Line - 1;
            }

            //Baixo
            position.ValuesDefinition(Position.Line + 1, Position.Column);

            while (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (Board.piece(position) != null && Board.piece(position).Color != Color)
                {
                    break;
                }
                position.Line = position.Line + 1;
            }

            //Direita
            position.ValuesDefinition(Position.Line, Position.Column + 1);

            while (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (Board.piece(position) != null && Board.piece(position).Color != Color)
                {
                    break;
                }
                position.Column = position.Column + 1;
            }

            //esquerda
            position.ValuesDefinition(Position.Line, Position.Column - 1);

            while (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (Board.piece(position) != null && Board.piece(position).Color != Color)
                {
                    break;
                }
                position.Column = position.Column - 1;
            }

            return matrix;
        }




        public override string ToString()
        {
            return "Q";
        }
    }
}
