using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal_Cont : MonoBehaviour
{
    // Start is called before the first frame update
    int index;
    public bool isAutoIncrement=true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isAutoIncrement)
        {
            if (collision.gameObject.name == "Tank")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else {
            if (collision.gameObject.name == "Tank")
            {
                SceneManager.LoadScene(index);
            }
        }
        
    }
}
