using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Variables para control de camara
    [SerializeField] float sensitivity = 5.0f;
    //variables para control de jugador 
    [SerializeField] GameObject[] trazoLuz;
    [SerializeField] float velocidad;
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerExplosion;
    [SerializeField] AudioSource playerExplosionSFX;
    [SerializeField] AudioSource theGridSFX;
    [SerializeField] GameObject buttonUI; 


    float velocidadTemp;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //----------------------- Control de jugador ---------------------------
        mover();
        turbo();


        //------------------------ Control de cámara --------------------------
        // Rotate the camera based on the mouse movement
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.eulerAngles += new Vector3(-mouseY * sensitivity, mouseX * sensitivity, 0);

        Vector3 rotationAmount = new Vector3(mouseX, 0, 0) * sensitivity;
        // Debug.Log("mouseX: " + mouseX);
        //Debug.Log("rotationAmount: "+ rotationAmount.x);
        player.transform.Rotate(rotationAmount);

    }

    //Maneja el turbo del jugador
    public void turbo(){
        if(Input.GetMouseButtonDown(1)){
            velocidadTemp = velocidad;
            velocidad = velocidad*3.0f;
            trazoLuz[0].SetActive(true);
            trazoLuz[1].SetActive(true);

        }
        if(Input.GetMouseButtonUp(1)){
            velocidad = velocidadTemp;
            trazoLuz[0].SetActive(false);
            trazoLuz[1].SetActive(false);
        }
    }


    //Se encarga de mover continuamente al jugador en su eje local Z
    public void mover(){


        // Obtén la dirección del eje local Z del objeto
        Vector3 localZDirection = transform.forward;

        // Calcula el desplazamiento basado en la dirección del eje local Z y la velocidad
        float displacement = velocidad * Time.deltaTime;

        // Mueve el objeto en su eje local Z
        transform.position += localZDirection * displacement;

    }

    //Evalua colisiones 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Piso"))
        {
            StartCoroutine(PlayerDestruction());   
        }
        if (other.CompareTag("Enemy")){
            StartCoroutine(PlayerDestruction());
        }
    }

    //Destruye jugador
    private IEnumerator PlayerDestruction(){



        velocidad = 0;
        velocidadTemp = 0;
        sensitivity = 0;

        GetComponent<Disparo>().enabled=false;

        buttonUI.SetActive(false);
        Renderer rendererPlayer = player.GetComponent<Renderer>();
        rendererPlayer.enabled = false;
        Collider playerCollider = player.GetComponent<Collider>();
        playerCollider.enabled = false;

        Rigidbody playerRB = GetComponent<Rigidbody>();
        playerRB.isKinematic = true;


        //Activa efecto de explosión
        theGridSFX.Stop();
        playerExplosionSFX.Play();
        playerExplosion.SetActive(true);

        // Esperar el tiempo especificado.
        yield return new WaitForSeconds(4);
        //Manda a la escena de muerte
        SceneManager.LoadScene("Death");
    }

}
