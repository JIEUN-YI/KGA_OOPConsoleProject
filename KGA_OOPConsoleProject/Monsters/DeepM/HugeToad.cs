namespace KGA_OOPConsoleProject.Monsters.DeepM
{
    public class HugeToad : Monster
    {
        public HugeToad() : base()
        {
            name = "거대한 두꺼비";
            maxHp = 15;
            nowHp = maxHp;
            ATK = 2;
            DEF = 0;
            level = 2;
            nowState = State.Live;
        }
    }
}