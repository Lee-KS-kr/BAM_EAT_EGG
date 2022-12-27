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

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            if (_level == 0) _level = 1;
            
            for (int i = _level; i < _bams.Length; i++)
            {
                _bams[i].gameObject.SetActive(false);
                _rails[i].SetActive(false);
            }
        }

        public void SetBamLength()
        {
            Debug.Log($"To do : BamManager SetBamLength");
            _bams[0].tailSet();

            // bams[0]의 인덱스와 카운트를 확인하여 동일하면 전부 끄고 다음으로 이동
        }

        public void SetBamSpeed()
        {
            Debug.Log($"To do : BamManager SetBamSpeed");
        }

        private void SetNextLevel()
        {
            _bams[_level].gameObject.SetActive(true);
            _rails[_level].SetActive(true);
            _level++;
        }
    }
}