using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject.CompareTag("Enemy"))
        {
            other.transform.gameObject.GetComponentInParent<Oliver_EnemyController>().Death();
        }
    }
}
