using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public class BamManager : MonoBehaviour
    {
        [SerializeField] private CameraZoom _camera;
        [SerializeField] private Baaaaaam[] _bams;
        [SerializeField] private GameObject[] _rails;

        [SerializeField] private Egg _egg;
        [SerializeField] private BaaamTail _tail;
        [SerializeField] private GameObject upgradeText;

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
                _bams[i].headTailAction -= SetNextLevel;
                _bams[i].headTailAction += SetNextLevel;
                _bams[i].gameObject.SetActive(false);

                _rails[i].SetActive(false);
            }

            _bams[0].gameObject.SetActive(true);
            _rails[0].SetActive(true);
        }

        public void SetBamLength()
        {
            _bams[0].tailSet();
        }

        public void SetSpeed()
        {
            _tail.setSpawnSpeed(0.1f);
        }

        public void SetEggPrice()
        {
            _egg.SetPrice(1.5f);
        }

        private void SetNextLevel(Baaaaaam bam)
        {
            // 몇번째 뱀에게서 온 신호인지를 확인한다.
            _index = 0;

            for (int i = 0; i < _bams.Length; i++)
            {
                if (IEqualityComparer<Baaaaaam>.ReferenceEquals(_bams[i], bam))
                    _index = i;
            }

            // 신호가 마지막 뱀에게서 왔으면 레벨을 추가한다
            if (_index == _level - 1)
            {
                if (_level == _bams.Length + 1) return;

                _camera.SetCameraSize();
                _bams[_level].gameObject.SetActive(true);
                _rails[_level].SetActive(true);
                _level++;
                StartCoroutine(offUpgradeText());
            }

            // 신호가 이전 뱀에게서 왔으면 다음 뱀의 꼬리를 추가한다
            else
            {
                _bams[_index + 1].tailSet();
            }
        }

        public IEnumerator offUpgradeText()
        {
            upgradeText.SetActive(true);
            yield return new WaitForSecondsRealtime(2f);
            upgradeText.SetActive(false);
        }

    }
}