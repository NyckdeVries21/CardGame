using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryCards : MonoBehaviour
{
    [SerializeField] private Transform cardLocation;
    [SerializeField] private List<GameObject> cards;
    public GameObject currentCard;

    public bool cardGivenThisTurn = false;

    void Update()
    {
        if (GameManager.instance.PlayersTurn && currentCard == null)
        {
            AddItem();
            Debug.Log("Kaart toegevoegd!");
        }
    }


    private void AddItem()
    {
        if (cards == null || cards.Count == 0)
        {
            Debug.LogError("Cards list is leeg");
            return;
        }

        GameObject cardPrefab = cards[Random.Range(0, cards.Count)];
        GameObject card = Instantiate(cardPrefab);
        card.transform.SetParent(cardLocation, false); 
        currentCard = card;

        RectTransform rt = card.GetComponent<RectTransform>();
        rt.anchoredPosition = Vector2.zero;
        rt.localScale = Vector3.one;
    }

    public void RemoveItem()
    {
        if (currentCard != null)
        {
            Debug.Log("Destroying card: " + currentCard.name);
            Destroy(currentCard);
            currentCard = null;
        }
        else
        {
            Debug.Log("No card to destroy!");
        }
    }
}

