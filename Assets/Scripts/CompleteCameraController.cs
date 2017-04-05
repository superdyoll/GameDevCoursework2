using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]
public class CompleteCameraController : MonoBehaviour
{

    public GameObject player;
	public float rotateSpeed = 5;
    private Vector3 offset;
    public float tiltOffset = 0;

	// Use this for initialization
	void Start () 
	{
		//Calculate and store the offset value by getting the distance between the player's position and camera's position.
		offset = transform.position - player.transform.position;
	}

	// LateUpdate is called after Update each frame
	void LateUpdate () 
	{
		//float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
		//player.transform.Rotate(0, horizontal, 0);

		float desiredAngle = player.transform.eulerAngles.y;
		//Quaternion rotation = Quaternion.Euler (0, desiredAngle, 0);
	    transform.position = player.transform.position + offset;

		transform.LookAt (player.transform);
        transform.Rotate(new Vector3(1, 0, 0), tiltOffset);
	}
}

