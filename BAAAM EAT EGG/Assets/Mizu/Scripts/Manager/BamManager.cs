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
        }

        public void SetBamSpeed()
        {
            Debug.Log($"To do : BamManager SetBamSpeed");
        }
    }
}