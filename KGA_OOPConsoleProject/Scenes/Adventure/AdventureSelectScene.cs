/* 코멘트
 * Update()함수의 이중 스위치문
 * 다른 방법이 있는지 연구가 필요함
 */
namespace KGA_OOPConsoleProject.Scenes.Adventure
{
    public class AdventureSelectScene : Scene
    {
        private enum State { select, finish } // 선택하는 상태, 종료한 상태
        private State nowState;
        private string input;

        public AdventureSelectScene(GameData game, Player player) : base(game, player)
        {

        }
        public override void Enter()
        {

        }
        public override void Render()
        {
            switch (nowState)
            {
                case State.select:
                    Console.Clear();
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine(" 모험 장소를 선택하세요");
                    Console.WriteLine(" 1. 마을 뒷 산");
                    Console.WriteLine(" 2. 깊은 강가");
                    Console.WriteLine(" 3. 어두운 숲");
                    Console.WriteLine(" ===================================== ");
                    Console.Write(" 선택 : ");
                    break;
                case State.finish:
                    Console.Clear();
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine(" 집으로 돌아갑니다.");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(1000);
                    break;
            }
        }
        public override void Input()
        {
            if (nowState != State.finish) // 모든 행동이 끝나면 자동으로 하루가 넘어감 = 입력X
            {
                input = Console.ReadLine();
            }
        }
        public override void Update()
        {
            switch (nowState)
            {
                case State.select:
                    switch (input)
                    {
                        case "1":
                            game.ChangeScene(SceneType.VillageMt);
                            nowState = State.finish;
                            break;
                        case "2":
                            game.ChangeScene(SceneType.DeepRiver);
                            nowState = State.finish;
                            break;
                        case "3":
                            game.ChangeScene(SceneType.DarkForest);
                            nowState = State.finish;
                            break;
                        default:
                            break;
                    }
                    break;
                case State.finish:
                    nowState = State.select;
                    game.ChangeScene(SceneType.SelectSchedule); //엔딩씬으로 이동
                    break;
                default:
                    break;
            }
        }
        public override void Exit()
        {

        }
    }
}
