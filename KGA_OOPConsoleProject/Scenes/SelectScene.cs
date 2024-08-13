using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KGA_OOPConsoleProject.Scenes
{
    public class SelectScene : Scene
    {
        public enum State { name, Confirm }
        private string input;
        private State nowState;

        public SelectScene(GameData game, Player player) : base(game, player)
        {

        }
        public override void Enter()
        {
            game.nowScene = this;
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

                Console.Clear();
                Console.WriteLine(" === 상태창 ========================== ");
                Console.WriteLine($" 이름 : {player.name,+2}");
                Console.WriteLine($" 체력   : {player.maxHp,+2}");
                Console.WriteLine($" 공격력 : {player.ATK,+2}");
                Console.WriteLine($" 방어력 : {player.DEF,+2}");
                Console.WriteLine($" 무술능력 : {player.str,+2}");
                Console.WriteLine($" 지력   : {player.INT,+2}");
                Console.WriteLine($" 예법   : {player.manner,+2}");
                Console.WriteLine($" 감수성 : {player.sensi,+2}");
                Console.WriteLine($" 사냥한 몬스터 수 : {player.mCount,+2}");
                Console.WriteLine($" 소지금 : {player.money,+2}G");
                Console.WriteLine(" ===================================== ");
                Console.WriteLine();
                Console.Write("이대로 플레이 하시겠습니까?(y/n)");
            }

        }
        public override void Input()
        {
            input = Console.ReadLine();
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
                    nowState = State.Confirm;

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
