using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Inventory/Weapon")]

public class WeaponsData : ItemData
{
    public override void Use(GameObject user)
    {
        throw new System.NotImplementedException();
    }

    public float dmg;
    public float atackSpeed;
    public float range;
    public float cd;
    public float area;
    public float shoots;

}
