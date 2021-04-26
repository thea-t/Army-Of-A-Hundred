using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thea_IntroScene : MonoBehaviour
{
    [SerializeField] Animator frontEnemy;
    [SerializeField] Animator leftEnemy;
    [SerializeField] Animator rightEnemy;
    [SerializeField] GameObject startingCamera;
    [SerializeField] GameObject UI;

    private void Start()
    {
        IntroAnimations();
        StartCoroutine(DisableCamera());
        Destroy(gameObject, 10);
    }

    void IntroAnimations()
    {
        frontEnemy.SetTrigger("idle");
        leftEnemy.SetTrigger("idle");
        rightEnemy.SetTrigger("idle");
        frontEnemy.SetTrigger("angry");
        leftEnemy.SetTrigger("withdrawing_sword");
        rightEnemy.SetTrigger("withdrawing_sword");
    }

    IEnumerator DisableCamera()
    {
        yield return new WaitForSeconds(3.1f);
        startingCamera.SetActive(false);
        UI.SetActive(true);
    }

}
