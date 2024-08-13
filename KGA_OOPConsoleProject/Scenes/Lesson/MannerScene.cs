using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Scenes.Lesson
{
    public class MannerScene : Scene
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
                        Console.WriteLine($" {player.name} : ");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                        break;
                    case 2:
                        Console.WriteLine(" ===================================== ");
                        Console.WriteLine($" {player.name} : ");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                        break;
                    case 3:
                        Console.WriteLine(" ===================================== ");
                        Console.WriteLine($" {player.name} : ");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                        break;
                    case 4:
                        Console.WriteLine(" ===================================== ");
                        Console.WriteLine($" {player.name} : ");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                        break;
                    case 5:
                        Console.WriteLine(" ===================================== ");
                        Console.WriteLine($" {player.name} : ");
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
        private void UpgradeStatus()
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
        private void LessonConment()
        {
            chance = ran.Next(1, 6);
            switch (chance)
            {
                case 1:
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine($" 오늘은 ");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 2:
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine($" 오늘은 ");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 3:
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine($" 오늘은 ");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 4:
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine($" 오늘은 ");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 5:
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine($" 오늘은 ");
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
        private void SelfConment()
        {
            chance = ran.Next(1, 6);
            switch (chance)
            {
                case 1:
                    Console.WriteLine($" {player.name} : ");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 2:
                    Console.WriteLine($" {player.name} : ");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 3:
                    Console.WriteLine($" {player.name} : ");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 4:
                    Console.WriteLine($" {player.name} : ");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 5:
                    Console.WriteLine($" {player.name} : ");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                default:
                    break;
            }
        }
    }
}
