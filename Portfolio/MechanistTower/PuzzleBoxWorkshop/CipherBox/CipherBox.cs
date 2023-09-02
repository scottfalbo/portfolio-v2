namespace Portfolio.MechanistTower.PuzzleBoxWorkshop.CipherBox
{
    public class CipherBox
    {
        private GameRune[,] GameBoard { get; set; }

        public CipherBox(int x, int y)
        {
            GameBoard = new GameRune[x, y];

            ConjureRunes();
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
        }
    }
}