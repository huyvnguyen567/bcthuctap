using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float moveSpeed, lifeTime;

    public Rigidbody rb;

    public GameObject impactEffect;

    public int damage = 1;

    public bool damageEnemy, damagePlayer;

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
        if (other.gameObject.tag == "Enermy" && damageEnemy)
        {
            //Destroy(other.gameObject);
            other.gameObject.GetComponent<EnermyHealthController>().DamageEnermy(damage);
        }
        if (other.gameObject.tag == "HeadShot" && damageEnemy)
        {
            other.transform.parent.GetComponent<EnermyHealthController>().DamageEnermy(damage * 2);
            Debug.Log("Headshot hit");
        }
        if (other.gameObject.tag == "Player" && damagePlayer)
        {
            Debug.Log("Hit Player at " + transform.position);
            PlayerHealthController.instance.DamagePlayer(damage);
        }
        Destroy(gameObject);
        Instantiate(impactEffect, transform.position + (transform.forward * (-moveSpeed * Time.deltaTime)), transform.rotation);
    }
}
