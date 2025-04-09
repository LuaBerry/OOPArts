using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    //한 필드에서 턴제 전투를 진행하는 스크립트
    public GameObject[] playerCharacter; // 플레이어 캐릭터
    public GameObject[] enemyCharacter; // 적 캐릭터

    Queue<GameObject> turnQueue = new Queue<GameObject>(); // 행동할 캐릭터 큐
    
    //캐릭터 속도에 따라 턴 
    void Start() {
        // 플레이어와 적 캐릭터를 큐에 추가
        foreach (GameObject character in playerCharacter) {
            turnQueue.Enqueue(character);
        }
        foreach (GameObject character in enemyCharacter) {
            turnQueue.Enqueue(character);
        }

        // 턴 시작
        StartCoroutine(TurnStart());
    }
    IEnumerator TurnStart() {
        while (turnQueue.Count > 0) {
            GameObject currentCharacter = turnQueue.Dequeue(); // 현재 턴의 캐릭터
            // 행동 수행 (예: 공격, 스킬 사용 등)
            yield return StartCoroutine(PerformAction(currentCharacter)); // 행동이 끝날 때까지 대기
            // 행동 후 다시 큐에 추가 (턴 종료 후 다음 캐릭터로 넘어감)
            turnQueue.Enqueue(currentCharacter);
        }
    }
    IEnumerator PerformAction(GameObject character) {
        BattleBehavior battlebehavior = character.GetComponent<BattleBehavior>();
        if (battlebehavior.isAbleToUseSkill()) {
            // 스킬 사용
            battlebehavior.UseSkill(playerCharacter, enemyCharacter);
        } else {
            // 기본 공격
            battlebehavior.Attack(playerCharacter, enemyCharacter); // 첫 번째 적을 공격 (예시)
        }
        // 행동이 끝날 때까지 대기 (예: 애니메이션 재생 등)
        yield return new WaitForSeconds(1f); // 1초 대기 (예시)
        // 행동 후 쿨타임 적용
    }
}
