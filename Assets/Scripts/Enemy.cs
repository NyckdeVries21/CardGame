using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("HP")]
    private float Heal = 18;

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
        }
        else if (currentCard.name == "Bezorgbus")
        {
            BezorgbusAttack();
            Debug.Log("Enemy Bezorgbus");
        }
        else if (currentCard.name == "Appel" && GameManager.instance.EnemyHP <= 75)
        {
            AppelHealYourself();
            Debug.Log("Enemy Appel");
        }
        else if (currentCard.name == "Kast")
        {
            KastBlock();
            Debug.Log("Enemy Appel");
        }
        else if (currentCard.name == "AppelTaart" && GameManager.instance.EnemyHP <= 75)
        {
            AppelTaartHealYourself();
            Debug.Log("Enemy taartAppel");
        }
        else if (currentCard.name == "Winkelkar")
        {
            WinkelkarAttack();
            Debug.Log("Enemy winkelkar");
        }
        else { return; }

        currentCard = null;
        GameManager.instance.EndTurn();
    }

    private void Block()
    {
        if (GameManager.instance.PlayersTurn) { return; }
        // destroy
        Debug.Log("enemy blokt hen");
        SpawnBlockobject();
    }private void KastBlock()
    {
        if (GameManager.instance.PlayersTurn) { return; }
        // destroy
        Debug.Log("enemy blokt hen");
        KastBlockobject();
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

    private void AppelHealYourself()
    {
        if (GameManager.instance.PlayersTurn) return;

        if (GameManager.instance.EnemyHP >= 100)
        {
            GameManager.instance.EnemyHP = 100;
        }
        AppelHealObject();
        GameManager.instance.EnemyHP += Heal;
        Debug.Log("enemy healed oke");
        GameManager.instance.UpdateEnemyHPBar();

    }
    private void AppelTaartHealYourself()
    {
        if (GameManager.instance.PlayersTurn) return;

        if (GameManager.instance.EnemyHP >= 100)
        {
            GameManager.instance.EnemyHP = 100;
        }
        AppelTaartObject();
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
        Instantiate(GameManager.instance.HealObject[1], healLoc.position, healLoc.rotation);
        GameObject spawnedObject = GameObject.FindGameObjectWithTag("Heal");
        Destroy(spawnedObject, 1f);
    }

    private void AppelHealObject()
    {
        Instantiate(GameManager.instance.HealObject[1], healLoc.position, healLoc.rotation);
        GameObject spawnedObject = GameObject.FindGameObjectWithTag("Appel");
        Destroy(spawnedObject, 1f);
    }
    private void AppelTaartObject()
    {
        Instantiate(GameManager.instance.HealObject[2], healLoc.position, GameManager.instance.HealObject[2].transform.rotation);
        GameObject spawnedObject = GameObject.FindGameObjectWithTag("Appeltaart");
        Destroy(spawnedObject, 1f);
    }

    private void SpawnBlockobject()
    {
        Instantiate(GameManager.instance.BlockObject[0], blockLoc.position, blockLoc.rotation);
        GameObject spawnedObject = GameObject.FindGameObjectWithTag("Block");
        Destroy(spawnedObject, 3f);
    }
    private void KastBlockobject()
    {
        Instantiate(GameManager.instance.BlockObject[1], blockLoc.position, blockLoc.rotation);
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

    public void BezorgbusAttack()
    {
        Vector3 BusSpawn = new Vector3 ( spawnObject.position.x, 0, spawnObject.position .z );
        Instantiate(GameManager.instance.AttackObject[3], BusSpawn, spawnObject.rotation);
    }

    public void WinkelkarAttack()
    {
        if (!GameManager.instance.PlayersTurn) { return; }
        Instantiate(GameManager.instance.AttackObject[4], spawnObject.transform.position, spawnObject.rotation);
        GameManager.instance.EndTurn();
    }

}
