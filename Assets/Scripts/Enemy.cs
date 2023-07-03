using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyTypes enemyType;
    [SerializeField] private float m_minDistanceToChase = 2f;
    [SerializeField] private Transform m_target;
    [SerializeField] private Transform m_enemyHead;
    [SerializeField] private float m_turningSpeed = 10f;
    [SerializeField] private float m_movementSpeed = 10f;

    [SerializeField] private Animator m_animator;


    [SerializeField] private Magic m_bulletToShoot;
    [SerializeField] private Transform m_shootingPoint;

    [SerializeField] private GameObject m_parentShooting;

    [SerializeField] private float enemyAttackTime = 2.20f;
    [SerializeField] private float currentAttackTime;

    [SerializeField] private bool enemyDeath;

    [SerializeField] private float enemyHealth;
    [SerializeField] private float enemyDamage;


    [SerializeField] private bool m_playerIsVisible;

    [SerializeField] private EnemyPowerData m_enemyData;

    [SerializeField] private HealthSystem m_healthSystem;

    [SerializeField] private bool m_playerIsDead = false;


    //AudioSource audioIsDead;
    AudioSource AttackEnemy;

    private void Awake()
    {
        AttackEnemy = GetComponent<AudioSource>();
        // audioIsDead = GetComponent<AudioSource>();
        m_healthSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
        m_healthSystem.Init();
        m_healthSystem.OnEntityDead += PlayerIsDead;
        switch (enemyType)
        {
            case EnemyTypes.EnemyMelee:
                enemyHealth = 20;
                enemyDamage = 20;
                break;
            case EnemyTypes.EnemyRangeMage:
                enemyHealth = m_enemyData.maxHealth;
                enemyDamage = m_enemyData.damage;
                break;
            case EnemyTypes.EnemyBoss:
                enemyHealth = 100;
                enemyDamage = 20;
                break;
        }

        m_target = GameObject.FindGameObjectWithTag("Player").transform;


    }

    public enum EnemyTypes
    {
        EnemyMelee,
        EnemyRangeMage,
        EnemyBoss
    }

    public void PlayerIsDead()
    {
       m_playerIsDead = true;
        m_healthSystem.OnEntityDead -= PlayerIsDead;
        Debug.Log("Evento: player muerto fue recibido");
        //m_animator.SetBool("EnemyAttack", false);
        m_playerIsVisible = false;
    }
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if (m_playerIsVisible && m_playerIsDead==false)
        {
            if (enemyDeath == false)
            {
                switch (enemyType)
                {
                    case EnemyTypes.EnemyMelee:
                        LookRotation();
                        Chase();
                        break;
                    case EnemyTypes.EnemyRangeMage:


                        LookRotation();
                        break;
                    case EnemyTypes.EnemyBoss:
                        LookRotation();
                        Chase();
                        break;
                }

                if (Input.GetKeyDown(KeyCode.K))
                {
                    Shoot();
                    m_animator.SetBool("EnemyAttack", true);
                }



                WaitToShoot();
            }
        }
        else
        {
            m_animator.SetBool("EnemyAttack", false);
        }

   
        IsDead();
    }

    private void Chase()
    {
        if (m_animator.GetBool("EnemyAttack") == false)
        {
            Debug.Log("attack enemy " + m_animator.GetBool("EnemyAttack"));
            var l_diffVector = m_target.position - transform.position;
        if (m_minDistanceToChase < l_diffVector.magnitude)
        {
            transform.position += l_diffVector * m_movementSpeed * Time.deltaTime;
            m_animator.SetFloat("EnemySpeed", l_diffVector.magnitude);
         
        }
        }

    }

    private void LookRotation()
    {
      
            var l_diffVector = m_target.transform.position - transform.position;
            Quaternion l_newRotation = Quaternion.LookRotation(l_diffVector.normalized);
            transform.rotation = Quaternion.Lerp(transform.rotation, l_newRotation, Time.deltaTime * m_turningSpeed);
       
       
    }


    private void WaitToShoot()
    {
        if (m_playerIsDead == false)
        {
            currentAttackTime += Time.deltaTime;
        if (currentAttackTime >= enemyAttackTime)
        {
                m_animator.SetBool("EnemyAttack", false);
                StartCoroutine(BulletWaitTime());
            currentAttackTime = 0;
        }
        }
    }
    private void Shoot()
    {
        m_movementSpeed = 0;
        m_animator.SetBool("EnemyAttack", true);
            Instantiate(m_bulletToShoot, m_shootingPoint.position, this.transform.rotation, m_parentShooting.transform);
        StartCoroutine(RunWaitTime());
        AttackEnemy.Play(0);
    }

    IEnumerator BulletWaitTime()
    {
        if (m_playerIsVisible)
        {
            
            yield return new WaitForSeconds(2);
           
            Shoot();
            
        }
        
    }

    IEnumerator RunWaitTime()
    {
        if (m_playerIsVisible)
        {

            yield return new WaitForSeconds(1);

            m_movementSpeed = 3;

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WeaponHand"))
        {
            enemyHealth -= 10;
        }


    }

    private void IsDead()
    {
        if (enemyHealth <= 0)
        {
            enemyDeath = true;
            this.m_animator.SetBool("EnemyDeath", true);
          // GameManager.Instance.DeleteEnemy(this.gameObject);
            // audioIsDead.Play(0);
          
        }
    }

    public float GetDamage()
    {
        return enemyDamage;
    }

    public float GetHealth()
    {
        return enemyHealth;
    }

    public void Attack(bool p_attack)
    {
        m_playerIsVisible = p_attack;
    }
}
