using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.Controls.AxisControl;

public class WirePuzzle : MonoBehaviour
{
    public Wire2 lamp;
    public GameObject box;
    private float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            box.transform.position += Vector3.forward * speed * Time.deltaTime;
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        Debug.Log("collision");
        lamp.ChangeMaterial();
    }



}
