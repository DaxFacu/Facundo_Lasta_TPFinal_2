using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //Check to see if the Collider's name is "Chest"
        if (collision.collider.CompareTag("Player"))
        {
            Finish();
        }
    }

    private void Finish()
    {
        GameManager.Instance.ChangeLevel("Finish");
    }
}
