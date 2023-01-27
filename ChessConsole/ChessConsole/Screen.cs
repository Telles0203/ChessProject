using Chess;
using ChessBoard;

namespace ChessConsole
{
    class Screen
    {

        public static void PrintBoard(GameChess gameChess)
        {
            PrintBoard(gameChess.Board);
            Console.WriteLine();
            PrintCapturedPieces(gameChess);
            Console.WriteLine($"Turn: {gameChess.Turn}");
            Console.WriteLine($"Waiting move: {gameChess.PlayerActual}");
            if (gameChess.Check)
            {
                Console.WriteLine("CHECK");
            }
        }


        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write($"{8 - i} |");
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.piece(i, j));

                }
                Console.WriteLine();
            }
            Console.WriteLine($"   a b c d e f g h");
        }


        public static void PrintBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor newBackground = ConsoleColor.DarkGray;


            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write($"{8 - i} |");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = newBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    PrintPiece(board.piece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine($"   a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }
        
        
        public static void PrintCapturedPieces(GameChess gameChess)
        {
            Console.WriteLine("Captured pieces: ");
            Console.Write($"White: ");
            PrintSet(gameChess.CapturedPieces(Color.White));
            Console.Write($"Black: ");
            ConsoleColor var = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            PrintSet(gameChess.CapturedPieces(Color.Black));
            Console.ForegroundColor = var;
            Console.WriteLine();
        }

        public static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[");
            int count = 0;
            foreach (Piece piece in set)
            {
                if (count <= 0)
                {
                    Console.Write($"{piece}");
                }
                else
                {
                    Console.Write($"{piece}, ");
                    count++;
                }
               
            }
            Console.WriteLine("]");
        }

        

    public static ChessPosition ReadChessPosition()
        {
            string var1 = Console.ReadLine();
            char column = var1[0];
            int line = int.Parse(var1[1] + " ");
            return new ChessPosition(column, line);
        }




        public static void PrintPiece(Piece piece)
        {

            if (piece == null)
            {
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("|");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    ConsoleColor var1 = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write($"{piece}");
                    Console.ForegroundColor = var1;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("|");
                }
                else
                {
                    ConsoleColor var1 = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"{piece}");
                    Console.ForegroundColor = var1;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("|");
                }
            }


        }

        public void BoardTemplate(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                for (int j = 0; j < board.Columns; j++)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }
            }
        }

    }

}
