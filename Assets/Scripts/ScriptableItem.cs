using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObjects/Items")] //En el botton de crate hace un boton llamado ScriptableObject, creara un asset del item.
public class ScriptableItem : ScriptableObject
{
    public string itemName;
    public string ItemDescription;
    public int itemSellPrice;
    public Sprite itemSprite;
}
