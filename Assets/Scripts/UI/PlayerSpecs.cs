using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpecs : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private Text damagePlayer;
    [SerializeField] private Text healthPlayer;
    [SerializeField] private Image m_weapon;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image m_weaponHandImagen;
    [SerializeField] private Sprite m_weaponHandImagenSword;
    [SerializeField] private Sprite m_weaponHandImagenAxe;
    [SerializeField] private Sprite m_weaponHandImagenHalberd;
    [SerializeField] private Image m_PotionHeal;

    // Start is called before the first frame update
    void Start()
    {
       // DontDestroyOnLoad(this.gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthSlider();
      //  damagePlayer.text = "Damage : " + player.GetDamage().ToString();
     //   healthPlayer.text = "Health : " + player.GetHealth().ToString();
    }

    private void HealthSlider() { 
        healthSlider.value = player.GetHealth();
    }


    public void ShowPotion()
    {
        m_PotionHeal.enabled= true;
    }

    public void HiddenPotion()
    {
        m_PotionHeal.enabled = false;

    }

    public void changeWeaponImage(string p_weapon)
    {
        if (p_weapon == "Sword") {
            m_weaponHandImagen.sprite = m_weaponHandImagenSword;
        }
        else if (p_weapon == "Axe")
        {
            m_weaponHandImagen.sprite = m_weaponHandImagenAxe;
        }
        else if(p_weapon == "Alabarda")
        {
            m_weaponHandImagen.sprite = m_weaponHandImagenHalberd;
        }

    }
}
