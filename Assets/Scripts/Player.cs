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
    [SerializeField] private Transform healLoc;
    
    private void Update()
    {

    }
    //public void Attack()
    //{
    //    if ( !GameManager.instance.PlayersTurn) { return; }
        
    //    GameManager.instance.EndTurn();
    //}

    public void Block()
    {
        if (!GameManager.instance.PlayersTurn) { return; }
        // destroy
        Debug.Log("block de attack");
        SpawnBlockobject();
        GameManager.instance.EndTurn();
    }

    public void HealYourself()
    {
        if (!GameManager.instance.PlayersTurn) { return; }
        if (GameManager.instance.PlayerHP > 100)
        {
            GameManager.instance.PlayerHP = 100;
        }
        SpawnHealObject();
        GameManager.instance.PlayerHP +=  Heal;
        GameManager.instance.UpdatePlayerHPBar();
        Debug.Log("heal bro");
        GameManager.instance.EndTurn();
    }

    private void SpawnHealObject()
    {
        Instantiate(GameManager.instance.HealObject, healLoc.position, Quaternion.identity);
        GameObject spawnedObject = GameObject.FindGameObjectWithTag("Heal");
        Destroy(spawnedObject, 1f);
    }

    private void SpawnBlockobject()
    {
        Instantiate(GameManager.instance.BlockObject, blockLoc.position, GameManager.instance.BlockObject.transform.rotation);
        GameObject spawnedObject = GameObject.FindGameObjectWithTag("Block");
        Destroy(spawnedObject, 0.5f);
    }
    public void BoomstamAttack()
    {
        if (!GameManager.instance.PlayersTurn) { return; }
        Instantiate(GameManager.instance.AttackObject[0], spawnObject.position, GameManager.instance.AttackObject[0].transform.rotation);
        GameManager.instance.EndTurn();
    }

    public void PiramideAttack()
    {
        if (!GameManager.instance.PlayersTurn) { return; }
        Instantiate(GameManager.instance.AttackObject[1], spawnObject.position, GameManager.instance.AttackObject[1].transform.rotation);
        GameManager.instance.EndTurn();
    }

    public void SteenAttack()
    {
        if (!GameManager.instance.PlayersTurn) { return; }
        Instantiate(GameManager.instance.AttackObject[2], spawnObject.position, GameManager.instance.AttackObject[2].transform.rotation);
        GameManager.instance.EndTurn();
    }

}
