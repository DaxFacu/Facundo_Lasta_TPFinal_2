using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RitualInstance : MonoBehaviour
{
    public UnityEvent OnTriggerEnterPlayer;
    private bool m_isPressed = false;

    // Start is called before the first frame update
    [ContextMenu("RespawnEnemyTrap")]

    public void RespawnEnemy()
    {
        if (m_isPressed)
            return;
        m_isPressed = true;
        OnTriggerEnterPlayer?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

            }
            Debug.Log($"Aparecer enemigos llamado por {other.gameObject.name}");
            RespawnEnemy();
        }
    }

}
