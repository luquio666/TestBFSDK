using BigfootSdk.Core.Idle;
using BigfootSdk.Helpers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomGeneratorGridItem : GeneratorGridItem
{
 
  
    public Button CollectButton;
    public GameObject Generated;
    public TextMeshProUGUI GeneratedAmount;
   
    protected override void OnEnable()
    {
        base.OnEnable();
        GeneratorManager.OnAutomateCollection += Refreshed;
        GeneratorManager.OnDeautomateCollection += Refreshed;
        OnGridItemPopulated += Refreshed;
        ResourceGenerationManager.OnResourcesReady += Refreshed;
        ResourceGenerationManager.OnGeneratorCollected += GeneratorCollected;
    }
    
    protected override void OnDisable()
    {
        base.OnDisable();
        GeneratorManager.OnAutomateCollection -= Refreshed;
        GeneratorManager.OnDeautomateCollection -= Refreshed;
        OnGridItemPopulated -= Refreshed;
        ResourceGenerationManager.OnResourcesReady -= Refreshed;
        ResourceGenerationManager.OnGeneratorCollected -= GeneratorCollected;
    }
    
    

    void Refreshed(string generatorName)
    {
        if (generatorName == _generatorModel.Name)
        {
            CollectButton.gameObject.SetActive(_generatorUserModel.WaitForCollection && _generatorUserModel.Generated > 0);
            Generated.SetActive(_generatorUserModel.WaitForCollection && _generatorUserModel.Generated > 0);
            GeneratedAmount.text = FormatHelper.Instance.FormatNumber(_generatorUserModel.Generated);
        }
    }

    void GeneratorCollected(string generator, double amount)
    {
        Refreshed(generator);
    }
}
