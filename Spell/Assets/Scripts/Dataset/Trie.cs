using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trie : MonoBehaviour
{
    private readonly Node _root;

    public Trie()
    {
        _root = new Node('^', 0, null);
    }

    /// <summary>
    /// Get length of string at the current node
    /// </summary>
    public Node Prefix(string s)
    {
        var currentNode = _root;
        var result = currentNode;

        foreach (var c in s)
        {
            currentNode = currentNode.FindChildNode(c);
            if (currentNode == null)
                break;
            result = currentNode;
        }

        return result;
    }

    /// <summary>
    /// Search if a string is in the dataset
    /// </summary>
    /// <param name="s">String to be searched</param>
    public bool Search(string s)
    {
        var prefix = Prefix(s);
        return prefix.Depth == s.Length && prefix.FindChildNode('$') != null;
    }

    /// <summary>
    /// Add a string to the dataset
    /// </summary>
    /// <param name="s">String to be added</param>
    public void Insert(string s)
    {
        var commonPrefix = Prefix(s);
        var current = commonPrefix;

        for (var i = current.Depth; i < s.Length; i++)
        {
            var newNode = new Node(s[i], current.Depth + 1, current);
            current.Children.Add(newNode);
            current = newNode;
        }

        current.Children.Add(new Node('$', current.Depth + 1, current));
    }
}
