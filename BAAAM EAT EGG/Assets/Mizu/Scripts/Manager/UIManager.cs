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

        [SerializeField] private TMP_Text _goldText;

        private void Awake()
        {
            _settingsButton.onClick.AddListener(OnSettingsButton);
            _upgrade1.onClick.AddListener(OnUpgrade1);
            _upgrade2.onClick.AddListener(OnUpgrade2);
            _upgrade3.onClick.AddListener(OnUpgrade3);
        }

        private void OnSettingsButton()
        {
            Debug.Log("Settings");
        }

        private void OnUpgrade1()
        {
            Debug.Log("Upgrade1");
        }

        private void OnUpgrade2()
        {
            Debug.Log("Upgrade2");
        }

        private void OnUpgrade3()
        {
            Debug.Log("Upgrade3");
        }
    }
}