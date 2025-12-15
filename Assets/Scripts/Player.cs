using UnityEngine;

public class Player : MonoBehaviour
{
    private GameManager gameManager;

    [Header("HP")]
    private int AttackDamage;
    private int Heal = 10;
    public void Attack()
    {
        
        GameManager.instance.EnemyHP -= AttackDamage;
        Debug.Log("hoppa op je hoofd");
    }

    public void Block()
    {
        // destroy
        Debug.Log("block de attack");
    }

    public void HealYourself()
    {
        if (GameManager.instance.PlayerHP >= 100)
        {
            GameManager.instance.PlayerHP = 100;
        }
        GameManager.instance.PlayerHP +=  Heal;
        Debug.Log("heal bro");
    }



}
