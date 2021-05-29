public class RemoveLiveItem : BaseItem
{
    #region Private Methods

    protected override void ApplyEffect()

    {
        base.ApplyEffect();
        GameManager.Instance.RemoveLive();
    }

    #endregion
}
