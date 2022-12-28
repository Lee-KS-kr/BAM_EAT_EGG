using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mizu;

public class BaaamHead : MonoBehaviour
{
    ObjectPool pool;
    int EggLayer;
    int AddPrice;
    //임시
    Egg egg;

    // Start is called before the first frame update
    void Start()
    {
        pool = GameObject.Find("EggPool").GetComponent<ObjectPool>();
        EggLayer = LayerMask.NameToLayer("Egg");
    }

    public void SetPrice(int price)
    {
        AddPrice = price;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == EggLayer)
        {
            //충돌 확인용 임시코드
            egg = other.GetComponent<Egg>();
            GameManager.Inst.UIMng.SetEarnMoney(egg.GetPrice() * AddPrice);
            pool.ReturnObject(other.gameObject);
            //////////////////
        }
    }
}
