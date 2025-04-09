using UnityEngine;

public class TestCharacter : BattleBehavior
{
    //사용 가능 캐릭터 정보
    //public hp, mp, ad, ap, ar, mr, maxHp, maxMp : 캐릭터의 기본 스탯
    //public skillCooldown, currentSkillCooldown : 스킬 쿨타임

    //데미지 타입
    //public enum DamageType { Physical, Magic, True };

    //사용 가능 전투 함수 목록
    //DealDamage(target, type, damage) : 데미지 주기
    //Heal(target, healAmount) : 체력 회복
    //HealMana(target, manaAmount) : 마나 회복
    //RegenerateHP(healAmount) : 본인 체력 재생
    //RegenerateMana(manaAmount) : 본인 마나 재생

    //사용 가능 타겟 선택 함수 목록
    //GetLowestHp(target) : 가장 체력이 낮은 캐릭터 선택
    //GetLowestMp(target) : 가장 마나가 낮은 캐릭터 선택
    //GetHighestHp(target) : 가장 체력이 높은 캐릭터 선택
    //GetHighestMp(target) : 가장 마나가 높은 캐릭터 선택
    //GetRandom(target) : 랜덤 캐릭터 선택


    protected override void UserDefinedAttack(GameObject[] allies, GameObject[] enemies)
    {
        //공격 시 행동을 정의해주세요
        Debug.Log("I am attacking!");
        //예시: 가장 체력이 낮은 적을 공격
        //GameObject target = GetLowestHp(enemies);
        //DealDamage(target, DamageType.Physical, ad); // 물리 공격
    }
    protected override void UserDefinedSkill(GameObject[] allies, GameObject[] enemies)
    {
        //스킬 사용 시 행동을 정의해주세요
        Debug.Log("I am using a skill!");
        //예시: 가장 체력이 낮은 아군을 힐
        //GameObject target = GetLowestHp(allies);
        // Heal(target, mp); // 스킬 사용 시 체력 회복
    }
}
