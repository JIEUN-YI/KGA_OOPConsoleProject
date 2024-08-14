using KGA_OOPConsoleProject.Monsters;
using KGA_OOPConsoleProject.Scenes;
using System.Threading.Tasks;
/* 코멘트
 * 모든 맵에 하나씩 생성하는 MonsterBattle Scene에 대해 공통으로 처리하는 인터페이스 생성
 */
namespace KGA_OOPConsoleProject.Scenes.Adventure
{
    public class MonsterBattleScene : Scene
    {
        public MonsterBattleScene(GameData game, Player player) : base(game, player)
        {
            this.game = game;
            this.player = player;
        }
        public override void Enter()
        {

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

