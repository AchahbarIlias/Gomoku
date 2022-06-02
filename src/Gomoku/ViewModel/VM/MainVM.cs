using Cells;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.VM
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            // Create empty cell
            CurrentScreen = Cell.Create<ScreenViewModel>(null);

            // Create screen A
            var firstScreen = new ScreenAViewModel(CurrentScreen);

            // Put first screen in CurrentScreen cell
            CurrentScreen.Value = firstScreen;

        }

        public ICell<ScreenViewModel> CurrentScreen { get; }
    }
}
