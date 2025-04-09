using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCurrentStat : MonoBehaviour
{
    //캐릭터 현재 성장 상태 및 능력치를 담는 클래스
    // 캐릭터의 기본 능력치 및 성장 정보를 담는 CharDefaultInfo를 참조합니다.
    // CharDefaultInfo를 통해 각 캐릭터의 능력치를 정의합니다.
    public CharDefaultInfo info;
    public GameObject character;
    public int HP;
    public int MP;
    public int AD;
    public int AP;
    public int AR;
    public int MR;

    public int level;
    public int exp;
    public int maxExp;

    //최초 캐릭터 생성 시 기본 능력치 설정 함수
    void Init()
    {
        HP = info.HP;
        MP = info.MP;
        AD = info.AD;
        AP = info.AP;
        AR = info.AR;
        MR = info.MR;
        level = 1;
        exp = 0;
        maxExp = 100; // Initial maxExp for level 1
    }

    //레벨 업 시 능력치 증가 및 경험치 초기화 함수
    public void LevelUp()
    {
        level++;
        HP += info.HPPerLevel;
        MP += info.MPPerLevel;
        AD += info.ADPerLevel;
        AP += info.APPerLevel;
        AR += info.ARPerLevel;
        MR += info.MRPerLevel;
        exp -= maxExp;
        maxExp = Mathf.RoundToInt(maxExp * 1.5f); // Increase maxExp for next level
    }

    //경험치 획득 함수
    public void GainExp(int amount)
    {
        exp += amount;
        if (exp >= maxExp)
            LevelUp();
    } 

}
