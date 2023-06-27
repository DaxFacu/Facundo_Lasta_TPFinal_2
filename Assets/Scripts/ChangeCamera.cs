using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField] private GameObject m_camera1Object, m_camera2Object;

    [SerializeField] private float currentCameraTime;
    [SerializeField] private float durationCameraTime;
    [SerializeField] private bool ChangeCamara;


    private void Awake()
    {
        durationCameraTime = 4;
        ChangeCamara = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        //m_camera1Object.SetActive(false);
       // m_camera2Object.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeCameras();
        }
        TimeToChangeCamara();
    }

    private void ChangeCameras()
    {
        //m_camera1Object.SetActive(!m_camera1Object.activeSelf);
       // m_camera2Object.SetActive(!m_camera2Object.activeSelf);
    }

    void OnTriggerEnter(Collider collider)
    {

        if (collider.TryGetComponent(out PlayerController player))
        {
            ChangeCamara = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {

        if (collider.TryGetComponent(out PlayerController player))
        {

            ChangeCamara = false;
            m_camera1Object.SetActive(true);
            m_camera2Object.SetActive(false);
        }
    }

    private void TimeToChangeCamara()
    {
        if (ChangeCamara)
        {
            currentCameraTime += Time.deltaTime;
            if (currentCameraTime <= durationCameraTime)
            {

                m_camera1Object.SetActive(false);
                m_camera2Object.SetActive(true);
            }
            else if (currentCameraTime > durationCameraTime)
            {
                m_camera1Object.SetActive(true);
                m_camera2Object.SetActive(false);
                ChangeCamara = false;
            }
        }
    }

      
}
