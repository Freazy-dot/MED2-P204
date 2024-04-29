using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;


public class Wire2 : MonoBehaviour
{
    //[SerializeField] GameObject boxFront, boxBottom, boxRight, boxLeft, boxTop;
    [SerializeField] GameObject wireRed, wireGreen, wireBlue, wireYellow, wirePurple, wirePink;
    Animator animator;

   // [SerializeField] Material material;

        void Start()
    {
            animator = GetComponent<Animator>();
       
             //   boxFront.GetComponent<Rigidbody>().useGravity = false;
            //    boxBottom.GetComponent<Rigidbody>().useGravity = false;
    }

  
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

            OpenBox();

           
            



         //  boxFront.GetComponent<Rigidbody>().useGravity = true;
         //  boxBottom.GetComponent<Rigidbody>().useGravity = true;

           // boxFront.SetActive (false);
           // boxBottom.SetActive (false);

            

          //  boxRight.GetComponent<Renderer>().material = material;
          //  boxLeft.GetComponent<Renderer>().material = material;
           // boxTop.GetComponent<Renderer>().material = material;
        }
    }


    public void OpenBox()
    {
        StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine()
    {
        animator.SetTrigger("Open");

        yield return 6000;

        ActivateWires();

    }

    public static async void Delay(int tmp)
    {
        await Task.Delay(tmp);


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
