using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mizu;


public class Baaaaaam : MonoBehaviour
{
    [SerializeField] ObjectPool pool;
    [SerializeField] List<GameObject> BamList = new List<GameObject>();
    [SerializeField] List<Vector3> bodyPosition = new List<Vector3>();
    [SerializeField] List<GameObject> posObjList = new List<GameObject>();
    [SerializeField] GameObject head;
    [SerializeField] GameObject tail;
    [SerializeField] GameObject emptyObj;
    [SerializeField] float radian;
    [SerializeField] float speed;
    [SerializeField] int count;
    int index = 0;

    GameObject tailObj;

    // Start is called before the first frame update
    void Start()
    {
        startSet(count);
        tailSet();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);


        //수동으로 뱀 몸 생성하는 코드 추후 자동화시 삭제 요망
        if(Input.GetKeyDown(KeyCode.Z))
        {
            tailSet();
        }
    }

    void startSet(int count)
    {
        for(int i = 0; i< 360; i+= 360 /count)
        {
            var rad = Mathf.Deg2Rad * i;
            float x = Mathf.Sin(rad);
            float y = Mathf.Cos(rad);
            x *= radian; y *= radian;
            //GameObject obj =  pool.GetObject(transform, new Vector3(x, 4, y));
            //BamList.Add(obj);

            //첫번째 경우 머리 생성
            if(i == 0)
            {
                GameObject obj = Instantiate(head, new Vector3(x, 4, y), Quaternion.identity);
                obj.transform.SetParent(transform);
                continue;
            }
            //몸통 좌표 저장
            bodyPosition.Add(new Vector3(x, 4, y));
            GameObject eObj = Instantiate(emptyObj, new Vector3(x, 4, y), Quaternion.identity);
            eObj.transform.SetParent(transform);
            posObjList.Add(eObj);
        }
    }


    public void tailSet()
    {
        
        if(index == 0)
        {
            //tailObj =  Instantiate(tail, bodyPosition[index], Quaternion.identity);
            tailObj = Instantiate(tail, posObjList[index].transform.position, Quaternion.identity);
            tailObj.transform.SetParent(transform);
            index++;
            return;
        }

        //tailObj.transform.position = bodyPosition[index];
        //pool.GetObject(transform, bodyPosition[index - 1]);

        tailObj.transform.position = posObjList[index].transform.position;
        pool.GetObject(transform, posObjList[index - 1].transform.position);

        index++;
    }
}
