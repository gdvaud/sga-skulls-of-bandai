using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneManagerBase : Manager {

    public bool isLoading;

    public abstract void ChangeScene(string name);
    public abstract void ChangeScene(int id);
}
