using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform [] m_enemySpawns;
    [SerializeField] private List<GameObject> m_enemiesList;
    [SerializeField] private GameObject m_enemy;
    [SerializeField] private DificultyData m_dificultyData;
    [SerializeField] private float m_currentTime;
    [SerializeField] private float m_spawnEnemy;
    [SerializeField] private float m_countEnemy;

    private void Awake()
    {
        if (m_dificultyData.dificultyHard == true)
        {
            m_spawnEnemy = 4;
        }
        else
        {
            m_spawnEnemy = 2;
        }
        m_enemiesList = new List<GameObject>();
        EnemyInstantiate();
       
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Hay {m_enemiesList.Count} enemigos");
        ArrayDown();
      
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void EnemyInstantiate()
    {
        foreach (Transform enemy in m_enemySpawns)
        {
            if (m_countEnemy < m_spawnEnemy)
            {
                m_enemiesList.Add(Instantiate(m_enemy, enemy));
            }
            m_countEnemy++;
          
            //Debug.Log(m_enemy.name);
        }
    }

    private void Arrayup()
    {
        for (var i = 0; i<m_enemySpawns.Length; i++)
        {
            //Futuro inventario
            Debug.Log(m_enemySpawns[i]);
        }
    }
    private void ArrayDown()
    {
        for (var i = m_enemySpawns.Length-1; i >= 0 ; i--)
        {
            //Futuro inventario
           // Debug.Log(m_enemySpawns[i]);
        }
    }

    private void RespawnEnemy()
    {

    }
    public void DestroyEnemy(GameObject enemys)
    {
      m_enemiesList.Remove(enemys);
        Debug.Log($"Quedan {m_enemiesList.Count} enemigos");
        
    }
}
