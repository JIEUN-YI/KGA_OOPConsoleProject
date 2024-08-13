using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Scenes
{
    public class TitleScene : Scene
    {

        public TitleScene(GameData game, Player player) : base(game, player)
        {

        }
        public override void Enter()
        {

        }
        public override void Render()
        {
            Console.Clear();
            Console.WriteLine(" =====================================");
            Console.WriteLine("∥                                     ∥");
            Console.WriteLine("∥                                     ∥");
            Console.WriteLine("∥       나만의!                       ∥");
            Console.WriteLine("∥                                     ∥");
            Console.WriteLine("∥          귀여운 용사 키우기         ∥");
            Console.WriteLine("∥                                     ∥");
            Console.WriteLine("∥                                     ∥");
            Console.WriteLine(" ===================================== ");
            Console.WriteLine();
            Console.WriteLine("     계속하려면 아무키나 누르세요      ");

        }
        public override void Input()
        {
            Console.ReadKey();
        }
        public override void Update()
        {
            game.ChangeScene(SceneType.Select);
        }
        public override void Exit()
        {

        }
    }
}
