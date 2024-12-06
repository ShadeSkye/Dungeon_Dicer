using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance;
    public bool PlayersTurn = true;

    private void Awake()
    {
        Instance = this;
    }

    //function to calculate the player's attack damage
    public void PlayerAttack()
    {
        int damage;

        damage = PlayerController.Instance.baseATK + Random.Range(-3, 3);

        EnemyController.Instance.TakeDamage(damage);

        PlayersTurn = false;
    }

    //decreases the player's health
    public void PlayerTakeDamage(int value)
    {
        PlayerController.Instance.currentHP -= value;

        UIManager.Instance.UpdatePlayerHP($"{PlayerController.Instance.currentHP}/{PlayerController.Instance.maxHp}");

        if (PlayerController.Instance.currentHP <= 0)
        {
            PlayerController.Instance.currentHP = 0;

            UIManager.Instance.UpdatePlayerHP($"{PlayerController.Instance.currentHP}/{PlayerController.Instance.maxHp}");

            EndCombat();

            GameManager.Instance.GameOverState();
        }
    }

    //main combat loop
    public void StartCombat(GameObject enemy)
    {
        PlayersTurn = true;
        EnemyController.Instance.EnemyHP = EnemyController.Instance.enemy.maxHp;
        PlayerController.Instance.InCombat = true;
        UIManager.Instance.ToggleInventoryButton();
        EnemyController.Instance.SetEnemyValues(enemy);
        UIManager.Instance.UpdateEnemyHP($"{EnemyController.Instance.EnemyHP}/{EnemyController.Instance.EnemyMaxHP}");
    }

    public void EndCombat()
    {
        UIManager.Instance.HideCombatScreen();
        UIManager.Instance.ToggleInventoryButton();
        PlayerController.Instance.InCombat = false;
    }

    private void Update()
    {
        if (PlayerController.Instance.InCombat && !GameManager.GamePaused)
        {
            if (PlayersTurn)
            {
                UIManager.Instance.ShowCombatScreen();
            }
            else if(!PlayersTurn)
            {
                UIManager.Instance.HideCombatScreen();
                EnemyController.Instance.Attack();
            }
        }
    }
}
