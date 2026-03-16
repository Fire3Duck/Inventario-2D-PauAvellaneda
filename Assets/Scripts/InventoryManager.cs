using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

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
    }
    
    public ScriptableItem[] items;
    public Text[] itemsNames;
    public Image[] itemsImages;
    
    public InventorySlots[] itemsSlots;

    public void AddItem(ScriptableItem item)
    {
        for(int i = 0; i < items.Length; i++)
        {
            if(items[i] == null)
            {
                items[i] = item;
                itemsNames[i].text = item.itemName;
                itemsImages[i].sprite = item.itemSprite;

                itemsSlots[i].slotItem = item;
                itemsSlots[i].slotNumber = i;

                return;
            }
        }
    }
}
