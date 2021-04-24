using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    Transform positionBlue;
    Transform positionGreen;
    Transform positionTank;
    float newX = 0;
    float newY = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject xBlue = GameObject.Find("PlayeBlue");
        GameObject xGreen = GameObject.Find("PlayeGreen");
        GameObject xTank = GameObject.Find("Tank");
        //xTank = xTank.transform.GetChild(1).gameObject;


        if (xBlue != null && xGreen != null)
        {
            newX = xBlue.GetComponent<Transform>().transform.position.x + (xGreen.GetComponent<Transform>().position.x - xBlue.GetComponent<Transform>().position.x) / 2;
            newY = xBlue.GetComponent<Transform>().transform.position.y + (xGreen.GetComponent<Transform>().position.y - xBlue.GetComponent<Transform>().position.y) / 2;
        }
        else if (xBlue == null && xGreen != null)
        {
            newX = xTank.GetComponent<Transform>().transform.position.x + (xGreen.GetComponent<Transform>().position.x - xTank.GetComponent<Transform>().position.x) / 2;
            newY = xTank.GetComponent<Transform>().transform.position.y + (xGreen.GetComponent<Transform>().position.y - xTank.GetComponent<Transform>().position.y) / 2;
        }
        else if (xBlue != null && xGreen == null)
        {
            newX = xTank.GetComponent<Transform>().transform.position.x + (xBlue.GetComponent<Transform>().position.x - xTank.GetComponent<Transform>().position.x) / 2;
            newY = xTank.GetComponent<Transform>().transform.position.y + (xBlue.GetComponent<Transform>().position.y - xTank.GetComponent<Transform>().position.y) / 2;
        }
        else {
            if (xTank != null) {
                newX = xTank.GetComponent<Transform>().transform.position.x;
                newY = xTank.GetComponent<Transform>().transform.position.y;
            }

        }

        this.transform.position = new Vector3(newX, newY, 0);
        //transform.position.x = josh.position.x + (mark.position.x - josh.position.x) / 2;
    }
}
