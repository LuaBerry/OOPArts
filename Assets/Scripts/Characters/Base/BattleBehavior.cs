using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BattleBehavior : MonoBehaviour
{
    public CharCurrentStat stat;
    public GameObject character;

    public int hp { get; set; } // 현재 체력
    public int mp { get; set; } // 현재 마나
    public int ad { get; set; } // 공격력
    public int ap { get; set; } // 주문력
    public int ar { get; set; } // 방어력
    public int mr { get; set; } // 마법 저항력
    public int maxHp { get; set; } // 최대 체력
    public int maxMp { get; set; } // 최대 마나

    public enum DamageType
    {
        Physical,
        Magic,
        True
    };

    void Start()
    {
        Init();
        character = gameObject;
    }

    //전투 시작 전 초기화 함수
    void Init()
    {
        hp = stat.HP;
        mp = stat.MP;
        ad = stat.AD;
        ap = stat.AP;
        ar = stat.AR;
        mr = stat.MR;
        maxHp = stat.HP;
        maxMp = stat.MP;
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
    public void DealDamage(GameObject[] target, DamageType type, int damage)
    {
        for (int i = 0; i < target.Length; i++)
        {
            BattleBehavior targetBehavior = target[i].GetComponent<BattleBehavior>();
            if (targetBehavior != null)
            {
                targetBehavior.TakeDamage(type, damage);
            }
            else
            {
                Debug.LogError("Target does not have BattleBehavior component.");
            }
        }
    }
    
    //일반 공격때 행할 행동. 공격, 힐, 기타 등등 가능.
    public void Attack(GameObject[] target, DamageType type)
    {
        //target은 1명 또는 전체일 수 있음.
        //공격을 한다면
        //DealDamage(target, type, ad);
        //힐을 한다면
        //Heal(character, ad);
        //기타 등등은 각자 구현.
    }

    //스킬 공격때 행할 행동. 공격, 힐, 기타 등등 가능.
    public void UseSkill(GameObject target, DamageType type, int damage)
    {
        
        //DealDamage(target, type, damage);
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

    //체력 힐 함수
    public void Heal(GameObject[] target, int healAmount)
    {
        for (int i = 0; i < target.Length; i++)
        {
            BattleBehavior targetBehavior = target[i].GetComponent<BattleBehavior>();
            if (targetBehavior != null)
            {
                targetBehavior.RegenerateHP(healAmount);
            }
            else
            {
                Debug.LogError("Target does not have BattleBehavior component.");
            }
        }
    }

    //마나 힐 함수
    public void HealMana(GameObject[] target, int manaAmount)
    {
        for (int i = 0; i < target.Length; i++)
        {
            BattleBehavior targetBehavior = target[i].GetComponent<BattleBehavior>();
            if (targetBehavior != null)
            {
                targetBehavior.RegenerateMana(manaAmount);
            }
            else
            {
                Debug.LogError("Target does not have BattleBehavior component.");
            }
        }
    }

    //체력 재생 함수
    public void RegenerateHP(int healAmount)
    {
        hp += healAmount;
        if (hp > stat.HP)
        {
            hp = stat.HP;
        }
    }
    //마나 재생 함수
    public void RegenerateMana(int manaAmount)
    {
        mp += manaAmount;
        if (mp > stat.MP)
        {
            mp = stat.MP;
        }
    }
}