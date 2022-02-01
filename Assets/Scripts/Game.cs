using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������� ������ - ������ �����
public class Game : MonoBehaviour
{
  

    private Loader loader;
    private Chest chest;

    void Start()
    {
        loader = GetComponent<Loader>();
        chest = GetComponent<Chest>();
        Debug.Log("���������� ������ �� ������ ��� �������� ���������� � �������");
        
        loader.LoadJSON(ParseChest);
    }

    private void ParseChest(string json)
    {
        Debug.Log("������� ����� �� �������:"+json);
        
        ChestInfo Content = JsonUtility.FromJson<ChestInfo>(json);
        foreach (items item in Content.chest_items)

            chest.AddItem(item);
        
        
        Debug.Log($"��������� ����������� �������[{Content.chest}]");
        chest.content = Content;
        chest.LoadChestTexture();

        
    }

    void Update()
    {
        
    }
}
