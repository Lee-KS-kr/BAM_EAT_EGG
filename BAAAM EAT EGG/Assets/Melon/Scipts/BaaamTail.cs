using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mizu;

public class BaaamTail : MonoBehaviour
{
    [SerializeField] GameObject poolObj;
    [SerializeField] ObjectPool pool;
    static float spawnSpeed;
    WaitForSeconds time;


    //알 생성을 위한 pool을 생성한뒤 objectPool스크립트 할당
    private void Awake()
    {
        pool = Instantiate(poolObj, Vector3.zero, Quaternion.identity).GetComponent<ObjectPool>();
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnSpeed = 2;
        time = new WaitForSeconds(spawnSpeed);
        StartCoroutine(spawnEgg());
    }

    //알 스폰시간 변경 함수
    public void setSpawnSpeed(float speed)
    {
        spawnSpeed -= speed;
        Debug.Log($"new spawn time {spawnSpeed}");
        time = new WaitForSeconds(spawnSpeed);
    }

    IEnumerator spawnEgg()
    {
        yield return time;
        while(true)
        {
            pool.GetObject(null, transform.position);
            yield return new WaitForSeconds(spawnSpeed);
        }
    }
}
