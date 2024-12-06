using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController Instance;

    public Enemy enemy;

    public int EnemyHP;
    public int EnemyMaxHP;
    private int Score;
    private int EnemyAtk;

    GameObject enemyTarget;

    private void Awake()
    {
        Instance = this;
    }

    public void SetEnemyValues(GameObject enemy)
    {
        enemyTarget = enemy;
        var enemyInstance = enemy.GetComponent<EnemyController>();
        EnemyHP = enemyInstance.enemy.maxHp;
        EnemyMaxHP = enemyInstance.enemy.maxHp;
        EnemyAtk = enemyInstance.enemy.baseATK;
        Score = enemyInstance.enemy.Score;
    }

    //function to calculate the enemy's attack damage
    public void Attack()
    {
        int damage;

        damage = EnemyAtk + Random.Range(-3, 3);

        CombatManager.Instance.PlayerTakeDamage(damage);

        CombatManager.Instance.PlayersTurn = true;
    }

    //enemy takes damage
    public void TakeDamage(int value)
    {
        EnemyHP -= value;

        UIManager.Instance.UpdateEnemyHP($"{EnemyHP}/{EnemyMaxHP}");

        if (EnemyHP <= 0)
        {
            EnemyHP = 0;
            UIManager.Instance.UpdateEnemyHP($"{EnemyHP}/{EnemyMaxHP}");
            CombatManager.Instance.EndCombat();
            PlayerController.Instance.Score += Score;
            Destroy(enemyTarget);
        }
    }
}
