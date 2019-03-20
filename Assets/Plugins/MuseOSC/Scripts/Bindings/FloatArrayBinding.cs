using extOSC;

namespace MuseOSC
{
    public class FloatArrayBinding : IBinding
    {
        private float[] values;

        public FloatArrayBinding(float[] values)
        {
            this.values = values;
        }

        public void Parse(OSCMessage message)
        {
            for (int i = 0; i < values.Length; i++)
                values[i] = message.Values[i].FloatValue;   
        }
    }
}