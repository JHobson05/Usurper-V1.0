using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    public class MoveList
    {
        /*
          Similar to the state system I am using a class to contain the moves.
          Each character will instead contain an array with id references to the moves it has access to. 
          When a move is needed it will use the id to access the move via this class.
        */
        private IcicleRain icicleRain;
        private Blizzard blizzard;
        private MightyShot mightyShot;
        private Barrage barrage;
        private Gut gut;
        private IceBeam iceBeam;
        private FrozenFury frozenFury;
        private FlameArrow flameArrow;
        private ThunderThrust thunderThrust;
        private VoltVolley voltVolley;
        private Slash slash;
        private ShieldBash shieldBash;
        private SoldiersShout soldiersShout;
        public List<Move> Moves;
        public MoveList()
        {
            icicleRain = new IcicleRain();
            blizzard = new Blizzard();
            mightyShot = new MightyShot();
            barrage = new Barrage();
            gut = new Gut();
            iceBeam = new IceBeam();
            frozenFury = new FrozenFury();
            flameArrow = new FlameArrow();
            thunderThrust = new ThunderThrust();
            voltVolley = new VoltVolley();
            slash = new Slash();
            shieldBash = new ShieldBash();
            soldiersShout = new SoldiersShout();
            Moves = new List<Move>();
            Moves.Add(icicleRain);
            Moves.Add(blizzard);
            Moves.Add(mightyShot);
            Moves.Add(barrage);
            Moves.Add(gut);
            Moves.Add(iceBeam);
            Moves.Add(frozenFury);
            Moves.Add(flameArrow);
            Moves.Add(thunderThrust);
            Moves.Add(voltVolley);
            Moves.Add(slash);
            Moves.Add(shieldBash);
            Moves.Add(soldiersShout);
        }


    }
}
