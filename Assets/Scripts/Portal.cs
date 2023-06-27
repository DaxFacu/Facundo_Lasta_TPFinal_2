using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private ActivatePortal m_activatePortal;
    private bool m_active = false;

    // Start is called before the first frame update
    void Start()
    {
        m_activatePortal.OnBossDie.AddListener(ActiveScript);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ActiveScript()
    {
       // m_active = true;
    }


    void OnCollisionEnter(Collision collision)
    {
        //Check to see if the Collider's name is "Chest"
        if (collision.collider.CompareTag("Player"))
        {
            //GameManager.Instance.ChangeLevel("Scene2");
              GameManager.Instance.ChangeLevel("Scene2");
            //Output the message
            Debug.Log("Portal is here!");
        }
    }
}
