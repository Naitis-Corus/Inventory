using UnityEngine;

public class CreaitCell : MonoBehaviour
{
    [SerializeField] GameObject cellPrefab;
    [SerializeField] byte totalNumberCell = 15;
    [SerializeField] ItemPasport testItem;
    [SerializeField] ItemPasport testItemNum2;
    CellScript[] cellMemory;

    void Start()
    {

        cellMemory = new CellScript[totalNumberCell];
        for (byte c = 0; c < totalNumberCell; c++)
        {
            cellMemory[c] = Instantiate(cellPrefab, transform).GetComponent<CellScript>();

        }
    PutCell(testItem);
     PutCell(testItem);
    PutCell(testItem);
    PutCell(testItemNum2);
    PutCell(testItemNum2);

    }
    public void PutCell(ItemPasport item)
    {
        for (byte c = 0; c < totalNumberCell; c++)
        {
            if (cellMemory[c].itemInside == null)
            {
                cellMemory[c].itemInside = item;
                cellMemory[c].totalItem++;
                cellMemory[c].ItemVisual();
                return;
            }
        }
    }
}

