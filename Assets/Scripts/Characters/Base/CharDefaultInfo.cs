using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharDefaultInfo", menuName = "Scriptable Object/Character Default Info", order = 10)]
public class CharDefaultInfo : ScriptableObject
{
    // 캐릭터의 기본 능력치 및 성장 정보를 담는 클래스
    // ScriptableObject를 사용하여 각 캐릭터의 기본 능력치를 정의합니다.
    [Header("캐릭터명")]
    public string CharacterName;
    [Header("체력/마나")]
    public int HP;
    public int MP;
    [Header("공격력/주문력")]
    public int AD;
    public int AP;
    [Header("방어력/마법저항력")]
    public int AR;
    public int MR;

    [Header("레벨당 능력치")]
    public int HPPerLevel;
    public int MPPerLevel;
    public int ADPerLevel;
    public int APPerLevel;
    public int ARPerLevel;
    public int MRPerLevel;
    // need to determine proper level up stats ratio
}