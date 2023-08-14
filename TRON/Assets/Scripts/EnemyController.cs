using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] Transform player;
   // [SerializeField] GameObject Enemy;
    [SerializeField] float speed = 10f;
    [SerializeField] float rotationalDamp = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Turn();
        Move();
    }

    void Turn(){
        Vector3 pos = player.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);

    }

    void Move(){
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
