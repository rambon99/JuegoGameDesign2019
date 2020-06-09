using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Inventory/RangedWeapon")]

public class RangeData : ItemData
{
    public override void Use(GameObject user)
    {
        CharacterTemplate u = user.GetComponent<CharacterTemplate>();
        if (u.equippedWeapon != null && u.tag == "Player")
        {
            GameObject.Destroy(u.weapon);
            InventoryControl inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryControl>();
            inv.AddItem(u.equippedWeapon);
        }
        u.equippedWeapon = this;
        u.weapon = Instantiate(prefab, u.hand.transform.position, u.hand.transform.rotation);
        u.weapon.transform.SetParent(u.hand.transform);
        u.weapon.AddComponent<WeaponDamageRange>();
        u.weapon.GetComponent<WeaponDamageRange>().damage = dmg;
        u.weapon.GetComponent<WeaponDamageRange>().ownerTag = user.tag;
        u.weapon.GetComponent<WeaponDamageRange>().ammo = ammo;
        u.weapon.GetComponent<WeaponDamageRange>().speed = bulletSpeed;
        u.weapon.GetComponent<WeaponDamageRange>().deathTime = range;
    }

    public void Shoot()
    {

    }

    public GameObject ammo;
    public float dmg;
    public float atackSpeed;
    public float bulletSpeed;
    public int shoots;
    public float range;
}
