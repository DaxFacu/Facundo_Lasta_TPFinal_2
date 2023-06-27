using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraHealth : MonoBehaviour
{

    [SerializeField] private float amountHeal;
    [SerializeField] private float currentHealTime;
    [SerializeField] private float durationHealTime;
    [SerializeField] private float enemyHealTime;
    [SerializeField] private float restantHeal;
    [SerializeField] private Material auraMaterial;
    // Start is called before the first frame update

    private void Awake()
    {
        amountHeal = 1;
        durationHealTime = 4;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RestartHealPlayer();
    }

    public float GetAmountHeal()
    {
        return amountHeal;
    }

    void OnTriggerStay(Collider collider)
    {

        if (collider.TryGetComponent(out PlayerController player))
        {
          
            currentHealTime += Time.deltaTime;
            if (currentHealTime <= durationHealTime)
            {
             
                player.ReceiveHealth(amountHeal);
            }
            else
            {
                amountHeal = 0;
                auraMaterial.color = new Color(0, 0, 0, 0.2f);
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {

        if (collider.TryGetComponent(out PlayerController player))
        {
           
            currentHealTime = 0;
            
        }
    }
    IEnumerator HealWaitTime()
    {
        yield return new WaitForSeconds(4);
        amountHeal = 1;
        auraMaterial.color= new Color(0.4f, 0.9f, 0.7f, 0.4f);
    }

    private void RestartHealPlayer()
    {
        if (amountHeal == 0)
        {
            StartCoroutine(HealWaitTime());
        }
       
    }
}
