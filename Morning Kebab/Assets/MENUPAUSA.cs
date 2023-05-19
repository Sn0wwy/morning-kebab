using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MENUPAUSA : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    public void Pausa()
    {
        Time.timeScale = 0f;
        Panel.active = true;
    }
    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void Reanudar()
    {
        Panel.active = false;
        Time.timeScale = 1f;
    }


    public void Salir()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
