using Cells;
using Model.Data;
using Model.Gomoku;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows;


namespace ViewModel
{
    public class GameViewModel
    {
        private ICell<IGame> GameVM;

        public int Size { get; set; }
        public IEnumerable<GameBoardRowViewModel> RowsVM { get; }
        public GameBoardViewModel BoardVM { get; }
        public GameViewModel(IGame game)
        {

            this.GameVM = Cell.Create(game);
            this.BoardVM = new GameBoardViewModel(GameVM);
            this.RowsVM = BoardVM.RowsVM;

        }


    }

    public class GameBoardViewModel
    {
        public ICell<IGameBoard> BoardVM { get; }
        public IEnumerable<GameBoardRowViewModel> RowsVM { get; }

        public GameBoardViewModel(ICell<IGame> game)
        {
            
            BoardVM = game.Derive(g => g.Board);
            RowsVM = setupRows(BoardVM.Value,game);
            
        }

       

        private IEnumerable<GameBoardRowViewModel> setupRows(IGameBoard board, ICell<IGame> game)
        {
            
            List<GameBoardRowViewModel> lists = new List<GameBoardRowViewModel>();
            for (int i = 0; i < board.Height; i++)
            {
                lists.Add((GameBoardRowViewModel)new GameBoardRowViewModel(game,i));
            }
            return lists;
        }
    }

    public class GameBoardRowViewModel
    {
        public IEnumerable<GameBoardSquareViewModel> Squares { get; }
        public GameBoardRowViewModel(ICell<IGame> game, int position)
        {

            this.Squares = Row(game, position);
        }
        private IEnumerable<GameBoardSquareViewModel> Row(ICell<IGame> game, int row)
        {
            
            List<GameBoardSquareViewModel> stones = new List<GameBoardSquareViewModel>();
            for (int i = 0; i < game.Value.Board.Width; i++)
            {
               var position = new Vector2D(i, row);
                stones.Add(new GameBoardSquareViewModel(game, position));
            }
            return stones;
        }
    }
    public class GameBoardSquareViewModel
    {
        public Vector2D pos { get; }

        private ICell<IGame> GameVM { get; set; }
    
        public object color { get; }

        public ICell<Stone> Owner { get; }
        

        public ICommand PutStone { get; }
        ///public ICell<bool> isValidMove;
        public GameBoardSquareViewModel(ICell<IGame> game, Vector2D position )
        {
            this.pos = position;
            this.Owner = game.Derive(b => b.Board[position]); ;
            ICell<bool> isValidMove = game.Derive(g => !g.IsGameOver ? g.IsValidMove(position) : false);
           
            //this.PutStone = new CellCommand(isValidMove, () => {  game.Value = game.Value.PutStone(position); });
            this.PutStone = new CellCommand(game.Derive(g => g.IsGameOver ? false : g.IsValidMove(position)), () => { game.Value = game.Value.PutStone(position); });

            this.color = game.Derive(ColorSquares);


        }
        public Object ColorSquares(IGame game)
        {
            if(!game.IsGameOver)
            {
                if (game.CapturedPositions.Contains(pos))
                {
                    return "Red";
                }

                else
                {
                    return "LightGray";
                }
            }
            else
            {
                if (game.WinningPositions.Contains(pos))
                {
                    return "LightBlue";
                }

                else
                {
                    return "LightGray";
                }
            }
           
        }
    }

   

    public class CellCommand : ICommand
    {
        public ICell<bool> canExecute;
        public Action execute;
        public CellCommand(ICell<bool> canExecute, Action execute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
            this.canExecute.ValueChanged += () => CanExecuteChanged?.Invoke(this, new EventArgs());
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
           return this.canExecute.Value;
        }

        public void Execute(object parameter)
        {
            execute();
        }
    }

}

