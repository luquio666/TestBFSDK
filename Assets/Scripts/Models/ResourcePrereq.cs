using BigfootSdk;
using BigfootSdk.Core.Idle;

public class ResourcePrereq : IPrerequisite
{
    /// <summary>
    /// The resource key.
    /// </summary>
    public string Resource = "points";

    /// <summary>
    /// The amount.
    /// </summary>
    public double Amount;
		
    /// <summary>
    /// Checks if the prerequisite is valid
    /// </summary>
    public override bool Check ()
    {
        // Grab the amount of currency
        double amountResources = ResourceManager.Instance.GetResourceAmount(Resource);

        return amountResources >= Amount;
    }
}
