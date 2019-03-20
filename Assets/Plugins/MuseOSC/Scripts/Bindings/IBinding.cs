using extOSC;

namespace MuseOSC
{
    public interface IBinding
    {
        void Parse(OSCMessage message);
    }
}