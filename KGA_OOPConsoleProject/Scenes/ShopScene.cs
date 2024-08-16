using KGA_OOPConsoleProject.Items;
using KGA_OOPConsoleProject.Manager;
/* 코멘트
 * 상점 기능 구현 중
 * - 분기는 제대로 진행되고 있으나
 * - 인벤토리 저장이 제대로 안되는 현상
 * - 일시적인 보유 골드의 감소 확인 / 영구적이지 않은 것 같아서 확인 필요
 * 버그를 잡을 시간적 여유 부족으로 버그 발생 중
 * - 구현되지 못한 기능은 의사코드의 형태로 일부 작성
 */
namespace KGA_OOPConsoleProject.Scenes
{
    public class ShopScene : Scene
    {
        ShoppingManager shopM = new();
        private enum State { Show, Buy, Sale, End }
        private State nowState;
        private Item[] productList;

        private string input;

        public ShopScene(GameData game, Player player) : base(game, player)
        {

        }
        public override void Enter()
        {
            productList = shopM.SetProduct();
        }
        public override void Render()
        {
            switch (nowState)
            {
                case State.Show:
                    Console.Clear();
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine(" 점원 : 상점에 오신 것을 환영합니다!   ");
                    Console.WriteLine("        어떻게 하시겠어요?");
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine(" 1. 구매하기");
                    Console.WriteLine(" 2. 판매하기");
                    Console.WriteLine(" 3. 돌아가기");
                    Console.WriteLine(" ===================================== ");
                    Console.Write(" 선택 : ");
                    break;
                case State.Buy:
                    Console.Clear();
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine(" 점원 : 원하는 상품을 선택해 주세요.   ");
                    shopM.ShowItems(); 
                    Console.WriteLine(" ===================================== ");
                    Console.Write(" 선택 : ");
                    break;
                case State.Sale:
                    /* 본인의 인벤토리를 출력해야함
                     * 본인의 인벤토리에서 판매하고자 하는 아이템의 번호를 입력받기*/
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
            if (nowState != State.End)
            {
                input = Console.ReadLine();
            }
        }
        public override void Update()
        {
            switch (nowState)
            {
                case State.Show:
                    /* input에 따라 스위치문으로 상태변화를 입력
                     * 구매하기 => NowState = State.Buy
                     * 판매하기 => NowState = State.Sale
                     * 돌아가기 => NowState = State.End
                     */
                    break;
                case State.Buy:
                   /* 구매를 원하는 상품번호 입력에 맞춰서
                    * 플레이어 인벤토리에 저장하고 아이템 가격만큼 플레이어의 골드 차감
                    * NowState = State.Show 로 전환
                    */
                case State.Sale:
                    /* 판매를 원하는 상품 입력에 맞춰서
                     * 플레이어 인벤토리에서 삭제하고 아이템 가격만큼 골드 가산
                     * NowState = State.Show 로 전환
                     */
                    break;
                case State.End:
                    game.ChangeScene(SceneType.Room); // 방으로 돌아가기
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
