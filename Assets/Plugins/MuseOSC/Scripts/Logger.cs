using System.Text;
using UnityEngine;

namespace MuseOSC
{
    public class Logger : MonoBehaviour
    {
        [SerializeField]
        private MuseOSCManager muse;
        private StringBuilder builder;

        private void Awake()
        {
            builder = new StringBuilder();
        }

        private void Update()
        {
            if (muse.EEG != null)
                LogArray("EEG", muse.EEG);
            if (muse.EEGVariance != null)
                LogArray("EEG_VARIANCE", muse.EEGVariance);
            if (muse.NotchFilteredEEG != null)
                LogArray("NOTCH_FILTERED_EEG", muse.NotchFilteredEEG);
            if (muse.NotchFilteredEEGVariance != null)
                LogArray("NOTCH_FILTERED_EEG_VARIANCE", muse.NotchFilteredEEGVariance);
            if (muse.Accelerometer != null)
                Debug.LogFormat("ACCELEROMETER: {0}", muse.Accelerometer.Value);
            if (muse.Gyroscope != null)
                Debug.LogFormat("GYROSCOPE: {0}", muse.Gyroscope.Value);
        }

        private void LogArray<T> (string label, T[] array)
        {
            builder.Remove(0, builder.Length);
            builder.Append(array[0]);
            for (int i = 01; i < array.Length; i++)
                builder.AppendFormat (", {0}", array[i]);
            Debug.LogFormat("{0}: {{ {1} }}", label, builder.ToString ());
        }
    }
}