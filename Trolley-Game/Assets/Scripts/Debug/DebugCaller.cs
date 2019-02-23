#if UNITY_EDITOR
// Luke Mayo 2019
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEngine.UI;

public class DebugCaller : PrefabbedSingleton<DebugCaller> {
    public string MyText;
    public GameObject DisplayObject;
    Text commandText;
    MonoBehaviour[] Components;
    GameObject[] GameObjects;
    List<string> previousEntries = new List<string>();
    int currentEntry = -1;
    bool bActive;
    public string ColorCode = "0f0";

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init()
    {
        Instance();
    }

	// Use this for initialization
	protected override void Awake () {
        base.Awake();

        DisplayObject.SetActive(true);
        commandText = GetComponentInChildren<Text>();
        GetAllComponents();
        DisplayObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            if (bActive)
            {
                Deactivate();
                return;
            }
            else
            {
                Activate();
                return;
            }
        }

        if (!bActive)
            return;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            BackTrackCommands();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            AdvanceCommands();
        }
        else if (Input.inputString == "\b")
        {
            if (MyText.Length > 0)
            {
                MyText = MyText.Remove(MyText.Length - 1, 1);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            InvokeCurrentString();
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            AutoComplete(Input.GetKey(KeyCode.LeftShift));
        }
        else
        {
            MyText += Input.inputString;
        }

        string input = Input.inputString;
        if (input != "" && input != "\t")
        {
            currentAutoComplete = "";
        }

        commandText.text = "> " + MyText + "<color=#" + ColorCode + ">_</color>";
    }

    void GetAllComponents()
    {
        Components = FindObjectsOfType<MonoBehaviour>();
    }

    void GetAllGameObjects()
    {
        GameObjects = FindObjectsOfType<GameObject>();
    }

    void InvokeCurrentString()
    {
        string[] args = MyText.Split(' ', '(', ')');

        if (args.Length < 3)
        {
            Debug.Log("Needs three arguments");
            MyText = "";
            return;
        }

        string gameObjectName = args[0].ToUpper();
        string monoBehaviourName = args[1].ToUpper();
        string functionName = args[2];

        string[] arguments = new string[1];

        FindFunction(args, gameObjectName, monoBehaviourName, functionName);
    }

    void FindFunction(string[] args, string gameObjectName, string monoBehaviourName, string functionName)
    {
        object[] parameters = new object[1];

        foreach (MonoBehaviour component in Components)
        {
            if (component.gameObject.name.ToUpper() == gameObjectName)
            {
                if (component.GetType().ToString().ToUpper() == monoBehaviourName)
                {
                    MethodInfo method;

                    try
                    {
                        method = component.GetType().GetMethod(functionName);
                    }
                    catch(AmbiguousMatchException e)
                    {
                        Debug.Log("Template or Generic functions such as Foo<T> are not supported.");
                        return;
                    }

                    if (method == null)
                    {
                        Debug.Log("Method does not exist");
                        MyText = "";
                        return;
                    }

                    CallMethod(method, args, component);
                    ClearDialogue();
                    return;
                }
            }
        }

        Debug.Log("MonoBehaviour Not Found");
        MyText = "";
    }

    void CallMethod(MethodInfo method, string[] args, MonoBehaviour component)
    {
        ParameterInfo[] ParameterInfos = method.GetParameters();
        if (ParameterInfos != null && ParameterInfos.Length > 0)
        {
            if (args.Length - 3 < ParameterInfos.Length)
            {
                Debug.Log("Method requires " + ParameterInfos.Length.ToString() + " arguments. You have supplied none you big dummy.");
                return;
            }
            object[] parameters = new object[ParameterInfos.Length];
            for (int i = 0; i < method.GetParameters().Length; i++)
            {
                System.Type ParamType = method.GetParameters()[i].ParameterType;
                if (ParamType == typeof(int))
                {
                    int Param = 0;
                    if (int.TryParse(args[i + 3], out Param))
                    {
                        parameters[i] = Param;
                    }
                }
                if (ParamType == typeof(float))
                {
                    float Param = 0;
                    if (float.TryParse(args[i + 3], out Param))
                    {
                        parameters[i] = float.Parse(args[i + 3]);
                    }
                }
                if (ParamType == typeof(bool))
                {
                    bool Param = false;
                    if (bool.TryParse(args[i + 3], out Param))
                    {
                        parameters[i] = bool.Parse(args[i + 3]);
                    }
                }
            }

            method.Invoke(component, parameters);
        }
        else
        {
            component.Invoke(method.Name, 0);
        }
    }

    void Uhhh()
    {
        Debug.Log("Invoked Uhhh");
    }

    void ClearDialogue()
    {
        previousEntries.Insert(0, MyText);
        currentEntry = -1;
        MyText = "";
    }

    void BackTrackCommands()
    {
        if (previousEntries.Count > 0)
        {
            if (currentEntry < 0)
            {
                currentEntry = 0;
            }
            else
            {
                currentEntry++;
                if (currentEntry >= previousEntries.Count)
                {
                    currentEntry = previousEntries.Count - 1;
                }
            }

            if (currentEntry < previousEntries.Count)
            {
                MyText = previousEntries[currentEntry];
            }
        }
    }

    void AdvanceCommands()
    {
        if (currentEntry > -1)
        {
            currentEntry--;
            if (currentEntry <= -1)
            {
                MyText = "";
            }
            else
            {
                MyText = previousEntries[currentEntry];
            }
        }
    }

    void Activate()
    {
        bActive = true;
        DisplayObject.SetActive(true);
    }

    void Deactivate()
    {
        MyText = "";
        currentAutoComplete = "";
        autoCompleteIndex = 0;
        bActive = false;
        DisplayObject.SetActive(false);
    }

    string currentAutoComplete = "";
    int autoCompleteIndex = 0;
    List<string> autoCompleteOptions = new List<string>();

    void AutoComplete(bool bShiftIsDown)
    {
        string[] arguments = MyText.Split(' ');

        bool bIsMethod = arguments.Length == 3;
        bool bIsMonoBehaviour = arguments.Length == 2;
        bool bIsGameObject = arguments.Length == 1;

        bool bQueryUnset = currentAutoComplete == "";
        bool bArgumentIsTooSmall = currentAutoComplete.Length > arguments[arguments.Length - 1].Length;
        bool bArgumentDoesNotMatchLastQuery = arguments[arguments.Length - 1].Substring(0, currentAutoComplete.Length).ToUpper() != currentAutoComplete.ToUpper();

        if (bQueryUnset || (!bArgumentIsTooSmall && bArgumentDoesNotMatchLastQuery))
        {
            currentAutoComplete = arguments[arguments.Length - 1];

            autoCompleteOptions = new List<string>();
            autoCompleteIndex = 0;

            if (bIsMonoBehaviour)
            {
                GetMonoBehaviourMatches(arguments[0], arguments[arguments.Length-1]);
            }
            else if (bIsGameObject)
            {
                GetGameObjectMatches(arguments[arguments.Length - 1]);
            }
            else if (bIsMethod)
            {
                GetFunctionMatches(arguments[1] ,arguments[arguments.Length - 1]);
            }
            else
            {
                Debug.Log("AutoComplete operation could not complete -- too many arguments");
                return;
            }

            if (autoCompleteOptions.Count == 0)
            {
                Debug.Log("No Options Found.");
                return;
            }
        }
        else
        {
            if (bShiftIsDown)
            {
                autoCompleteIndex--;
                if (autoCompleteIndex < 0)
                {
                    autoCompleteIndex = autoCompleteOptions.Count - 1;
                }
            }
            else
            {
                autoCompleteIndex = (autoCompleteIndex + 1) % autoCompleteOptions.Count;
            }
        }

        if (bIsMonoBehaviour)
        {
            MyText = arguments[0] + " " + autoCompleteOptions[autoCompleteIndex];
        }
        else if (bIsGameObject)
        {
            MyText = autoCompleteOptions[autoCompleteIndex];
        }
        else if (bIsMethod)
        {
            MyText = arguments[0] + " " + arguments[1] + " " + autoCompleteOptions[autoCompleteIndex];
        }
    }

    void GetGameObjectMatches(string incomplete)
    {
        GetAllGameObjects();

        foreach(GameObject gObj in GameObjects)
        {
            CheckString(incomplete, gObj.name);
        }
    }

    void GetMonoBehaviourMatches(string gameObjectName, string incomplete)
    {
        GetAllGameObjects();

        foreach (GameObject gameObject in GameObjects)
        {
            if (gameObjectName == gameObject.name)
            {
                foreach (MonoBehaviour monoBehaviour in gameObject.GetComponents<MonoBehaviour>())
                {
                    CheckString(incomplete, monoBehaviour.GetType().ToString());
                }
                return;
            }
        }
    }

    void GetFunctionMatches(string monoName, string incomplete)
    {
        System.Type[] types = Assembly.GetExecutingAssembly().GetTypes();

        foreach (System.Type type in types)
        {
            if (type.ToString().ToUpper() == monoName.ToUpper())
            {
                foreach (MethodInfo method in type.GetMethods())
                {
                    CheckString(incomplete, method.Name);
                }
                return;
            }
        }

    }

    void CheckString(string incomplete, string target)
    {
        if (incomplete.Length > target.Length)
            return;

        if (target.Substring(0, incomplete.Length).ToUpper() == incomplete.ToUpper())
        {
            autoCompleteOptions.Add(target);
        }
    }

}

#endif 