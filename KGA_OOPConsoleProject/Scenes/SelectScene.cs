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

        public SelectScene(GameData game) : base(game)
        {
            Player player = new Player();
        }
        public override void Enter()
        {

        }
        public override void Render()
        {
            Console.Clear();
            Console.WriteLine(" ===================================== ");
            Console.Write(" 아이의 이름을 정해주세요 : ");
        }
        public override void Input()
        {

        }
        public override void Update()
        {

        }
        public override void Exit()
        {

        }
    }
}
