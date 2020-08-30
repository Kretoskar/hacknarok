﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<int, GameObject> ItemsKeyGameObject;
    public GameObject[] inventorySlots;
    public List<string> itemsList; //just for testing


    private void Start()
    {
        ItemsKeyGameObject = new Dictionary<int, GameObject>();
    }

    public bool IsIdInInventory(int id)
    {
        foreach(var slot in inventorySlots)
        {
            if(slot.GetComponent<ItemInInventory>().itemKey == id)
            {
                return true;
            }
        }
        return false;
    }



}
