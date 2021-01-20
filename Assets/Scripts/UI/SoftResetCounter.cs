
using System;
using BigfootSdk;
using BigfootSdk.Backend;
using BigfootSdk.Core.Idle;
using TMPro;
using UnityEngine;

public class SoftResetCounter : MonoBehaviour
{
    public TextMeshProUGUI Label;
    
    private void OnEnable()
    {
        DependencyManager.OnEverythingLoaded += UpdateLabel;
    }

    private void OnDisable()
    {
        DependencyManager.OnEverythingLoaded -= UpdateLabel;
    }

    void UpdateLabel()
    {
        Label.text = PlayerManager.Instance
            .GetCounter(CountersConstants.SOFT_RESET_AMOUNT, GameModeManager.CurrentGameMode).ToString();
    }
}
