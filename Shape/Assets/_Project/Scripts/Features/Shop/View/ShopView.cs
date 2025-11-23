using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class ShopView : MonoBehaviour
{
    [Header("웨폰상점 UI")]
    public GameObject weaponShopUI;

    [Header("스킬상점 UI")]
    public GameObject skillShopUI;
    public Image selectSkill_Img;

    [Header("AA상점 UI")]
    public GameObject aaShopUI; 

    public void SwitchShopUI(GameObject shopUI, bool activeSelf)
    {
        shopUI.SetActive(!activeSelf);
        GameManager.Instance.SwitchGame();
        if(shopUI == skillShopUI) selectSkill_Img.GetComponent<Image>().enabled = false;
    }

    /// <summary>
    ///  스킬상점
    /// </summary>
    public void OnSelectSkill(Skill skill) // 스킬을 선택하면
    {
        selectSkill_Img.GetComponent<Image>().enabled = true;
        selectSkill_Img.sprite = skill.skillDefinition.skillIcon;
    }
}
