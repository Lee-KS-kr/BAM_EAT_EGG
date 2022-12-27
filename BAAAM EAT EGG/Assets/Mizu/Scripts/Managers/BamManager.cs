using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public class BamManager : MonoBehaviour
    {
        [SerializeField] private Baaaaaam[] _bams;
        [SerializeField] private GameObject[] _rails;

        private static int _level = 0;
        private int _index = 0;

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            if (_level == 0) _level = 1;

            for (int i = 0; i < _bams.Length; i++)
            {
                _bams[i].gameObject.SetActive(false);
                _bams[i].headTailAction -= SetNextLevel;
                _bams[i].headTailAction += SetNextLevel;

                _rails[i].SetActive(false);
            }

            _bams[0].gameObject.SetActive(true);
            _rails[0].SetActive(true);

            _index = _level;
        }

        public void SetBamLength()
        {
            Debug.Log($"To do : BamManager SetBamLength");
            _bams[0].tailSet();
        }

        public void SetBamSpeed()
        {
            Debug.Log($"To do : BamManager SetBamSpeed");
        }

        private void SetNextLevel(Baaaaaam bam)
        {
            // 몇번째 뱀에게서 온 신호인지를 확인한다.

            // 신호가 마지막 뱀에게서 왔으면 레벨을 추가한다

            // 신호가 이전 뱀에게서 왔으면 다음 뱀의 꼬리를 추가한다
        }
    }
}