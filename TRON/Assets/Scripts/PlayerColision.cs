using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerColision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Piso"){
            Debug.Log("chocouuw");
            SceneManager.LoadScene("Death");
           // animator.SetBool("Correr", true);
        }

        /*
        if(collision.gameObject.tag == "Enemy"){
            //Destroy(Player);
            //SceneManager.LoadScene("Demo");
            SceneManager.LoadScene("DeathScene");

        }
        */
    }
}
