using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtack : MonoBehaviour
{

    [SerializeField] Transform player;
    [SerializeField] GameObject bala;
    public float fuerza = 15f;
    public Transform punto;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(InSight())
        {
            /*
            GameObject nuevaBala;
            nuevaBala = Instantiate(bala, punto.position, punto.rotation);
            nuevaBala.GetComponent<Rigidbody>().AddForce(punto.forward * fuerza);
            Destroy(nuevaBala, 2f);
            */
        }
    }

    bool InSight(){
        Vector3 directionToTarget = transform.position - player.position;
        float angle = Vector3.Angle(transform.forward, directionToTarget);

        //Si esta en rango
        if(Mathf.Abs(angle) > 90 && Mathf.Abs(angle) <270){
            Debug.DrawLine(transform.position, player.position, Color.green);
            return true;
        }
        Debug.DrawLine(transform.position, player.position, Color.yellow);
        return false;
    }
}
