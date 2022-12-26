using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Mizu
{
    public sealed class UIManager : MonoBehaviour
    {
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _upgrade1;
        [SerializeField] private Button _upgrade2;
        [SerializeField] private Button _upgrade3;

        [SerializeField] private TMP_Text _moneyText;
        [SerializeField] private TMP_Text _scoreText;

        private int _score = 0;
        public int Money { get; private set; } = 0;

        private void Awake()
        {
            _settingsButton.onClick.AddListener(OnSettingsButton);
            _upgrade1.onClick.AddListener(OnUpgrade1);
            _upgrade2.onClick.AddListener(OnUpgrade2);
            _upgrade3.onClick.AddListener(OnUpgrade3);
        }

        private void Start()
        {
            SetScore();
            SetMoney();
        }

        private void OnSettingsButton()
        {
            Debug.Log("Settings");
        }

        private void OnUpgrade1()
        {
            Debug.Log(_upgrade1.gameObject.name);
        }

        private void OnUpgrade2()
        {
            Debug.Log(_upgrade2.gameObject.name);
        }

        private void OnUpgrade3()
        {
            Debug.Log(_upgrade3.gameObject.name);
        }

        private void SetScore()
        {
            _scoreText.text = $"{_score}";
        }

        private void SetMoney()
        {
            _moneyText.text = $"{Money}";
        }
    }
}