using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : MonoBehaviour
{
    public float bulletSpeed = 30;
    public float lifeTime = 3;
    public ParticleSystem Explosion;

    private void Start()
    {
        Vector3 rotation = transform.rotation.eulerAngles;

        transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);

        GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }

    private void Update()
    {
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag == "Enemy")
        {
            print("hit " + other.name + "!");
            Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);
            other.GetComponent<Enemy>().TakeDamage(50);
            Destroy(gameObject);
        }

    }
}
