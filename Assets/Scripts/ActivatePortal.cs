using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivatePortal : MonoBehaviour
{
    public UnityEvent OnBossDie;
    private bool m_isPressed = false;
    [SerializeField] private Enemy m_enemy; 

   // [SerializeField] private GameObject m_portalChangeLevel;
    // Start is called before the first frame update
    [ContextMenu("ChangeLevel")]


    public void ActiveChangeLevel()
    {
        if (m_isPressed)
            return;
        Debug.Log("Button");
        m_isPressed = true;
       OnBossDie?.Invoke();
    }

    private void BossHealth()
    {
        if(m_enemy.GetHealth() <= 0)
        {
            ActiveChangeLevel();
        }
    }
}
