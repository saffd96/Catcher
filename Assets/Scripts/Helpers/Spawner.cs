using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    #region Variables

    [Header("Spawner Settings")]
    [SerializeField] private BaseItem[] normalItems;
    [SerializeField] private BaseItem[] specialItems;

    [Range(0, 100)] [SerializeField] private int specialItemRate;

    [Header("Difficulty Settings")]
    [SerializeField] private float repeatRate;
    [SerializeField] private float gravityScale;
    [SerializeField] private float difficultyPeriod;

    [Header("DEV")]
    [SerializeField] private Vector3 spawnerStartPosition;
    [SerializeField] private Vector3 spawnerEndPosition;
    [SerializeField] private BaseItem receivedItem;

    [Space]
    [SerializeField] private float lastSpawnTime;
    [SerializeField] private float currentRepeatRate;
    [SerializeField] private float currentGravityScale;
    [SerializeField] private float currentDifficultyPeriod;

    #endregion


    #region Unity Lifecycle

    void Start()
    {
        Reset();
        StartSpawn();
    }

    #endregion


    #region Public Methods

    public void Reset()
    {
        currentRepeatRate = repeatRate;
        currentGravityScale = gravityScale;
        currentDifficultyPeriod = difficultyPeriod;

        var xOffsetInPixels = Screen.width;
        var vectorOffsetX = new Vector3(xOffsetInPixels, 0, 0);
        var xOffsetInWorld = Camera.main.ScreenToWorldPoint(vectorOffsetX);

        spawnerStartPosition = xOffsetInWorld;
        spawnerEndPosition = -xOffsetInWorld;
    }

    #endregion


    #region Private Methods

    private void StartSpawn(float delay = 0f)
    {
        InvokeRepeating(nameof(SpawnItem), delay, currentRepeatRate);
        Invoke(nameof(AddDifficulty), currentDifficultyPeriod);
    }

    private void SpawnItem()
    {
        var position = transform.position;
        var xPos = Random.Range(spawnerStartPosition.x, spawnerEndPosition.x);
        Vector3 randomPosition = new Vector3(xPos, position.y, 0);
        var itemPrefab = GetItem();

        var item = Instantiate(itemPrefab, randomPosition, itemPrefab.transform.rotation);
        item.SetGravity(currentGravityScale);

        lastSpawnTime = Time.deltaTime;
    }

    private BaseItem GetItem()
    {
        receivedItem = ShouldSpawnSpecial()
                ? GetItem(specialItems)
                : GetItem(normalItems);

        return receivedItem;
    }

    private BaseItem GetItem(BaseItem[] items)
    {
        var index = Random.Range(0, items.Length);

        return items[index];
    }

    private bool ShouldSpawnSpecial()
    {
        if (specialItems == null || specialItems.Length == 0)
        {
            return false;
        }

        int chance = Random.Range(1, 101);

        return chance <= specialItemRate;
    }

    private void AddDifficulty()
    {
        CancelInvoke(nameof(SpawnItem));

        currentGravityScale += 0.25f;

        if (currentRepeatRate > 0.1)
        {
            currentRepeatRate -= 0.1f;
        }

        var delay = currentRepeatRate - (Time.time - lastSpawnTime);

        StartSpawn(currentRepeatRate);
    }

    #endregion
}
