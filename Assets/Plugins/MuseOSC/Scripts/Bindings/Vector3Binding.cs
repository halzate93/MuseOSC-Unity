using extOSC;
using UnityEngine;

namespace MuseOSC
{
    public class Vector3Binding: IBinding
    {
        private Vector3 value;

        public Vector3? Value
        { 
            get
            {
                return value;
            }
        }

        public Vector3Binding ()
        {
            value = new Vector3();
        }

        public void Parse(OSCMessage message)
        {
            value.x = message.Values[0].FloatValue;
            value.y = message.Values[1].FloatValue;
            value.z = message.Values[2].FloatValue;
        }
    }
}