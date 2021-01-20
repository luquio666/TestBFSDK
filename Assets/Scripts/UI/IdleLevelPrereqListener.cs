using UnityEngine;
using UnityEngine.UI;

public class IdleLevelPrereqListener : MonoBehaviour
{
    public Button Button;
    
    private void OnEnable()
    {
        IdleLevelsManager.OnPrereqsCompleted += UpdateButton;
        UpdateButton();
    }

    private void OnDisable()
    {
        IdleLevelsManager.OnPrereqsCompleted -= UpdateButton;
    }

    void UpdateButton()
    {
        Button.interactable = IdleLevelsManager.Instance.PrereqsCompleted;
    }
}
