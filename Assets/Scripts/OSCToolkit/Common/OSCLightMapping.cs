using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public delegate void MessageLightMap(OscMessage message, Light light, LightData lightdata);
public struct LightData{
	public Gradient colorGradient;
	public Vector2 inputRange;
	public Vector2 outputRange;
}
public class OSCLightMapping : OSCReceiver {
	
	[SerializeField] private Gradient colorGradient;
	[SerializeField]private Vector2 inputRange = new Vector2(0.0f, 1.0f);
	[SerializeField]private Vector2 outputRange = new Vector2(0.0f, 1.0f);
	[SerializeField] private bool debugMessage = false;
	private Light light;
	// [SerializeField] bool intensity = true;
	MessageLightMap[] MapLightFuncs = {MapColorGradient, MapColorVec3, MapIntensity};
	public enum MapFunction{MapColorGradient, MapColorVec3, MapIntensity}
	public MapFunction function;
	private LightData lightdata;

	void Awake() {
		light = GetComponent<Light>();
		lightdata.colorGradient = colorGradient;
		lightdata.inputRange = inputRange;
		lightdata.outputRange = outputRange;
	}
	public override void onReceiveMessage(OscMessage message)
    {
        if (debugMessage){
        	Debug.Log("light control received: " + message.address + " with value:" + message.GetFloat(0));
		}
		MapLightFuncs[(int)function](message, light, lightdata);
		// UpdateLight(message);
        
    }
	void UpdateLight(OscMessage message){
		// float val = message.GetFloat(0);
		// val = Unicom.Utility.MapValue(val, 0.0f, 1000.0f, 0.0f, 1.0f);
		// Mathf.Clamp(val, 0.0f, 1.0f);
		// if (!intensity){
		// 	light.color = colorGradient.Evaluate(val);
		// }else {
		// 	light.intensity = val;
		// }
	}
	static void MapColorGradient(OscMessage message, Light light, LightData lightdata){
		float val = message.GetFloat(0);
		val = Unicom.Utility.MapValue(val, lightdata.inputRange.x, lightdata.inputRange.y, lightdata.outputRange.x, lightdata.outputRange.y);
		// Mathf.Clamp(val, 0.0f, 1.0f);
		light.color = lightdata.colorGradient.Evaluate(val);
	}
	static void MapColorVec3(OscMessage message, Light light, LightData lightdata){
		float r = message.GetFloat(0);
		float g = message.GetFloat(1);
		float b = message.GetFloat(2);
		light.color = new Color(r,g,b);
	}
	static void MapIntensity(OscMessage message, Light light, LightData lightdata){
		float val = message.GetFloat(0);
		val = Unicom.Utility.MapValue(val, lightdata.inputRange.x, lightdata.inputRange.y, lightdata.outputRange.x, lightdata.outputRange.y);
		// Mathf.Clamp(val, 0.0f, 1.0f);
		light.intensity = val;
	}
}
