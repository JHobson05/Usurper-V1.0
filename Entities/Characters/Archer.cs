
namespace Usurper_V1._0
{
    public class Archer : Character
    {
        public Archer() : base(CharacterID.Archer)
        {
            atk = 7;
            spAtk = 3;
            def = 3;
            spDef = 4;
            maxHp = 200; hp = maxHp;
            spriteString = "Archer";
            name = "Archer";
            type = "Normal";
            Moves[0] = 2;
            Moves[1] = 3;
            Moves[2] = 4;
            Moves[3] = 7;
        }
    }
}
