namespace KGA_OOPConsoleProject.Monsters.DarkM
{
    public class UnknownMonster : Monster
    {
        public UnknownMonster() : base()
        {
            name = "정체를 알 수 없는 괴물";
            maxHp = 85;
            nowHp = maxHp;
            ATK = 30;
            DEF = 30;
            level = 6;
            nowState = State.Live;
        }
    }
}