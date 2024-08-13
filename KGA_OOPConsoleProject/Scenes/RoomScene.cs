using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Scenes
{
    public class RoomScene : Scene
    {
        public RoomScene(GameData game, Player player) : base(game, player)
        {

        }
        public override void Enter()
        {
            Console.Clear();
            Console.WriteLine("방으로 이동합니다.");
        }
        public override void Render()
        {

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
