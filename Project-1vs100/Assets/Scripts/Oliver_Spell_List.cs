using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oliver_Spell_List : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject fireBallEffect;
    public float fireBallRadius = 5f;
    public float fireBallForce = 700f;
    public GameObject gravitySinkHoleEffect;
    public float gravitySinkHoleRadius = 5f;
    public float gravitySinkHoleForce = 700f;
    private void Fireball(Vector3 position, Quaternion rotation)
    {
        Instantiate(fireBallEffect, position, rotation);

        Collider[] colliders = Physics.OverlapSphere(position, fireBallRadius);
        foreach (Collider nearbyObject in colliders)
        {
            nearbyObject.GetComponent<Oliver_RagdollToggle>().isWalking = false;
            nearbyObject.GetComponent<Oliver_RagdollToggle>().ToggleRagdoll(true);
        }

        Collider[] collidersToExplode = Physics.OverlapSphere(position, fireBallRadius);
        foreach (Collider nearbyObject in collidersToExplode)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(fireBallForce, position, fireBallRadius);
            }
        }
    }
}
