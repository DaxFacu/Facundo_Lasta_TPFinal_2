using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapArrow : Trap
{
    [SerializeField] private float m_range;
    [SerializeField] private float m_cooldown;
    [SerializeField] private Magic m_magic;
    AudioSource AttackEnemy;


    // Start is called before the first frame update
    void Start()
    {
        AttackEnemy = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if(GetTriggerTag() == "Player")
        {
            Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
         
            var m_range = Vector3.Distance(playerTransform.position, this.transform.position);
                if(m_range< 6){
                AttackEnemy.Play(0);
                Instantiate(m_magic, this.transform.position, this.transform.rotation);
            } 
        }    
    }

}
