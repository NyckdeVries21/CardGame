using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.GPUSort;

public class CardShowcase : MonoBehaviour
{
    [SerializeField] private Transform cardLocation;
    [SerializeField] private GameObject card;

    private void Start()
    {
        ShowCard();
    }

    private void ShowCard()
    {
        GameObject showCard = Instantiate(card, cardLocation, false);

        RectTransform rt = showCard.GetComponent<RectTransform>();
        RectTransform parentRT = cardLocation.GetComponent<RectTransform>();

        rt.anchorMin = Vector2.zero;
        rt.anchorMax = Vector2.one;
        rt.offsetMin = Vector2.zero;
        rt.offsetMax = Vector2.zero;

        rt.pivot = parentRT.pivot;

        rt.anchoredPosition = Vector2.zero;
    }

}
