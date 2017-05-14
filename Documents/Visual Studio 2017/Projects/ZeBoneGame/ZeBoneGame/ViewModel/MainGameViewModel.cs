using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeBoneGame.Model;

namespace ZeBoneGame.ViewModel
{
    public class MainGameViewModel : BaseViewModel
    { 
        public BaseViewModel CurrentStepView { get; set; }

        public BoneGame Game { get; set; }

        public MainGameViewModel()
        {
            Game = new BoneGame();
        }



    }
}
