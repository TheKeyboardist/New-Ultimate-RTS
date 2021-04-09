using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBullet : MonoBehaviour
{
    public float bulletSpeed = 30;
    public float lifeTime = 3;
    public float slowSpeed = 0.5f;
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

        //other.tag != "Player" &&
        if ( other.tag != "Enemy")
        {
            print("hit " + other.name + "!");
            Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);
            var targetScript = other.GetComponentInParent<S_MainBasic>();

            if (targetScript != null)
            {
                //Debug.Log("trying to deal damage");
                other.GetComponentInParent<S_MainBasic>().TakeDamage(50);
            }
            Destroy(gameObject.transform.parent);
        }

    }
}
