using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour {

    //public GameObject Player;
    public float RotationSpeed = 5;
    //public float triggerDistance = 5;
    public float closedAngle, openAngle;

    private Transform doorTransform;

	// Use this for initialization
	void Start () {
        //GameObject door = GameObject.
        doorTransform = GetComponent<Transform>().Find("Door");
        Debug.Log(doorTransform);
       //playerTransform = Player.GetComponent<Transform>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            open = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Player")
        {
            open = false;
        }
    }

    bool open = false;

    // Update is called once per frame
    void Update () {
        if(open) //Vector3.Distance(myTransform.position, playerTransform.position) < triggerDistance)
        {
            if (doorTransform.rotation.eulerAngles.y < openAngle)
            {
                doorTransform.Rotate(0, RotationSpeed, 0);
            }
            /*if (myTransform.rotation.eulerAngles.y > openAngle)
            {
                myTransform.rotation = Quaternion.Euler(0, openAngle, 0);
            }*/
        }
        else
        {
            if (doorTransform.rotation.eulerAngles.y > closedAngle)
            {
                doorTransform.Rotate(0, -RotationSpeed, 0);
            }
            /*if (myTransform.rotation.eulerAngles.y < closedAngle)
            {
                myTransform.rotation = Quaternion.Euler(0, closedAngle, 0);
            }*/
        }
	}
}
