using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider(); 
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider enemyBoxCollider = gameObject.AddComponent<BoxCollider>();
        enemyBoxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        GameObject explosionFX = Instantiate(deathFX, transform.position, Quaternion.identity);
        explosionFX.transform.parent = parent;
        Destroy(gameObject);
    }
}
