using UnityEngine;

public class Player : MonoBehaviour
{
    private GameManager gameManager;

    [Header("HP")]
    private float AttackDamage = 10;
    private float Heal = 10;
    public void Attack()
    {
        if ( !GameManager.instance.PlayersTurn) { return; }
        GameManager.instance.EnemyHP -= AttackDamage;
        GameManager.instance.UpdateEnemyHPBar();
        Debug.Log("hoppa op je hoofd");
    }

    public void Block()
    {
        if (!GameManager.instance.PlayersTurn) { return; }
        // destroy
        Debug.Log("block de attack");
    }

    public void HealYourself()
    {
        if (!GameManager.instance.PlayersTurn) { return; }
        if (GameManager.instance.PlayerHP > 100)
        {
            GameManager.instance.PlayerHP = 100;
        }
        GameManager.instance.PlayerHP +=  Heal;
        GameManager.instance.UpdatePlayerHPBar();
        Debug.Log("heal bro");
    }



}
