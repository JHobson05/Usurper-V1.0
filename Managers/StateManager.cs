﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Usurper_V1._0
{
    public class StateManager
    {
        public List<State> states = new List<State>();
        public int selected;
        public int Count 
        {
            get{ return states.Count; } 
        }

        public void Update(GameTime gt,Game1 g)
        {
            states[selected].Update(gt, g);
        }

        public void Draw(Game1 g)
        {
            states[selected].Draw(g);
        }

        public void Add(State state,Game1 g)
        {
            states.Add(state);
            state.Initialize(g);
        }
        public void remove(State state)
        {
            states.Remove(state);
        }

        public virtual void Set(int id)
        {
            selected = id;
        }
        public virtual void Set(State state)
        {
            selected = state.Id;
        }
        public void Clear() { states.Clear(); }
    }
}