using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("HP")]
    private float AttackDamage = 10;
    private float Heal = 10;

    [Header("AI Setting")]
    private float EnemyTurnTimer = 3;
    private bool Usedcard = false;

    private void Update()
    {
        if(GameManager.instance.PlayersTurn == false)
        {
            Attack();
        }

        if( GameManager.instance.EnemyHP <= 0)
        {

            Destroy(gameObject);
        }
    }
    private void Attack()
    {

        GameManager.instance.PlayerHP -= AttackDamage;
        Debug.Log("enemy attack");
        GameManager.instance.UpdatePlayerHPBar();
        StartCoroutine(EnemyTimer(EnemyTurnTimer));
    }

    private void Block()
    {
        // destroy
        Debug.Log("enemy blokt hen");
        StartCoroutine(EnemyTimer(EnemyTurnTimer));
    }

    private void HealYourself()
    {
        if (GameManager.instance.EnemyHP >= 100)
        {
            GameManager.instance.EnemyHP = 100;
        }
        GameManager.instance.EnemyHP += Heal;
        Debug.Log("enemy healed oke");
        GameManager.instance.UpdateEnemyHPBar();

        StartCoroutine(EnemyTimer(EnemyTurnTimer));
    }

    IEnumerator EnemyTimer(float time)
    {
        yield return new WaitForSeconds(time);
        GameManager.instance.EndTurn();
    }
}
