using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharCurrentInfo : MonoBehaviour
{
    public string uniqueId; // 보유 캐릭터의 고유 ID
    public string characterId; // 캐릭터 정보의 고유 ID
    public CharDefaultInfo characterInfo; // 캐릭터의 기본 정보 (ScriptableObject)
    public string characterName; // 캐릭터의 이름
    public int characterLevel; // 캐릭터의 레벨
    public int characterExp; // 캐릭터의 경험치
    public int characterStar; // 캐릭터의 별 등급 (1~4성)

    public int HP {get { return characterInfo.HP + characterInfo.HPPerLevel * characterLevel;}} // 기본 최대 체력
    public int MP {get { return characterInfo.MP + characterInfo.MPPerLevel * characterLevel;}} // 기본 최대 마나
    public int AD {get { return characterInfo.AD + characterInfo.ADPerLevel * characterLevel;}} // 기본 공격력
    public int AP {get { return characterInfo.AP + characterInfo.APPerLevel * characterLevel;}} // 기본 주문력
    public int AR {get { return characterInfo.AR + characterInfo.ARPerLevel * characterLevel;}} // 기본 방어력
    public int MR {get { return characterInfo.MR + characterInfo.MRPerLevel * characterLevel;}} // 기본 마법 저항력

    
}
