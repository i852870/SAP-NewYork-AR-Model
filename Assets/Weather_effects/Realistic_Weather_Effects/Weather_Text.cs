using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Weather_Text : MonoBehaviour
{
	string JSON_Name;
	string JSON_Country;
	string JSON_Temperature;
	string JSON_Weather;
	string path;
	string Url;
	float temperature;
	public int StateWeather;

    //using SAP API management services

	string Zero;
	WWW www;
	string url = "https://i852870trial-trial.apim1.hanatrial.ondemand.com/i852870trial/management";

   
	void Start() // Use this for initialization
    {
		www = new WWW(url);
		StartCoroutine(WaitForRequest(www));



    }

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;

		// check for errors
		if (www.error == null)
		{
			string work = www.text;

			_Particle fields = JsonUtility.FromJson<_Particle>(work);
			JSON_Name = fields.location.name;
			JSON_Country = fields.location.country;
			JSON_Weather = fields.current.condition.text;
			JSON_Temperature = fields.current.temp_f;
			temperature = float.Parse (JSON_Temperature);
			Debug.Log (JSON_Name);
			Debug.Log (JSON_Country);
			Debug.Log (JSON_Weather);
			Debug.Log (JSON_Temperature);
		} else {

		}    
	}

    // Update is called once per frame
    void Update()
    {

		GetComponent<TextMesh>().text = temperature.ToString("f0")+"° F " + "in \n " + JSON_Name + ",\n " + JSON_Country;
		if (JSON_Weather == "Overcast" || JSON_Weather == "Partly cloudy") {
			StateWeather = 5;
			Debug.Log (StateWeather);
		}
		else if (JSON_Weather == "Sunny"){
				StateWeather = 3;
				Debug.Log (StateWeather);
		}
		else if (JSON_Weather == "Clear"){
			StateWeather = 2;
			Debug.Log (StateWeather);
		}
		

	 }


	[System.Serializable]
	public class _condition{
		public string text;

	}

	[System.Serializable]
	public class _location{
		public string name;
		public string country;

	}

	[System.Serializable]
	public class _current{
		public _condition condition;
		public string temp_f;

	}


	[System.Serializable]
	public class _Particle{
		public _condition condition;
		public _location location;
		public _current current;
		public string temp;
		public string main;
	}




}
