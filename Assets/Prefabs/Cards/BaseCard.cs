using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "BaseCard", menuName = "Scriptable Objects/BaseCard")]
public class BaseCard : ScriptableObject
{
    [Header("Data")]
    public string CardName;
    public string CardAmount;
    public Sprite CardPicture;
    public string CardTarget;
    public string CardInformation;
}
