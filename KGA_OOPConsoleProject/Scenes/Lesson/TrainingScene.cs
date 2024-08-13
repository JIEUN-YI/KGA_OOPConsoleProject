using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Scenes.Lesson
{
    public class TrainingScene : Scene
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
        private void UpgradeStatus()
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
        private void LessonConment() // 수업 내용 문장
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
        private void SelfConment() // 플레이어 평가
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
