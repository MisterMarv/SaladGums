using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Variables (Alert: This script is about effects of the projectiles)

    public GameObject damageEffect;
    public GameObject damageEffectTwo;
    public GameObject damageEffectThree;

    int differentEquip = LootBox.numberReference;

    private int damageAmount = 0;

    private void Start()
    {
        if (differentEquip == 1)
        {
            print("oh no 1");
            damageEffect.SetActive(true);
            damageAmount = 40;
        }
        else if (differentEquip == 2)
        {
            print("oh no 2");
            damageEffectTwo.SetActive(true);
            damageAmount = 60;
        }
        else if (differentEquip == 3)
        {
            print("oh no 3");
            damageEffectThree.SetActive(true);
            damageAmount = 20;
        }
    }
    //Main Function
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (differentEquip == 1)
            {
                Instantiate(damageEffect, transform.position, damageEffect.transform.rotation);
                other.GetComponent<Enemy>().TakeDamage(damageAmount);
                Destroy(gameObject);
            }
            else if (differentEquip == 2)
            {
                Instantiate(damageEffectTwo, transform.position, damageEffectTwo.transform.rotation);
                other.GetComponent<Enemy>().TakeDamage(damageAmount);
                Destroy(gameObject);
            }
            else if (differentEquip == 3)
            {
                Instantiate(damageEffectThree, transform.position, damageEffectThree.transform.rotation);
                other.GetComponent<Enemy>().TakeDamage(damageAmount);
                Destroy(gameObject);
            }
        }
        if (other.tag == "Boss")
        {
            if (differentEquip == 1)
            {
                Instantiate(damageEffect, transform.position, damageEffect.transform.rotation);
                other.GetComponent<BossLife>().TakeDamage(damageAmount);
                Destroy(gameObject);
            }
            else if (differentEquip == 2)
            {
                Instantiate(damageEffectTwo, transform.position, damageEffectTwo.transform.rotation);
                other.GetComponent<BossLife>().TakeDamage(damageAmount);
                Destroy(gameObject);
            }
            else if (differentEquip == 3)
            {
                Instantiate(damageEffectThree, transform.position, damageEffectThree.transform.rotation);
                other.GetComponent<BossLife>().TakeDamage(damageAmount);
                Destroy(gameObject);
            }
        }
    }
}
