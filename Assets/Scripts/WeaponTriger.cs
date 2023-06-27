using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTriger : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    // Start is called before the first frame update
    private bool m_canGetWeapon=true;

    private void Awake()
    {
        player.OnWeaponSelect.AddListener(WeaponBlock);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void WeaponBlock()
    {
        m_canGetWeapon = false;
        Debug.Log($"Bloqueo de armas recibido por {gameObject.name}");
    }
    void OnTriggerStay(Collider collider)
    {
        if(m_canGetWeapon)
            if (collider.TryGetComponent(out Weapons l_weapon))
            {
            string nameWeapon = this.name;
            player.CanGetWeapons(nameWeapon, true);
            }
}
}
