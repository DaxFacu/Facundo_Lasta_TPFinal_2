using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyManager : MonoBehaviour
{
    [SerializeField] private int m_currentCoins;
    public int GetCurrentCoins() => m_currentCoins;

    public void AddCoins(int p_coins)
    {
        m_currentCoins += p_coins;
      //  Debug.Log(m_currentCoins);
    }

    private int m_currentScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
