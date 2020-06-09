using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float dmg, deathTime, speed;
    public string ownerTag;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Die());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.transform.tag == "Enemy" || other.transform.tag == "Player") && other.transform.tag != ownerTag)
        {
            other.gameObject.GetComponent<CharacterTemplate>().TakeDamage(dmg);
            GameObject.Destroy(gameObject);
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(deathTime);
        GameObject.Destroy(gameObject);
    }
}
