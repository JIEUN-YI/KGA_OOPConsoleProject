namespace KGA_OOPConsoleProject.Monsters.VillageM
{
    public class MildDeer : Monster
    {
        public MildDeer() : base()
        {
            name = "순한 사슴";
            maxHp = 10;
            nowHp = maxHp;
            ATK = 1;
            DEF = 0;
            level = 1;
            nowState = State.Live;
        }
    }
}