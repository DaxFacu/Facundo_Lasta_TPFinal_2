using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
   // [SerializeField] private EnemyTrap m_trapEnemy;
    [SerializeField] private GameObject m_enemyToRespawn;

    private void Awake()
    {
     //  m_trapEnemy.OnTriggerEnterPlayer.AddListener(RespawnEnemy);
    }

    public void RespawnEnemy()
    {
        Instantiate(m_enemyToRespawn, transform.position, Quaternion.identity);
        Debug.Log($"Aparición de enemigo recibido por {gameObject.name}");
    }
}
