using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _mainCoin_Text;

    public void OnUpdateCoinText(int coin)
    {
        _mainCoin_Text.text = $"Coin : {CoinManager.Instance.Coin}";
    }

}
