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
        [NamedArrayAttribute(new string[] { "EEG", "EEGVariance", "NotchFilteredEEG", "NotchFilteredEEGVariance", "Accelerometer", "Gyroscope" })]
        [SerializeField]
        private bool[] isTracked;
        private Vector3Binding accelerometerBinding;
        private Vector3Binding gyroscopeBinding;

        public float[] EEG
        {
            get; private set;
        }

        public float[] EEGVariance
        {
            get; private set;
        }

        public float[] NotchFilteredEEG
        {
            get; private set;
        }

        public float[] NotchFilteredEEGVariance
        {
            get; private set;
        }

        public Vector3? Accelerometer
        {
            get
            {
                return accelerometerBinding != null ? accelerometerBinding.Value : null;  
            }
        }

        public Vector3? Gyroscope
        {
            get
            {
                return gyroscopeBinding != null ? gyroscopeBinding.Value : null;
            }
        }

        private void Start()
        {
            if (isTracked[(int)Feature.EEG])
            {
                EEG = new float[6];
                receiver.Bind(Paths.GetPathFormatted(deviceName,Feature.EEG), new FloatArrayBinding(EEG).Parse);
            }
            if (isTracked[(int)Feature.EEG_VARIANCE])
            {
                EEGVariance = new float[4];
                receiver.Bind(Paths.GetPathFormatted(deviceName, Feature.EEG_VARIANCE), new FloatArrayBinding(EEGVariance).Parse);
            }
            if (isTracked[(int)Feature.NOTCH_FILTERED_EEG])
            {
                NotchFilteredEEG = new float[4];
                receiver.Bind(Paths.GetPathFormatted(deviceName, Feature.NOTCH_FILTERED_EEG), new FloatArrayBinding(NotchFilteredEEG).Parse);
            }
            if (isTracked[(int)Feature.NOTCH_FILTERED_EEG_VARIANCE])
            {
                NotchFilteredEEGVariance = new float[4];
                receiver.Bind(Paths.GetPathFormatted(deviceName, Feature.NOTCH_FILTERED_EEG_VARIANCE), new FloatArrayBinding(NotchFilteredEEGVariance).Parse);
            }
            if (isTracked[(int)Feature.ACCELEROMETER])
            {
                accelerometerBinding = new Vector3Binding();
                receiver.Bind(Paths.GetPathFormatted(deviceName, Feature.ACCELEROMETER), accelerometerBinding.Parse);
            }
            if (isTracked[(int)Feature.GYROSCOPE])
            {
                gyroscopeBinding = new Vector3Binding();
                receiver.Bind(Paths.GetPathFormatted(deviceName, Feature.GYROSCOPE), gyroscopeBinding.Parse);
            }
        }
    }
}
