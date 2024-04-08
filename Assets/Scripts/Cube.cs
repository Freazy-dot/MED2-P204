using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour


{
    InstantiateCubes instantiateCubes;

    private Rigidbody _rb;
    private Vector3 spawnPosition;


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
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();   
        spawnPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("whatIsVRGround"))
        {
            transform.position = spawnPosition;
            
        }
    }
}
