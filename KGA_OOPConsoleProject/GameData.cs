﻿using KGA_OOPConsoleProject.Scenes;
namespace KGA_OOPConsoleProject
{
    //게임 데이터 클래스
    public class GameData
    {
        // 게임데이터 클래스가 가지는 변수들
        private bool isRunning;
        private Player player;
        private Scene[] scenes;
        public Scene nowScene;
        private int allDay;
        private int nowDay;
        private int sCount;
        /* 
         * 게임의 진행 여부 - bool 타입
         * 플레이어 - Player 타입
         * 각 장면들이 모두 들어있는 배열 - Scenes[] 타입
         * 현재의 장면 - Scene 타입
         * 전체 플레이 일수 - int 타입
         * 현재 플레이 일수 - int 타입
         * 스케쥴 카운팅 - int 타입 / 스케쥴 카운팅 3번 = 현재 플레이 일수++
         */
        // 게임데이터 클래스가 가지는 함수들
        private void Run()
        {
            Start();
            while (isRunning)
            {
                Render();
                Input();
                Update();
            }
            Gameover();

        }
        private void Start()
        {
            isRunning = true;
            //열거형 마지막 부분에 Size를 추가하여 열거형의 갯수만큼 배열 생성
            scenes = new Scene[(int)SceneType.Size];
            scenes[(int)SceneType.Title] = new Scene(this);
            scenes[(int)SceneType.Select] = new Scene();
            scenes[(int)SceneType.Room] = new Scene();
            scenes[(int)SceneType.Shop] = new Scene();
            scenes[(int)SceneType.School] = new Scene();
            scenes[(int)SceneType.Manner] = new Scene();
            scenes[(int)SceneType.Music] = new Scene();
            scenes[(int)SceneType.VillageMt] = new Scene();
            scenes[(int)SceneType.DeepRiver] = new Scene();
            scenes[(int)SceneType.DarkForest] = new Scene();

            nowScene = scenes[(int)SceneType.Title];
            nowScene.Enter();
        }
        public void ChangeScene(SceneType scenetype)
        {
            nowScene.Exit(); // 원래의 씬에서 빠져나오고
            nowScene=scenes[(int)scenetype]; // 새로운 씬을 저장
            nowScene.Enter(); // 새로운 씬에 입장
        }
        private void Gameover()
        {
            isRunning = false;
            nowScene.Exit();
        }
        /*
         * Start() - 게임을 시작할 때 준비해야하는 내용이 담긴 함수
         * 씬(장면) 변경 함수 : 변경할 씬을 받아서 이전의 장면을 종료하고 새로운 장면을 시작
         * Gameover() - 게임을 완전히 종료하는 함수
         */
        // 각각의 장면에 알맞은 함수를 출력하는
        private void Exit()
        {
            nowScene.Exit();
        }
        private void Render()
        {
            nowScene.Render();
        }
        private void Input()
        {
            nowScene.Input();
        }
        private void Update()
        {
            nowScene.Update();
        }
        /* Exit()  / Render() / Input() / Update() 함수들
         * - Render() 장면을 그리고 Input() 장면에서 알맞은 행동을 입력받고
         * - Update() 새로운 행동을 시키고 Exit() 장면에서 빠져나옴
         */
    }
}
