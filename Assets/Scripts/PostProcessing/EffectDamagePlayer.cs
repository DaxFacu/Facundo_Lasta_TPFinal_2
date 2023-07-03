using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class EffectDamagePlayer : MonoBehaviour
{
    [SerializeField] private Volume m_postDamage;
    private bool m_changePostDamageLowHealth;
    // Start is called before the first frame update

    private void Awake()
    {
        //EffectLowHealth();
        if (m_postDamage.sharedProfile.TryGet(out ColorAdjustments m_colorLowHealth))
            m_changePostDamageLowHealth = false;
        m_colorLowHealth.colorFilter.overrideState = m_changePostDamageLowHealth;

}
    public void EffectLowHealth()
    {if(m_postDamage.sharedProfile.TryGet(out ColorAdjustments m_colorLowHealth))
        m_changePostDamageLowHealth = true;
           m_colorLowHealth.colorFilter.overrideState=m_changePostDamageLowHealth;

    }
    void Start()
    {
      //  DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
