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
    [SerializeField] float turnSpeed = 50f;
    bool lookUp;
    bool lookDown;
    bool lookR;
    bool lookL;

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

        //cameraControl();

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

        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        transform.Rotate(0,0,yaw);
        if(Input.GetAxis("Vertical") > 0){
            // Calcula el desplazamiento en la dirección negativa del eje local X.
            Vector3 localMovement = new Vector3(-velocidad * Time.deltaTime * Input.GetAxis("Vertical"), 0, 0);

            // Transforma el desplazamiento al espacio del mundo.
            Vector3 worldMovement = transform.TransformDirection(localMovement);

            // Actualiza la posición del objeto en el espacio del mundo.
            transform.position += worldMovement;
        }
        /*
        // Calcula el desplazamiento en la dirección negativa del eje local X.
        Vector3 localMovement = new Vector3(-velocidad * Time.deltaTime, 0, 0);

        // Transforma el desplazamiento al espacio del mundo.
        Vector3 worldMovement = transform.TransformDirection(localMovement);

        // Actualiza la posición del objeto en el espacio del mundo.
        transform.position += worldMovement;
        */


    }

    public void cameraControl(){
        
        //------------------------ Control de cámara --------------------------
        // Rotate the camera based on the mouse movement
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //Si mira hacia la derecha
        if(mouseX > 0 ){
            lookR = true;
            lookDown = false;
            lookL = false;
            lookUp = false;
        }
        //Si mira hacia la izquierda
        if(mouseX < 0 ){
            lookL = true;
            lookR = false;
            lookDown = false;
            lookUp = false;
        }
        //Si mira hacia arriba
        if(mouseY > 0 ){
            lookL = false;
            lookR = false;
            lookDown = false;
            lookUp = true;
        }
        //Si mira hacia abajo
        if(mouseY < 0 ){
            lookL = false;
            lookR = false;
            lookDown = true;
            lookUp = false;
        }



        if(lookR){
            // Calcula el desplazamiento en la dirección negativa del eje local y.
            Vector3 localMovement = new Vector3(0, -velocidad * Time.deltaTime, 0);

            // Transforma el desplazamiento al espacio del mundo.
            Vector3 worldMovement = transform.TransformDirection(localMovement);

            // Actualiza la posición del objeto en el espacio del mundo.
            transform.position += worldMovement;
        }
        if(lookL){
            // Calcula el desplazamiento en la dirección positiva del eje local y.
            Vector3 localMovement = new Vector3(0, velocidad * Time.deltaTime, 0);

            // Transforma el desplazamiento al espacio del mundo.
            Vector3 worldMovement = transform.TransformDirection(localMovement);

            // Actualiza la posición del objeto en el espacio del mundo.
            transform.position += worldMovement;
        }
        if(lookUp){
            // Calcula el desplazamiento en la dirección positiva del eje local z.
            Vector3 localMovement = new Vector3(0, 0, velocidad * Time.deltaTime);

            // Transforma el desplazamiento al espacio del mundo.
            Vector3 worldMovement = transform.TransformDirection(localMovement);

            // Actualiza la posición del objeto en el espacio del mundo.
            transform.position += worldMovement;
        }
        if(lookDown){
            // Calcula el desplazamiento en la dirección negativa del eje local z.
            Vector3 localMovement = new Vector3(0, 0, -velocidad * Time.deltaTime);

            // Transforma el desplazamiento al espacio del mundo.
            Vector3 worldMovement = transform.TransformDirection(localMovement);

            // Actualiza la posición del objeto en el espacio del mundo.
            transform.position += worldMovement;
        }
        
        Debug.Log("Mouse X: " + mouseX);
        Debug.Log("Mouse Y: " + mouseY);
        //player.transform.Rotate(rotationAmount);
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
