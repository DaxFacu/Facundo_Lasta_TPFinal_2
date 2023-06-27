using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloorPlatePressed : MonoBehaviour
{
    public UnityEvent OnPlatePressed;
    private bool m_isPressed = false;

    [SerializeField] private DoorController m_doorToOpen;
    // Start is called before the first frame update
    [ContextMenu("Press Button")]

    public void PlatePressed()
    {
        if (m_isPressed)
            return;
        Debug.Log("Button");
        m_isPressed = true;
        OnPlatePressed?.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log($"Activar Puerta llamado por {collision.gameObject.name}");
            PlatePressed();
        }
    }
}
