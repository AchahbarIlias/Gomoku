using Cells;
using Model.Gomoku;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ViewModel.VM
{
    public class ScreenAViewModel : ScreenViewModel
    {
        public ICell<bool> Checked { get; set; }
        
        

        public ScreenAViewModel(ICell<ScreenViewModel> currentScreen) : base(currentScreen)
        {
           
            SwitchToScreenB = new ActionCommand(() => CurrentScreen.Value = new ScreenBViewModel(this.CurrentScreen, this.Size.Value, this.Capture.Value));
            this.Minimum = IGame.MinimumBoardSize;
            this.Maximum = IGame.MaximumBoardSize;

            

            this.Size = Cell.Create(15);
            this.Capture = Cell.Create(true);
        }

        public ICell<int> Size { get; }
        public ICell<bool> Capture { get; }

        public ICommand SwitchToScreenB { get; }

        public int Minimum { get; }
        public int Maximum { get; }

       

    }
}
