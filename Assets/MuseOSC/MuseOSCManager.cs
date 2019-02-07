using extOSC;
using UnityEngine;

namespace MuseOSC
{
    public class MuseOSCManager : MonoBehaviour
    {
        public delegate void ReceiveEEGDataHandler ();

        [SerializeField]
        private OSCReceiver receiver;
        [SerializeField]
        private MuseOSCManagerSettings settings;

        private void Start()
        {
            receiver.Bind(settings.eegPath, ReceiveEEGData);
        }

        private void ReceiveEEGData(OSCMessage message)
        {
            Debug.Log (message);
        }
    }
}
