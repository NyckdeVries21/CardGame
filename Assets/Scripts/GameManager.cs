using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Player Settings")]
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject ActiveEnemy;
    [SerializeField] private GameObject EnemyObject;
    public bool PlayersTurn = true;

    [SerializeField] private Transform EnemySpawnLoc;

    [Header("HP")]
    public float PlayerHP = 100;
    [SerializeField] private Image PlayerHPBar;
    public float EnemyHP = 100;
    [SerializeField] private Image EnemyHPBar;
    private float maxHealth = 100;
    public float AttackDamage;
    public float Heal = 10;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI whosTurn;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject ResultScreen;

    
 
    void Start()
    {
        PlayersTurn = true;
        whosTurn.text = "Your turn";

        if (instance == null)
        {
            instance = this;
        }

        //UI aan/uit zetten
        PauseMenu.SetActive(false);
        ResultScreen.SetActive(false);

    }

    void Update()
    {
        if (ActiveEnemy == null)
        {
            SpawnEnemy();
            EnemyHP = maxHealth;
        } 
    }

    public void EndTurn()
    {
        if (PlayersTurn == true)
        {
            whosTurn.text = "Enemy's turn";
            PlayersTurn = false;

        } else if (PlayersTurn == false)
        {
            whosTurn.text = "Your turn";
            PlayersTurn = true;
            
        }
    }
    public void UpdatePlayerHPBar()
    {
        PlayerHPBar.fillAmount = PlayerHP / maxHealth;
    }

    public void UpdateEnemyHPBar()
    {
        EnemyHPBar.fillAmount = EnemyHP / maxHealth;
    }

    private void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    private void RoundFinished()
    {
        if( Player == null)
        {
            ResultScreen.SetActive(true);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(EnemyObject, EnemySpawnLoc.transform.position, Quaternion.identity);
        ActiveEnemy = GameObject.FindGameObjectWithTag("Enemy");
        Debug.Log("enemy spawned");
    }
}
