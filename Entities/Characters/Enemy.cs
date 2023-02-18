
namespace Usurper_V1._0
{
    public class Enemy: Character
    {
        //This class is not currently in use and probably wont be.
        public Enemy(int h, int a, int sa, int d,int sd , string Sprite,string name, string type) : base(4)
        {
            hp = h; atk = a; spAtk = sa; spDef = sd;
            spriteString = Sprite;
            this.name = name;
            this.type = type;
        }

    }
}
