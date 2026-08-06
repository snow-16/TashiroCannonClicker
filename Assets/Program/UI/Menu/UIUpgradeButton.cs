using UnityEngine;

/// <summary>
/// アップグレードを付与するボタンコンポーネント
/// </summary>
public class UIUpgradeButton : InteractableButtonUI
{
    /// <summary> アップグレード対象 </summary>
    [SerializeField]
    private UpgradableObject _target;
    /// <summary> 付与するアップグレード </summary>
    [SerializeField]
    private UpgradeData _upgrade;

    protected override void Start()
    {
        base.Start();
        
        InteractEvent[(int)Mathf.Log((int)UIIntercatType.Click, 2)].AddListener(GrantUpgrade);
    }

    /// <summary>
    /// アップグレードの付与
    /// </summary>
    public void GrantUpgrade()
    {
        _target.ApplyUpgrade(_upgrade.Upgrade);
    }
}
