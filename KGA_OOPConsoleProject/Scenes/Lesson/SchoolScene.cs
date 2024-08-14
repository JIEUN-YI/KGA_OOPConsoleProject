/* 코멘트
 * Lesson 폴더 안의 클래스끼리 추상으로 묶고서 작업했어도 괜찮았을 것 같다.
 *  - 능력치 증감 함수 / 수업 내용 문장 함수 / 플레이어 평가 함수 까지 포함한 추상클래스
 * 그러면 Scene 부모클래스가 아니라 모험 장면 부모클래스 / Lesson장면 부모클래스로 나눠야 했을 것 같고
 * 이 경우에 장면의 대분류가 늘어난다면 좋을 것 같다
 * 예를 들어서 수업과 모험 외에도 아르바이트나 휴식 바캉스가 따로 있는 경우
 */
namespace KGA_OOPConsoleProject.Scenes.Lesson
{
    public class SchoolScene : Scene, LessonManager
    {
        public enum State { Start, Lesson } // 시작하는 상태, 수업 상태
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
                switch (chance) // 랜덤으로 인삿말 출력
                {
                    case 1:
                        Console.WriteLine(" ===================================== ");
                        Console.WriteLine($" {player.name} : 학교는 친구들을 만나서 즐거워");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                        break;
                    case 2:
                        Console.WriteLine(" ===================================== ");
                        Console.WriteLine($" {player.name} : 오늘은 어떤 걸 배우게 될까?");
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
                LessonComment();
                SelfComment();

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
                UpgradeStatus();
                game.ChangeScene(SceneType.SelectSchedule);
            }

        }
        public override void Exit()
        {

        }

        /// <summary>
        /// 수업 후 증감스텟
        /// </summary>
        public void UpgradeStatus()
        {
            player.INT += 5;
            player.maxHp += 2;
            player.INT = Math.Clamp(player.INT, 0, 100); // 범위를 벗어나는 경우 최대/최소값을 맞추기
            player.maxHp = Math.Clamp(player.maxHp, 0, 100);
        }
        /// <summary>
        /// 수업 중 코멘트
        /// </summary>
        public void LessonComment()
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
        /// <summary>
        /// 수업 후 코멘트
        /// </summary>
        public void SelfComment()
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
