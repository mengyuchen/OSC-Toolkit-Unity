using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSCUserObjDist : OSCSender
{
    [SerializeField] Transform user;
    [SerializeField] Transform target;
    private float distance;
    [SerializeField] private bool directSend = true;
    [SerializeField] private bool debugMessage = false;
    private OSCCentralPosition oscCentralPos;
    // void Awake()
    // {
    //     if (!directSend)
    //     {
    //         oscCentralPos = GetComponent<OSCCentralPosition>();
    //     }
    // }
    public override void Start(){
    	base.Start();
    	if (!directSend){
    		Debug.Log("not direct send find object in start");
    		oscCentralPos = GetComponent<OSCCentralPosition>();
    	}
    }
    void Update()
    {
        if (directSend)
        {
            distance = Vector3.Distance(user.position, target.position);
        }
        else
        {
            distance = Vector3.Distance(user.position, oscCentralPos.objectPosition);
        }
		SendMessage();
    }
    public override void SendMessage()
    {
        if (debugMessage) {
        	Debug.Log("sending " + distance);
        }
        OSCMethods.SendFloatSingle(base.osc, base.OSCAddress, distance);
    }

}
