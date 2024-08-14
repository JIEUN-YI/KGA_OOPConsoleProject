using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Scenes.Lesson
{
    public class MannerScene : Scene, LessonManager
    {
        public enum State { Start, Lesson } // 시작하는 상태, 수업 상태
        public State nowState;
        Random ran = new Random(); // 랜덤을 사용
        private int chance;

        public MannerScene(GameData game, Player player) : base(game, player)
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
                        Console.WriteLine($" {player.name} : 잘부탁드리겠습니다!");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                        break;
                    case 2:
                        Console.WriteLine(" ===================================== ");
                        Console.WriteLine($" {player.name} : 예절교실은 너무 조용해...");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                        break;
                    case 3:
                        Console.WriteLine(" ===================================== ");
                        Console.WriteLine($" {player.name} : 예절교실은 마음이 차분해지는 기분이야.");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                        break;
                    case 4:
                        Console.WriteLine(" ===================================== ");
                        Console.WriteLine($" {player.name} : 사범님은 엄격하셔.");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                        break;
                    case 5:
                        Console.WriteLine(" ===================================== ");
                        Console.WriteLine($" {player.name} : 으아, 지각할뻔했어!");
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
            player.manner += 5;
            player.INT += 3;
            player.sensi -= 3;
            player.manner = Math.Clamp(player.manner, 0, 100);
            player.INT = Math.Clamp(player.INT, 0, 100);
            player.sensi = Math.Clamp(player.sensi, 0, 100);
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
                    Console.WriteLine($" 오늘은 식사 예절을 배웠다.");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 2:
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine($" 오늘은 인사 예절을 배웠다.");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 3:
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine($" 오늘은 다과회 예절을 배웠다.");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 4:
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine($" 오늘은 올바르게 걷기를 배웠다.");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 5:
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine($" 오늘은 기품있게 말하기를 배웠다.");
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
                    Console.WriteLine($" {player.name} : 사범님께 지적만 들었어...");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 2:
                    Console.WriteLine($" {player.name} : 오늘은 꽤 잘한 것 같은데?");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 3:
                    Console.WriteLine($" {player.name} : 중간에 졸고 말았어...");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 4:
                    Console.WriteLine($" {player.name} : 친구와 장난을 치다가 혼났어...");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 5:
                    Console.WriteLine($" {player.name} : 사범님께 칭찬받았어!");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                default:
                    break;
            }
        }
    }
}
