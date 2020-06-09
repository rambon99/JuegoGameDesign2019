using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamageRange : MonoBehaviour
{
    public string ownerTag;
    public float damage, speed, deathTime;
    public GameObject ammo;

    public void Shoot()
    {
        GameObject bullet = Instantiate(ammo, transform.position, transform.rotation);
        bullet.AddComponent<Bullet>();
        bullet.GetComponent<Bullet>().speed = speed;
        bullet.GetComponent<Bullet>().deathTime =deathTime;
        bullet.GetComponent<Bullet>().ownerTag = ownerTag;
        bullet.GetComponent<Bullet>().dmg = damage;
    }

}
