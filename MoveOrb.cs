using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOrb : MonoBehaviour
{
    public KeyCode moveL;
    public KeyCode moveR;

    public float horizVel = 0;
    public int laneNumber = 2;
    public string controlLocked = "n";
    
    void Start()
    {
        
    }
    
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(horizVel, 0, 4);
        
        if (Input.GetKeyDown(moveL) && laneNumber > 1 && controlLocked == "n")
        {
            horizVel = -2;
            StartCoroutine(stopSlide());
            laneNumber -= 1;
            controlLocked = "y";
        }
        if (Input.GetKeyDown(moveR) && laneNumber < 3 && controlLocked == "n")
        {
            horizVel = 2;
            StartCoroutine(stopSlide());
            laneNumber += 1;
            controlLocked = "y";
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Lethal")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.name == "Capsule")
        {
            Destroy(other.gameObject);
        }
    }

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(0.5f);
        horizVel = 0;
        controlLocked = "n";
    }
}
