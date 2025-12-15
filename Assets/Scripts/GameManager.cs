using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Player Settings")]
    [SerializeField] private List<GameObject> Players;
    public bool PlayersTurn = true;

    [Header("HP")]
    public int PlayerHP = 100;
    [SerializeField] private GameObject PlayerHPBar;
    public int EnemyHP = 100;
    [SerializeField] private GameObject EnemyHPBar;
    public int AttackDamage;
    public int Heal = 100;

    void Start()
    {

        if (instance == null)
        {
            instance = this;
        }
    }
    
    private void EnemyTurn()
    {
        PlayersTurn = false;

    }

    private void PlayerTurn()
    {
        PlayersTurn = true;
    }
}
