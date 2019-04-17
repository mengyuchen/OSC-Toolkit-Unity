using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class OSCReceiver : MonoBehaviour {
	[SerializeField] public string OSCAddress = "/test";
	private OSC osc;
	void Start () {
		osc = FindObjectOfType<OSC>();
		// osc = GameObject.Find("OSCManager2").GetComponent<OSC>();
		osc.SetAddressHandler(OSCAddress, onReceiveMessage);
    }
	public abstract void onReceiveMessage(OscMessage message);

}
