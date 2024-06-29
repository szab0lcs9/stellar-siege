using System;
using UnityEngine;

public class PathNode
{
    public Vector3 location;
    public float gCost;
    public float hCost;
    public float FCost { get { return gCost + hCost; }}
    public GameObject node;
    public PathNode parent;

    public PathNode(Vector3 location)
    {
        this.location = location;
    }

    public override bool Equals(object obj)
    {
        return obj is PathNode node &&
               location.Equals(node.location);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(location);
    }
}
