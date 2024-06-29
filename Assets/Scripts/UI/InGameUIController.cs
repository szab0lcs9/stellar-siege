using TMPro;
using UnityEngine;

public class InGameUIController : MonoBehaviour
{
    TextMeshProUGUI collectedGoldText;

    void Start()
    {
        collectedGoldText = GameObject.Find("GoldNumber").GetComponent<TextMeshProUGUI>();
    }

    public void UpdateCollectedGoldText(PlayerInventory playerInventory) => collectedGoldText.text = playerInventory.NumberOfGold.ToString();

    public void PlaySFXSound(string name) => AudioManager.Instance.PlaySFX(name);
}
