using UnityEditor;
using UnityEngine;

public class OctreeTest:MonoBehaviour
{
    public GameObject TestObject;
    
    private Octree ocTree; 

    void Start ()
    {
        var size = 1;
        ocTree = new Octree(
            size,
            -size,
            -size,
            size,
            size,
            -size,
            4
            );

        size = 10;
        for (var x = 0; x < size; x++)
        {
            for (var y = 0; y < size; y++)
            {
                for (var z = 0; z < size; z++)
                {
                    var position = new Vector3(x, y, z);
                    ocTree.AddNode(position,new OcTreeNodeObject(x+y+z, position));
                }
            }
        }
        
    }

    void OnDrawGizmos()
    {
        if (ocTree == null) return;

        var result = ocTree.Top.GetNodes(TestObject.transform.position, TestObject.renderer.bounds.size.x/2);


        foreach (var item in result)
        {
            var i = (OcTreeNodeObject) item;
            Gizmos.DrawWireCube(i.Position, Vector3.one);
        }

        Handles.Label(new Vector3(0, 0, 0), "result.Count :" + result.Count);
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
