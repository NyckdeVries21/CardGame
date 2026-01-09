using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryCards : MonoBehaviour
{
    [SerializeField] private Transform cardLocation;
    [SerializeField] private List<GameObject> cards;
    public GameObject currentCard;

    private bool cardGivenThisTurn = false;

    void Update()
    {
        bool currentPlayersTurn = GameManager.instance.PlayersTurn;

        if (currentPlayersTurn && (currentCard == null || !cardGivenThisTurn))
        {
            AddItem();
            cardGivenThisTurn = true;
            Debug.Log("Kaart toegevoegd!");
        }

        if (!currentPlayersTurn && currentCard != null && cardGivenThisTurn)
        {
            RemoveItem();
            cardGivenThisTurn = false;
            Debug.Log("Kaart verwijderd!");
        }
    }

    void AddItem()
    {
        if (cards == null || cards.Count == 0)
        {
            Debug.LogError("Cards list is leeg");
            return;
        }

        GameObject cardPrefab = cards[Random.Range(0, cards.Count)];
        GameObject card = Instantiate(cardPrefab, cardLocation);
        currentCard = card;

        RectTransform rt = card.GetComponent<RectTransform>();
        rt.anchoredPosition = Vector2.zero;
        rt.localScale = Vector3.one;
    }

    void RemoveItem()
    {
        if (currentCard != null)
        {
            Debug.Log("Verwijder: " + currentCard.name + " Parent: " + currentCard.transform.parent.name);
            currentCard.transform.SetParent(null);
            Destroy(currentCard);
            currentCard = null;
        }
    }
}

