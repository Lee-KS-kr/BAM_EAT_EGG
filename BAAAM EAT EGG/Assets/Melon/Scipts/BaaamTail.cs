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

    // Start is called before the first frame update
    void Start()
    {
        pool = GameObject.Find("EggPool").GetComponent<ObjectPool>();

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
