using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLaunch : MonoBehaviour
{
    private Transform targetTransform;

    private float rocketSpeed = 10f;
    private float rocketForce = 10f;
    private float aliveTimer = 5f;

    // Update is called once per frame
    void Update()
    {
        if (targetTransform != null)
        {
            transform.position += (targetTransform.position - transform.position).normalized * Time.deltaTime * rocketSpeed;
            transform.LookAt(targetTransform);
        }
        else if (targetTransform == null)
        {
            Destroy(gameObject);
        }
    }

    public void Fire(Transform enemyTransform)
    {
        targetTransform = enemyTransform;
        Destroy(gameObject,aliveTimer);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (targetTransform != null)
        {
            if (other.gameObject.CompareTag(targetTransform.tag))
            {
                Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
                enemyRb.AddForce((targetTransform.position - transform.position) * rocketForce, ForceMode.Impulse);
                Destroy(gameObject);
            }
        }
    }
}
