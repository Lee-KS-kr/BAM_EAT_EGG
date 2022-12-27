using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mizu;

public class BaaamHead : MonoBehaviour
{
    ObjectPool pool;
    int EggLayer;

    //임시
    Egg egg;

    // Start is called before the first frame update
    void Start()
    {
        EggLayer = LayerMask.NameToLayer("Egg");
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == EggLayer)
        {
            //충돌 확인용 임시코드
            egg = other.GetComponent<Egg>();
            Debug.Log("알에 충돌했습니다. 알의 가치 : " + egg.GetPrice());
            other.gameObject.SetActive(false);
            //////////////////
        }
    }
}
