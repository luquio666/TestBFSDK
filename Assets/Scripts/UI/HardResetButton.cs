using System.Collections;
using System.Collections.Generic;
using BigfootSdk.Backend;
using UnityEngine;

public class HardResetButton : MonoBehaviour
{
    public void HardReset()
    {
        PlayerManager.Instance.DeletePlayerData();
        Application.Quit();
    }
}
