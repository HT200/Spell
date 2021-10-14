using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Import : MonoBehaviour
{
    public Trie TrieTree
    {
        get { return TrieTree; }
    }
    
    private Trie trieTree;
    
    void Awake()
    {
        trieTree = gameObject.AddComponent<Trie>();
        
        string filePath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, "english");

        try
        {
            using (StreamReader sr = File.OpenText(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    trieTree.Insert(line);
                }
            }
        }
        catch (Exception Ex)
        {
            Debug.LogError(Ex.ToString());
        }
    }
}
