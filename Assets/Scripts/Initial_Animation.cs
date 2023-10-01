using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initial_Animation : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.alice.GetComponent<PlayerMovement>().setMovementsOff();
        GetComponent<Animator>().SetTrigger("Fall_trigger");
    }

    public void AnimationEnded()
    {
        GameManager.Instance.alice.GetComponent<PlayerMovement>().setMovementOn();
    }
}
