using BigfootSdk;
using BigfootSdk.Core.Idle;

public class GeneratorLevelPrereq : IPrerequisite
{
    /// <summary>
    /// The generator name.
    /// </summary>
    public string Name;

    /// <summary>
    /// The min level.
    /// </summary>
    public int MinLevel;
		
    /// <summary>
    /// Checks if the prerequisite is valid
    /// </summary>
    public override bool Check ()
    {
        // Grab the generator level
        int generatorAmount = GeneratorManager.Instance.GetGeneratorAmount(Name);

        return generatorAmount >= MinLevel;
    }
}
