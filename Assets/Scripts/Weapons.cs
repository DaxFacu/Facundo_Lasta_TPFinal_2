using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] private WeaponTypes weaponType;
    [SerializeField] private GameObject Sword;
    [SerializeField] private GameObject Axe;
    [SerializeField] private GameObject Alabarda;
    [SerializeField] private ArrayList listWeapons;
    [SerializeField] public GameObject weaponActive;

    public enum WeaponTypes
    {
        none,
        Sword,
        Axe,
        Alabarda
        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (weaponType)
        {
            case WeaponTypes.Sword:
                Sword.SetActive(true);
                Axe.SetActive(false);
                Alabarda.SetActive(false);
                break;
            case WeaponTypes.Axe:
                Axe.SetActive(true);
                Sword.SetActive(false);
                Alabarda.SetActive(false);
                break;
            case WeaponTypes.Alabarda:
                Alabarda.SetActive(true);
                Axe.SetActive(false);
                Sword.SetActive(false);
                break;
        }

    }

    public void ChangeWeapon(string l_getWeapon)
    {
        string weaponName = l_getWeapon;
        switch (weaponName)
        {
            case "Sword":
                weaponType = WeaponTypes.Sword;
                weaponActive = Sword;
                break;
            case "Axe":
                weaponType = WeaponTypes.Axe;
                weaponActive = Axe;
                break;
            case "Alabarda":
                weaponType = WeaponTypes.Alabarda;
                weaponActive = Alabarda;
                break;
        }
    }

}
