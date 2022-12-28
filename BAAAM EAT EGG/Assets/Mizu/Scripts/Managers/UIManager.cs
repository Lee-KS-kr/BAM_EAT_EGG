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
        //[SerializeField] private TMP_Text _gotMoneyText;
        //[SerializeField] private Animator _scoreAnim;
        //private int hashEarn = Animator.StringToHash("earned");

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

        private void Update()
        {
            if (Money < levStruct.costs[_speedLev - 1] || _speedLev == levStruct.levels[levStruct.levels.Length - 1])
                _speedUpgradeBtn.interactable = false;
            else
                _speedUpgradeBtn.interactable = true;

            if (Money < levStruct.costs[_lengthLev - 1])
                _lengthUpgradeBtn.interactable = false;
            else
                _lengthUpgradeBtn.interactable = true;

            if (Money < levStruct.costs[_incomeLev - 1]|| _incomeLev == levStruct.levels[levStruct.levels.Length - 1])
                _incomeUpgradeBtn.interactable = false;
            else
                _incomeUpgradeBtn.interactable = true;
        }

        private void Initialize()
        {
            _settingsButton.onClick.AddListener(OnSettingsButton);

            _speedUpgradeBtn.onClick.AddListener(SpeedUpgrade);
            _lengthUpgradeBtn.onClick.AddListener(LengthUpgrade);
            _incomeUpgradeBtn.onClick.AddListener(IncomeUpgrade);

            //_gotMoneyText.gameObject.SetActive(false);
        }

        private void SetUpgradeLevels()
        {
            UpgradeCosts cost = new UpgradeCosts();
            cost.GetDefaultStruct();
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
            SetEarnMoney(100000);
        }

        private void SpeedUpgrade()
        {
            GameManager.Inst.BamMng.SetSpeed();
            Debug.Log(_speedUpgradeBtn.gameObject.name);

            MoneyUse(levStruct.costs[_speedLev - 1]);
            _speedLev = levStruct.levels[_speedLev];

            if (_speedLev == levStruct.levels[levStruct.levels.Length - 1])
            {
                _speedUpgradeCost.text = $"Full";
                _speedUpgradeBtn.interactable = false;
                return;
            }

            _speedUpgradeCost.text = $"{levStruct.costs[_speedLev - 1]}";
        }

        private void LengthUpgrade()
        {
            GameManager.Inst.BamMng.SetBamLength();
            Debug.Log(_lengthUpgradeBtn.gameObject.name);

            MoneyUse(levStruct.costs[_lengthLev - 1]);
            _lengthLev = levStruct.levels[_lengthLev];

            if (_lengthLev == levStruct.levels[levStruct.levels.Length - 1])
            {
                //_lengthUpgradeCost.text = $"Full";
                //_lengthUpgradeBtn.interactable = false;
                _lengthLev = levStruct.levels[_lengthLev - 2];
                return;
            }

            _lengthUpgradeCost.text = $"{levStruct.costs[_lengthLev - 1]}";

        }

        private void IncomeUpgrade()
        {
            GameManager.Inst.BamMng.SetEggPrice();
            Debug.Log(_incomeUpgradeBtn.gameObject.name);

            MoneyUse(levStruct.costs[_incomeLev - 1]);
            _incomeLev = levStruct.levels[_incomeLev];

            if (_incomeLev == levStruct.levels[levStruct.levels.Length - 1])
            {
                _incomeUpgradeCost.text = $"Full";
                _incomeUpgradeBtn.interactable = false;
                return;
            }

            _incomeUpgradeCost.text = $"{levStruct.costs[_incomeLev - 1]}";
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
            //_scoreAnim.SetTrigger(hashEarn);
            //_gotMoneyText = GameManager.Inst.ScoreUIPool.GetObject().GetComponent<TMP_Text>();

            Money += earnedMoney;
            SetMoney();
        }
    }
}