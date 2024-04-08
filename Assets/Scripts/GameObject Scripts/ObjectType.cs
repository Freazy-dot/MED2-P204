using UnityEngine;

public class ObjectType : MonoBehaviour
{
    public int objectType; // 0 = Equip Battery, 1 = Place Battery (slot), 2 = Miscellaneous

    private void Awake()
    {
        switch (gameObject.tag)
        {
            case "Battery":
                objectType = 0;
                break;
            case "BatterySlot":
                objectType = 1;
                break;
            case "MiscellaneousInteractable":
                objectType = 2;
                break;
        }
    }
}