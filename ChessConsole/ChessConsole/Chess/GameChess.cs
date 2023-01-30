

using ChessBoard;
using ChessConsole.Chess;

namespace Chess
{
    class GameChess
    {
        public Board Board { get; set; }
        public int Turn { get; private set; }
        public Color PlayerActual { get; private set; }
        public bool GameEnd { get; private set; }
        public bool Check { get; private set; }

        private HashSet<Piece> pieces;
        private HashSet<Piece> capturedPieces;


        public GameChess()
        {
            Board = new Board(8, 8);
            Turn = 1;
            PlayerActual = Color.White;
            pieces = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();
            GameEnd = false;
            InsertPieces();
        }

        public Piece ExecuteMoviment(Position origin, Position destiny)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncrementAmountMoviment();
            Piece capturedPiece = Board.RemovePiece(destiny);
            Board.InsertPiece(piece, destiny);
            if (capturedPiece != null)
            {
                capturedPieces.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void ReturnMoviment(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece piece = Board.RemovePiece(destiny);
            piece.DencrementAmountMoviment();
            if (capturedPiece != null)
            {
                Board.InsertPiece(capturedPiece, destiny);
                capturedPieces.Remove(capturedPiece);
            }
            Board.InsertPiece(piece, origin);
        }



        public void PerformsMove(Position origin, Position destiny)
        {
            Piece capturedPiece = ExecuteMoviment(origin, destiny);


            if (IsCheck(PlayerActual))
            {
                ReturnMoviment(origin, destiny, capturedPiece);
                throw new ExceptionBoard("You can't stay in check!");
            }
            if (IsCheck(AdversaryPlayer(PlayerActual)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }
            if (CheckMateTest(AdversaryPlayer(PlayerActual)))
            {
                GameEnd= true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }

            
        }

        public void OriginPositionValidation(Position position)
        {
            if (Board.piece(position) == null)
            {
                throw new ExceptionBoard("This position don´t have a piece");
            }
            if (PlayerActual != Board.piece(position).Color)
            {
                throw new ExceptionBoard("The origin piece isn´t your color");
            }
            if (!Board.piece(position).HavePossibleMoviments())
            {
                throw new ExceptionBoard("There are no moves possible for the chosen piece!");
            }
        }

        public void DestinyPositionValidation(Position origin, Position destiny)
        {
            if (!Board.piece(origin).PossibleMoviment(destiny))
            {
                throw new ExceptionBoard("Invalid destiny position!");
            }

        }


        private void ChangePlayer()
        {
            if (PlayerActual == Color.White)
            {
                PlayerActual = Color.Black;
            }
            else
            {
                PlayerActual = Color.White;
            }
        }
        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> var = new HashSet<Piece>();
            foreach (Piece piece in capturedPieces)
            {
                if (piece.Color == color)
                {
                    var.Add(piece);
                }
            }
            return var;
        }

        public HashSet<Piece> PieceInGame(Color color)
        {
            HashSet<Piece> var = new HashSet<Piece>();
            foreach (Piece piece in pieces)
            {
                if (piece.Color == color)
                {
                    var.Add(piece);
                }
            }
            var.ExceptWith(CapturedPieces(color));
            return var;
        }

        private Color AdversaryPlayer(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece King(Color color)
        {
            foreach (Piece piece in PieceInGame(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }
            return null;//Vale lembrar que não é para acontecer isto.
        }

        public bool IsCheck(Color color)
        {
            Piece king = King(color);
            if (king == null)
            {
                throw new ExceptionBoard($"Don´t have a King {color} in the boardgame");
            }



            foreach (Piece piece in PieceInGame(AdversaryPlayer(color)))
            {
                bool[,] matriz = piece.PossibleMoviments();
                if (matriz[king.Position.Line, king.Position.Column])
                {
                    return true;
                }

            }
            return false;
        }

        public bool CheckMateTest(Color color)
        {
            if (!IsCheck(color))
            {
                return false;
            }
            foreach (Piece piece in PieceInGame(color))
            {
                bool[,] matriz = piece.PossibleMoviments();

                for (int i = 0; i < Board.Lines; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (matriz[i, j])
                        {
                            
                            Position destiny = new Position(i, j);
                            Position origin = piece.Position;//Tive que adicionar esta parte para funcionar.

                            Piece capturedPiece = ExecuteMoviment(piece.Position, destiny);
                            bool checkTest = IsCheck(color);
                            ReturnMoviment(origin, destiny, capturedPiece);
                            if (!checkTest)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }


        public void InsertNewPiece(char column, int line, Piece piece)
        {
            Board.InsertPiece(piece, new ChessPosition(column, line).ToPosition());
            pieces.Add(piece);
        }
        private void InsertPieces()
        {
            //Black
            InsertNewPiece('a', 8, new Tower(Color.Black, Board));
            InsertNewPiece('b', 8, new Horse(Color.Black, Board));
            InsertNewPiece('c', 8, new Bishop(Color.Black, Board)); 
            InsertNewPiece('d', 8, new King(Color.Black, Board));
            InsertNewPiece('e', 8, new Queen(Color.Black, Board));
            InsertNewPiece('f', 8, new Bishop(Color.Black, Board));
            InsertNewPiece('g', 8, new Horse(Color.Black, Board));
            InsertNewPiece('h', 8, new Tower(Color.Black, Board));

            InsertNewPiece('a', 7, new Pawn(Color.Black, Board));
            InsertNewPiece('b', 7, new Pawn(Color.Black, Board));
            InsertNewPiece('c', 7, new Pawn(Color.Black, Board));
            InsertNewPiece('d', 7, new Pawn(Color.Black, Board));
            InsertNewPiece('e', 7, new Pawn(Color.Black, Board));
            InsertNewPiece('f', 7, new Pawn(Color.Black, Board));
            InsertNewPiece('g', 7, new Pawn(Color.Black, Board));
            InsertNewPiece('h', 7, new Pawn(Color.Black, Board));

            //Peça de teste
            //InsertNewPiece('b', 3, new Pawn(Color.Black, Board));



            //White
            InsertNewPiece('a', 1, new Tower(Color.White, Board));
            InsertNewPiece('b', 1, new Horse(Color.White, Board));
            InsertNewPiece('c', 1, new Bishop(Color.White, Board));
            InsertNewPiece('d', 1, new King(Color.White, Board));
            InsertNewPiece('e', 1, new Queen(Color.White, Board));     
            InsertNewPiece('f', 1, new Bishop(Color.White, Board));
            InsertNewPiece('g', 1, new Horse(Color.White, Board));
            InsertNewPiece('h', 1, new Tower(Color.White, Board));
            InsertNewPiece('a', 2, new Pawn(Color.White, Board));
            InsertNewPiece('b', 2, new Pawn(Color.White, Board));
            InsertNewPiece('c', 2, new Pawn(Color.White, Board));
            InsertNewPiece('d', 2, new Pawn(Color.White, Board));
            InsertNewPiece('e', 2, new Pawn(Color.White, Board));
            InsertNewPiece('f', 2, new Pawn(Color.White, Board));
            InsertNewPiece('g', 2, new Pawn(Color.White, Board));
            InsertNewPiece('h', 2, new Pawn(Color.White, Board));

        }
    }
}
