using TMPro;
using UnityEngine;

public class DiceUI : MonoBehaviour
{
    [SerializeField] private TMP_Text numberText;

    public void SetNumber(int number)
    {
        numberText.text = number.ToString();
    }
}