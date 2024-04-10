using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour

{
    InstantiateCubes instantiateCubes; //Reference to the InstantiateCubes script

    private Rigidbody _rb; //Reference to the rigidbody component
    private Vector3 spawnPosition; //The spawn position of the cube, Called in start

    //Rigidbody property, makes sure that the rigidbody is not null
    public Rigidbody Rb
    {         
        get
        {
            if (!_rb)
            {
                _rb = GetComponent<Rigidbody>();
            }

            return _rb;
        }
    }
  
    void Start()
    {
        _rb = GetComponent<Rigidbody>();   
        spawnPosition = transform.position;
    }

    //On Collision with the ground, the cube will be reset to its spawn position
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("whatIsVRGround"))
        {
            transform.position = spawnPosition;
            
        }
    }
    public void MoveCube()
    {
        Debug.Log("Moving Cube");

    }
}
