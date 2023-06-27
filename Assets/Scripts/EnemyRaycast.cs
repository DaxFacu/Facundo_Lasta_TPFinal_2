using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyRaycast : MonoBehaviour
{
    [SerializeField] private Transform m_player;
    [SerializeField] private Transform m_enemy;
   


    [SerializeField] private Transform m_rayCastPoint;
    [SerializeField] private float m_maxDistance;

    [SerializeField] private Enemy enemyScript;

    public event Action OnVisiblePlayer;
    private bool m_limitAttackDisabled=false;

    [SerializeField] private EnemyRaycast m_enemyRaycast;

    private void Awake()
    {
        m_player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector3.Distance(m_player.position, this.transform.position) < 6) || m_limitAttackDisabled==true)
        {
          
            if ((Vector3.Angle(m_player.position - transform.position, transform.forward) < 30) || m_limitAttackDisabled == true)
            {
                if (m_limitAttackDisabled == false)
                {
                    this.gameObject.GetComponent<EnemyRaycast>().OnVisiblePlayer += OnEntityVisible;
                    Debug.Log($"Evento: enemigo {gameObject.name} avisó que detectó al player");
                }
               
               
                // Debug.Log("You've been spotted! RUN!");
                bool l_isHitting = Physics.Raycast(m_rayCastPoint.position, transform.forward, out RaycastHit l_hit, m_maxDistance);


                if (l_isHitting)
                {

                    Debug.Log($"Collider{l_hit.collider.name}");
                    this.gameObject.GetComponent<Enemy>().Attack(true);

                }
            }

        }
        if (Vector3.Distance(m_player.position, this.transform.position) > 10)
        {
            this.gameObject.GetComponent<Enemy>().Attack(false);
            m_limitAttackDisabled = true;
            m_enemyRaycast.OnVisiblePlayer -= OnEntityVisible;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(m_rayCastPoint.position, m_rayCastPoint.position + m_rayCastPoint.forward * m_maxDistance);
    }

    public void OnEntityVisible()
    {
        m_limitAttackDisabled = true;
        Debug.Log($"Evento: enemigo {gameObject.name} fue avisado que detectaron al player");
    }

    [ContextMenu("PlayerVisibleEvent")]
    public void Test()
    {
        OnVisiblePlayer?.Invoke();
    }
}
     
