using Cells;
using Model.Gomoku;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ViewModel.VM
{

    public class ScreenBViewModel : ScreenViewModel
    {
        public ICell<IGame> GameVM { get; set; }
        public IEnumerable<GameBoardRowViewModel> RowsVM { get; }
        public ICell<Stone> CurrentPlayer { get; set; }
        public ICell<Stone> Winner { get; set; }
        public ICell<bool> IsGameOver { get; }

        public GameBoardViewModel BoardVM { get; }

        public ScreenBViewModel(ICell<ScreenViewModel> currentScreen, int size, bool capturing) : base(currentScreen)
        {
            SwitchToScreenA = new ActionCommand(() => CurrentScreen.Value = new ScreenAViewModel(this.CurrentScreen));
            // SwitchToScreenC = new ActionCommand(() => CurrentScreen.Value = new ScreenCViewModel(this.CurrentScreen));
            this.GameVM = Cell.Create(IGame.Create(size, capturing));
            this.BoardVM = new GameBoardViewModel(GameVM);
            this.RowsVM = BoardVM.RowsVM;
            this.CurrentPlayer = GameVM.Derive(g => g.IsGameOver ? null : g.CurrentPlayer);
            this.Winner = GameVM.Derive(g => g.IsGameOver ? g.Winner : null);
            
        }
        
        

       // public ICommand Winner { get; }

        public ICommand SwitchToScreenA { get; }

        

       // public ICommand CurrentPlayer { get; }

        public ICommand CapturedPositions { get; }

        
        



    }

}
