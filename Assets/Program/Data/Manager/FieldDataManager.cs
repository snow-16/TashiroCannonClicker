/// <summary>
/// FieldDataの管理を行うマネージャーコンポーネント
/// </summary>
public class FieldDataManager : ServiceBase
{
    /// <summary> FieldDataのインスタンス </summary>
    public readonly FieldData Data = new();

    protected override void CreateService()
    {
        ServiceLocater.AddService(this);
    }
}
