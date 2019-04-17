using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSCAzimuth : MonoBehaviour {
	[SerializeField] private string OSCAddress = "/test";
	[SerializeField] private OSC osc;
	 [SerializeField] Transform user;
	 [SerializeField] Transform userRot;
    [SerializeField] Transform target;
    private float angle;
	private Vector3 targetDir;
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
    public void Start(){
    	// base.Start();
    	if (!directSend){
    		Debug.Log("not direct send find object in start");
    		oscCentralPos = GetComponent<OSCCentralPosition>();
    	}
    }
    void Update()
    {
        if (directSend)
        {
			targetDir = target.position - user.position;
            angle = Vector3.SignedAngle(targetDir, userRot.rotation * Vector3.forward, Vector3.up);
        }
        else
        {
			targetDir = oscCentralPos.objectPosition - user.position;
            angle = Vector3.SignedAngle(targetDir, userRot.rotation * Vector3.forward, Vector3.up);
        }
		SendMessage();
    }
    public void SendMessage()
    {
        if (debugMessage) {
        	Debug.Log("sending " + angle);
        }
        OSCMethods.SendFloatSingle(osc, OSCAddress, angle);
    }
}
