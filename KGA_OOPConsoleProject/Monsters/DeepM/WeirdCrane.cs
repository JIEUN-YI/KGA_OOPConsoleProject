namespace KGA_OOPConsoleProject.Monsters.DeepM
{
    public class WeirdCrane : Monster
    {
        public WeirdCrane() : base()
        {
            name = "어딘가 이상한 두루미";
            maxHp = 40;
            nowHp = maxHp;
            ATK = 20;
            DEF = 15;
            level = 4;
            nowState = State.Live;
        }
    }
}