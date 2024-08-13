namespace KGA_OOPConsoleProject.Scenes
{
    public class SelectScheduleScene : Scene
    {
        // 스케줄을 3번 선택하거나 모험을 1번 다녀오면 하루가 끝나는 상태
        private enum State { one, two, three, finish }
        private State nowState;
        private string input;
        public SelectScheduleScene(GameData game, Player player) : base(game, player)
        {

        }
        public override void Enter()
        {

        }
        public override void Render()
        {
            switch (nowState)
            {
                case State.one:
                    Console.Clear();
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine(" 일정을 선택하세요");
                    Console.WriteLine(" 1. 학교");
                    Console.WriteLine(" 2. 무술 훈련");
                    Console.WriteLine(" 3. 예법 교실");
                    Console.WriteLine(" 4. 음악 교실");
                    Console.WriteLine(" 5. 모험");
                    Console.WriteLine(" ===================================== ");
                    Console.Write(" 선택 : ");
                    break;
                case State.two:
                case State.three: // 모험 선택지가 없어야 함
                    Console.Clear();
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine(" 일정을 선택하세요");
                    Console.WriteLine(" 1. 학교");
                    Console.WriteLine(" 2. 무술훈련");
                    Console.WriteLine(" 3. 서예 교실");
                    Console.WriteLine(" 4. 음악 교실");
                    Console.WriteLine(" ===================================== ");
                    Console.Write(" 선택 : ");
                    break;
                case State.finish:
                    Console.Clear();
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine(" 하루가 저물고 있습니다.");
                    Console.WriteLine(" ===================================== ");
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
            //각 스케쥴 별로 장면을 이동시켜서 스케쥴을 진행
            //모험을 제외하고 스케쥴에서 입력을 받지 않고 진행해야함
            switch (nowState)
            {
                case State.one:
                    switch (input)
                    {
                        case "1":
                            game.ChangeScene(SceneType.School);
                            nowState = State.two;
                            break;
                        case "2":
                            game.ChangeScene(SceneType.Training);
                            nowState = State.two;
                            break;
                        case "3":
                            game.ChangeScene(SceneType.Manner);
                            nowState = State.two;
                            break;
                        case "4":
                            game.ChangeScene(SceneType.Music);
                            nowState = State.two;
                            break;
                        case "5":
                            game.ChangeScene(SceneType.AdventureSelect);
                            nowState = State.finish;
                            break;
                        default:
                            Console.WriteLine(" 잘못입력하셨습니다.");
                            break;
                    }
                    break;
                    // 모험은 스케쥴 가장 처음만 선택 가능
                case State.two:
                    switch (input)
                    {
                        case "1":
                            game.ChangeScene(SceneType.School);
                            nowState = State.three;
                            break;
                        case "2":
                            game.ChangeScene(SceneType.Training);
                            nowState = State.three;
                            break;
                        case "3":
                            game.ChangeScene(SceneType.Manner);
                            nowState = State.three;
                            break;
                        case "4":
                            game.ChangeScene(SceneType.Music);
                            nowState = State.three;
                            break;
                        default:
                            Console.WriteLine(" 잘못입력하셨습니다.");
                            break;
                    }
                    break;
                case State.three:
                    switch (input)
                    {
                        case "1":
                            game.ChangeScene(SceneType.School);
                            nowState = State.finish;
                            break;
                        case "2":
                            game.ChangeScene(SceneType.Training);
                            nowState = State.finish;
                            break;
                        case "3":
                            game.ChangeScene(SceneType.Manner);
                            nowState = State.finish;
                            break;
                        case "4":
                            game.ChangeScene(SceneType.Music);
                            nowState = State.finish;
                            break;
                        default:
                            Console.WriteLine(" 잘못입력하셨습니다.");
                            break;
                    }
                    break;
                case State.finish:
                    game.nowDay++; // 하루가 끝나면 nowDay++
                    nowState = State.one;
                    if (game.nowDay == game.allDay) // 전체 일수와 같아지면
                    {
                        game.ChangeScene(SceneType.Ending); //엔딩씬으로 이동
                    }
                    else
                        game.ChangeScene(SceneType.Room); // 전체 일수와 다르면 스케쥴을 반복
                    break;
            }
        }
        public override void Exit()
        {

        }
    }
}
