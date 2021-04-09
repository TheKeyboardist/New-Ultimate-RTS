using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ReciveDamageCol : MonoBehaviour
{
    [SerializeField] Turret turretScript;
    [SerializeField] S_ItemInfo ItemInfoScript;
    GameObject enemy;

    public bool ItemAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GetDamage()
    {
        while (ItemAlive == true)
        {
            yield return new WaitForSeconds(2);
            ItemInfoScript.Health -= 10;

            if (ItemInfoScript.Health <= 0)
            {
                enemy.GetComponent<Enemy>().StopAttack();
                Destroy(ItemInfoScript.gameObject);
                Debug.Log("Item died");
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemy = other.gameObject;
            other.GetComponent<Enemy>().DoAttack();
            Debug.Log("attck turret");
            StartCoroutine(GetDamage());
        }
    }
}
