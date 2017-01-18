using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class FEMCalibrator : MonoBehaviour {

	/**
	                                            ^ V
	 .-------> X                                |
	 |  n4-------n3              (-U/2, V/2)n4-------n3(U/2, V/2)
	 |  |        |       map                |   |    |
	 v  |        |      ----->              |   .----|--> U
	 Y  |        |                          |        |
		n1-------n2             (-U/2, -V/2)n1-------n2(U/2, V/2)
		 Color Space                         Game Space
	**/

	public GameObject node1;
	public GameObject node2;
	public GameObject node3;
	public GameObject node4;
	public float UVectorOfGameSpace = 960f;
	public float VVectorOfGameSpace = 540f;

    private KinectSensor kinectSensor;
    private CoordinateMapper coordinateMapper;

    // Use this for initialization
    void Start () {
        this.kinectSensor = KinectSensor.GetDefault();
        coordinateMapper = this.kinectSensor.CoordinateMapper;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // Map camera point to game space
    public Vector3 MapWorldPointToColorSpace(Vector3 worldPoint) {
        Vector3 colorPoint;

        var U = UVectorOfGameSpace;
        var V = VVectorOfGameSpace;

        var x = U - worldPoint.x;
        var y = V - worldPoint.y;

        colorPoint = new Vector3(x, y, 0);

        return colorPoint;
    }

    // Map camera point to game space
    public Vector3 MapInducingPointToWorldSpace(ColorSpacePoint colorPoint)
    {
        Vector3 worldPoint;

        var n1 = MapWorldPointToColorSpace(node1.transform.position);
        var n3 = MapWorldPointToColorSpace(node3.transform.position);

        var U = UVectorOfGameSpace;
		var V = VVectorOfGameSpace;

		var u = (2 * colorPoint.X - n1.x - n3.x) * U / (n3.x - n1.x);
		var v = (2 * colorPoint.Y - n1.y - n3.y) * V / (n3.y - n1.y);

        worldPoint = new Vector3(u, v, 0);

        return worldPoint;
	}

    // Debug
    private void PrintInducingPointToWorldSpace(float X, float Y)
    {
        var colorPoint = new ColorSpacePoint();
        colorPoint.X = X;
        colorPoint.Y = Y;
        print("MAP (" + X + ", " + Y + ") to " + this.MapInducingPointToWorldSpace(colorPoint).ToString());
    }
}
