namespace Portfolio.MechanistTower.PuzzleBoxWorkshop.CipherBox
{
    public class CipherBox
    {
        private GameRune[,] GameBoard { get; set; }

        public CipherBox(int x, int y)
        {
            GameBoard = new GameRune[x, y];

            ConjureRunes();
            ScatterRunes();
        }

        private void ConjureRunes()
        {
            var counter = 0;

            for (int x = 0; x < GameBoard.GetLength(0); x++)
            {
                for (int y = 0; y < GameBoard.GetLength(1); y++)
                {
                    GameBoard[x, y] = new GameRune
                    {
                        Sigil = 0,
                        X = x,
                        Y = y,
                        SolvedX = x,
                        SolvedY = y,
                        ImageUrl = $"https://something-{counter}.png"
                    };

                    counter++;
                }
            }
        }

        private void ScatterRunes()
        {
            var random = new Random();

            for (var i = 0; i < 1000; i++)
            {
                var randomX = random.Next(0, GameBoard.GetLength(0));
                var randomY = random.Next(0, GameBoard.GetLength(1));

                var randomX2 = random.Next(0, GameBoard.GetLength(0));
                var randomY2 = random.Next(0, GameBoard.GetLength(1));

                var runeOne = GameBoard[randomX, randomY];
                runeOne.X = randomX2;
                runeOne.Y = randomY2;

                var runeTwo = GameBoard[randomX2, randomY2];
                runeTwo.X = randomX;
                runeTwo.Y = randomY;

                GameBoard[randomX, randomY] = runeTwo;
                GameBoard[randomX2, randomY2] = runeOne;
            }
        }
    }
}