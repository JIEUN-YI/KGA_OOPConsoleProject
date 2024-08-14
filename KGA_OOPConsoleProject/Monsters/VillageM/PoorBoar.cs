namespace KGA_OOPConsoleProject.Monsters.VillageM
{
    public class PoorBoar : Monster
    {
        public PoorBoar() : base()
        {
            name = "둔한 멧돼지";
            maxHp = 15;
            nowHp = maxHp;
            ATK = 5;
            DEF = 5;
            level = 2;
            nowState = State.Live;
        }
    }
}
