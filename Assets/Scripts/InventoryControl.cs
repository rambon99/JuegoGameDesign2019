using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryControl : MonoBehaviour
{
    public List<ItemData> objetos = new List<ItemData>();
    public int capacity;
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        RedrawInventory();
    }
    public void AddItem(ItemData item)
    {
        if (objetos.Count<capacity)
        {
            objetos.Add(item);
            RedrawInventory();
        }
        else
        {
            Debug.Log("No puedes meter cosas");
        }
    }
    public void RemoveItem(ItemData item)
    {
        for (int i = 0; i < objetos.Count; i++)
        {
            if (objetos[i]==item)
            {
                objetos.RemoveAt(i);
                RedrawInventory();
                return;
            }
        }
        return;
    }
    public void RemoveItem(int index)
    {
        if (index<objetos.Count)
        {
            objetos.RemoveAt(index);
            RedrawInventory();
        }
    }
    public void RedrawInventory()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < objetos.Count; i++)
        {
            GameObject auxGO = Instantiate(new GameObject(), transform);           
            auxGO.AddComponent<Image>();
            auxGO.AddComponent<Button>();
            auxGO.GetComponent<Image>().sprite = objetos[i].sprite;
            auxGO.GetComponent<Button>().onClick.AddListener(() => objetos[i].Use(player));
            auxGO.GetComponent<Button>().onClick.AddListener(delegate { RemoveItem(i); });
        }

    }
}
