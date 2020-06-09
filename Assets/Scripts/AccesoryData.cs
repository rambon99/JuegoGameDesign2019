using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Inventory/Accesory")]

public class AccesoryData : ItemData
{
    public override void Use(GameObject user)
    {
        throw new System.NotImplementedException();
    }

    public float dmg;
    public float vida;
    public float armadura;
    public float speed;
    public float range;
    public float cdMax;
}
