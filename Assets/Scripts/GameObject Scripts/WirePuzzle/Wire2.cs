using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;


public class Wire2 : MonoBehaviour
{
    [SerializeField] GameObject wireRed, wireGreen, wireBlue, wireYellow, wirePurple, wirePink;
    [SerializeField] Animator animator,rampAnimator;

        void Start()
    {
            animator = GetComponent<Animator>();
    }

  
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            rampAnimator.SetTrigger("Ramp");
            OpenBox();
        }




    }


    public void OpenBox()
    {
        Debug.Log("button pushed");
        StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine()
    {
        Debug.Log("coroutine started");

        animator.SetTrigger("Open");

        yield return new WaitForSeconds(1f);

        Debug.Log("yield return");
        ActivateWires();
    }

    public void ActivateWires()
    {
         wireRed.SetActive(true);
         wireGreen.SetActive(true);
         wireBlue.SetActive(true);
         wireYellow.SetActive(true);
         wirePurple.SetActive(true);
         wirePink.SetActive(true);
    }


}
