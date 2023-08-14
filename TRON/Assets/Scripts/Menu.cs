using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void Inicio()
    {
        SceneManager.LoadScene("Menu");
    }

    public void EscenaJuego()
    {
        SceneManager.LoadScene("Juego");
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void Pausa()
    {
        SceneManager.LoadScene("Pausa");
    }
}
