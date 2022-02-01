using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ќсновной укласс - точ€ка входа
public class Game : MonoBehaviour
{
  

    private Loader loader;
    private Chest chest;

    void Start()
    {
        loader = GetComponent<Loader>();
        chest = GetComponent<Chest>();
        Debug.Log("ќтправл€ем запрос на сервер дл€ загрузки информации о сундуке");
        
        loader.LoadJSON(ParseChest);
    }

    private void ParseChest(string json)
    {
        Debug.Log("получен ответ от сервера:"+json);
        
        ChestInfo Content = JsonUtility.FromJson<ChestInfo>(json);
        foreach (items item in Content.chest_items)

            chest.AddItem(item);
        
        
        Debug.Log($"загружаем изображение сундука[{Content.chest}]");
        chest.content = Content;
        chest.LoadChestTexture();

        
    }

    void Update()
    {
        
    }
}
