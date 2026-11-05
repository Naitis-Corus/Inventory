using UnityEngine;

[CreateAssetMenu(fileName = "ItemPasport", menuName = "Scriptable Objects/ItemPasport")]
public class ItemPasport : ScriptableObject
{
    public string nameItem;
    public string DescriptionItem;
    public Sprite SpriteItem;
    public bool stacked;
}
