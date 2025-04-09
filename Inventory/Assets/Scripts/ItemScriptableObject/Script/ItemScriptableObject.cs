using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObject/Item")]
public class ItemScriptableObject : ScriptableObject
{
    [Header("Name")]
    [SerializeField] protected int id;
    [SerializeField] protected string itemName;
    [Header("Type")]
    [SerializeField] protected ItemType itemType;
    [Header("Size in Slot")]
    [SerializeField] protected int maxStackInSlot;
    [Header("Image")]
    [SerializeField] protected Sprite itemIcon;
  

    public int ID => id;
    public string ItemName => itemName;
    public ItemType ItemType => itemType;
    public int MaxStackInSlot => maxStackInSlot;
    public Sprite ItemIcon => itemIcon;
}
