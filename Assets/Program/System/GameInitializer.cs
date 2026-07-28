using UnityEngine;

/// <summary>
/// ゲーム初期化用コンポーネント
/// </summary>
public class GameInitializer : MonoBehaviour
{
    void Awake()
    {
        if(FindObjectsByType<GameInitializer>(FindObjectsSortMode.None).Length == 1)
        {
            DontDestroyOnLoad(gameObject);

            ServiceLocater.Reset();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
