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
        pool = GameObject.Find("EggPool").GetComponent<ObjectPool>();
        EggLayer = LayerMask.NameToLayer("Egg");
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == EggLayer)
        {
            //충돌 확인용 임시코드
            egg = other.GetComponent<Egg>();
            GameManager.Inst.UIMng.SetEarnMoney(egg.GetPrice());
            pool.ReturnObject(other.gameObject);
            //////////////////
        }
    }
}
