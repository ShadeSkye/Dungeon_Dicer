using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private int maxHp = 10;
    private int baseATK = 7;
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
