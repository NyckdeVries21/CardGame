using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("HP")]
    private int AttackDamage = 9;
    private int Heal = 10;

    private void Update()
    {
        if(GameManager.instance.PlayersTurn == false)
        {

        }

        if( GameManager.instance.EnemyHP <= 0)
        {

            Destroy(gameObject);
        }
    }
    private void Attack()
    {

        GameManager.instance.PlayerHP -= AttackDamage;
        Debug.Log("hoppa op je hoofd");
    }

    private void Block()
    {
        // destroy
        Debug.Log("block de attack");
    }

    private void HealYourself()
    {
        if (GameManager.instance.EnemyHP >= 100)
        {
            GameManager.instance.EnemyHP = 100;
        }
        GameManager.instance.EnemyHP += Heal;
        Debug.Log("heal bro");
    }
}
