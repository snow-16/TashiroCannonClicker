using System.Collections.Generic;

/// <summary>
/// ユニークなインスタンスを取得するクラス
/// </summary>
public class ServiceLocater
{
    /// <summary> インスタンスのリスト </summary>
    private static Dictionary<string, ServiceBase> Services { get; set; }

    /// <summary>
    /// リストの初期化
    /// </summary>
    public static void Reset()
    {
        Services = new();
    }

    /// <summary>
    /// インスタンスを追加する
    /// </summary>
    /// <typeparam name="T">インスタンスの型</typeparam>
    /// <param name="service">インスタンス</param>
    public static void AddService<T>(T service) where T : ServiceBase
    {
        Services.Add(typeof(T).ToString(), service);
    }

    /// <summary>
    /// インスタンスを取得する
    /// </summary>
    /// <typeparam name="T">インスタンスの型</typeparam>
    /// <param name="result">返すインスタンス</param>
    /// <returns>インスタンス</returns>
    public static bool LocateService<T>(out T result) where T : ServiceBase
    {
        result = (T)Services[typeof(T).ToString()];

        if(!result)
        {
            Services.Remove(typeof(T).ToString());
            return false;
        }
        
        return true;
    }
}
