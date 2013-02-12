using System.Collections;
using System.Linq;
using UnityEditor;
using UnityEngine;
using System;

public class OctreeTest:MonoBehaviour
{
    public GameObject TestObject;
    private Octree ocTree;
    private Vector3 oldPos;
    private ArrayList result;
    
    private void Start ()
    {
        var size = 1;
        ocTree = new Octree( size,-size,-size,
                             size,size,-size,1);
    }

    void OnDrawGizmos()
    {
        if (result != null)
            foreach (var i in result.Cast<OcTreeNodeObject>())
                Gizmos.DrawWireCube(i.Position, Vector3.one);
            
        if (ocTree == null) return;
        if (oldPos == TestObject.transform.position) return;

        result = ocTree.Top.GetNodes(TestObject.transform.position, TestObject.renderer.bounds.size.x/2);
        if (result.Count == 0)
            ocTree.AddNode(TestObject.transform.position,  new OcTreeNodeObject(11, TestObject.transform.position));
        
        Handles.Label(new Vector3(0, 0, 0), "result.Count :" + result.Count);
        oldPos = TestObject.transform.position;
    }
}


class OcTreeNodeObject
{
    public Vector3 Position;
    public int Id;
    public Color Color;

    public OcTreeNodeObject(int id, Vector3 pos)
    {
        Id = id;
        Position = pos;
    }
}
