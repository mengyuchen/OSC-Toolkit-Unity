using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSCCentralPosition : OSCReceiver
{

    [SerializeField] private int ObjectID = 0;
    [SerializeField] private int numObjects = 16;
    [SerializeField] private Vector3 center = new Vector3(0, 0, 0);
    [SerializeField] private bool directMap = true;
    [SerializeField] private bool lockYaxis = false;
	[SerializeField] private bool debugMessage = false;
	public float maxDistance = 15.0f;
    public float minDistance = 5.0f;
    [System.NonSerialized]public Quaternion objectRotation;
    [System.NonSerialized]public Vector3 objectPosition;
    [System.NonSerialized]public float distanceAway = 15;

    // Update is called once per frame
    void Update()
    {
        objectRotation = Quaternion.Euler(0, (float)360 / numObjects * ObjectID, 0);
        objectPosition = center + Quaternion.Euler(0, (float)360 / numObjects * ObjectID, 0) * Vector3.forward * distanceAway;
        if (directMap)
        {
            if (lockYaxis){
                transform.rotation = objectRotation;
            }
            transform.position = objectPosition;
        }
    }

    void GetDistance(OscMessage message)
    {
		float mDist = message.GetFloat(0);
        distanceAway = Unicom.Utility.MapValue(mDist, -17.0f, 0.0f, maxDistance, minDistance);

    }
    public override void onReceiveMessage(OscMessage message)
    {
		if (debugMessage){
        	Debug.Log("central pos received: " + message.address + " with value:" + message.GetFloat(0));
		}
        GetDistance(message);
    }
}
