using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPlay : MonoBehaviour
{
    private bool activeOption;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject options;
    private Dropdown m_dropdown;
    [SerializeField] private GameObject m_dropdownObj;
    

    // Start is called before the first frame update
    void Start()
    {
        m_dropdown = m_dropdownObj.GetComponent<Dropdown>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void Option()
    {
        activeOption = !activeOption;
        menu.SetActive (!activeOption);
        options.SetActive(activeOption);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Saliendo de la aplicación");
    }

    public void GotoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ChangeResolution(int p_resolution)
    {
        switch (p_resolution)
        {
            case 0:
                Screen.SetResolution(1920, 1080, true);
                Debug.Log("Resolucion cambiada a:" + p_resolution);
                break;
            case 1:
                Screen.SetResolution(1080, 720, true);
                Debug.Log("Resolucion cambiada a:" + p_resolution);
                break;
            case 2:
                Screen.SetResolution(720, 480, true);
                Debug.Log("Resolucion cambiada a:" + p_resolution);
                break;
        } 
    }

    void DropdownValueChanged(Dropdown change)
    {
        m_dropdown.onValueChanged.AddListener(delegate {
           ChangeResolution(m_dropdown.value);
            Debug.Log("Resolucion cambiada a:" + change);
        });
    }
}
