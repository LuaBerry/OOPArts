using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BattleBehavior : MonoBehaviour
{
    //캐릭터 전투 행동을 정의하는 클래스.

    // 캐릭터 설계자가 디자인해야 하는 부분입니다.
    protected abstract void UserDefinedAttack(GameObject[] allies, GameObject[] enemies);
    protected abstract void UserDefinedSkill(GameObject[] allies, GameObject[] enemies);
    
    // 캐릭터 설계자를 위한 기본 코드입니다.

    //캐릭터 기본 정보
    public CharCurrentInfo info;

    public int hp { get; set; } // 현재 체력
    public int mp { get; set; } // 현재 마나
    public int ad { get; set; } // 공격력
    public int ap { get; set; } // 주문력
    public int ar { get; set; } // 방어력
    public int mr { get; set; } // 마법 저항력
    public int maxHp { get; set; } // 최대 체력
    public int maxMp { get; set; } // 최대 마나 == 스킬 사용 시 소모되는 마나


    public double skillCooldown { get; set; } // 스킬 쿨타임
    public double currentSkillCooldown { get; set; } // 현재 스킬 쿨타임

    public enum DamageType
    {
        Physical,
        Magic,
        True
    };

    //전투 시작 전 초기화 함수
    public void Init()
    {
        hp = info.characterInfo.HP;
        mp = info.characterInfo.MP;
        ad = info.characterInfo.AD;
        ap = info.characterInfo.AP;
        ar = info.characterInfo.AR;
        mr = info.characterInfo.MR;
        maxHp = info.characterInfo.HP;
        maxMp = info.characterInfo.MP;
    }
    
    //데미지 받을 때 받는 데미지 계산 및 적용 함수
    public void TakeDamage(DamageType type, int damage)
    {  
        double calcDamage = 0;

        switch (type)
        {
            case DamageType.Physical:
                calcDamage = damage * (1 - (ar / 100.0));
                break;
            case DamageType.Magic:
                calcDamage = damage * (1 - (mr / 100.0));
                break;
            case DamageType.True:
                calcDamage = damage;
                break;
        }
        hp -= (int)calcDamage;
        if (hp < 0)
        {
            hp = 0;
        }
    }

    //데미지 주는 함수
    public void DealDamage(GameObject target, DamageType type, int damage)
    {
        BattleBehavior targetBehavior = target.GetComponent<BattleBehavior>();
        if (targetBehavior != null)
        {
            targetBehavior.TakeDamage(type, damage);
        }
        else
        {
            Debug.LogError("Target does not have BattleBehavior component.");
        }
    }
    


    //일반 공격때 행할 행동. 공격, 힐, 기타 등등 가능.
    public void Attack(GameObject[] allies, GameObject[] enemies)
    {
        RegenerateMana(maxMp / 10); // 공격 시 마나 회복
        UserDefinedAttack(allies, enemies); // 유저 정의 공격 함수 호출

    }

    //스킬 공격때 행할 행동. 공격, 힐, 기타 등등 가능.
    public void UseSkill(GameObject[] allies, GameObject[] enemies)
    {
        mp = 0; // 스킬 사용 시 마나 소모
        currentSkillCooldown = skillCooldown; // 스킬 쿨타임 초기화
        UserDefinedSkill(allies, enemies); // 유저 정의 스킬 함수 호출
        //DealDamage(target, type, damage);
    }

    //체력 힐 함수
    public void Heal(GameObject target, int healAmount)
    {
        BattleBehavior targetBehavior = target.GetComponent<BattleBehavior>();
        if (targetBehavior != null)
        {
            targetBehavior.RegenerateHP(healAmount);
        }
        else
        {
            Debug.LogError("Target does not have BattleBehavior component.");
        }
    }

    //마나 힐 함수
    public void HealMana(GameObject target, int manaAmount)
    {
        BattleBehavior targetBehavior = target.GetComponent<BattleBehavior>();
        if (targetBehavior != null)
        {
            targetBehavior.RegenerateMana(manaAmount);
        }
        else
        {
            Debug.LogError("Target does not have BattleBehavior component.");
        }
    }

    //체력 재생 함수
    public void RegenerateHP(int healAmount)
    {
        hp += healAmount;
        if (hp > maxHp)
        {
            hp = maxHp;
        }
    }

    //마나 재생 함수
    public void RegenerateMana(int manaAmount)
    {
        mp += manaAmount;
        if (mp > maxMp)
        {
            mp = maxMp;
        }
    }

    //마나 소모 함수
    public void SpendMana(int manaCost)
    {
        mp -= manaCost;
        if (mp < 0)
        {
            mp = 0;
        }
    }

    //스킬 사용 가능 여부 체크 함수
    public bool isAbleToUseSkill()
    {
        //스킬 사용 가능 여부 체크
        if (mp >= maxMp && currentSkillCooldown <= 0)
        {
            return true;
        }
        return false;
    }

    //타겟 지정 함수들 5개 (가장 낮은 체력, 가장 낮은 마나, 가장 높은 체력, 가장 높은 마나, 랜덤)
    public GameObject GetLowestHp(GameObject[] target)
    {
        GameObject lowestHpTarget = target[0];
        for (int i = 1; i < target.Length; i++)
        {
            if (target[i].GetComponent<BattleBehavior>().hp < lowestHpTarget.GetComponent<BattleBehavior>().hp)
            {
                lowestHpTarget = target[i];
            }
        }
        return lowestHpTarget;
    }
    public GameObject GetLowestMp(GameObject[] target)
    {
        GameObject lowestMpTarget = target[0];
        for (int i = 1; i < target.Length; i++)
        {
            if (target[i].GetComponent<BattleBehavior>().mp < lowestMpTarget.GetComponent<BattleBehavior>().mp)
            {
                lowestMpTarget = target[i];
            }
        }
        return lowestMpTarget;
    }

    public GameObject GetHighestHp(GameObject[] target)
    {
        GameObject highestHpTarget = target[0];
        for (int i = 1; i < target.Length; i++)
        {
            if (target[i].GetComponent<BattleBehavior>().hp > highestHpTarget.GetComponent<BattleBehavior>().hp)
            {
                highestHpTarget = target[i];
            }
        }
        return highestHpTarget;
    }

    public GameObject GetHighestMp(GameObject[] target)
    {
        GameObject highestMpTarget = target[0];
        for (int i = 1; i < target.Length; i++)
        {
            if (target[i].GetComponent<BattleBehavior>().mp > highestMpTarget.GetComponent<BattleBehavior>().mp)
            {
                highestMpTarget = target[i];
            }
        }
        return highestMpTarget;
    }

    public GameObject GetRandom(GameObject[] target)
    {
        int randomIndex = Random.Range(0, target.Length);
        return target[randomIndex];
    }

    void update()
    {
        //스킬 쿨타임 감소
        if (currentSkillCooldown > 0)
        {
            currentSkillCooldown -= Time.deltaTime;
        }
    }
}