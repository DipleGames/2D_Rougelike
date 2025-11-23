using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CostView : MonoBehaviour
{
    [Header("웨폰상점 Cost 텍스트")]
    [SerializeField] private TextMeshProUGUI _weaponUpgradeCost_Text;
    public void OnUpdateWeaponCostText(int cost)
    {
        _weaponUpgradeCost_Text.text = $"{cost}";
    }

    [Header("스킬상점 Cost 텍스트")]
    [SerializeField] private TextMeshProUGUI _skillUpgradeCost_Text;
    public void OnUpdateSkillCostText(int cost)
    {
        _skillUpgradeCost_Text.text = $"{cost}";
    }

    [Header("AA상점 Cost 텍스트")]
    [SerializeField] private TextMeshProUGUI _rangeUpgradeCost_Text;
    [SerializeField] private TextMeshProUGUI _penetrationUpgradeCost_Text;
    public void OnUpdateRangeCostText(int cost)
    {
        _rangeUpgradeCost_Text.text = $"{cost}";
    }

    public void OnUpdatePenetrationCostText(int cost)
    {
        _penetrationUpgradeCost_Text.text = $"{cost}";
    }
}
