using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Scenes.Lesson
{
    public class TrainingScene : Scene, LessonManager
    {
        public enum State { Start, Lesson } // 시작하는 상태, 수업 상태
        public State nowState;
        Random ran = new Random(); // 랜덤을 사용
        private int chance;

        // 입력은 따로 받지 않고 랜덤한 내용을 조합하여
        // 일정 확률로 다른 문구를 띄우고
        // 모두 끝나면 돌아가기
        public TrainingScene(GameData game, Player player) : base(game, player)
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
                        Console.WriteLine($" {player.name} : 잘부탁드립니다!");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                        break;
                    case 2:
                        Console.WriteLine(" ===================================== ");
                        Console.WriteLine($" {player.name} : 오늘은 몸 상태가 좋아");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                        break;
                    case 3:
                        Console.WriteLine(" ===================================== ");
                        Console.WriteLine($" {player.name} : 아~ 오늘은 좀 피곤해");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                        break;
                    case 4:
                        Console.WriteLine(" ===================================== ");
                        Console.WriteLine($" {player.name} : 오늘은 무엇을 배울까?");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                        break;
                    case 5:
                        Console.WriteLine(" ===================================== ");
                        Console.WriteLine($" {player.name} : 나도 강해질 수 있을까?");
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
            if (nowState == State.Start)
            {
                nowState = State.Lesson;
            }
            else if (nowState == State.Lesson)
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
            player.maxHp += 10;
            player.str += 10;
            player.ATK += 5;
            player.DEF += 5;
            player.maxHp = Math.Clamp(player.maxHp, 0, 100);
            player.str = Math.Clamp(player.str, 0, 100);
            player.ATK = Math.Clamp(player.ATK, 0, 100);
            player.DEF = Math.Clamp(player.DEF, 0, 100);
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
                    Console.WriteLine($" 오늘은 격투술을 배웠다.");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 2:
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine($" 오늘은 호신술을 배웠다.");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 3:
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine($" 오늘은 검술을 배웠다.");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 4:
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine($" 오늘은 방어술을 배웠다.");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 5:
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine($" 오늘은 궁술을 배웠다.");
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
                    Console.WriteLine($" {player.name} : 형편없는 실력이였어...");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 2:
                    Console.WriteLine($" {player.name} : 힘이 좀 더 강해진 것 같아!");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 3:
                    Console.WriteLine($" {player.name} : 친구와 딴짓을 했다.");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 4:
                    Console.WriteLine($" {player.name} : 모의 대련에서 승리했어!");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 5:
                    Console.WriteLine($" {player.name} : 모의 대련에서 져버렸어... ");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                default:
                    break;
            }
        }
    }
}
