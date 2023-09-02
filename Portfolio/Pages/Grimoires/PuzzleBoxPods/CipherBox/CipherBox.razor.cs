using Microsoft.AspNetCore.Components;
using Portfolio.MechanistTower.PuzzleBoxWorkshop.CipherBox;

namespace Portfolio.Pages.Grimoires.PuzzleBoxPods.CipherBox
{
    public partial class CipherBox : ComponentBase
    {
        private CipherBoard CipherBoard { get; set; }

        public int TeleportTranscript => CipherBoard.TeleportTranscript;
        public GameRune[,] GameBoard => CipherBoard.GameBoard;
        public int GameBoardX => CipherBoard.GameBoardX;
        public int GameBoardY => CipherBoard.GameBoardY;
        public bool Victory => CipherBoard.Victory;

        protected override void OnInitialized()
        {
            CipherBoard = new CipherBoard(4, 4);
        }

        public void ActivateRune(int x, int y)
        {
            if (!Victory)
            {
                CipherBoard.TranslocateRune(x, y);

                if (Victory)
                {
                    CipherBoard.GameBoard[GameBoardX, GameBoardY] = CipherBoard.ExiledRune;
                }
            }
        }
    }
}