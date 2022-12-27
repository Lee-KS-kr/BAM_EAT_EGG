using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeedUp : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(speedUp());
        }
    }


    IEnumerator speedUp()
    {
        Time.timeScale = 2;
        yield return new WaitForSeconds(2f);
        Time.timeScale = 1;
    }
}
