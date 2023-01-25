using ChessBoard;


namespace Chess
{
    class King : Piece
    {
        public King(Color color, Board board) : base(color, board)
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

            //Cima
            position.ValuesDefinition(position.Line - 1, position.Column);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }

            //Cima direita
            position.ValuesDefinition(position.Line - 1, position.Column + 1);

            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }

            //Direita
            position.ValuesDefinition(position.Line, position.Column +1);

            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }

            //Baixo direita
            position.ValuesDefinition(position.Line + 1, position.Column + 1);

            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }

            //Baixo
            position.ValuesDefinition(position.Line + 1, position.Column);

            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }


            //Baixo esquerda
            position.ValuesDefinition(position.Line + 1, position.Column -1);

            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }

            //esquerda
            position.ValuesDefinition(position.Line, position.Column -1);

            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }

            //cima esquerda
            position.ValuesDefinition(position.Line - 1, position.Column -1);

            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }

            return matrix;
        }




        public override string ToString()
        {
            return "K";
        }
    }
}
