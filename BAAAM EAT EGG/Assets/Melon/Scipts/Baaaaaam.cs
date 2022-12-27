using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mizu;
using System;

public class Baaaaaam : MonoBehaviour
{
    [SerializeField] ObjectPool pool;
    [SerializeField] List<GameObject> posObjList = new List<GameObject>();
    [SerializeField] List<GameObject> bodyList = new List<GameObject>();
    [SerializeField] GameObject head;
    [SerializeField] GameObject tail;
    [SerializeField] GameObject emptyObj;
    [SerializeField] float radian;
    [SerializeField] float speed;
    [SerializeField] int count;
    int index = 0;
    float NextY;


    public Action<Baaaaaam> headTailAction;

    public float BaaamSpeed { get => speed; }
    public int BaaamCount { get => count; }
    public int BaaamIndex { get => index; }

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

            //첫번째 경우 머리 생성
            if(i == 0)
            {
                GameObject obj = Instantiate(head, new Vector3(x, 0, y), Quaternion.identity);
                obj.transform.SetParent(transform);
                continue;
            }
            //몸통 좌표 저장
            GameObject eObj = Instantiate(emptyObj, new Vector3(x, 0, y), Quaternion.Euler(0,Mathf.Rad2Deg * rad, 0));
            eObj.transform.SetParent(transform);
            posObjList.Add(eObj);
        }
    }


    public void tailSet()
    {
        //머리가 꼬리뒤에 있을경우
        if(index == 0)
        {
            //꼬리를 생성하지 않았다면 꼬리를 먼저 생성
            if (tailObj == null)
            {
                tailObj = Instantiate(tail, posObjList[index].transform.position, Quaternion.identity);
                tailObj.transform.SetParent(transform);
            }
            index++;
            return;
        }

        //body pool에서 몸통을 꺼내와 사용
        tailObj.transform.position = posObjList[index].transform.position;
        tailObj.transform.localRotation = posObjList[index].transform.localRotation;

        bodyList.Add(pool.GetObject(posObjList[index - 1].transform, posObjList[index - 1].transform.position));
        bodyList[index - 1].transform.localRotation = Quaternion.Euler(0, 0, 0);

        //뱀의 길이가 최대가 되었을때 => 꼬리의 다음위치가 머리일때 뱀을 초기화 한다.
        if (index >= posObjList.Count - 1)
        {
            resetBaaam();
            return;
        }

        index++;
    }

    //최대 길이가 되었을때 모든 몸을 반환하고 꼬리를 다시 머리 뒤로 이동
    void resetBaaam()
    {
        headTailAction?.Invoke(this);

        Debug.Log("최대 길이입니다.");
        for(int i = 0; i< bodyList.Count; i++)
        {
            bodyList[i].transform.rotation = Quaternion.identity;
            pool.ReturnObject(bodyList[i]);
        }
        bodyList.Clear();
        tailObj.transform.localRotation = posObjList[0].transform.localRotation;
        tailObj.transform.position = posObjList[0].transform.position;
        index = 1;
    }
}
