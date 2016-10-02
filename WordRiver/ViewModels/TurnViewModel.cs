using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordRiver.Common;

namespace WordRiver.ViewModels
{
    public class TurnViewModel
    {
        public TurnViewModel(string word, PlayerType player)
        {
            Word = word;
            Player = player;
        }

        public TurnViewModel(PlayerType player)
        {
            Word = null;
            Player = player;
        }

        public TurnViewModel()
        {

        }

        public string Word
        {
            get;
            set;
        }

        public PlayerType Player
        {
            get;
            set;
        }
    }
}
