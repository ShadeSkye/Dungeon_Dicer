using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    private int maxHp = 15;
    private int baseATK = 10;
    public int damage;

    private void EnemyAttack()
    {
        int damageModifier = Random.Range(-3, 3);
        damage = baseATK + damageModifier;
    }

    private void EnemyTakeDamage()
    {

    }
}
