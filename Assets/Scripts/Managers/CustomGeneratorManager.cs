using BigfootSdk.Core.Idle;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CustomGeneratorManager : GeneratorManager
{
    public override List<GeneratorItemModel> GetGenerators()
    {
        List<GeneratorItemModel> result = new List<GeneratorItemModel>();
        var allGenerators = base.GetGenerators();
        string[] currentLevelGenerators = IdleLevelsManager.Instance.CurrentLevel.Generators;
        for (int i = 0; i < currentLevelGenerators.Length; i++)
        {
            var match = allGenerators.Where(x => x.Name == currentLevelGenerators[i]).FirstOrDefault();
            if (match != null)
                result.Add(match);
        }
        return result;
    }
}
