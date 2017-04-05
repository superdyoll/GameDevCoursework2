using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBasedDoor : MonoBehaviour {
    
    public float RotationSpeed = 5;
    public float closedAngle = 90;
    public float openAngle = 180;

    private Transform doorTransform;

	void Start () {
        doorTransform = GetComponent<Transform>().Find("Door");
        Debug.Log(doorTransform);
	}

    bool open = false;
    
    public void OpenDoor()
    {
        open = true;
    }

    public void CloseDoor()
    {
        open = false;
    }

    void Update () {
        if(open)
        {
            if (doorTransform.rotation.eulerAngles.y < openAngle)
            {
                doorTransform.Rotate(0, RotationSpeed, 0);
            }
        }
        else
        {
            if (doorTransform.rotation.eulerAngles.y > closedAngle)
            {
                doorTransform.Rotate(0, -RotationSpeed, 0);
            }
        }
    }
    
}
