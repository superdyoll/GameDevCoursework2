using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autotranslucencer : MonoBehaviour {

    //public GameObject Player;
    public Material OpaqueMaterial;
    public Material TranslucentMaterial;

    private Transform pTransform;
    private Transform thisTransform;
    private Renderer rendererObj;

    void Start()
    {
        GameObject Player = GameObject.Find("Player");
        pTransform = Player.GetComponent<Transform>();
        thisTransform = GetComponent<Transform>();
        rendererObj = GetComponent<Renderer>();
    }
    
	void Update () {
		if(pTransform.position.z > thisTransform.position.z)
        {
            rendererObj.material = TranslucentMaterial;
        }
        else
        {
            rendererObj.material = OpaqueMaterial;
        }
	}
}
