using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
    public Transform prefab;

    int counter = 0;

    private void Start()
    {
        Invoke("CubeCreation", 3f);
        //InvokeRepeating("CubeCreation", 3f, 1f);
    }

    // Update is called once per frame
    /*
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefab, new Vector3(-15f + 3f * counter, 0, 0), Quaternion.identity);
            counter++;
        }
    }
    */

    public void CubeCreation()
    {

        Instantiate(prefab, new Vector3(-15f + 3f * counter, 0, 0), Quaternion.identity);
        counter++;

        if (counter > 5)
        {
            CancelInvoke();
        }
    }
}
