using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usurper_V1._0
{
    class Stack
    {
        //Custom stack data type used for the repeat last move feature.
        private Turn[] stack;
        private int pointer,Capacity;
        
        public Stack(int size)
        {
            stack = new Turn[size];
            pointer = -1;
            Capacity = size-1;
        }

        public bool isEmpty()
        {
            if(pointer == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isFull()
        {
            if (pointer == Capacity)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void push(int Index,int Attacker,int Victim)
        {
            if (isFull())
            {
                Console.WriteLine("Stack full!");
            }
            else
            {
                pointer++;
                Turn turn = new Turn(Index, Attacker, Victim);
                stack[pointer] = turn;
            }
        }

        public Turn Pop()
        {
            if (isEmpty())
            {
                return null;
            }
            else
            {
                pointer--;
                return stack[pointer+1];
            }
        }

        public void peek()
        {
            if (isEmpty())
            {
                Console.WriteLine("Stack empty!");
            }
            else
            {
                Console.WriteLine(stack[pointer]);
            }
        }

        public void DisplayStack()
        {
            for(int i = 0; i < pointer; i++)
            {
                Console.WriteLine(stack[i]);
            }
        }
    }
}
