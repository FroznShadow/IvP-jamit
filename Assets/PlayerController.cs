using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 2;
    public bool objectivecomplete = false;
    public bool wincondition = false;
	// Use this for initialization
	void Start () 
    {
        

	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetKey(KeyCode.W))
            transform.localPosition+=(transform.forward * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.localPosition -= (transform.forward * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.localPosition += (transform.right * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            transform.localPosition -= (transform.right * speed * Time.deltaTime);
        
	}
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("joku osui");

        if (col.gameObject.tag == "Objective")
        {
            Debug.Log("Osuttiin objectiveen");
            objectivePickup();
            objectivecomplete = true;
        }
        else if (col.gameObject.tag == "Exit" && objectivecomplete == true)
        {
            Debug.Log("Osuttiin Exit Blockiin");
            exitScene(col);

        }
        else if (col.gameObject.tag == "win" && wincondition == true)
        {
            Debug.Log("Yaywinrar");
            winthegame(col);
        }
    }
    
    public GameObject Objective;
    public GameObject Exit;
    public GameObject Exit2;
    public GameObject Win;
    void objectivePickup()
    {
       Objective.gameObject.SendMessage ("Gotit",SendMessageOptions.DontRequireReceiver); 
    }
    void exitScene(Collision col)
    {
        if(col.gameObject.name == "Exitblock")
        Exit.gameObject.SendMessage("exit", SendMessageOptions.DontRequireReceiver);
        else if (col.gameObject.name == "Exitblock2")
        Exit2.gameObject.SendMessage("exit", SendMessageOptions.DontRequireReceiver);
    }
    void winthegame(Collision col)
    {
        Win.gameObject.SendMessage("win",SendMessageOptions.DontRequireReceiver);
    }
    
}

