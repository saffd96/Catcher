using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    #region Variables

    [Header("Spawner Settings")]
    [SerializeField] private GameObject spawnerStartPosition;
    [SerializeField] private GameObject spawnerEndPosition;
    [SerializeField] private GameObject[] normalItems;
    [SerializeField] private GameObject[] specialItems;

    [Range(0, 100)] [SerializeField] private int specialItemRate;

    [Header("Difficulty Settings")]
    [SerializeField] private float repeatRate;
    [SerializeField] private float gravityScale;
    [SerializeField] private float addDiffcultyPeriod;

    [Header("For DEV")]
    private GameObject receivedItem;

    #endregion


    #region Unity Lifecycle

    void Start()
    {
        StartSpawn();
    }

    #endregion


    #region Private Methods

    private void SpawnItem()
    {
        var position = gameObject.transform.position;
        var xPos = Random.Range(spawnerStartPosition.transform.position.x, spawnerEndPosition.transform.position.x);
        Vector3 randomPosition = new Vector3(xPos, position.y, 0);
        var item = GetItem();
        Instantiate(item, randomPosition, item.transform.rotation);
        item.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
    }

    private GameObject GetItem()
    {
        receivedItem =
                SpawnSpecial() ? specialItems[GetIndexOfItem(specialItems)] : normalItems[GetIndexOfItem(normalItems)];

        return receivedItem;
    }

    private int GetIndexOfItem(Array items)
    {
        var index = Random.Range(0, items.Length);

        return index;
    }

    private bool SpawnSpecial()
    {
        if (specialItems == null || specialItems.Length == 0)
        {
            return false;
        }

        int chance = Random.Range(1, 101);
        {
            return chance <= specialItemRate;
        }
    }

    private void StartSpawn()
    {
        InvokeRepeating(nameof(SpawnItem), 0, repeatRate);
        Invoke(nameof(AddDifficulty), addDiffcultyPeriod);
    }

    private void AddDifficulty()
    {
        CancelInvoke(nameof(SpawnItem));
        gravityScale += 0.25f;
        repeatRate -= 0.1f;
        StartSpawn();
    }

    #endregion
}
