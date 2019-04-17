using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class OSCSender : MonoBehaviour {

	[SerializeField] public string OSCAddress = "/test";
	[System.NonSerialized]public OSC osc;

	public virtual void Start () {
		// osc = FindObjectOfType<OSC>();
		osc = GameObject.Find("OSCManager").GetComponent<OSC>();
	}
	public abstract void SendMessage();
}
