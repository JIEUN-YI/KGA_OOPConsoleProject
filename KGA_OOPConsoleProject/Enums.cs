﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject
{
    // 게임에 필요한 열거형을 나타내는 곳
    // 장면 열거형
    public enum SceneType
    {
        Title, Select, Room, Shop, Inventory, 
        Training, School, Manner, Music, 
        VillageMt, DeepRiver, DarkForest, 
        SelectSchedule, AdventureSelect, 
        Battle, BossBattle, Ending, Size
    }
    /*
     * Title(게임시작 타이틀화면) , Select(게임정보 입력화면), 
     * Room(플레이어 기본 화면/방), Shop(상점),
     * School(학교), Training(무술수업), Manner(예법수업), Music(음악수업)
     * VillageMt(마을 뒷 산), DeepRiver(깊은 강가), DarkForest(어두운 숲)
     *    - 각 모험지는 Map 형식을 차용하여 미로찾기 형식으로 진행할 것
     *    - 미로찾기의 마지막 
     */

    // 아이템 종류 열거형
    public enum ItemsType
    {
        Weapon, Device, Supplies
    }
    /* weapon(무기), device(방어구), supplies(소모품) */


    // 타이틀 종류 열거형
    public enum TitleType
    {
        VillageMtConqueror, DeepRiverConqueror, DarkForestConqueror
    }
    /* VillageMtConqueror - 마을 뒷 산을 정복한 자 / 마을 뒷 산 보스 처치 후 획득 가능
     * DeepRiverConqueror - 깊은 강가를 정복한 자 / 깊은 강가 보스 처치 후 획득 가능
     * DarkForestConqueror - 어두운 숲을 정복한 자 / 어두운 숲 보스 처치 후 획득 가능
     */

    public enum StatusType
    {
        maxHp, ATK, DEF, STR, INT, manner, sensi
     // 체력, 공격력, 방어력, 무술능력, 지력, 예법, 감수성
    }

}
