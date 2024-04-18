using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//https://youtu.be/pKSUhsyrj_4?si=TK0DmCgr3koXpmD3


public class Wire : MonoBehaviour
{
    [SerializeField] GameObject wirePartPrefab, parentObject;

    [SerializeField] [Range(1, 1000)] int length = 1;           //used to set the lenght of the wire

    [SerializeField] float partDistance = 0.21f;

    [SerializeField] bool reset, spawn, snapFirst, snapLast;    //checkboxes in inspector

   
    void Update()
    {
        if (reset)      //destroys wires
        {
            foreach(GameObject tmp in GameObject.FindGameObjectsWithTag("Wire"))
            {
                Destroy(tmp);
            }

            reset = false;
        }

        if (spawn)
        {
            Spawn();

            spawn = false;
        }




    }

    public void Spawn()
    {
        int count = (int)(length / partDistance);

        for(int x = 0; x < count; x++)
        {
            GameObject tmp;

            tmp = Instantiate(wirePartPrefab, new Vector3(transform.position.x, transform.position.y + partDistance * (x+1), transform.position.z), Quaternion.identity, parentObject.transform);
            tmp.transform.eulerAngles = new Vector3(180, 0, 0);
                
            tmp.name = parentObject.transform.childCount.ToString();

            //destroy first characterjoint, cause there is nothing we can connect to this object
            if(x==0)
            {
                Destroy(tmp.GetComponent<CharacterJoint>());
                if (snapFirst)
                {
                    tmp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                }
            }
            else
            {
                tmp.GetComponent<CharacterJoint>().connectedBody = parentObject.transform.Find((parentObject.transform.childCount - 1).ToString()).GetComponent<Rigidbody>();
            }
        }

        if(snapLast)
        {
            parentObject.transform.Find((parentObject.transform.childCount).ToString()).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }

    }








}
