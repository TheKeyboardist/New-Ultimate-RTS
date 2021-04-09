using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_ItemInfo : MonoBehaviour
{
    [SerializeField] int Cost = 350;
    [SerializeField] int EnergyCost = 8;
    public bool HasPower = false;

    public float Health = 100;
    public GameObject HealthUI;
    public Slider HealthSlider;
    public bool TurretAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        HealthSlider.value = Health;

        if (!EnoughForItem() || !FuelBehaviour.UsePower(EnergyCost))
        {
            Destroy(gameObject);
        }
        if(!EnoughForItem())
        {
            Debug.Log("Not enough resources to build this item.");
        }
        else if(!FuelBehaviour.UsePower(EnergyCost))
        {
            Debug.Log("Not enough power to operate this item.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        HealthSlider.value = Health;
        if(Health <= 0)
        {
          // Destroy(transform.parent.parent.parent.parent.gameObject);

            foreach (Transform child in transform)
            {
                Destroy(gameObject);
            }
        }
    }

    public void BuyItem()
    {
        ResourceCounter.resourceNumber -= Cost;
        FuelBehaviour.Electricity -= EnergyCost;
        HasPower = true;
    }

    bool EnoughForItem()
    {
        return ResourceCounter.resourceNumber >= Cost;
    }

    public void TakeDamage(float amount)
    {
        Health -= amount;
    }
}
