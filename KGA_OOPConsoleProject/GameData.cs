﻿using System;

//게임 데이터 클래스
public class GameData
{
    // 게임데이터 클래스가 가지는 변수들
    /* 
     * 게임의 진행 여부 - bool 타입
     * 플레이어 - Player 타입
     * 각 장면들이 모두 들어있는 배열 - Scenes[] 타입
     * 현재의 장면 - Scene 타입
     */

    // 게임데이터 클래스가 가지는 함수들
    /*
     * 씬(장면) 변경 함수 : 변경할 씬을 받아서 이전의 장면을 종료하고 새로운 장면을 시작
     * Start() - 게임을 시작할 때 준비해야하는 내용이 담긴 함수
     * Gameover() - 게임을 완전히 종료하는 함수
     * 
     * 각각의 장면에 알맞은 함수를 출력하는
     * Exit()  / Render() / Input() / Update() 함수들
     * - Render() 장면을 그리고 Input() 장면에서 알맞은 행동을 입력받고
     * - Update() 새로운 행동을 시키고 Exit() 장면에서 빠져나옴
     */
}
