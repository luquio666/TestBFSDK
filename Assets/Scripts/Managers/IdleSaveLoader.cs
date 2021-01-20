using BigfootSdk;
using BigfootSdk.Backend;
using BigfootSdk.Core.Idle;

public class IdleSaveLoader : ILoadable
{

    public override void StartLoading()
    { 
        PlayerManager.Instance.SetSaveMethod(Save); 
        FinishedLoading(true);  
    }

    void Save()
    {
        IdleUserManager.Instance.PersistUser(false);
    }
}
