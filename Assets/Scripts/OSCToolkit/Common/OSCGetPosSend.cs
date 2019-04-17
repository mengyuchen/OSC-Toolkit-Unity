using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSCGetPosSend : OSCSender {

	private Vector3 objectPos;
	private OSCCentralPosition oscCentralPos;
	public override void Start(){
    	base.Start();
		oscCentralPos = GetComponent<OSCCentralPosition>();
	}
	
	// Update is called once per frame
	void Update () {
		objectPos = oscCentralPos.objectPosition;
		SendMessage();
	}
	public override void SendMessage(){
		OSCMethods.SendVector3(base.osc, base.OSCAddress, objectPos);
	}
}
