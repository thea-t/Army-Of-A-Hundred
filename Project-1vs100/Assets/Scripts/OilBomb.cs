using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilBomb : MonoBehaviour
{
    [SerializeField]
    float m_impactThreshold;
    
    [SerializeField]
    GameObject m_oilSplatter;

    private void OnCollisionEnter(Collision collision)
    {
        float collisionForce = collision.relativeVelocity.magnitude;
        if (collisionForce > m_impactThreshold)
        {
            Debug.Log("I'm gonna blow up" + collisionForce);
            Instantiate(m_oilSplatter, transform.position,transform.rotation);
            Destroy(gameObject,3f);
        }
    }
}
