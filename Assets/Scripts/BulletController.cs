using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float moveSpeed, lifeTime;
    public Rigidbody rb;
    
    void Update()
    {
        rb.velocity = transform.forward * moveSpeed;
        lifeTime -= Time.deltaTime;
        if(lifeTime <=0)
        {
            Destroy(gameObject);
        }    
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
