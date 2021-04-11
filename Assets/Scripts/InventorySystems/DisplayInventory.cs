using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;

    public int X_SPACE_BETWEEN_ITEMS;
    public int NUMBER_OF_COLLUMNS;
    public int Y_SPACE_BETWEEN_ITEMS;
    public int NUMBER_OF_SLOTS;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }
    public void UpdateDisplay()
    {
        for(int i = 0; i < inventory.Container.Count; i++)
        {
            if (i >= NUMBER_OF_SLOTS)
            {
                inventory.Container.RemoveAt(i);
                Debug.Log("INVENTORY FULL!");
                continue;
            }
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
        }
    }
    public void CreateDisplay()
    {
        for(int i=0;i<inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(inventory.Container[i], obj);
        }
    }
    public Vector3 GetPosition(int i)
    {
        GameObject found = GameObject.Find("AZIMasjhda");
        Vector3 posit = GameObject.Find("Slot ("+i.ToString()+")").transform.localPosition;
        return new Vector3((posit.x),(posit.y),0f);
    }
}
