using UnityEngine;
using System.Collections;
using Leap;

public class RecordKeyTest : MonoBehaviour {

    private HandController controller;
    private LeapRecorder recorder = new LeapRecorder();

    [SerializeField] private KeyCode record = KeyCode.R;
    [SerializeField] private KeyCode finishAndSave = KeyCode.S;
    [SerializeField] private KeyCode playRecording = KeyCode.Space;
    [SerializeField] private KeyCode resetRecording = KeyCode.Z;

    private TextAsset recordFile;

    private string recordFilePath;


    void Start() {
         controller = GetComponent<HandController>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(record))
            recorder.Record();

        if (Input.GetKeyDown(finishAndSave))
        {
            recordFilePath = recorder.SaveToNewFile();
            Debug.Log("Recording saved to: " + recordFilePath);
        }

        if (Input.GetKeyDown(resetRecording)){
            recorder.Reset();
        }

        if (Input.GetKeyDown(playRecording)) {

            recordFile = (Resources.Load("Recording_20150919_111225.bytes") as TextAsset);
            Debug.Log(recordFilePath);
            Debug.Log(recordFile);
            recorder.Load(recordFile);
            recorder.Play();

        }

    }


}