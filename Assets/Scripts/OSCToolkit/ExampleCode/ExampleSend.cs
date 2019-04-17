using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleSend : OSCSender {
	//how to use:
	//put this code onto an object, in the GUI, fill the address handler name
	//the message you compose will be sent out with the address handler name.
	void Update () {
		SendMessage();
	}
	public override void SendMessage(){
		OscMessage message = new OscMessage();
		message.address = base.OSCAddress; // where you will specify in the GUI

		//place your own send data here like below:
		// message.values.Add(transform.position.x);
		// message.values.Add(transform.position.y);
		// message.values.Add(transform.position.z);
		
		osc.Send(message);
	}
}
