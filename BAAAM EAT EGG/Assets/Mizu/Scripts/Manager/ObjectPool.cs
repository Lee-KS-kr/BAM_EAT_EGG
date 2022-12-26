using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject bamObject;
        private Queue<GameObject> objectPool;
        private int poolCount = 0;
        private int poolCapacity = 4;

        private void Start()
        {
            SetPool();
        }

        private void SetPool()
        {
            objectPool = new Queue<GameObject>(poolCapacity);

            for(int i=0;i<poolCapacity;i++)
            {
                var obj = Instantiate(bamObject);
                obj.SetActive(false);
                obj.transform.parent = transform;
                obj.transform.position = transform.position;

                objectPool.Enqueue(obj);
                poolCount++;
            }
        }

        private void ExpandPool()
        {
            poolCapacity <<= 1;
            SetPool();
        }

        /// <summary>
        /// 새 부모가 될 객체의 tranform과, 새 포지션을 받아서 설정하고 object를 반환합니다.
        /// </summary>
        /// <param name="newParent"></param>
        /// <returns></returns>
        public GameObject GetObject(Transform newParent, Vector3 newPos)
        {
            if (poolCount < 1) ExpandPool();

            var obj = objectPool.Dequeue();
            obj.transform.parent = newParent;
            obj.transform.position = newPos;
            obj.SetActive(true);
            poolCount--;

            return obj;
        }

        public GameObject GetObject()
        {
            if (poolCount < 1) ExpandPool();

            var obj = objectPool.Dequeue();
            obj.SetActive(true);
            poolCount--;

            return obj;
        }

        public void ReturnObject(GameObject obj)
        {
            obj.SetActive(false);
            obj.transform.parent = transform;
            obj.transform.position = transform.position;
            objectPool.Enqueue(obj);
            poolCount++;
        }
    }
}