using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    public class Party
    {
        //All characters in a fight are grouped in parties to distinguish between the opposing sides.
        private int cap = 3;
        private bool reachedCap = false,empty = true;
        private string title;
        //public List<Character> party = new List<Character>();
        public Character[] party = new Character[3];

        //public Party(Character F,Character S, Character T)
        //{
        //    if (F.Name != "")
        //    {
        //        party.Add(F);
        //    }
        //    if (S.Name != "")
        //    {
        //        party.Add(S);
        //    }
        //    if (T.Name != "")
        //    {
        //        party.Add(T);
        //    }
        //    if (party[2].Name != "")
        //    {
        //        reachedCap = true;
        //    }
        //}

        public Party(Character F,Character S,Character T)
        {
            if (F.Name != "")
            {
                party[0] = F;
            }
            if (S.Name != "")
            {
                party[1] = S;
            }
            if (T.Name != "")
            {
                party[2] = T;
            }
            if (party[2].Name != "")
            {
                reachedCap = true;
            }
        }

        //public Party(Character F)
        //{
        //    if (F.Name != "")
        //    {
        //        party.Add(F);
        //    }
        //}
        public Party(Character F)
        {
            if (F.Name != "")
            {
                party[0] = F;
            }
        }

        //public Party(Character F,Character S)
        //{
        //    if (F.Name != "")
        //    {
        //        party.Add(F);
        //    }
        //    if(S.Name != "")
        //    {
        //        party.Add(S);
        //    }
        //}
        public Party(Character F, Character S)
        {
            if (F.Name != "")
            {
                party[0] = F;
            }
            if (S.Name != "")
            {
                party[1] = S;
            }
        }

        //public void AddToParty(Character F)
        //{
        //    if (reachedCap) { return; }
        //    else 
        //    { 
        //        party.Add(F);
        //        if (empty)
        //        {
        //            empty = false;
        //        }
        //        if(party.Count == cap) { reachedCap = true; }
        //    }
        //}
        //public void RemoveFromParty(Character F)
        //{
        //    if (empty)
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        party.Remove(F);
        //        if(party.Count == 0)
        //        {
        //            empty = true;
        //        }
        //    }
        //}
    }
}
