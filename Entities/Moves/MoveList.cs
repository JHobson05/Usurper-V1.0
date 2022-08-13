using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    public class MoveList
    {
        /*
          Similar to the state system I am using a global class to contain the moves.
          Each character will instead contain an id reference to the moves it has access to. 
          When a move is needed it will use the id to access the move through this class.
        */
        private IcicleRain icicleRain;
        private Blizzard blizzard;
        private MightyShot mightyShot;
        public List<Move> Moves;
        public MoveList()
        {
            icicleRain = new IcicleRain();
            blizzard = new Blizzard();
            mightyShot = new MightyShot();
            Moves = new List<Move>();
            Moves.Add(icicleRain);
            Moves.Add(blizzard);
            Moves.Add(mightyShot);
        }


    }
}
