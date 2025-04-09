using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
// 플레이어의 정보를 저장하는 클래스
public class PlayerInfo : MonoBehaviour
{
    public string uniqueId; // 플레이어의 고유 ID
    public string playerName; // 플레이어의 이름
    public int playerLevel; // 플레이어의 레벨
    public int playerExp; // 플레이어의 경험치
    public int playerGold; // 플레이어의 골드
    public int playerGem; // 플레이어의 보석
    public int playerCharacterCount; // 보유 캐릭터 수
    public List<CharCurrentInfo> ownedCharacters;// 보유 캐릭터 목록

    public PlayerInfo(string id, string name, int level, int exp, int gold, int gem, int characterCount) {
        uniqueId = id;
        playerName = name;
        playerLevel = level;
        playerExp = exp;
        playerGold = gold;
        playerGem = gem;
        playerCharacterCount = characterCount;
    }
    public PlayerInfo() {
        uniqueId = "defaultId";
        playerName = "defaultName";
        playerLevel = 1;
        playerExp = 0;
        playerGold = 0;
        playerGem = 0;
        playerCharacterCount = 0;
    }
}
