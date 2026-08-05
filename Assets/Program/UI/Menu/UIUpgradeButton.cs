using UnityEngine;

/// <summary>
/// アップグレードを付与するボタンコンポーネント
/// </summary>
public class UIUpgradeButton : InteractableButtonUI
{
    [SerializeField]
    private UpgradableObject _target;
    [SerializeField]
    private UpgradeData _upgrade;

    void Start()
    {
        InteractEvent[(int)Mathf.Log((int)UIIntercatType.Click, 2)].AddListener(GrantUpgrade);
    }

    public void GrantUpgrade()
    {
        _target.ApplyUpgrade(_upgrade.Upgrade);
    }
}
