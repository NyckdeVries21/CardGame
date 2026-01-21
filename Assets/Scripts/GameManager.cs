using System.Collections;
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
    [SerializeField] private GameObject ActivePlayer;
    [SerializeField] private GameObject ActiveEnemy;
    [SerializeField] private GameObject EnemyObject;
    public bool PlayersTurn = true;

    [SerializeField] private Transform PlayerLoc;
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
    [SerializeField] private GameObject InGameUI;

    [Header("Objects")]
    [SerializeField] public List<GameObject> BlockObject;
    [SerializeField] public List<GameObject> HealObject;
    [SerializeField] public List<GameObject> AttackObject;

    [Header("Stats")]
    public int EnemyKilled;
    public int CardsUsed;

    [SerializeField] private TextMeshProUGUI statsUI;

    [Header("Scripts")]
    [SerializeField] private List<InventoryCards> InventoryCards;

    [Header("Data")]
    private float WaitTimer = 3;
    private bool enemyIsSpawning = false;


    void Start()
    {
        ActivePlayer = GameObject.FindGameObjectWithTag("Player");

        if (instance == null)
        {
            instance = this;
        }

        //UI aan/uit zetten
        PauseMenu.SetActive(false);
        ResultScreen.SetActive(false);

        EnemyKilled = -1;
    }

    void Update()
    {
        if (ActiveEnemy == null && ActivePlayer != null && !enemyIsSpawning)
        {
            enemyIsSpawning = true;
            EnemyKilled++;
            whosTurn.text = "Nieuwe enemy";
            CardInv.SetActive(false);
            StartCoroutine(EnemySpawns(WaitTimer));
        }

        if (ActivePlayer == null)
        {
            InGameUI.SetActive(false);
            CardInv.SetActive(false);
            ResultScreen.SetActive(true);
            LoadStats();
        }

        if (EnemyHP <= 0 && ActiveEnemy != null)
        {
            EnemyHP = 0;
            Destroy(ActiveEnemy);
            ActiveEnemy = null;
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
            CardsUsed++;
            PlayersTurn = false; // nu enemy's beurt
            for(int i = 0; i < InventoryCards.Count; i++)
            {
                InventoryCards[i].RemoveItem();
            }
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
        CardInv.SetActive(false);
        Time.timeScale = 0f;
    }

    private void SpawnEnemy()
    {
        ActiveEnemy = Instantiate(EnemyObject, EnemySpawnLoc.transform.position, EnemySpawnLoc.rotation);
        EnemyHP = 100;
        Debug.Log("enemy spawned");
    }

    private void PlayerSpawn()
    {
        Instantiate(Player, PlayerLoc.transform.position, PlayerLoc.rotation);
        ActivePlayer = GameObject.FindGameObjectWithTag("Player");
        PlayerHP = 100;
        Debug.Log("enemy spawned");
    }

    public void Continue()
    {
        PauseMenu.SetActive(false);
        CardInv.SetActive(true);
        Time.timeScale = 1f;
    }

    private void LoadStats()
    {
        statsUI.text = "Vijanden verslagen: " + EnemyKilled + "\n" +
            "Kaarten gebruikt: " + CardsUsed;
    }

    public void StartRound()
    {
        if (ActiveEnemy != null)
        {
            Destroy(ActiveEnemy);
            ActiveEnemy = null;
        }

        ResultScreen.SetActive(false);
        InGameUI.SetActive(true);

        whosTurn.text = "Nieuwe game wordt opgestart";
        whosTurn.fontSize = 20;

        StartCoroutine(SetNewRound(WaitTimer));

        SpawnEnemy();
        PlayerSpawn();

        UpdateEnemyHPBar();
        UpdatePlayerHPBar();

        CardsUsed = 0;
        EnemyKilled = 0;
        PlayersTurn = true;

        whosTurn.text = "Jouw beurt";
        whosTurn.fontSize = 30;
        CardInv.SetActive(true);
    }

    IEnumerator SetNewRound(float time)
    {
        yield return new WaitForSeconds(time);
    }

    IEnumerator EnemySpawns(float time)
    {
        yield return new WaitForSeconds(time);

        SpawnEnemy();
        UpdateEnemyHPBar();

        whosTurn.text = "Jouw beurt";
        CardInv.SetActive(true);
        PlayersTurn = true;

        enemyIsSpawning = false;
    }
}
