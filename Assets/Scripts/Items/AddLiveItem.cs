public class AddLiveItem : BaseItem
{
    #region Private Methods

    protected override void ApplyEffect()
    
    {
        base.ApplyEffect();
        GameManager.Instance.AddLive();
    }

    #endregion
}
