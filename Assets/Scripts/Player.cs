using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private GameManager gameManager;

    [Header("HP")]
    private float Heal = 25;

    [Header("Transforms")]
    [SerializeField] private Transform spawnObject;
    [SerializeField] private Transform blockLoc;
    [SerializeField] private Transform healLoc;

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
        SpawnHealObject();
        GameManager.instance.PlayerHP +=  Heal;
        if (GameManager.instance.PlayerHP >= 100)
        {
            GameManager.instance.PlayerHP = 100;
        }
        GameManager.instance.UpdatePlayerHPBar();
        Debug.Log("heal bro");
        GameManager.instance.EndTurn();
    }

    private void SpawnHealObject()
    {
        Instantiate(GameManager.instance.HealObject, healLoc.transform.position, Quaternion.identity);
        GameObject spawnedObject = GameObject.FindGameObjectWithTag("Heal");
        Destroy(spawnedObject, 1f);
    }

    private void SpawnBlockobject()
    {
        Instantiate(GameManager.instance.BlockObject, blockLoc.transform.position, GameManager.instance.BlockObject.transform.rotation);
        GameObject spawnedObject = GameObject.FindGameObjectWithTag("Block");
        Destroy(spawnedObject, 3f);
    }
    public void BoomstamAttack()
    {
        if (!GameManager.instance.PlayersTurn) { return; }
        Instantiate(GameManager.instance.AttackObject[0], spawnObject.transform.position, GameManager.instance.AttackObject[0].transform.rotation);
        GameManager.instance.EndTurn();
    }

    public void PiramideAttack()
    {
        if (!GameManager.instance.PlayersTurn) { return; }
        Instantiate(GameManager.instance.AttackObject[1], spawnObject.transform.position, GameManager.instance.AttackObject[1].transform.rotation);
        GameManager.instance.EndTurn();
    }

    public void SteenAttack()
    {
        if (!GameManager.instance.PlayersTurn) { return; }
        Instantiate(GameManager.instance.AttackObject[2], spawnObject.transform.position, GameManager.instance.AttackObject[2].transform.rotation);
        GameManager.instance.EndTurn();
    }

}
