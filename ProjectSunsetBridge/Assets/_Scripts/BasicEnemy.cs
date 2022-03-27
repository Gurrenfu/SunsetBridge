using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour, IBasicEnemy
{
    [SerializeField] private float health = 30f;
    public AudioSource audioSource; 
    public void TakeDamage(float dmg)
    {
        Debug.Log("I GOT HIT");
        audioSource.Play();
        health -= dmg;
        if(health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
