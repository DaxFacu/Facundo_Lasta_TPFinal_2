using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveObjects : Entity
{
    protected string m_tagObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            m_tagObject = other.gameObject.tag;
            Debug.Log("player found");
            Debug.Log(m_tagObject);
        }

        else if (other.TryGetComponent(out Enemy Enemy))
        {
            m_tagObject = other.gameObject.tag;
            Debug.Log("enemy found");
        }

        else
        {
            m_tagObject = "none";
        }


    }

    protected string GetTriggerTag()
    {
        return m_tagObject;
        

    }
}


