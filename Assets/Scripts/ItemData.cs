using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item")]
public abstract class ItemData :ScriptableObject
{
    public string nombre;
    public Sprite sprite;
    public GameObject prefab;
    public bool stackeable;
    public abstract void Use(GameObject user);

}
