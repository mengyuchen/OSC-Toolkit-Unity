using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleReceive : OSCReceiver {
	//how to use:
	//once you attach this code, in the GUI, you will need to fill the address handler name
	//this OSCReceiver will automatically check the address when it receives data
	//if matches the name, it will call onReceiveMessage() function below
	public override void onReceiveMessage(OscMessage message){
		//place your custom code here
		//this will be called automatically 
		//when the string handler name matches the message handler
		
		//example:
		// float x = message.GetFloat(0);
        // float y = message.GetFloat(1);
		// float z = message.GetFloat(2);
		// transform.position = new Vector3(x,y,z);
	}
}
