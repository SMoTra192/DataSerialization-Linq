using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class NickNames : MonoBehaviour
{
    private Dictionary<string, int> nickNames = new Dictionary<string, int>();

    private string[] listOfNicks()
    {
     return textAsset.text.Replace("\r", "").
         Split('\n').
         ToArray();
    }
    [SerializeField] private TextAsset textAsset;
    [SerializeField] private Transform theHolderOfNickNames;
    [SerializeField] private TextMeshProUGUI nickNameHolder;
    private int Key = 1;
    
    public void AddNickName()
    {
        var RandomNickname = Random.Range(0, listOfNicks().Length);
         nickNames.Add($"{listOfNicks()[RandomNickname]}", Key);
         Key++;
         print(nickNames.Last());
         nickNameHolder.text = nickNames.Last().ToString();
         Instantiate(nickNameHolder, theHolderOfNickNames.transform.position, Quaternion.identity);
         
    }

    public void RemoveNickName()
    {
        string TKey = $"{nickNames.Last()}";
        print(TKey);
        nickNames.Remove(TKey);
    }

    public void ShowFullList()
    {
        foreach (var nick in nickNames)
        {
            print(nick);
        }
    }
    
}
