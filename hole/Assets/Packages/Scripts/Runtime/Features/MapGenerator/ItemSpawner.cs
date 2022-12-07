using UnityEngine;
using Random = UnityEngine.Random;

namespace Hole.Runtime.Features.MapGenerator
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private float maxXPosition;
        [SerializeField] private float minXPosition;
        [SerializeField] private float maxZPosition;
        [SerializeField] private float minZPosition;
        
        [SerializeField] private float yOffset;
        
        [SerializeField] private int numberSpeedBusters;
        [SerializeField] private int numberTimeBusters;
        [SerializeField] private int numberSimpleItem;
        
        [SerializeField] private GameObject SpeedBusterPrefab;
        [SerializeField] private GameObject TimeBusterPrefab;
        [SerializeField] private GameObject SimpleItemPrefab;

        private void Awake()
        {
            GenerateItems(numberSpeedBusters, SpeedBusterPrefab);
            GenerateItems(numberTimeBusters, TimeBusterPrefab);
            GenerateItems(numberSimpleItem, SimpleItemPrefab);
        }

        private void GenerateItems(int itemsCount, GameObject itemPrefab)
        {
            for (var i = 0; i < itemsCount; i++)
            {
                var position = new Vector3(
                    Random.Range(minXPosition, maxXPosition),
                    yOffset,
                    Random.Range(minZPosition, maxZPosition));

                Instantiate(itemPrefab, position, Quaternion.identity);
            }
        }
    }
}