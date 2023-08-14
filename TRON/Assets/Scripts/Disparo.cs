using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    //[SerializeField] AudioSource disparoSFX;
    public Transform[] punto;
    public GameObject bala;
    public float fuerza = 15f;
    public float tiempo = 0.5f;
    private float contador = 0f;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //disparoSFX.Play();
            GameObject nuevaBala;
            nuevaBala = Instantiate(bala, punto[0].position, punto[0].rotation);
            nuevaBala.GetComponent<Rigidbody>().AddForce(punto[0].forward * fuerza);
            Destroy(nuevaBala, tiempo);

            AudioSource balaSFX = nuevaBala.GetComponent<AudioSource>();
            balaSFX.Play();

            GameObject nuevaBala2;
            nuevaBala2 = Instantiate(bala, punto[1].position, punto[1].rotation);
            nuevaBala2.GetComponent<Rigidbody>().AddForce(punto[1].forward * fuerza);
            Destroy(nuevaBala2, tiempo);
        }
    }
}

