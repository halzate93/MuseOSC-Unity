using extOSC;
using UnityEngine;

namespace MuseOSC
{
    public class MuseOSCManager : MonoBehaviour
    {
        [SerializeField]
        private string deviceName;
        [SerializeField]
        private OSCReceiver receiver;
        [SerializeField]
        private Feature[] trackedFeatures;

        public float[] EEG
        {
            get; private set;
        }

        private void Awake ()
        {
            EEG = new float[6];
        }

        private void Start()
        {
            receiver.Bind(Paths.GetPathFormatted(deviceName, Feature.EEG), ReceiveEEGData);
        }

        private void ReceiveEEGData(OSCMessage message)
        {
            for (int i = 0; i < message.Values.Count; i++)
                EEG[i] = message.Values[i].FloatValue;
            Debug.LogFormat("EEG:{0},{1},{2},{3},{4},{5}", EEG[0], EEG[1], EEG[2], EEG[3], EEG[4], EEG[5]);
        }
    }
}
