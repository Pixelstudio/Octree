using System;

[Serializable]
public class OctreeBox
{
    private float top;
    private float bottom;
    private float left;
    private float right;
    private float front;
    private float back;

    public OctreeBox(float xMax, float xMin, float yMax, float yMin, float zMax, float zMin)
    {
        right = xMax;
        left = xMin;
        front = yMax;
        back = yMin;
        top = zMax;
        bottom = zMin;
    }

    public bool Within(OctreeBox box)
    {
        return Within(box.Top, box.Left, box.Bottom, box.Right, box.Front, box.Back);
    }

    public bool Within(float xMax, float xMin, float yMax, float yMin, float zMax, float zMin)
    {
        if (xMin >= Right ||
            xMax < Left ||
            yMin >= Front ||
            yMax < Back ||
            zMin >= Top ||
            zMax < Bottom)
            return false;

        return true;
    }

    public bool PointWithinBounds(float x, float y, float z)
    {
        return x <= Right &&
               x > Left &&
               y <= Front &&
               y > Back &&
               z <= Top &&
               z > Bottom;
    }

    public double BorderDistance(float x, float y, float z)
    {
        double nsdistance;
        double ewdistance;
        double fbdistance;

        if (Left <= x && x <= Right)
            ewdistance = 0;
        else
            ewdistance = Math.Min((Math.Abs(x - Right)), (Math.Abs(x - Left)));

        if (Front <= y && y <= Back)
            fbdistance = 0;
        else
            fbdistance = Math.Min(Math.Abs(y - Back), Math.Abs(y - Front));

        if (Bottom <= z && z <= Top)
            nsdistance = 0;
        else
            nsdistance = Math.Min(Math.Abs(z - Top), Math.Abs(z - Bottom));

        return Math.Sqrt(nsdistance*nsdistance +
                         ewdistance*ewdistance +
                         fbdistance*fbdistance);
    }

    public float Right
    {
        get { return right; }
        set { right = value; }
    }

    public float Left
    {
        get { return left; }
        set { left = value; }
    }

    public float Front
    {
        get { return front; }
        set { front = value; }
    }

    public float Back
    {
        get { return back; }
        set { back = value; }
    }

    public float Top
    {
        get { return top; }
        set { top = value; }
    }

    public float Bottom
    {
        get { return bottom; }
        set { bottom = value; }
    }

}