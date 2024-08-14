using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Scenes.Lesson
{
    public class MusicScene : Scene, LessonManager
    {
        public enum State { Start, Lesson } // 시작하는 상태, 수업 상태
        public State nowState;
        Random ran = new Random(); // 랜덤을 사용
        private int chance;
        public MusicScene(GameData game, Player player) : base(game, player)
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
                        Console.WriteLine($" {player.name} : 정말 아름다운 음악소리야");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                        break;
                    case 2:
                        Console.WriteLine(" ===================================== ");
                        Console.WriteLine($" {player.name} : 나도 잘 할 수 있을까?");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                        break;
                    case 3:
                        Console.WriteLine(" ===================================== ");
                        Console.WriteLine($" {player.name} : 오늘은 너무 힘든데...");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                        break;
                    case 4:
                        Console.WriteLine(" ===================================== ");
                        Console.WriteLine($" {player.name} : 빨리 새로운 곡을 연주하고 싶어!");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                        break;
                    case 5:
                        Console.WriteLine(" ===================================== ");
                        Console.WriteLine($" {player.name} : 오늘도 화이팅!");
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
            player.sensi += 5;
            player.manner -= 3;
            player.sensi = Math.Clamp(player.sensi, 0, 100);
            player.manner = Math.Clamp(player.manner, 0, 100);
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
                    Console.WriteLine($" 오늘은 새로운 곡을 배웠다.");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 2:
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine($" 오늘은 음악의 이론을 배웠다.");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 3:
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine($" 오늘은 배운 곡을 연습했다.");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 4:
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine($" 오늘은 새로운 악기를 배웠다.");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 5:
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine($" 오늘은 합주를 연습했다.");
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
                    Console.WriteLine($" {player.name} : 형편없는 연주실력이야...");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 2:
                    Console.WriteLine($" {player.name} : 딴짓을 했어");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 3:
                    Console.WriteLine($" {player.name} : 끔찍한 불협화음이었어");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 4:
                    Console.WriteLine($" {player.name} : 완벽한 연주였어!");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                case 5:
                    Console.WriteLine($" {player.name} : 그럭저럭 들어줄만 했어");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(2000);
                    break;
                default:
                    break;
            }
        }
    }
}