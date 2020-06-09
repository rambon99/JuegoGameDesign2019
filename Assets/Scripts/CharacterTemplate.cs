using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTemplate : MonoBehaviour
{
    public float lifeMax, life, lifeExtra, invFrames, speed, speedExtra, magicCooldown, counterMagic;
    [SerializeField] ItemData initWeapon;
    public int def = 0, defExtra, arrows = 2;
    private bool magicUse;
    private Animator charAnimator;

    public GameObject hand, weapon;
    public ItemData[] equippedAccesories;
    public ItemData equippedWeapon;

    public virtual void Start()
    {
        counterMagic = magicCooldown;
        charAnimator = GetComponent<Animator>();
        initWeapon.Use(gameObject);
        equippedAccesories = new ItemData[3];
    }

    public void HorizontalMovement (float hor)
    {
        transform.Translate(Vector3.right * hor * speed * Time.deltaTime, Space.World);
    }

    public void VerticalMovement(float ver)
    {
        transform.Translate(Vector3.forward * ver * speed * Time.deltaTime, Space.World);
    }

    public void Attack()
    {
        if (equippedWeapon.GetType() == typeof(MeleeData))
        {
            charAnimator.SetTrigger("Attack");
        }
        else if (equippedWeapon.GetType() == typeof(RangeData))
        {
            if (arrows > 0)
            {
                arrows -= 1;
                weapon.GetComponent<WeaponDamageRange>().Shoot();
            }
            else  //Indicate no arrows left
            {

            }
        }
        else //magic Weapons
        {
            if (!magicUse) //cooldown over/ready to use
            {
                weapon.GetComponent<WeaponDamageRange>().Shoot();
                StartCoroutine(MagicCooldownTimer());
            }
            else //magic in cooldown/indicate magic isn't ready
            {

            }
        }
    }

    IEnumerator MagicCooldownTimer()
    {
        magicUse = true;
        counterMagic = 0;
        while (counterMagic <= magicCooldown)
        {
            yield return new WaitForSeconds(1);
            counterMagic++;
        }
        magicUse = false;
    }

    public void TakeDamage(float damage)
    {
        float reducedDamage = (damage - def) / 100;
        float totalDamage = damage - reducedDamage;
        life -= totalDamage;
        if (life <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("DED" + transform.tag);
        if (transform.tag == "Player")
        {

        }
        else
        {
            gameObject.GetComponent<Enemy>().SpawnLoot();
        }
        GameObject.Destroy(gameObject);
    }

    public float AccessoryDamage()
    {
        return 0;
    }

    public float AcessoryDefense()
    {
        return 0;
    }

    public bool AcessoryFull()
    {
        return true;
    }

    public void AcessoryReorder()
    {

    }

    public void AcessoryAdd()
    {

    }

    public void AcessoryRemove()
    {

    }
}



