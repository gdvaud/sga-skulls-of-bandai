using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateElements : MonoBehaviour {

    [SerializeField] public GameObject[] realEstate;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            foreach (GameObject element in realEstate)
            {
                MeshRenderer tempMesh = element.GetComponent<MeshRenderer>();
                tempMesh.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            foreach (GameObject element in realEstate)
            {
                MeshRenderer tempMesh = element.GetComponent<MeshRenderer>();
                tempMesh.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            }
        }
    }
}
