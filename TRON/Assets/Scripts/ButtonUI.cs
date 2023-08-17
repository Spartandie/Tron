using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    [SerializeField] private GameObject[] Buttons;
    [SerializeField] GameObject player;
    [SerializeField] AudioSource click;


    public void Pausa(){
        Time.timeScale = 0f;
        Buttons[0].SetActive(true);
        Buttons[1].SetActive(true);
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<Disparo>().enabled = false;
        //Buttons[2].SetActive(true);
        //gameObject.SetActive(false);
    }

    public void Continuar(){
        Time.timeScale = 1f;
        Buttons[0].SetActive(false);
        Buttons[1].SetActive(false);
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<Disparo>().enabled = true;
        //Buttons[2].SetActive(false);
    }

    public void Reiniciar(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Jueaago");
    }

     public void Menu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void clickSFX(){
        click.Play();
    }
}
