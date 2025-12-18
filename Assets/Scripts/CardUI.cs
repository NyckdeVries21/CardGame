using TMPro;
using UnityEditor.AssetImporters;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    [Header("S-Object")]
    [SerializeField] private ScriptableObject card;

    [Header("Card -> UI")]
    [SerializeField] private TextMeshProUGUI cardName;
    [SerializeField] private TextMeshProUGUI cardAmount;
    [SerializeField] private Image cardPicture;
    [SerializeField] private TextMeshProUGUI cardTarget;
    [SerializeField] private TextMeshProUGUI cardInfo;


}
