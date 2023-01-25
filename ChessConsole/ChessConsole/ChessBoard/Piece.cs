namespace ChessBoard
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public Board Board { get; protected set; }
        public int AmountMoviment { get; protected set; }


        public Piece(Color color, Board board)
        {
            
            Color = color;
            Board = board;
            AmountMoviment = 0;
            Position = null;
        }
    }
}
