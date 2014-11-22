using UnityEngine;
using System.Collections;

public class Player_movement : MonoBehaviour {

    public float speed = 2F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += transform.up * speed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition -= transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition -= transform.right * speed * Time.deltaTime;
        }
	}
}
