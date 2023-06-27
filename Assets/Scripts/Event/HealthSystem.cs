using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{

    private float m_currentHealth;
    public event Action OnEntityDead;
   // public event Action<float> OnDamagedReceived;
    [SerializeField] private PlayerController m_player;

    public void Init()
    {
        m_currentHealth = m_player.GetHealth();
    }

    public void TakeDamage() {
        m_currentHealth = m_player.GetHealth();
        //Debug.Log($"Evento: el jugador {m_currentHealth}");
        if (m_currentHealth <= 0)
        {
            Die();
            Debug.Log($"Evento: el jugador está muerto {gameObject.name}");
            m_currentHealth = 0;
            //return;
        }
    }

    [ContextMenu("Test entity health")]
    public void Test()
    {
        OnEntityDead?.Invoke();
    }


    private void Die()
    {
        OnEntityDead?.Invoke();
    }

}
