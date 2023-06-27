using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    [SerializeField] private FloorPlatePressed m_plate;

    private void Awake()
    {
        m_plate.OnPlatePressed.AddListener(OpenDoor);
    }

    public void OpenDoor()
    {
        m_animator.SetBool("Open", true);
        Debug.Log($"Activar Puerta recibido por {gameObject.name}");
    }
    // Start is called before the first frame update
}
