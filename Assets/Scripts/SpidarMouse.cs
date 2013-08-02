using UnityEngine;
using System.Collections;

public class SpidarMouse : MonoBehaviour {

    [System.Runtime.InteropServices.DllImport("Assets\\Scripts\\SpidarMouse")]
	private static extern int OpenSpidarMouse();

    [System.Runtime.InteropServices.DllImport("Assets\\Scripts\\SpidarMouse")]
	public static extern void SetForce(float Force_XScale, float Force_YScale, int duration);

    [System.Runtime.InteropServices.DllImport("Assets\\Scripts\\SpidarMouse")]
    private static extern bool CloseSpidarMouse();

    private	bool _IsConnected = false;
    private float _forceRatio = 1.0f;
	private string _dllpath;
		
	readonly private int _DURATION = 50;

    private static SpidarMouse instance = null;
    // sindleton
    public static SpidarMouse Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("SpidarMouse").AddComponent<SpidarMouse>();
            }

            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

	// Use this for initialization
	void Start () 
	{
        if (OpenSpidarMouse() == 1)
		{
            this.IsConnected = true;
		}
        else
		{
			Debug.LogError("SPIDAR-mouse failed to initialize.");
            this.IsConnected = false;
		}
	}

    public void SetForce2D(float Force_XScale, float Force_YScale)
    {
        SetForce(Force_XScale * _forceRatio, Force_YScale * _forceRatio, _DURATION);
    }

    public void SetForce2D(float Force_XScale, float Force_YScale, int duration)
    {
        SetForce(Force_XScale * _forceRatio, Force_YScale * _forceRatio, duration);
    }

    public float forceRatio
    {
        get { return _forceRatio; }
        set { _forceRatio = value; }
    }

    public bool IsConnected
    {
        get { return _IsConnected; }
        set { _IsConnected = value; }
    }
  
    void Destroy()
    {
        Debug.Log("Destroy");
        CloseSpidarMouse();
    }

    void OnDestroy()
    {
        Destroy();
    }
}