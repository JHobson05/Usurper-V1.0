﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    public class MoveList
    {
        /*
          Similar to the state system I am using a class to contain the moves.
          Each character will instead contain an array with id references to the moves it has access to. 
          When a move is needed it will use the id to access the move via this class. Originally each move was its own subclass
          but that has been changed to have each one instantiated as just a move inside the list.
        */
        //private IcicleRain icicleRain;
        //private Blizzard blizzard;
        //private MightyShot mightyShot;
        //private Barrage barrage;
        //private Gut gut;
        //private IceBeam iceBeam;
        //private FrozenFury frozenFury;
        //private FlameArrow flameArrow;
        //private ThunderThrust thunderThrust;
        //private VoltVolley voltVolley;
        //private Slash slash;
        //private ShieldBash shieldBash;
        //private SoldiersShout soldiersShout;

        private Move icicleRain;
        private Move blizzard;
        private Move mightyShot;
        private Move barrage;
        private Move gut;
        private Move iceBeam;
        private Move frozenFury;
        private Move flameArrow;
        private Move thunderThrust;
        private Move voltVolley;
        private Move slash;
        private Move shieldBash;
        private Move soldiersShout;
        public List<Move> Moves;
        public MoveList()
        {
            icicleRain = new Move(MoveID.icicleRain,"atk","Frost","IcicleRainIcon","Icicle Rain", 40, false, 0);
            blizzard = new Move(MoveID.blizzard,"spAtk","Frost","BlizzardIcon","Blizzard",20,true,2);
            mightyShot = new Move(MoveID.mightyShot,"atk","Normal",null,"Mighty Shot",40,false,0);
            barrage = new Move(MoveID.barrage,"atk","Normal",null,"Barrage",35,false,0);
            gut = new Move(MoveID.gut,"spAtk","Normal",null,"Gut",50,false,0);
            iceBeam = new Move(MoveID.iceBeam,"spAtk","Frost", "IceBeamIcon","Ice Beam",60,true,1);
            frozenFury = new Move(MoveID.frozenFury,"spAtk","Frost","FrozenFuryIcon","Frozen Fury",80, false,0);
            flameArrow = new Move(MoveID.flameArrow,"spAtk","Fire",null,"Flame Arrow",30,true,5);
            thunderThrust = new Move(MoveID.thunderThrust,"atk","Electric","ThunderThrustIcon","Thunder Thrust",55,false,0);
            voltVolley = new Move(MoveID.voltVolley,"spAtk","Electric",null,"Volt Volley",45,true,3);
            slash = new Move(MoveID.slash,"atk","Normal",null,"Slash",30,false,0);
            shieldBash = new Move(MoveID.shieldBash,"atk","Normal",null,"Shield Bash", 25, true,0);
            soldiersShout = new Move(MoveID.soldiersShout,"spAtk","Normal",null,"Soldiers Shout",0,true,0);
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
