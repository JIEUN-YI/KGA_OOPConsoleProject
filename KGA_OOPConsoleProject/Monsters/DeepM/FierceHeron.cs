namespace KGA_OOPConsoleProject.Monsters.DeepM
{
    public class FierceHeron : Monster
    {
        public FierceHeron() : base()
        {
            name = "사나운 왜가리";
            maxHp = 30;
            nowHp = maxHp;
            ATK = 10;
            DEF = 10;
            level = 3;
            nowState = State.Live;
        }
    }
}