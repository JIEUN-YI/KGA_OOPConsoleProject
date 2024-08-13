namespace KGA_OOPConsoleProject.Scenes.Lesson
{
    public class SchoolScene : Scene
    {
        public enum State { Start, Lesson } // 시작하는 상태. 수업 상태
        public State nowState;
        Random ran = new Random(); // 랜덤을 사용
        private int chance;

        // 입력은 따로 받지 않고 랜덤한 내용을 조합하여
        // 일정 확률로 다른 문구를 띄우고
        // 모두 끝나면 돌아가기
        public SchoolScene(GameData game, Player player) : base(game, player)
        {

        }
        public override void Enter()
        {
            nowState = State.Start;
            chance = ran.Next(1, 6);

        }
        public override void Render()
        {
            Console.Clear();
            if (nowState == State.Start) // 수업 시작 시
            {
                switch (chance)
                {
                    case 1:
                        Console.WriteLine(" ===================================== ");
                        Console.WriteLine($" {player.name} : 학교는 친구들을 만나서 즐거워");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                        break;
                    case 2:
                        Console.WriteLine(" ===================================== ");
                        Console.WriteLine($" {player.name} : 오늘은 어떤 걸 배우게 될까");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                        break;
                    case 3:
                        Console.WriteLine(" ===================================== ");
                        Console.WriteLine($" {player.name} : 아, 귀찮아~~");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                        break;
                    case 4:
                        Console.WriteLine(" ===================================== ");
                        Console.WriteLine($" {player.name} : 얘들아 안녕!!");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                        break;
                    case 5:
                        Console.WriteLine(" ===================================== ");
                        Console.WriteLine($" {player.name} : 숙제를 깜빡했어!");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                        break;
                    default:
                        break;
                }
            }
            else if (nowState == State.Lesson) // 수업 중
            {
                LessonConment();
                SelfConment();

            }
        }
        public override void Input()
        {

        }
        public override void Update()
        {
            if(nowState == State.Start)
            {
                nowState = State.Lesson;
            }
            else if(nowState == State.Lesson)
            {
                game.ChangeScene(SceneType.SelectSchedule);
            }


        }
        public override void Exit()
        {

        }

        private void LessonConment() // 수업 내용 문장
        {
            chance = ran.Next(1, 6);
            switch (chance)
            {
                case 1:
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine($" 오늘은 국어 수업이 있었다!");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 2:
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine($" 오늘은 수학 수업이 있었다!");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 3:
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine($" 오늘은 과학 수업이 있었다!");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 4:
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine($" 오늘은 역사 수업이 있었다!");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 5:
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine($" 오늘은 약초학 수업이 있었다!");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                default:
                    break;
            }
        }
        private void SelfConment() // 플레이어 평가
        {
            chance = ran.Next(1, 6);
            switch (chance)
            {
                case 1:
                    Console.WriteLine($" {player.name} : 딴짓을 해버렸어...");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 2:
                    Console.WriteLine($" {player.name} : 오늘은 그럭저럭 괜찮은 것 같아.");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 3:
                    Console.WriteLine($" {player.name} : 오늘은 공부가 잘 된 것 같아!");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 4:
                    Console.WriteLine($" {player.name} : 오늘은 완전 집중했어!!");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 5:
                    Console.WriteLine($" {player.name} : 친구들과 떠들어서 혼났어...");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                default:
                    break;
            }
        }
    }
}
