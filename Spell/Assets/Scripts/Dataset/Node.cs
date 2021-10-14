using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public char Value { get; set; }
    public List<Node> Children { get; set; }
    public Node Parent { get; set; }
    public int Depth { get; set; }

    public Node(char value, int depth, Node parent)
    {
        Value = value;
        Children = new List<Node>();
        Depth = depth;
        Parent = parent;
    }

    public bool IsLeaf()
    {
        return Children.Count == 0;
    }

    public Node FindChildNode(char c)
    {
        foreach (var child in Children)
            if (child.Value == c)
                return child;

        return null;
    }
}
