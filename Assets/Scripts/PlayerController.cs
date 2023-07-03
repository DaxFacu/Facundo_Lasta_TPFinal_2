using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;
    [SerializeField] private float speedPlayer;
    [SerializeField] private Animator playerAnimator;

    [SerializeField] private Rigidbody m_rigidbody;

    [SerializeField] private float rotationSpeed;

    [SerializeField] private Weapons weapons;

    [SerializeField] private float healthPlayer;
    [SerializeField] private float damagePlayerInit;
    [SerializeField] private float damagePlayer;
    [SerializeField] private bool attack;

    //Raycast
    [SerializeField] private Transform m_player;

    [SerializeField] private Transform m_rayCastPoint;

    private float m_distanceRaycast;
    [SerializeField] private bool m_canJump;

    [SerializeField] private PlayerSpecs specs;

    public UnityEvent OnWeaponSelect;
    private bool m_isWeaponBlock;

    [SerializeField] private HealthSystem m_healthSystem;

    [SerializeField] EffectDamagePlayer m_lowHealth;

    [SerializeField] GameObject m_resetGame;

    private bool m_playerDie = false;

    [SerializeField] private Inventory m_inventory;

   // [SerializeField] GameObject m_headRotation;


    public float sensitivity = 2f;
    public float minYAngle = -60f;
    public float maxYAngle = 60f;

    private float rotationX = 0f;

    AudioSource audioData;

    private void Awake()
    {
        damagePlayerInit = 2;
        healthPlayer = 80;
        attack = false;
        m_distanceRaycast = 0.08f;
        m_resetGame.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
      //  DontDestroyOnLoad(this.gameObject);
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_playerDie == false)
        {
            Rotate(GetRotationInput());

            if (Input.GetKey(KeyCode.W))
            {
                transform.position += (transform.forward * speedPlayer * 10) * Time.deltaTime;
                if (speedPlayer < 1)
                {
                    speedPlayer += 0.6f * Time.deltaTime;

                    playerAnimator.SetFloat("PlayerSpeed", speedPlayer);

                }

            }
            else
            {
                if (speedPlayer > 0)
                {
                    speedPlayer -= 3 * Time.deltaTime;
                    playerAnimator.SetFloat("PlayerSpeed", speedPlayer);
                }
            }

            if (Input.GetKey(KeyCode.S))
            {
                speedPlayer = 0.4f;
                transform.position += (-transform.forward * speedPlayer * 10) * Time.deltaTime;
                playerAnimator.SetFloat("PlayerSpeed", speedPlayer);
            }

            if (Input.GetKey(KeyCode.A))
            {
                speedPlayer = 0.4f;
                transform.position += (-transform.right * speedPlayer * 10) * Time.deltaTime;
                playerAnimator.SetFloat("PlayerSpeed", speedPlayer);
            }
            if (Input.GetKey(KeyCode.D))
            {
                speedPlayer = 0.4f;
                transform.position += (transform.right * speedPlayer * 10) * Time.deltaTime;
                playerAnimator.SetFloat("PlayerSpeed", speedPlayer);
            }


            Attack1();
            Jump();
            UseItem();
        }
      
    }

    private void UseItem()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            m_inventory.UseItem("SmallPotionHeal");
        }
       
    }

    private void Rotate(Vector2 p_scrollDelta)
    {
            transform.Rotate(Vector3.up, p_scrollDelta.x * rotationSpeed * Time.deltaTime);
        
    }


    private Vector2 GetRotationInput()
    {
        var l_mouseX = Input.GetAxis("Mouse X");
        var l_mouseY = Input.GetAxis("Mouse Y");
        return new Vector2(l_mouseX, l_mouseY);
    }

    private Vector3 GetMovementInput()
    {
        var l_horizontal = Input.GetAxis("Horizontal");
        var l_vertical = Input.GetAxis("Vertical");
        return new Vector3(l_horizontal, 0, l_vertical).normalized;
    }

    private void Attack1()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            audioData.Play(0);
            playerAnimator.SetTrigger("PlayerAttack");
           
            StartCoroutine(TimeToColliderWeapon());
        }
        else
        {

        }
       
    }

    IEnumerator TimeToColliderWeapon()
    {
        attack = true;
        if (weapons.weaponActive!= null)
        {
            weapons.weaponActive.GetComponent<Collider>().enabled = attack;
            yield return new WaitForSeconds(1.5f);
            attack = false;
            weapons.weaponActive.GetComponent<Collider>().enabled = attack;
        }
       
       
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && m_canJump)
        {
            playerAnimator.SetTrigger("PlayerJump");
            m_rigidbody.AddForce(transform.up * 4, ForceMode.Impulse);
            m_canJump = false;
        }

        bool l_isHitting = Physics.Raycast(m_rayCastPoint.position, -transform.up, m_distanceRaycast);


        if (l_isHitting)
        {
         //   Debug.Log("Ground");
            m_canJump = true;

        }

        else
        {
        }

    }

    public void CanGetWeapons(string l_getWeaponsName, bool l_getWeapons)
    {
        if (l_getWeapons)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                weapons.ChangeWeapon(l_getWeaponsName);

                WeaponBlock();
                switch (l_getWeaponsName)
                {
                    case "Sword":
                        damagePlayer = damagePlayerInit * 2;
                        specs.changeWeaponImage(l_getWeaponsName);
                        break;
                    case "Axe":
                        damagePlayer = damagePlayerInit * 4;
                        specs.changeWeaponImage(l_getWeaponsName);
                        break;
                    case "Alabarda":
                        damagePlayer =  damagePlayerInit * 6;
                        specs.changeWeaponImage(l_getWeaponsName);
                        break;
                }
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WeaponEnemy"))
        {

            if (collision.collider.TryGetComponent(out DamageSpects l_damage))
            {
                var enemyDanamge = l_damage.GetDamage();
                ReceiveDamage(enemyDanamge);
            
            }
        }


    }

    private void ReceiveDamage(float p_damage)
    {
        healthPlayer -= p_damage;
        if (healthPlayer < 1)
        {
            playerAnimator.SetBool("PlayerDeath", true);
            m_healthSystem.TakeDamage();
            m_lowHealth.EffectLowHealth();
            m_playerDie = true;
            m_resetGame.SetActive(true);
        }
    }

   public void ReceiveHealth(float p_health)
    {
        if (healthPlayer < 200)
        {
            healthPlayer += p_health;
        }
    }

    public float GetHealth()
    {

        return healthPlayer;
    }

    public float GetDamage()
    {
        return damagePlayer;
    }

    [ContextMenu("WeaponBlock")]
    //WeaponSelectEventBlock
    public void WeaponBlock()
    {
        if (m_isWeaponBlock)
            return;
        //m_isWeaponBlock = true;
       // OnWeaponSelect?.Invoke();
       // Debug.Log($"Bloqueo de armas enviado por {gameObject.name}");
    }
}
