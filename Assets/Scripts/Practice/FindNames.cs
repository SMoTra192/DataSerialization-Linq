using System;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;


namespace DefaultNamespace.Practice
{
    public class FindNames : MonoBehaviour
    {
        [SerializeField]
        private TextAsset textAsset;
        
        private string[] Find()
        {
            return textAsset.text.Replace("\r", "").
                Split('\n').
                Where(s => s.EndsWith('s')).
                ToArray();
            //print lenght of names that starts with "N" and more than 5 characters
            return textAsset.text.
                Split('\n').
                Where(s => s.StartsWith('N')).
                Where(s => s.Length > 5).
                Select(s => $"{s} : {s.Length}").
                ToArray();
            
        }

        private string FindTwo()
        {
            return textAsset.text.Split('\n').
                Max(s => s.Length).
                ToString();
        }
        [ContextMenu(nameof(PrintNames))]
        public void PrintNames()
        {
            
            print(JsonConvert.SerializeObject(Find()));
            print(JsonConvert.SerializeObject(FindTwo()));
        }
    }
}