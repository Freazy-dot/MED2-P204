using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryStationTest : MonoBehaviour
{
    public BatteryStation batteryStation;



    private void Awake()
    {
        //batteryStation = GetComponent<BatteryStation>();
    }
    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Space))
            {
            InsertBattery();
            }
    }

    private void InsertBattery()
    {
        if (batteryStation != null)
        {
            batteryStation.InsertBattery();
        }
    }
}
