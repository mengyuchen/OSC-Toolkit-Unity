using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void MessageTransformSend(OSC osc, string oscAddress, Transform transform);
public class OSCTransformSend : OSCSender {
	MessageTransformSend[] transformSendFuncs = {
		OSCMethods.SendPosition,
		OSCMethods.SendRotationEuler,
		OSCMethods.SendRotationQuat,
		OSCMethods.SendScale,
		OSCMethods.SendScaleSingle
	};
	public enum MapFunction{
		SendPosition, SendRotationEuler, SendRotationQuat, SendScale, SendScaleSingle
	}
	public MapFunction function;
	private Transform mTransform;

	void Update(){
		mTransform = this.transform;
		SendMessage();
	}
	
	public override void SendMessage(){
		transformSendFuncs[(int)function](osc, OSCAddress, mTransform);
	}

}
