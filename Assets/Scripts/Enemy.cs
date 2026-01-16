using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("HP")]
    private float Heal = 25;

    [Header("AI Setting")]
    private float EnemyTurnTimer = 2;
    private bool Usedcard = false;
    [SerializeField] private List<GameObject> Cards;
    public GameObject currentCard;

    [Header("Transforms")]
    [SerializeField] private Transform spawnObject;
    [SerializeField] private Transform blockLoc;
    [SerializeField] private Transform healLoc;

    private void Update()
    {
        if (!GameManager.instance.PlayersTurn && !Usedcard)
        {
            Usedcard = true;
            StartCoroutine(EnemyTimer(EnemyTurnTimer));
        }

        //if (GameManager.instance.EnemyHP < 0)
        //{
        //    Destroy(gameObject);
        //}
    }

    private void UseCard()
    {
        currentCard = Cards[Random.Range(0, Cards.Count)];
        if (currentCard.name == "Appelsap" && GameManager.instance.EnemyHP <= 75)
        {
            HealYourself();
            Debug.Log("Enemy Appelsap");
        }
        else if (currentCard.name == "Boomstam")
        {
            BoomstamAttack();
            Debug.Log("Enemy Boomstam");
        }
        else if (currentCard.name == "Piramide")
        {
            PiramideAttack();
            Debug.Log("Enemy Piramide");
        }
        else if (currentCard.name == "Snelwegbord")
        {
            Block();
            Debug.Log("Enemy Snelweg");
        }
        else if (currentCard.name == "Steen")
        {
            SteenAttack();
            Debug.Log("Enemy Steen");
        } else {return;}

        currentCard = null;
        GameManager.instance.EndTurn();
    }

    private void Block()
    {
        if (GameManager.instance.PlayersTurn) { return; }
        // destroy
        Debug.Log("enemy blokt hen");
        SpawnBlockobject();
    }

    private void HealYourself()
    {
        if (GameManager.instance.PlayersTurn) return; 

        if (GameManager.instance.EnemyHP >= 100)
        {
            GameManager.instance.EnemyHP = 100;
        }
        SpawnHealObject();
        GameManager.instance.EnemyHP += Heal;
        Debug.Log("enemy healed oke");
        GameManager.instance.UpdateEnemyHPBar();

    }

    IEnumerator EnemyTimer(float time)
    {
        yield return new WaitForSeconds(time);

        UseCard();
        Usedcard = false;
    }


    private void SpawnHealObject()
    {
        Instantiate(GameManager.instance.HealObject, healLoc.position, healLoc.rotation);
        GameObject spawnedObject = GameObject.FindGameObjectWithTag("Heal");
        Destroy(spawnedObject, 1f);
    }

    private void SpawnBlockobject()
    {
        Instantiate(GameManager.instance.BlockObject, blockLoc.position, blockLoc.rotation);
        GameObject spawnedObject = GameObject.FindGameObjectWithTag("Block");
        Destroy(spawnedObject, 3f);
    }
    public void BoomstamAttack()
    {
        Quaternion BoomstamRotatie = Quaternion.Euler(0f, -90f, 90f);
        Instantiate(GameManager.instance.AttackObject[0], spawnObject.position, BoomstamRotatie);
    }

    public void PiramideAttack()
    {
        Instantiate(GameManager.instance.AttackObject[1], spawnObject.position, spawnObject.rotation);
    }

    public void SteenAttack()
    {
        Instantiate(GameManager.instance.AttackObject[2], spawnObject.position, spawnObject.rotation);
    }

}
