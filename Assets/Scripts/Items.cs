using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] private Item items;
    [SerializeField] private Inventory inventory;
    [SerializeField] private string itemName;
    public enum Item
    {
        SmallPotionHeal,
      MiddlePotionHeal,
      SpeedPotion
    }
    private void Awake()
    {
        switch (items)
        {
            case Item.SmallPotionHeal:
                itemName = "SmallPotionHeal";
                break;
            case Item.MiddlePotionHeal:
                itemName = "MiddlePotionHeal";
                break;
            case Item.SpeedPotion:
                itemName = "SpeedPotion";
                break;
        }

    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider collider)
    {

        if (collider.TryGetComponent(out PlayerController player))
        {

            // currentHealTime = 0;
            inventory.GetItem(itemName);
            Debug.Log(itemName);

        }
    }
}
