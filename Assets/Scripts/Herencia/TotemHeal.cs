using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemHeal : Totem
{
   // [SerializeField] private Animator m_heal;
   // [SerializeField] private Animator m_animator;
 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealPlayer();
    }

    public void HealPlayer()
    {
        if (GetTriggerTag() == "Player")
        {
           // Debug.Log($"estoy curando al player {m_heal} de vida");
        }
      
    }
}
