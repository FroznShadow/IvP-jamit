using UnityEngine;
using System.Collections;

public class Vision : MonoBehaviour {

    public Transform sightStart;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {

    }

    public GameObject Dad_AI;

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("joku osui");

        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Pelaaja havaittu");
            Dad_AI.gameObject.SendMessage("spotter", SendMessageOptions.DontRequireReceiver);
        }
    }
    void OnTriggerStay(Collider col)
    {
        Debug.Log("joku osui");

        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Pelaaja havaittu");
            Dad_AI.gameObject.SendMessage("spotter", SendMessageOptions.DontRequireReceiver);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
            Dad_AI.gameObject.SendMessage("pakeni", SendMessageOptions.DontRequireReceiver);
    }
}
