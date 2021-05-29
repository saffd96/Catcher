using UnityEngine;

public class DetectionZone : SingletonMonoBehaviour<DetectionZone>
{

    #region Variables

    [SerializeField] private Cat cat;

    #endregion


    #region Public Methods

    public void OnTriggerEnter2D(Collider2D other) //с автоплеем помогити))))))
    {
        if (GameManager.Instance.IsAutoPlay)
        {
            var contactPoint = other.transform.position;
            var catTransform = cat.transform;

            if (other.gameObject.CompareTag(Tags.GoodItem) || other.gameObject.CompareTag(Tags.GoodPowerUp))
            {
                catTransform.position = new Vector3(contactPoint.x, catTransform.position.y, 0);
            }
            else if (other.gameObject.CompareTag(Tags.BadItem) || other.gameObject.CompareTag(Tags.BadPowerUp))
            {
                catTransform.position = new Vector3(-contactPoint.x, catTransform.position.y, 0);
            }
        }
    }

    #endregion
}
