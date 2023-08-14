using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] AudioSource click;

    //Funcion que nos permite cambiar de escena
    public void CambiarEscena(string Nombre)
    {
        //Usando "SceneManager" cambiamos de escena mandando el nombre de la escena como parametro
        SceneManager.LoadScene(Nombre);
    }

    public void EndGame(){
        //Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Salir del editor de Unity
        #else
                Application.Quit(); // Salir de la aplicación en tiempo de ejecución
        #endif
    }

     public void clickSFX(){
        click.Play();
    }
    
 

}