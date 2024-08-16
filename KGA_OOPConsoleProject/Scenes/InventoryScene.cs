/* 코멘트
 * 제작 시간 부족으로 일부 의사코드 형태로 작성
 */
namespace KGA_OOPConsoleProject.Scenes
{
    public class InventoryScene : Scene
    {
        private enum State { Show, Use, End }
        private State nowState;

        private string input;

        public InventoryScene(GameData game, Player player) : base(game, player)
        {
            this.game = game;
            this.player = player;
        }

        // 각 장면에서 사용하는 함수
        public override void Enter()
        {
            nowState = State.Show;
        }
        public override void Render()
        {
            switch (nowState)
            {
                case State.Show:
                    /* 인벤토리를 보여주는 함수 출력 
                     * Player 클래스의 inventory 리스트를 차례대로 출력 - for문이용해서 출력 가능
                     * 방으로 돌아갈지
                     * 아이템을 사용할지 선택 => input
                     */

                    break;
                case State.Use:
                    /* Console.Clear();
                     * 인벤토리를 보여주는 함수 출력
                     * 사용을 원하는 인벤토리의 번호를 입력받기
                     */
                    break;
                case State.End:
                    Console.Clear();
                    break;
                default:

                    break;
            }
        }
        public override void Input()
        {
            /* nowState == State.Show || nowState == State.Use 인 경우 input을 받기 */
        }
        public override void Update()
        {
            switch (nowState)
            {
                case State.Show:
                    /* 스위치 문으로 input에 따라서 분기
                     * 방으로 돌아가기 => nowState = State.End;
                     * 아이템 사용하기 => nowState = State.Use;
                     */
                    break;
                case State.Use:
                    /* inventoryManager의 OutputInven() 함수를 완성하여 사용
                     *  - input한 번호에 맞춰서 리스트에 있는 아이템을 인벤토리에서 삭제
                     * 아이템 종류에 따라서 스위치 문으로 분기? -> 이중스위치문 말고 다른 방식을 생각할 필요가 있음...
                     * 장비
                     *  - 장비의 경우 DeviceManager 또는 WeaponManager의 UseItem함수를 완성하여 Player의 equip 리스트에
                     *    장비를 장비해야함
                     *    => Device나 Weapon은 하나씩만 장비되어야하므로 주의
                     * 소모품
                     *  - SuppliesManager의 UseItem함수를 완성하여
                     *    능력치의 증가를 출력하고 플레이어의 능력치 변화
                     * nowState = State.Show;
                     */
                    break;
                case State.End:
                    game.ChangeScene(SceneType.Room);
                    break;
                default:

                    break;
            }
        }
        public override void Exit()
        {

        }
    }
}
