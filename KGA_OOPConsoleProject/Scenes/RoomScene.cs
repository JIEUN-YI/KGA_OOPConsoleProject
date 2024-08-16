namespace KGA_OOPConsoleProject.Scenes
{
    public class RoomScene : Scene
    {
        // 현재 상태가 기본 / 상태보기 / 인벤토리 열기 선택
        public enum State { normal, Status, Inventory }
        public State nowState;
        private string input;
        public RoomScene(GameData game, Player player) : base(game, player)
        {

        }
        public override void Enter()
        {
            nowState = State.normal;
        }
        public override void Render()
        {
            Thread.Sleep(1000);
            if (nowState == State.normal)
            {
                Console.Clear();
                Console.WriteLine(" ===================================== ");
                Console.WriteLine($" Day : {game.nowDay}");
                Thread.Sleep(1000);
                Console.WriteLine(" 아늑한 방이다.");
                Console.WriteLine($" {player.name}이(가) 좋아하는 물건들로 가득 차 있다.");
                Console.WriteLine(" 오늘 하루는 무엇을 할까?");
                Console.WriteLine(" ===================================== ");
                Console.WriteLine(" 1. 스케쥴 수행하기");
                Console.WriteLine(" 2. 상점가기");
                Console.WriteLine(" 3. 상태보기");
                Console.WriteLine(" 4. 인벤토리");
                // 아이템 구현 후 인벤토리 보기 구현예정
                Console.Write(" 선택 : ");
            }
            else if (nowState == State.Status)
            {
                player.ShowStatus(game);
            }
        }
        public override void Input()
        {
            input = Console.ReadLine();
        }
        public override void Update()
        {
            if (nowState == State.normal)
            {
                switch (input)
                {
                    case "1":
                        game.ChangeScene(SceneType.SelectSchedule);
                        break;
                    case "2":
                        game.ChangeScene(SceneType.Shop);
                        break;
                    case "3":
                        nowState = State.Status;
                        break;
                    case "4":
                        game.ChangeScene(SceneType.Inventory);
                        break;
                    default:
                        break;
                }
            }
            else if (nowState == State.Status)
            {
                nowState = State.normal;
            }

        }
        public override void Exit()
        {

        }
    }
}
