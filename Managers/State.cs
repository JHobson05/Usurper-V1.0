using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Usurper_V1._0
{
    public abstract class State
    {
        private int id;

        public State(int id)
        {
            this.id = id;
        }

        public int Id
        {
            get { return id; }
        }

        public abstract void Initialize(Game1 g);
        public abstract void Update(GameTime gt, Game1 g);
        public abstract void Draw(Game1 g);
    }
}
