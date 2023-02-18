
namespace Usurper_V1._0
{
    class FlameDemon : Character
    {
        public FlameDemon() : base(CharacterID.FlameDemon)
        {
            name = "Flame Demon";
            spriteString = "FlameDemon";
            type = "Fire";
            atk = 8;
            spAtk = 9;
            def = 10;
            spDef = 11;
            maxHp = 1500; hp = maxHp;
            Moves[0] = 15;
            Moves[1] = 16;
            Moves[2] = 17;
            Moves[3] = 19;
        }
    }
}
