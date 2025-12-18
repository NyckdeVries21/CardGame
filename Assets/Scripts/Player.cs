using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private GameManager gameManager;

    [Header("HP")]
    private float AttackDamage = 10;
    private float Heal = 10;

    [Header("Transforms")]
    [SerializeField] private Transform spawnObject;
    [SerializeField] private Transform blockLoc;
    
    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && GameManager.instance.PlayersTurn== true)
        {
            Instantiate(GameManager.instance.BlockObject, blockLoc.transform.position, Quaternion.identity);
            GameObject spawnedObject = GameObject.FindGameObjectWithTag("Block");
            Destroy(spawnedObject, 0.5f);
        } else { return; }

    }
    public void Attack()
    {
        if ( !GameManager.instance.PlayersTurn) { return; }
        GameManager.instance.EnemyHP -= AttackDamage;
        GameManager.instance.UpdateEnemyHPBar();
        Debug.Log("hoppa op je hoofd");
        GameManager.instance.EndTurn();
    }

    public void Block()
    {
        if (!GameManager.instance.PlayersTurn) { return; }
        // destroy
        Debug.Log("block de attack");
        GameManager.instance.EndTurn();
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
        GameManager.instance.EndTurn();
    }



}
