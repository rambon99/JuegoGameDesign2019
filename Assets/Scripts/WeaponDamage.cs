using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public string ownerTag;
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.transform.tag == "Enemy" || other.transform.tag == "Player") && other.transform.tag != ownerTag)
        {
            other.gameObject.GetComponent<CharacterTemplate>().TakeDamage(damage);
        }
    }
}
