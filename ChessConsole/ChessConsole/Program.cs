using Chess;
using ChessBoard;

namespace ChessConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {



            try
            {
                GameChess gameChess= new GameChess();
                while (!gameChess.GameEnd)
                {
                    Console.Clear();
                    Screen.PrintBoard(gameChess.Board);
                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origem = Screen.ReadChessPosition().ToPosition();

                    //bool[,] possiblePositions = gameChess.Board.piece(origem).PossibleMoviments();


                    //Console.Clear();
                   // Screen.PrintBoard(gameChess.Board, possiblePositions);


                    Console.Write("Destiny: ");
                    Position destiny = Screen.ReadChessPosition().ToPosition();

                    gameChess.ExecuteMoviment(origem, destiny);
                }


            }
            catch (ExceptionBoard exception)
            {
                Console.WriteLine(exception.Message);
            }

        }
    }
}