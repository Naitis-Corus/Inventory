using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DescriptionScript : MonoBehaviour
{public static DescriptionScript Instance {get; private set;}
[SerializeField]TextMeshProUGUI textItemName;
[SerializeField]TextMeshProUGUI textDescription;
[SerializeField]Image imageItem;
[SerializeField]Transform leftScreen;
[SerializeField]Transform rightScreen;
ItemPasport lastItemInside;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        gameObject.SetActive(false);
    }
    public void ShowDescription(ItemPasport ItemInsideForCell,PointerEventData eventInformationForCell)
    {if(gameObject.activeInHierarchy && ItemInsideForCell == lastItemInside){
    gameObject.SetActive(false);
    lastItemInside = null;}
    else
    {
       
        gameObject.SetActive(true);
         if(eventInformationForCell.position.x > (Screen.width / 2)){
               gameObject.transform.position = leftScreen.position;
            }
            else
            {
                 gameObject.transform.position = rightScreen.position;
            }
        textItemName.text = ItemInsideForCell.nameItem;
        textDescription.text = ItemInsideForCell.DescriptionItem;
        imageItem.sprite = ItemInsideForCell.SpriteItem;
        lastItemInside = ItemInsideForCell;
    }
        
    }

}
