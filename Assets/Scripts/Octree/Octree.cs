using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class Octree : IOctree
{
    protected internal OctreeNode Top;

    public Octree()
        : this(1.0f, 0.0f, 1.0f, 0.0f, 1.0f, 0.0f, 20, OctreeNode.NoMinSize)
    {
    }

    public Octree(float xMax, float xMin, float yMax, float yMin, float zMax, float zMin, int maxItems)
        : this(xMax, xMin, yMax, yMin, zMax, zMin, maxItems, OctreeNode.NoMinSize)
    {
    }

    public Octree(int up, int left, int down, int right, int front, int back, int maxItems)
        : this(
            up, left, down, right, front, back, maxItems,
            OctreeNode.DefaultMinSize)
    {
    }

    public Octree(float xMax, float xMin, float yMax, float yMin, float zMax, float zMin, int maxItems, float minSize)
    {
        Top = new OctreeNode(xMax, xMin, yMax, yMin, zMax, zMin, maxItems, minSize);
    }

    #region Add Node

    public bool AddNode(float x, float y, float z, object obj)
    {
        return Top.AddNode(x, y, z, obj);
    }

    public bool AddNode(Vector3 vector, object obj)
    {
        return Top.AddNode(vector.x, vector.y, vector.z, obj);
    }

    #endregion

    #region Remove Node
  
    public object RemoveNode(float x, float y, float z, object obj)
    {
        return Top.RemoveNode(x, y, z, obj);
    }

    public object RemoveNode(Vector3 vector, object obj)
    {
        return Top.RemoveNode(vector.x, vector.y, vector.z, obj);
    }

    #endregion

    #region Get Node

  
    public object GetNode(float x, float y, float z)
    {
        return Top.GetNode(x, y, z);
    }

    public object GetNode(Vector3 vector)
    {
        return Top.GetNode(vector.x, vector.y, vector.z);
    }

    public object GetNode(float x, float y, float z, double shortestDistance)
    {
        return Top.GetNode(x, y, z, shortestDistance);
    }

    public object GetNode(Vector3 vector, double shortestDistance)
    {
        return Top.GetNode(vector.x, vector.y, vector.z, shortestDistance);
    }
   
    public ArrayList GetNode(float xMax, float xMin, float yMax, float yMin, float zMax, float zMin)
    {
        return GetNode(xMax, xMin, yMax, yMin, zMax, zMin, ArrayList.Synchronized(new ArrayList(100)));
    }

    public ArrayList GetNode(float xMax, float xMin, float yMax, float yMin, float zMax, float zMin, ArrayList nodes)
    {
        if (nodes == null)
            nodes = ArrayList.Synchronized(new ArrayList(10));

        if (xMin > xMax || (Math.Abs(xMin - xMax) < 1e-6))
            return Top.GetNode(xMax, xMin, yMax, yMin, zMax, zMin, Top.GetNode(xMax, 0, yMax, yMin, zMax, zMin, nodes));
        
        return Top.GetNode(xMax, xMin, yMax, yMin, zMax, zMin, nodes);
    }


    #endregion

    #region Get Nodes

    public ArrayList GetNodes(float x, float y, float z, double radius)
    {
        return Top.GetNodes(x, y, z, radius);
    }

    public ArrayList GetNodes(Vector3 vector, double radius)
    {
        return Top.GetNodes(vector.x, vector.y, vector.z, radius);
    }

    public ArrayList GetNodes(float x, float y, float z, double minRadius, double maxRadius)
    {
        return Top.GetNodes(x, y, z, minRadius, maxRadius);
    }

    public ArrayList GetNodes(Vector3 vector, double minRadius, double maxRadius)
    {
        return Top.GetNodes(vector.x, vector.y, vector.z, minRadius, maxRadius);
    }

    #endregion

    public void Clear()
    {
        Top.Clear();
    }

}