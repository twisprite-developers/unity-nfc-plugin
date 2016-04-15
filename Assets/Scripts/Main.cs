using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{

	string qrString = "";
	bool background = true;

	void Start(){
		AndroidNFCReader.enableBackgroundScan ();
		AndroidNFCReader.ScanNFC (gameObject.name, "OnFinishScan");
	}

	void OnGUI ()
	{
		if (!background) {
			// Scan NFC button
			if (GUI.Button (new Rect (0, Screen.height - 50, Screen.width, 50), "Scan NFC")) {
				AndroidNFCReader.ScanNFC (gameObject.name, "OnFinishScan");
			}
			if (GUI.Button (new Rect (0, Screen.height - 100, Screen.width, 50), "Enable Backgraound Mode")) {
				AndroidNFCReader.enableBackgroundScan ();
				background = true;
			}
		}else{
			if (GUI.Button (new Rect (0, Screen.height - 50, Screen.width, 50), "Disable Backgraound Mode")) {
				AndroidNFCReader.disableBackgroundScan ();
				background = false;
			}
		}
		GUI.Label (new Rect (0, 0, Screen.width, 50), "Result: " + qrString);
	}

	// NFC callback
	void OnFinishScan (string result)
	{

		// Cancelled
		if (result == AndroidNFCReader.CANCELLED) {
		
			// Error
		} else if (result == AndroidNFCReader.ERROR) {
		

			// No hardware
		} else if (result == AndroidNFCReader.NO_HARDWARE) {
		}


		qrString = getToyxFromUrl (result);
	}

	// Extract toyxId from url
	string getToyxFromUrl (string url)
	{		
		int index = url.LastIndexOf ('/') + 1;
		
		if (url.Length > index) {
			return url.Substring (index);		
		} 
		
		return url;
	}

}
