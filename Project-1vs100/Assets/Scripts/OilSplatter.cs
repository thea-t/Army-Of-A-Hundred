using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilSplatter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.LogError("Collision!!");
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("An enemy walked in");
            //Oliver_EnemyController enemyController;
            //other.gameObject.TryGetComponent(out enemyController);
            other.gameObject.GetComponent<Animator>().speed=0f;

            float newSpeed = other.gameObject.GetComponent<Animator>().speed;

        }
    }

}
