using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    [SerializeField] private float m_speed;
    [SerializeField] private float m_deathTime = 3f;
    private float m_currentTime;
    private Vector3 newScale;
    // Start is called before the first frame update
    void Start()
    {
        m_currentTime = m_deathTime;
        newScale = transform.localScale * 2;
    }

    // Update is called once per frame
    void Update()
    {
        m_currentTime -= Time.deltaTime;
        if (m_currentTime <= 0)
        {
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.localScale = newScale;
        }
        transform.position += m_speed * Time.deltaTime * transform.forward;
    }


}