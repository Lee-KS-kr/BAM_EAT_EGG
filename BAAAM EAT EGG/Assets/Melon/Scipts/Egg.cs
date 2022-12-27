using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    //알의 가치 - 풀링에서 사용되지 않은 알의 가치가 변경되지 않음을 고려해 static선언
    static int price = 10;

    public void SetPrice(float num)
    {
        price = (int)Mathf.Ceil(num * price);
    }

    public int GetPrice()
    {
        return price;
    }
}
