using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mizu;

public class BaaamHead : MonoBehaviour
{
    ObjectPool particlePool;
    ObjectPool pool;
    int EggLayer;
    int AddPrice;
    //임시
    Egg egg;

    // Start is called before the first frame update
    void Start()
    {
        pool = GameObject.Find("EggPool").GetComponent<ObjectPool>();
        particlePool = GameObject.Find("EggParticlePool").GetComponent<ObjectPool>();
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
            StartCoroutine(particleOn(other));
            egg = other.GetComponent<Egg>();
            GameManager.Inst.UIMng.SetEarnMoney(egg.GetPrice() * AddPrice);
            pool.ReturnObject(other.gameObject);
            //////////////////
        }
    }

    IEnumerator particleOn(Collider col)
    {
        GameObject obj =  particlePool.GetObject(null, col.transform.position + new Vector3(0,0.5f,0));
        yield return new WaitForSeconds(2f);
        particlePool.ReturnObject(obj);
    }
}
