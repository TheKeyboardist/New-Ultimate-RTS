using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float Speed;
    public CharacterController controller;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 30;

    public float lifeTime = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * Speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }

    }

    private void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab);

        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), 
            bulletSpawn.parent.GetComponent<Collider>());

        bullet.transform.position = bulletSpawn.position;

        Vector3 rotation = bullet.transform.rotation.eulerAngles;

        bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);

        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);

        Debug.Log("fire");
    }
}
