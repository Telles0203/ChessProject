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
                GameChess gameChess = new GameChess();
                while (!gameChess.GameEnd)
                {

                    try
                    {
                        Console.Clear();
                        Screen.PrintBoard(gameChess.Board);
                        Console.WriteLine();
                        Console.WriteLine($"Turn: {gameChess.Turn}");
                        Console.WriteLine($"Waiting move: {gameChess.PlayerActual}");


                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origem = Screen.ReadChessPosition().ToPosition();
                        gameChess.OriginPositionValidation(origem);


                        bool[,] possiblePositions = gameChess.Board.piece(origem).PossibleMoviments();


                        Console.Clear();
                        Screen.PrintBoard(gameChess.Board, possiblePositions);


                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = Screen.ReadChessPosition().ToPosition();
                        gameChess.DestinyPositionValidation(origem, destiny);

                        gameChess.PerformsMove(origem, destiny);
                    }
                    catch (ExceptionBoard exception)
                    {
                        Console.WriteLine(exception.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch (ExceptionBoard exception)
            {
                Console.WriteLine(exception.Message);
            }

        }
    }
}