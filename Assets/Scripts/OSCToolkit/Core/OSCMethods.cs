using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSCMethods : MonoBehaviour {
	static public void MapPosition(OscMessage message, Transform transform){
		float x = message.GetFloat(0);
        float y = message.GetFloat(1);
		float z = message.GetFloat(2);
		transform.position = new Vector3(x,y,z);
	}
	static public void MapRotationEuler(OscMessage message, Transform transform){
		float x = message.GetFloat(0);
        float y = message.GetFloat(1);
		float z = message.GetFloat(2);
		transform.rotation = Quaternion.Euler(x,y,z);
	}
	static public void MapRotationQuat(OscMessage message, Transform transform){
		float x = message.GetFloat(0);
        float y = message.GetFloat(1);
		float z = message.GetFloat(2);
		float w = message.GetFloat(3);
		transform.rotation = new Quaternion(x,y,z,w);
	}
	static public void MapScale(OscMessage message, Transform transform){
		float x = message.GetFloat(0);
        float y = message.GetFloat(1);
		float z = message.GetFloat(2);
		transform.localScale = new Vector3(x,y,z);
	}
	static public void MapScaleSingle(OscMessage message, Transform transform){
		float x = message.GetFloat(0);
		transform.localScale = new Vector3(x,x,x);
	}
	static public void SendPosition(OSC osc, string oscAddress, Transform transform){
		OscMessage message = new OscMessage();
		message.address = oscAddress;
		message.values.Add(transform.position.x);
		message.values.Add(transform.position.y);
		message.values.Add(transform.position.z);
		osc.Send(message);
	}
	static public void SendRotationEuler(OSC osc, string oscAddress, Transform transform){
		OscMessage message = new OscMessage();
		message.address = oscAddress;
		message.values.Add(transform.rotation.eulerAngles.x);
		message.values.Add(transform.rotation.eulerAngles.y);
		message.values.Add(transform.rotation.eulerAngles.z);
		// Debug.Log(transform.rotation.eulerAngles.x + " " + transform.rotation.eulerAngles.y + " " + transform.rotation.eulerAngles.z);
		osc.Send(message);
	}
	static public void SendRotationQuat(OSC osc, string oscAddress, Transform transform){
		OscMessage message = new OscMessage();
		message.address = oscAddress;
		message.values.Add(transform.rotation.x);
		message.values.Add(transform.rotation.y);
		message.values.Add(transform.rotation.z);
		message.values.Add(transform.rotation.w);
		osc.Send(message);
	}
	static public void SendScale(OSC osc, string oscAddress, Transform transform){
		OscMessage message = new OscMessage();
		message.address = oscAddress;
		message.values.Add(transform.localScale.x);
		message.values.Add(transform.localScale.y);
		message.values.Add(transform.localScale.z);
		osc.Send(message);
	}
	static public void SendScaleSingle(OSC osc, string oscAddress, Transform transform){
		OscMessage message = new OscMessage();
		message.address = oscAddress;
		message.values.Add(transform.localScale.x);
		osc.Send(message);
	}
	static public void SendFloatSingle(OSC osc, string oscAddress, float value){
		OscMessage message = new OscMessage();
		message.address = oscAddress;
		message.values.Add(value);
		osc.Send(message);
	}
	static public void SendVector3(OSC osc, string oscAddress, Vector3 vector){
		OscMessage message = new OscMessage();
		message.address = oscAddress;
		message.values.Add(vector.x);
		message.values.Add(vector.y);
		message.values.Add(vector.z);
		osc.Send(message);
	}
}
