using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BuyManager m_coinsManager;
    [SerializeField] private LevelSceneManager m_levelSceneManager;
    [SerializeField] private EnemyManager m_enemyManager;


    public static GameManager Instance;


    private void Awake()
    {
      //  var l_gameManager = FindAnyObjectByType<GameManager>();
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoins(int p_coins)
    {
        m_coinsManager.AddCoins(p_coins);
        var l_currentCoins = m_coinsManager.GetCurrentCoins();
        if (l_currentCoins > 100)
        {
            //aparecer mercader
        }
    }

    public void ChangeLevel(string level)
    {
        m_levelSceneManager.LoadLevel(level);
    }

    public void DeleteEnemy(GameObject enemys)
    {
        m_enemyManager.DestroyEnemy(enemys);
        Debug.Log("Enemy" + enemys);
    }
}
