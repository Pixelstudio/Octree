using System.Collections;
using UnityEngine;

public interface IOctree
{
    bool AddNode(float x, float y, float z, object obj);
    bool AddNode(Vector3 vector, object obj);
   
    object RemoveNode(float x, float y, float z, object obj);
    object RemoveNode(Vector3 vector, object obj);
  
    void Clear();

    object GetNode(float x, float y, float z);
    object GetNode(Vector3 vector);
    object GetNode(float x, float y, float z, double shortestDistance);
    object GetNode(Vector3 vector, double shortestDistance);
 
    ArrayList GetNodes(float x, float y, float z, double radius);
    ArrayList GetNodes(Vector3 vector, double radius);
    ArrayList GetNodes(float x, float y, float z, double minRadius, double maxRadius);
    ArrayList GetNodes(Vector3 vector, double minRadius, double maxRadius);
    ArrayList GetNode(float xMax, float xMin, float yMax, float yMin, float zMax, float zMin);
}
