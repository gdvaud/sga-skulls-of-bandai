using UnityEngine;

public class Manager : MonoBehaviour {

	public AppManager getAppManager() {
        return FindObjectOfType<AppManager>();
    }
}
