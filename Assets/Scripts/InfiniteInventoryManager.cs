using UnityEngine;
using System.Collections.Generic;
public class InfiniteInventoryManager : MonoBehaviour
{
    public static InfiniteInventoryManager Instance;

    void Awake()
    {
        if(Instance != this && Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        inventoryCanvasTransform = GameObject.Find("Inventory").transform;
    }
    
    public List<ScriptableItem> items;
    public List<InventorySlots> itemsSlots;
    public GameObject slotPrefab;
    private Transform inventoryCanvasTransform;

    public void AddItem(ScriptableItem item)
    {
        GameObject prefab = Instantiate(slotPrefab);
        prefab.transform.SetParent(inventoryCanvasTransform);

        InfiniteInventorySlot prefabScript = prefab.GetComponent<InfiniteInventorySlot>();
        prefabScript.slotItem = item;

        items.Add(item);
        
    }
}
