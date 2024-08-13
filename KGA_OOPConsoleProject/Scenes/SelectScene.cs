using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KGA_OOPConsoleProject.Scenes
{
    public class SelectScene : Scene
    {
        public enum State { name, Confirm }
        private string input;
        private State nowState;

        public SelectScene(GameData game) : base(game)
        {

        }
        public override void Enter()
        {
            nowState = State.name;
        }
        public override void Render()
        {
            Console.Clear();
            Console.WriteLine(" ===================================== ");
            if (nowState == State.name)
            {
                Console.Write(" 아이의 이름을 정해주세요 : ");
            }
            else if (nowState == State.Confirm)
            {
                player.ShowStatus();
                Console.WriteLine();
                Console.Write("이대로 플레이 하시겠습니까?(y/n)");
            }

        }
        public override void Input()
        {
            input = Console.ReadLine();
            /* 
             * 이름을 입력받아서 플레이어의 이름에 저장되어야 하는데
             * player.name = Console.ReadLine();
             * 으로 입력받는 경우
             * System.NullReferenceException: 'Object reference not set to an instance of an object.' 에러 발생
             */
        }
        public override void Update()
        {
            if (nowState == State.name)
            {
                if (input == string.Empty)
                {
                    return;
                }
                else
                {
                    player.name = input;
                    nowState = State.Confirm; // 왜...? System.NullReferenceException?? 왜???

                }
            }
            else if (nowState == State.Confirm)
            {
                switch (input)
                {
                    case "Y":
                    case "y":
                        game.ChangeScene(SceneType.Room);
                        break;
                    case "N":
                    case "n":
                        nowState = State.name;
                        break;
                    default:
                        break;
                }
            }
            /* 이름을 입력받아서 플레이어의 정보에 저장*/
        }
        public override void Exit()
        {

        }
    }
}
