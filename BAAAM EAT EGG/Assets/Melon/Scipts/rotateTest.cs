using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateTest : MonoBehaviour
{
    public GameObject[] slot;
    public float speed;
    public GameObject obj;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        startSet(count);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void startSet(int count)
    {
        for(int i = 0; i<= 360; i+= 360 /count)
        {
            var rad = Mathf.Deg2Rad * i;
            float x = Mathf.Sin(rad);
            float y = Mathf.Cos(rad);
            Instantiate(obj, new Vector3(x, 4, y), Quaternion.identity);
        }
    }

}
