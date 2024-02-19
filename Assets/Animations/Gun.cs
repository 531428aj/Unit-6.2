using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera tpsCam;
   

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(tpsCam.transform.position, tpsCam.transform.forward, out hit, range))
            {
            Debug.Log(hit.transform.name);

            FindFirstObjectByType<SoundManager>().Play("gunshot");

            Enemyhealth target = hit.transform.GetComponent<Enemyhealth>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
