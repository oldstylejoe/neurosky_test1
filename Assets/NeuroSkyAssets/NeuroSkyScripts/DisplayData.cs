using UnityEngine;
using System.Collections;

public class DisplayData : MonoBehaviour
{
    public UpdateScroll lineDrawer;
    public UpdateScroll alphaDrawer;
    public UpdateScroll attentionDrawer;
    public UpdateScroll meditationDrawer;
    public Texture2D[] signalIcons;

    public float scaleData = 2048.0f;
    public float scaleAlpha = 2048.0f;
    public float scaleAttention = 2048.0f;
    public float scaleMeditation = 2048.0f;

    private int indexSignalIcons = 1;
	
    TGCConnectionController controller;

    private int poorSignal1;
    private int attention1;
    private int meditation1;
	
	private float delta;

    void Start()
    {
		
		controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
		
		controller.UpdatePoorSignalEvent += OnUpdatePoorSignal;
		//controller.UpdateAttentionEvent += OnUpdateAttention;
		//controller.UpdateMeditationEvent += OnUpdateMeditation;

        controller.UpdateRawdataEvent += OnUpdateRaw;
        controller.UpdateAttentionEvent += OnUpdateAttention2;
        controller.UpdateMeditationEvent += OnUpdateMeditation2;
        controller.UpdateHighAlphaEvent += OnUpdateAlpha;

        //controller.UpdateDeltaEvent += OnUpdateDelta;

    }

    void OnUpdateAttention2(int value)
    {
        //Debug.Log("gh1: "+value.ToString());
        attentionDrawer.AddPoint((float)value / scaleAttention);
    }

    void OnUpdateMeditation2(int value)
    {
        //Debug.Log("gh1: "+value.ToString());
        meditationDrawer.AddPoint((float)value / scaleMeditation);
    }

    void OnUpdateAlpha(float value)
    {
        //Debug.Log("gh1: "+value.ToString());
        alphaDrawer.AddPoint((float)value / scaleAlpha);
    }

    void OnUpdateRaw(int value)
    {
        //Debug.Log("gh1: "+value.ToString());
        lineDrawer.AddPoint((float)value / scaleData);
    }

    void OnUpdatePoorSignal(int value){
		poorSignal1 = value;
		if(value < 25){
      		indexSignalIcons = 0;
		}else if(value >= 25 && value < 51){
      		indexSignalIcons = 4;
		}else if(value >= 51 && value < 78){
      		indexSignalIcons = 3;
		}else if(value >= 78 && value < 107){
      		indexSignalIcons = 2;
		}else if(value >= 107){
      		indexSignalIcons = 1;
		}
	}
	void OnUpdateAttention(int value){
		attention1 = value;
	}
	void OnUpdateMeditation(int value){
		meditation1 = value;
	}
	void OnUpdateDelta(float value){
		delta = value;
	}


    void OnGUI()
    {
		GUILayout.BeginHorizontal();
		
		
        if (GUILayout.Button("Connect"))
        {
            controller.Connect();
        }
        if (GUILayout.Button("DisConnect"))
        {
            controller.Disconnect();
			indexSignalIcons = 1;
        }
		
		GUILayout.Space(Screen.width-250);
		GUILayout.Label(signalIcons[indexSignalIcons]);
		
		GUILayout.EndHorizontal();

		
        GUILayout.Label("PoorSignal1:" + poorSignal1);
        GUILayout.Label("Attention1:" + attention1);
        GUILayout.Label("Meditation1:" + meditation1);
		GUILayout.Label("Delta:" + delta);

    }
}
