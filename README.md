# Unity 3D Android NFC Plugin

This project illustrates how to read a NFC tag from Unity 3D using an Android native plugin.

## Usage

The plugin provides two different usage modes. A background scan mode, that catches any NFC tag (NDEF formatted) event fired during the scene execution, and an external reader mode (default mode) that opens a new screen to read the NFC tag.

The plugin functionality is exposed via the /Assets/Plugins/AndroidNFCReader.cs methods:

`void enableBackgroundScan()` configures the plugin to be used in background scan mode.

`void disableBackgroundScan()` disables the background scan mode, enabling the external reader mode.

`void ScanNFC(string objectName, string functionName)` configures the method to be fired after a NFC tag scan and fires the NFC scanning view if the background scan mode is disabled. These are the method params:

`objectName` name of the Game Object that includes the `functionName` declaration.

`functionName` method executed after a NFC event.

This snippet illustrates the main logic included required to setup the plugin: 

### Background Mode Example


```java

public class Main : MonoBehaviour
{
	void Start(){
		AndroidNFCReader.enableBackgroundScan ();
		AndroidNFCReader.ScanNFC (gameObject.name, "OnFinishScan");
	}
	
	...

	// NFC callback
	void OnFinishScan(string result) {
		if (result == AndroidNFCReader.CANCELLED) {
			// The user has canceled the scan (back button)
		} else if (result == AndroidNFCReader.ERROR) {
			// There was an error reading the NFC tag
		} else if (result == AndroidNFCReader.NO_HARDWARE) {
			// No NFC hardware available
		}
		// result contains the NFC tag text content
	}
	...
}

```

### External Reader Mode Example


```java

public class Main : MonoBehaviour
{

	void Foo ()
	{
		AndroidNFCReader.ScanNFC (gameObject.name, "OnFinishScan");
	}
	
	...

	// NFC callback
	void OnFinishScan(string result) {
		if (result == AndroidNFCReader.CANCELLED) {
			// The user has canceled the scan (back button)
		} else if (result == AndroidNFCReader.ERROR) {
			// There was an error reading the NFC tag
		} else if (result == AndroidNFCReader.NO_HARDWARE) {
			// No NFC hardware available
		}
		// result contains the NFC tag text content
	}
	...
}
```

Please check the /Assets/Scripts/Main.cs script, it provides a full example of the plugin usage.


## Integrate the NFC Plugin in your projects

1. To use the NFC Plugin you have to copy the content under the  /Assets/Plugins folder to your project /Assets/Plugins folder.

2. Then select the /Assets/Plugins/Android/AndroidScan(.jar) file and in the Plugin Inspector view check the Android platform.

3. Configure the scan model and call the `AndroidNFCReader.ScanNFC (gameObject.name, "OnFinishScan")` as described on the "Usage" section.

## Code Overview

[/Assets/Scripts/Main.cs](https://github.com/twisprite-developers/unity-nfc-plugin/blob/master/Assets/Scripts/Main.cs) illustrates the usage of the plugin in both background and external reader mode.

[/Assets/Plugins/AndroidNFCReader.cs](https://github.com/twisprite-developers/unity-nfc-plugin/blob/master/Assets/Plugins/AndroidNFCReader.cs) fires the native event to scan the NFC tag and retrieve the result.

[/Assets/Pugings/Android](https://github.com/twisprite-developers/unity-nfc-plugin/tree/master/Assets/Plugins/Android) includes the /Assets/Plugins/Android/AndroidScan(.jar) native Java code and the Android manifest file required by the project.


## Customize the NFC Plugin

If you want to generate your own native plugin, the [anroid-nfc-plugin](https://github.com/twisprite-developers/anroid-nfc-plugin) repository includes the Android Studio project to generate the AdroidScan.jar file inside the Plugins folder.

## License

The source code of this project is available under the [MIT](https://opensource.org/licenses/MIT) license.

The NFC image included in /Assets/Plugins/Android/res/drawable/nfc is available for free on the [Icons8 site](https://icons8.com/web-app/2305/nfc-sign).




