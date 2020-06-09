using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Inventory/MeleeWeapon")]

public class MeleeData : ItemData
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
        u.weapon.AddComponent<WeaponDamage>();
        u.weapon.GetComponent<WeaponDamage>().damage = dmg;
        u.weapon.GetComponent<WeaponDamage>().ownerTag = user.tag;
        //Physics.IgnoreCollision(weapon.GetComponent<Collider>(), u.hand.GetComponent<Collider>());
    }

    public float dmg;
    public float atackSpeed;
}
