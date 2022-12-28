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
        private GameObject _scoreObj;
        private TMP_Text _gotMoneyText;
        //[SerializeField] private Animator _scoreAnim;
        private WaitForSeconds waitTime = new WaitForSeconds(1.5f);

        public int Money { get; private set; } = 0;

        [Header("Upgrades")]
        [SerializeField] private int _speedLev = 0;
        [SerializeField] private int _lengthLev = 0;
        [SerializeField] private int _incomeLev = 0;


        private Vector2 inputPos;
        private float elapsedTime;
        private float benchmarkTime = 1f;

        LevelStruct levStruct = new LevelStruct();

        private void Start()
        {
            Initialize();
            SetUpgradeLevels();

            SetMoney();
        }

        private void Update()
        {
            OnHold();

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
        }

        private void SetUpgradeLevels()
        {
            UpgradeCosts cost = new UpgradeCosts();
            cost.SetCustomStrcut(11, 100);
            var temp = cost.SetUpgradeCost();
            levStruct = cost.GetUpgrades(temp);

            _speedUpgradeCost.text = $"{levStruct.costs[_speedLev]}";
            _speedLev = levStruct.levels[0];
            _lengthUpgradeCost.text = $"{levStruct.costs[_lengthLev]}";
            _lengthLev = levStruct.levels[0];
            _incomeUpgradeCost.text = $"{levStruct.costs[_incomeLev]}";
            _incomeLev = levStruct.levels[0];
        }

        private void OnHold()
        {
            if (Input.GetMouseButtonDown(0))
            {
                inputPos = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                elapsedTime += Time.deltaTime;

                if(elapsedTime >= benchmarkTime)
                {
                    if (Money >= levStruct.costs[_lengthLev - 1])
                    {
                        elapsedTime -= (Time.deltaTime * 20);
                        LengthUpgrade();
                    }
                    else
                        return;
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                elapsedTime = 0f;
                inputPos = Vector2.zero;
            }
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
            _scoreObj = GameManager.Inst.ScoreUIPool.GetObject();
            StartCoroutine(MoneyEffect(_scoreObj));

            _scoreObj.transform.rotation = Quaternion.Euler(76, 0, 0);
            _gotMoneyText = _scoreObj.GetComponentInChildren<TMP_Text>();
            _gotMoneyText.text = $"{earnedMoney}";

            Money += earnedMoney;
            SetMoney();
        }

        private IEnumerator MoneyEffect(GameObject scoreObj)
        {
            yield return waitTime;
            GameManager.Inst.ScoreUIPool.ReturnObject(scoreObj);
        }
    }
}