using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupTrigger : MonoBehaviour {

    public GameObject powerup;

    private void OnTriggerEnter(Collider other)
    {
        var carRB = other.transform.parent.parent.GetComponent<Rigidbody>();
        var vehicle = other.transform.parent.parent;
        vehicle.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * 500, ForceMode.Acceleration);

        powerup.GetComponent<Renderer>().enabled = false;
        powerup.GetComponentInChildren<ParticleSystem>().Stop();
        StartCoroutine(HideShow());
    }

    IEnumerator HideShow()
    {
        yield return (new WaitForSeconds(3));
        powerup.GetComponent<Renderer>().enabled = true;
        powerup.GetComponentInChildren<ParticleSystem>().Play();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
