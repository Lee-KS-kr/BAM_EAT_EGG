using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Mizu
{
    public sealed class UIManager : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private Button _settingsButton;
        
        [Header("Upgrades")]
        [SerializeField] private Button _speedUpgradeBtn;
        [SerializeField] private Button _lengthUpgradeBtn;
        [SerializeField] private Button _incomeUpgradeBtn;
        [SerializeField] private TMP_Text _speedUpgradeCost;
        [SerializeField] private TMP_Text _lengthUpgradeCost;
        [SerializeField] private TMP_Text _incomeUpgradeCost;

        [Header("Scores")]
        [SerializeField] private TMP_Text _moneyText;
        [SerializeField] private TMP_Text _gotMoneyText;


        private int _score = 0;
        public int Money { get; private set; } = 0;

        private void Start()
        {
            Initialize();
            
            SetMoney();
        }
        
        private void Initialize()
        {
            _settingsButton.onClick.AddListener(OnSettingsButton);
            
            _speedUpgradeBtn.onClick.AddListener(SpeedUpgrade);
            _lengthUpgradeBtn.onClick.AddListener(LengthUpgrade);
            _incomeUpgradeBtn.onClick.AddListener(IncomeUpgrade);

            _gotMoneyText.gameObject.SetActive(false);
        }

        private void OnSettingsButton()
        {
            Debug.Log("Settings");
        }

        private void SpeedUpgrade()
        {
            Debug.Log(_speedUpgradeBtn.gameObject.name);
            GameManager.Inst.BamMng.SetBamSpeed();
        }

        private void LengthUpgrade()
        {
            Debug.Log(_lengthUpgradeBtn.gameObject.name);
            GameManager.Inst.BamMng.SetBamLength();
        }

        private void IncomeUpgrade()
        {
            Debug.Log(_incomeUpgradeBtn.gameObject.name);
        }

        private void SetMoney()
        {
            _moneyText.text = $"{Money}";
        }

        public void SetEarnMoney(int earnedMoney)
        {
            _gotMoneyText.gameObject.SetActive(true);
            _gotMoneyText.text = $"{earnedMoney}";
            Debug.Log(earnedMoney);
            
            Money += earnedMoney;
            SetMoney();
        }
    }
}