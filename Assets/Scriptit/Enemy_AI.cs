using UnityEngine;
using System.Collections;

public class Dad_AI : MonoBehaviour {

    private GameObject Enemy;
    private GameObject Player;
    public float Range = 0F;
    public float Speed = 2F;
    public Transform target;
    public Transform sightStart;
    public Transform sightEnd;
    public bool spotted = false;
    private bool getbacktothechoppa = false;

    //------Patrol--------//

    public float x_max = 0;
    public float x_min = 0;
    public float z_max = 0;
    public float z_min = 0;
    public Transform origin;
    public Quaternion oriang;
    Vector3 siirtyma = new Vector3(0F,0F,0F);
    int xdir = 0; //xdir 0 = left, xdir 1 = right, xdir 2 = stop
    int zdir = 2; //zdir 0 = backwards, zdir 1 = forwards, zdir 2 = stop

    //--------------------//

	void Start () {
        siirtyma = transform.position;
        oriang = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        Range = Vector3.Distance(transform.position, target.position);
        if (spotted != true)
        {
            if (transform.position.z < x_max && transform.position.z > x_min && xdir != 2) // x_max > z > x_min
            {
                transform.position += transform.up * Speed * Time.deltaTime;
            }
            if (transform.position.x < z_max && transform.position.x > z_min && zdir != 2) // 
            {
                transform.position += transform.right * Speed * Time.deltaTime;
            }
            if (transform.position.z >= x_max || transform.position.z <= x_min)
            {
                dirsx();
                transform.position += transform.up * Speed * Time.deltaTime;
            }
            if (transform.position.x >= x_max || transform.position.x <= x_min)
            {
                dirsy();
                transform.position += transform.right * Speed * Time.deltaTime;
            }
        }
        if (getbacktothechoppa == true)
        {
            Vector3 dir = siirtyma - transform.position;
            float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);

            transform.position += transform.forward * Speed * Time.deltaTime;
            transform.rotation = Quaternion.AngleAxis(90, Vector3.right);
            transform.Rotate(Vector3.forward, -angle);

            if ((transform.position.x > (siirtyma.x - 0.5F) && transform.position.x < (siirtyma.x + 0.5F)) && (transform.position.y > (siirtyma.y - 0.5F) && transform.position.y < (siirtyma.y + 0.5F)) && (transform.position.z > (siirtyma.z - 0.5F) && transform.position.z < (siirtyma.z + 0.5F)))
            {
                transform.rotation = oriang;
                getbacktothechoppa = false;
                spotted = false;
            }
        }

        if (Range < 1.5)
        {
            Debug.Log("YOU LOSE. FUCKING WANKER, GIT GUD!");
            Speed = 0;
        }
    }

    public void spotter()
    {
        spotted = true;
        Debug.Log("VITTUSAATANPERKELE!!!");
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);

        transform.position += transform.forward * Speed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(90, Vector3.right);
        transform.Rotate(Vector3.forward, -angle);
    }

    private void pakeni()
    {
        getbacktothechoppa = true;
    }

    private void dirsx()
    {
        if (xdir != 2)
        {
            transform.Rotate(Vector3.forward, 180);
        }
    }
    private void dirsy()
    {
        if (zdir != 2)
        {
            transform.Rotate(Vector3.right, 180);
        }
    }
}
