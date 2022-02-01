using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentItem : MonoBehaviour
{
    private RawImage ItemIcon;
    private Text DataText;
    internal Vector3 newPosition;
    internal bool reposition;

    // Start is called before the first frame update
    void Start()
    {
        ItemIcon = GetComponent<RawImage>();
        transform.GetChild(0).gameObject.SetActive(false);
    }
    private void Update()
    {
        if (reposition)
        {
            transform.position = Vector3.Lerp(transform.position, newPosition, 0.04f);
            if (Vector3.Distance(transform.position, newPosition) <= 0.1f)
                reposition = false;
        }
    }

    public void ShowData()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    public void HideData()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }


    internal void SetTexture(Texture2D itemTexture)
    {
        ItemIcon = GetComponent<RawImage>();
        ItemIcon.texture = itemTexture;
    }

    internal void SetData(items itemData)
    {
        DataText = transform.GetChild(0).GetComponent<Text>();
        DataText.text="slottype:"+itemData.slottype;
        DataText.text+="\nrarity:"+itemData.rarity;
        DataText.text+="\nlevel:"+itemData.level;
        DataText.text+="\nlevel:"+itemData.level;
        DataText.text+="\nlevel:"+itemData.level;
        DataText.text+="\nitemKey:"+itemData.itemkey;
        DataText.text+="\nvalue:"+itemData.value;
    }
}
