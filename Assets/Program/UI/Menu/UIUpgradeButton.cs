using System.Collections.Generic;
using Unity.VisualScripting;
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
    /// <summary> アップグレード購入条件 </summary>
    [SerializeReference, SubclassSelector]
    private List<IUpgradeFilter> _filters;

    /// <summary> アップグレードが購入済みか </summary>
    private bool _isBought = false;

    protected override void Start()
    {
        base.Start();

        InteractEvent[(int)Mathf.Log((int)UIIntercatType.Click, 2)].AddListener(GrantUpgrade);
        InteractEvent[(int)Mathf.Log((int)UIIntercatType.Click, 2)].AddListener(() => IsLocked = _isBought = true);
        IsLocked = true;
    }

    void Update()
    {
        if(!_isBought && IsLocked)
        {
            IsLocked = false;
            foreach(var filter in _filters)
            {
                if(!filter.CanUpgrade())
                {
                    IsLocked = true;
                    break;
                }
            }
        }
    }

    /// <summary>
    /// アップグレードの付与
    /// </summary>
    public void GrantUpgrade()
    {
        _target.ApplyUpgrade(_upgrade.Upgrade);
        _filters.ForEach(filter => filter.AppliedUpgrade());
    }
}
