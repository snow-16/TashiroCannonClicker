using UnityEngine;

/// <summary>
/// ユニークなインスタンスを持つコンポーネントの抽象クラス
/// </summary>
public abstract class ServiceBase : MonoBehaviour
{
    void Awake()
    {
        CreateService();
    }
    
    /// <summary>
    /// ServiceLocaterに自身を登録する
    /// </summary>
    protected abstract void CreateService();
}
