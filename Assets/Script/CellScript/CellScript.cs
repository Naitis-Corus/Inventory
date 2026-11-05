using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CellScript : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler,IDropHandler,IPointerClickHandler
{
[SerializeField]TextMeshProUGUI text;
public ItemPasport itemInside;
public int totalItem = 0;
public Image imageItem;
Transform nativeCell;
    void Start()
    {
        ItemVisual();
        
    }
    public void ItemVisual()
    {
        if(itemInside != null){
        imageItem.sprite = itemInside.SpriteItem;
        imageItem.enabled =true;
        if(totalItem > 1){
        text.enabled = true;
        text.text = totalItem.ToString();}
            else
            {
                text.enabled = false;
            }
       
        }
      
        
        else
        {
            imageItem.enabled = false;
            imageItem.sprite = null;
            text.enabled = false;
        }
    }
    public void OnBeginDrag(PointerEventData eventInformation)
    {
        if(itemInside == null)
        return;
        nativeCell = imageItem.transform.parent;
        imageItem.transform.SetParent(imageItem.transform.root);
        imageItem.raycastTarget = false;

    }
    public void OnDrag(PointerEventData eventInformation)
    {
         if(itemInside == null)
        return;
        imageItem.transform.position = eventInformation.position;
    }
        public void OnDrop(PointerEventData eventInformation)
    {
        if(eventInformation.pointerDrag == null)
        return;
       CellScript PreviousCell =  eventInformation.pointerDrag.GetComponent<CellScript>();
       if(PreviousCell == null)
       return;
       if (PreviousCell.itemInside == itemInside)
       {
        totalItem += PreviousCell.totalItem;
        PreviousCell.itemInside = null;
        PreviousCell.totalItem = 0;
        }
        else
        {
        ItemPasport temp = itemInside;
        itemInside = PreviousCell.itemInside;
        PreviousCell.itemInside = temp;
        int totalTemp = totalItem;
        totalItem = PreviousCell.totalItem;
        PreviousCell.totalItem = totalTemp;
       
        }

   
       ItemVisual();
       PreviousCell.ItemVisual();
    }
    public void OnEndDrag(PointerEventData eventInformation)
    {
        imageItem.transform.SetParent(nativeCell);
        imageItem.raycastTarget = true;
        imageItem.transform.localPosition = Vector3.zero;
    }
public void OnPointerClick(PointerEventData eventInformation)
    {
        if(itemInside == null)
       return;
      DescriptionScript.Instance.ShowDescription(itemInside,eventInformation);
    }
}
