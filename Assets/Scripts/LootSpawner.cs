using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootSpawner : MonoBehaviour
{
    [SerializeField] ItemData[] itemList;
    [SerializeField] GameObject activeText;

    private GameObject newItem;
    private int listLength;
    private bool inRange;
    // Start is called before the first frame update
    void Start()
    {
        listLength = itemList.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.F))
        {
            SpawnItem(transform.position, transform.rotation);
            activeText.SetActive(false);
            Object.Destroy(gameObject);
        }
    }

    public void SpawnItem(Vector3 pos, Quaternion rot)
    {
        int num = Random.Range(0, listLength);
        newItem = itemList[num].prefab;
        newItem.AddComponent<ItemPickup>();
        newItem.GetComponent<ItemPickup>().item = itemList[num];
        newItem.GetComponent<Collider>().isTrigger = true;
        Instantiate(newItem, pos, rot);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = true;
            activeText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
            activeText.SetActive(false);
        }
    }
}
