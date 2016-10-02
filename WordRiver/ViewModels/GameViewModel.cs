using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordRiver.Common;
using WordRiver.Models;

namespace WordRiver.ViewModels
{
    public class GameViewModel
    {
        private GameModel Game;

        private ObservableCollection<TurnViewModel> turns = new ObservableCollection<TurnViewModel>();
        public ObservableCollection<TurnViewModel> Turns
        {
            get { return this.turns; }
        }

        public GameViewModel()
        {
            AsyncInitialize();
        }

        private async void AsyncInitialize()
        {
            Game = await GameFactory.CreateGame();
            GoToPlayerTurn();
        }

        private void GoToPlayerTurn()
        {
            var compWord = Game.GetNextWord();
            var compTurn = new TurnViewModel(compWord, PlayerType.Computer);
            Turns.Add(compTurn);

            var playerTurn = new TurnViewModel(PlayerType.Player);
            Turns.Add(playerTurn);
        }
    }


}
