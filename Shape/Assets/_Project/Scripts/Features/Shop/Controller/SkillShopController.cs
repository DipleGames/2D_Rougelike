using UnityEngine;

public class SkillShopController : Shop
{
    [Header("Model")]
    [SerializeField] private SkillShop _skillShop;

    [Header("View")]
    [SerializeField] private ShopView _shopView;

    [SerializeField] private Skill selectSkill;

    public override void Interact()
    {
        if(isInteract)
        {
            _shopView.SwitchShopUI(_shopView.skillShopUI, _shopView.skillShopUI.activeSelf);
        }
    }
    
    public void OnClickedQBtn() // 버튼을 누르는 인풋 -> 모델로 전달
    {
        selectSkill = _skillShop.skillUpgradeBtns[0].skill;
        _shopView.OnSelectSkill(selectSkill);
    }

    public void OnClickedWBtn() // 업그레이드 버튼을 누르는 인풋 -> 모델로 전달
    {
        selectSkill = _skillShop.skillUpgradeBtns[1].skill;
        _shopView.OnSelectSkill(selectSkill);
    }

    public void OnClickedEBtn() // 업그레이드 버튼을 누르는 인풋 -> 모델로 전달
    {
        selectSkill = _skillShop.skillUpgradeBtns[2].skill;
        _shopView.OnSelectSkill(selectSkill);
    }

    public void OnClickedRBtn() // 업그레이드 버튼을 누르는 인풋 -> 모델로 전달
    {
        selectSkill = _skillShop.skillUpgradeBtns[3].skill;
        _shopView.OnSelectSkill(selectSkill);
    }

    public void OnClickedDBtn() // 업그레이드 버튼을 누르는 인풋 -> 모델로 전달
    {
        selectSkill = _skillShop.skillUpgradeBtns[4].skill;
        _shopView.OnSelectSkill(selectSkill);
    }

    public void OnClickedUpgradeBtn()
    {
        if(selectSkill == _skillShop.skillUpgradeBtns[0].skill)
        {
            _skillShop.UpgradeQSkill();
        }
        else if(selectSkill == _skillShop.skillUpgradeBtns[1].skill)
        {
            _skillShop.UpgradeWSkill();
        }
        else if(selectSkill == _skillShop.skillUpgradeBtns[2].skill)
        {
            _skillShop.UpgradeESkill();
        }
        else if(selectSkill == _skillShop.skillUpgradeBtns[3].skill)
        {
            _skillShop.UpgradeRSkill();
        }
        else if(selectSkill == _skillShop.skillUpgradeBtns[4].skill)
        {
            
        }
    }
}
