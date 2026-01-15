using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
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
    [SerializeField] private TextMeshProUGUI PlayerHPText;
    [SerializeField] private Image PlayerHPBar;
    public float EnemyHP = 100;
    [SerializeField] private TextMeshProUGUI EnemyHPText;
    [SerializeField] private Image EnemyHPBar;
    private float maxHealth = 100;
    public float AttackDamage;
    public float Heal = 10;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI whosTurn;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject ResultScreen;
    [SerializeField] private GameObject CardInv;

    [Header("Objects")]
    [SerializeField] public GameObject BlockObject;
    [SerializeField] public GameObject HealObject;
    [SerializeField] public List<GameObject> AttackObject;

    [Header("Stats")]
    private int EnemyKilled;
    private int CardsUsed;

    [SerializeField] private TextMeshProUGUI statsUI;


    void Start()
    {
        PlayersTurn = true;
        whosTurn.text = "Jouw beurt";

        if (instance == null)
        {
            instance = this;
        }

        //UI aan/uit zetten
        PauseMenu.SetActive(false);
        ResultScreen.SetActive(false);
        CardInv.SetActive(true);

    }

    void Update()
    {
        if (ActiveEnemy == null)
        {
            EnemyKilled++;
            SpawnEnemy();
            EnemyHP = maxHealth;
            UpdateEnemyHPBar();
        }

        if (Player == null)
        {
            ResultScreen.SetActive(true);
            LoadStats();
        }

        if(EnemyHP <=0)
        {
            Destroy(ActiveEnemy);
        }



        if (Keyboard.current.escapeKey.isPressed)
        {
            PauseGame();
            Time.timeScale = 0f;
        }
    }

    public void EndTurn()
    {
        if (PlayersTurn) 
        {
            PlayersTurn = false; // nu enemy's beurt
            CardInv.SetActive(false); 
            whosTurn.text = "Enemy z'n beurt";
        }
        else
        { 
            PlayersTurn = true; // nu speler aan de beurt
            CardInv.SetActive(true); 
            whosTurn.text = "Jouw beurt";
        }
    }
    public void UpdatePlayerHPBar()
    {
        PlayerHPBar.fillAmount = PlayerHP / maxHealth;
        PlayerHPText.text = "" + PlayerHP;
    }

    public void UpdateEnemyHPBar()
    {
        EnemyHPBar.fillAmount = EnemyHP / maxHealth;
        EnemyHPText.text = "" + EnemyHP;
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
        Instantiate(EnemyObject, EnemySpawnLoc.transform.position, EnemySpawnLoc.rotation);
        ActiveEnemy = GameObject.FindGameObjectWithTag("Enemy");
        Debug.Log("enemy spawned");
    }

    public void Continue()
    {
        ResultScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    private void LoadStats()
    {
        statsUI.text = "Vijanden verslagen: " + EnemyKilled + "\n" +
            "Kaarten gebruikt: " + CardsUsed;
    }
}
