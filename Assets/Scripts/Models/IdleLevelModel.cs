using System.Collections.Generic;
using BigfootSdk;

public class IdleLevelModel
{
    public int Id;
    public List<IPrerequisite> SoftResetPrerequisites;
    public string[] Generators;
}
