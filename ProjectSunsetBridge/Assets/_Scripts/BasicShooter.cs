using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShooter : MonoBehaviour
{
    [SerializeField] private float maxDistance = 100f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private Transform origin; 


    public void Shoot()
    {
        RaycastHit hitInfo; 
        if(Physics.Raycast(origin.position, origin.forward, out hitInfo, maxDistance))
        {
            Debug.Log(hitInfo.transform.name);
            IBasicEnemy enemy = hitInfo.transform.GetComponent<IBasicEnemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }

}
