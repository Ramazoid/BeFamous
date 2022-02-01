using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public Image chestImage;
    public ChestInfo content;
    private static Chest INST;
    public Loader loader;
    
    public List<items> ContentItems = new List<items>();
    private bool loaded;
    public GameObject itemPrefab;
    private int itemsCounter;
    public Canvas canvas;


    public void Start()
    {
        chestImage = GameObject.Find("Chest").GetComponent<Image>();
    }

    internal void SetChest(Texture2D chestTexture)
    {
        chestImage.sprite = Sprite.Create(chestTexture, new Rect(0, 0, 540, 500), Vector2.zero);
        ScaleManager.Show("Chest", null);
        ScaleManager.Show("ClickText", null);
    }

    public void AddItem(items item)
    {
        ContentItems.Add(item);
    }

    public void LoadItems()
    {
        ScaleManager.Hide("Chest", null);
        ScaleManager.Hide("ClickText", null);
        Debug.Log("Загружаем изображения предметов");itemsCounter = 0;
        foreach (items item in ContentItems)
        {
            Debug.Log("pfuhe;ftv:"+item.itemkey);
            loader.LoadPNG( item.itemkey + ".png", AddItem);
        }
    }

    public static void SetContent(ChestInfo Content)
    {
        INST.content = Content;
        foreach (items item in INST.content.chest_items)
        {
            INST.ContentItems.Add(item);
            Debug.Log($"Добавлен предмет[{item.itemkey}]");
        }
    }

    private void AddItem(Texture2D itemTexture)
    {
        Debug.Log($"Загружена текстура[{itemTexture.name}]");
        ContentItem item = Instantiate(itemPrefab,canvas.transform).GetComponent<ContentItem>();

        items itemData = ContentItems[itemsCounter++];
        item.transform.localPosition = transform.localPosition;
        //позиция куда будут разлетаться предметы из сундука
        item.newPosition = Vector3.zero + Vector3.right * itemsCounter * 150 + Vector3.up * Screen.height / 2;
        item.reposition = true;
        item.SetTexture(itemTexture);
        item.SetData(itemData);
    }

    public void LoadChestTexture()
    {
        loader.LoadPNG("chest_" + content.chest + ".png", SetChest);
    }
}
