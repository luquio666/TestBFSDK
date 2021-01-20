using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BigfootSdk;
using BigfootSdk.Backend;
using BigfootSdk.Core.Idle;
using BigfootSdk.Helpers;
using UnityEngine;

public class IdleLevelsManager : LoadableSingleton<IdleLevelsManager>
{
    public List<IdleLevelModel> Levels;
    public IdleLevelModel CurrentLevel;
    public bool PrereqsCompleted;
    public static Action OnPrereqsCompleted;
    
    protected override void OnEnable()
    {
        base.OnEnable();
        ResourceManager.OnResourceBalanceChanged += UpdateResources;
    }

    private void OnDisable()
    {
        ResourceManager.OnResourceBalanceChanged -= UpdateResources;
    }


    void UpdateResources(string resourceKey, double amount)
    {
        CheckPrereqs();
    }

    void CheckPrereqs()
    {
        bool completed = true;
        foreach (var p in CurrentLevel.SoftResetPrerequisites)
        {
            if (!p.Check())
            {
                completed = false;
                break;
            }
        }

        if (completed)
        {
            PrereqsCompleted = true;
            OnPrereqsCompleted?.Invoke();
        }
    }

    public override void StartLoading()
    {
        Levels = ConfigHelper.LoadConfig<List<IdleLevelModel>>("idle_levels");
        int softResets = PlayerManager.Instance
            .GetCounter(CountersConstants.SOFT_RESET_AMOUNT, GameModeManager.CurrentGameMode);
        CurrentLevel = Levels.FirstOrDefault(x => x.Id == softResets);
        CheckPrereqs();
        FinishedLoading(true);
    }
    
    
}
