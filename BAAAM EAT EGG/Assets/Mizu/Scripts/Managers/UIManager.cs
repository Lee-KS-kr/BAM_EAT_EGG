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

        public int Money { get; private set; } = 0;

        [Header("Upgrades")]
        [SerializeField] private int _speedLev = 0;
        [SerializeField] private int _lengthLev = 0;
        [SerializeField] private int _incomeLev = 0;

        LevelStruct levStruct = new LevelStruct();

        private void Start()
        {
            Initialize();
            SetUpgradeLevels();

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

        private void SetUpgradeLevels()
        {
            UpgradeCosts cost = new UpgradeCosts();
            var temp = cost.SetUpgradeCost();
            levStruct = cost.GetUpgrades(temp);

            _speedUpgradeCost.text = $"{levStruct.costs[_speedLev]}";
            _speedLev = levStruct.levels[0];
            _lengthUpgradeCost.text = $"{levStruct.costs[_lengthLev]}";
            _lengthLev = levStruct.levels[0];
            _incomeUpgradeCost.text = $"{levStruct.costs[_incomeLev]}";
            _incomeLev = levStruct.levels[0];
        }

        private void OnSettingsButton()
        {
            Debug.Log("Settings");
        }

        private void SpeedUpgrade()
        {
            Debug.Log(_speedUpgradeBtn.gameObject.name);
            MoneyUse(levStruct.costs[_speedLev - 1]);
            _speedUpgradeCost.text = $"{levStruct.costs[_speedLev]}";
            _speedLev = levStruct.levels[_speedLev];

            GameManager.Inst.BamMng.SetBamSpeed();
        }

        private void LengthUpgrade()
        {
            Debug.Log(_lengthUpgradeBtn.gameObject.name);
            MoneyUse(levStruct.costs[_lengthLev - 1]);
            _lengthUpgradeCost.text = $"{levStruct.costs[_lengthLev]}";
            _lengthLev = levStruct.levels[_lengthLev];

            GameManager.Inst.BamMng.SetBamLength();
        }

        private void IncomeUpgrade()
        {
            Debug.Log(_incomeUpgradeBtn.gameObject.name);
            MoneyUse(levStruct.costs[_incomeLev - 1]);
            _incomeUpgradeCost.text = $"{levStruct.costs[_incomeLev]}";
            _incomeLev = levStruct.levels[_incomeLev];
        }

        private void SetMoney()
        {
            _moneyText.text = $"{Money}";
        }

        private void MoneyUse(int usedMoney)
        {
            Money -= usedMoney;
            SetMoney();
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