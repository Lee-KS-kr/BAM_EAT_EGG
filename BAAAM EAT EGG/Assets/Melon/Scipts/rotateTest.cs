using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mizu;


public class rotateTest : MonoBehaviour
{
    [SerializeField] ObjectPool pool;
    [SerializeField] List<GameObject> BamList;
    [SerializeField] float radian;
    public float speed;
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        startSet(count);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }

    void startSet(int count)
    {
        for(int i = 0; i< 360; i+= 360 /count)
        {
            var rad = Mathf.Deg2Rad * i;
            float x = Mathf.Sin(rad);
            float y = Mathf.Cos(rad);
            x *= radian; y *= radian;
            Debug.Log("x : " + x + " y : " + y);
            GameObject obj =  pool.GetObject(transform, new Vector3(x, 4, y));
            BamList.Add(obj);
        }
    }

}
