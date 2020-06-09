using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemData item;
    private InventoryControl inv;
    public bool arrow;

    private void Start()
    {
        inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryControl>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (arrow)
            {
                other.GetComponent<CharacterTemplate>().arrows++;
                Object.Destroy(gameObject);
            }
            else
            {
                if (inv.objetos.Count < inv.capacity)
                {
                    inv.AddItem(item);
                    Object.Destroy(gameObject);
                }
            }
        }
    }
}
