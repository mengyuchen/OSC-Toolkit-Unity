using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void MessageTransformMapFunc(OscMessage message, Transform transform);
public class OSCTransformReceive : OSCReceiver {
	MessageTransformMapFunc[] transformFuncs = {
		OSCMethods.MapPosition, 
		OSCMethods.MapRotationEuler, 
		OSCMethods.MapRotationQuat,
		OSCMethods.MapScale, 
		OSCMethods.MapScaleSingle
	};
	public enum MapFunction{
		MapPosition, MapRotationEuler, MapRotationQuat, MapScale, MapScaleSingle
	}
	public MapFunction function;
	[SerializeField] private bool debugMessage = false;
	// Use this for initialization
	public override void onReceiveMessage(OscMessage message){
		transformFuncs[(int)function](message, this.transform);
		if (debugMessage){
			Debug.Log(OSCAddress + " received message " + message.address);
		}
	}
}
