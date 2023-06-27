using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private PlayerController m_player;
    [SerializeField] private PlayerSpecs m_playerSpecs;
    /*
    public struct InvenToryItem
    {
        public int amount;
        public ItemData itemData;
    }*/

    public struct ItemData
    {
        public string ID;
        public string ItemName;
        public string Effect;
    }



    private Dictionary<string, ItemData> m_itemsData = new Dictionary<string, ItemData>();

    ItemData SmallPotionHeal = new ItemData()
    {
        ID = "SmallPotionHeal",
        ItemName = "Small Potion Heal ",
        Effect = "Cura 30 de vida"
    };

    ItemData MiddlepotionHeal = new ItemData()
    {

        ID = "MiddlePotionHeal",
        ItemName = "Middle Potion Heal",
        Effect = "Cura 60 de vida"

    };

    ItemData BigpotionHeal = new ItemData()
    {

        ID = "BigPotionHeal",
        ItemName = "Big Potion Heal",
        Effect = "Cura 90 de vida"

    };

    ItemData SpeedPotion = new ItemData()
    {

        ID = "SpeedPotion",
        ItemName = "SpeedPotion",
        Effect = "Da velocidad extra"

    };






    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addToInventory(string p_id, ItemData p_item)
    {
        if (m_itemsData.ContainsKey(p_id))
        {
            Debug.Log("Ya contiene ese item");
        }
        else
        {
            var l_inventoryItem = p_item;
            m_itemsData.Add(p_id, p_item);
            m_playerSpecs.ShowPotion();
        }
    }

    public void UseItem(string p_id)
    {

        if (m_itemsData.ContainsKey(p_id))
        {
            if (p_id == "SmallPotionHeal")
            {
                m_player.ReceiveHealth(50);
                Debug.Log("Se usó el item");
                m_itemsData.Remove(p_id);
                m_playerSpecs.HiddenPotion();
            }

             
        }
    }

    public void GetItem(string p_itemName)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(SmallPotionHeal.ID == p_itemName)
            {
                addToInventory(p_itemName, SmallPotionHeal);

                PrintInfoData();
            }
            
        }

            if (SpeedPotion.ID == p_itemName)
            {
                addToInventory(p_itemName, SpeedPotion);

                PrintInfoData();
            }



    }

    private void PrintInfoData()
    {
        if(m_itemsData.TryGetValue("SmallPotionHeal", out ItemData l_potionData)){
            Debug.Log(l_potionData.ID);
            Debug.Log(l_potionData.ItemName);
            Debug.Log(l_potionData.Effect);
        }
    }

}
