using TMPro;
using UnityEditor.AssetImporters;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    [Header("BaseCard")]
    [SerializeField] private BaseCard card;

    [Header("Card -> UI")]
    [SerializeField] private TextMeshProUGUI cardNameUI;
    [SerializeField] private TextMeshProUGUI cardAmountUI;
    [SerializeField] private Image cardPictureUI;
    [SerializeField] private TextMeshProUGUI cardTargetUI;
    [SerializeField] private TextMeshProUGUI cardInfoUI;

    private void Start()
    {
        cardNameUI.text = card.CardName;
        cardAmountUI.text = card.CardAmount;
        cardPictureUI.sprite = card.CardPicture;
        cardTargetUI.text = card.CardTarget;
        cardInfoUI.text = card.CardInformation;
    }
}
