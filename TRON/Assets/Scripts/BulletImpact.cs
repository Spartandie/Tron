using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpact : MonoBehaviour
{
    [SerializeField] GameObject enemyExplosion;
    [SerializeField] GameObject enemyCollider;
    [SerializeField] AudioSource enemySFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bala")){
            enemyExplosion.SetActive(true);
            enemySFX.Play();
            StartCoroutine(EnemyDestruction()); 
            
        }
    }

    private IEnumerator EnemyDestruction(){

            enemyCollider.GetComponent<Collider>().enabled=false;
            Renderer rendererPlayer = GetComponent<Renderer>();
            rendererPlayer.enabled = false;
            Collider playerCollider = GetComponent<Collider>();
            playerCollider.enabled = false;

            Rigidbody playerRB = GetComponent<Rigidbody>();
            playerRB.isKinematic = true;
            
            yield return new WaitForSeconds(4);
            Destroy(gameObject);
    }
}
