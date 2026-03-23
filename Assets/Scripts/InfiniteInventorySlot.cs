using UnityEngine;
using UnityEngine.UI;

public class InfiniteInventorySlot : MonoBehaviour
{
    public ScriptableItem slotItem;
    public int slotNumber;
    private Text itemNameText;
    private Image itemImage;
    
    //Ventana de inspeccion de objetos.
    public GameObject inspectWindow;
    public Image inspectionImage;
    public Text inspectionName;
    public Text inspectionPrice;
    public Text inspectionDescription;

    public Button thisSlotButton;
    public Button deleteButton;
    public Button closeButton;

    void Awake()
    {
        itemNameText = GetComponentInChildren<Text>();
        itemImage = GetComponentInChildren<Image>();

        GameObject canvas = GameObject.Find("Canvas");

        inspectWindow = canvas.transform.Find("InspectWindow").gameObject;
        inspectionImage = inspectWindow.transform.Find("Item Image").GetComponent<Image>();
        inspectionName = inspectWindow.transform.Find("Item Name").GetComponent<Text>();
        inspectionDescription = inspectWindow.transform.Find("Item Description").GetComponent<Text>();
        inspectionPrice = inspectWindow.transform.Find("Item Price").GetComponent<Text>();

        deleteButton = inspectWindow.transform.Find("Delete Button").GetComponent<Button>();
        closeButton = inspectWindow.transform.Find("Close Button").GetComponent<Button>();

        thisSlotButton = GetComponentInChildren<Button>();
        thisSlotButton.onClick.AddListener(InspectItem);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemNameText.text = slotItem.itemName;
        itemImage.sprite = slotItem.itemSprite;
    }

    void InspectItem()
    {
        if(slotItem != null)
        {
            closeButton.onClick.AddListener(CloseWindow);
            deleteButton.onClick.AddListener(DeleteItem);

            inspectionImage.sprite = slotItem.itemSprite;
            inspectionName.text = slotItem.itemName;
            inspectionPrice.text = slotItem.itemSellPrice.ToString();
            
            inspectWindow.SetActive(true);
        }
    }

    void CloseWindow()
    {
        inspectWindow.SetActive(false);

        closeButton.onClick.RemoveListener(CloseWindow);

        deleteButton.onClick.RemoveListener(DeleteItem);
    }

    void DeleteItem()
    {
        InventoryManager.Instance.items[slotNumber] = null;
        InventoryManager.Instance.itemsNames[slotNumber].text = "Empty";
        InventoryManager.Instance.itemsImages[slotNumber].sprite = null;

        slotItem = null;

        CloseWindow();
    }
}
