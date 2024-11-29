using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public int maxHp;
    public int baseATK;
    public static int damage;

    private void EnemyAttack()
    {
        int damageModifier = Random.Range(-3, 3);
        damage = baseATK + damageModifier;
    }

    private void EnemyTakeDamage()
    {

    }
}
