using UnityEngine;

/// <summary>
/// MenuDataの管理を行うマネージャーコンポーネント
/// </summary>
[DefaultExecutionOrder(-99)]
public class MenuDataManager : ServiceBase
{
    /// <summary> MenuDataのインスタンス </summary>
    public readonly MenuData Data = new();

    protected override void CreateService()
    {
        ServiceLocater.AddService(this);
    }
}
