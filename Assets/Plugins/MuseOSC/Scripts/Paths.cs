namespace MuseOSC
{
    public static class Paths
    {
        public static string EEG_PATH = "eeg";
        public static string EEG_VARIANCE_PATH = "variance_eeg";
        public static string NOTCH_FILTERED_EEG_PATH = "notch_filtered_eeg";
        public static string NOTCH_FILTERED_EEG_VARIANCE_PATH = "notch_filtered_eeg_variance";
        public static string ACCELEROMETER_PATH = "acc";
        public static string GYROSCOPE_PATH = "gyro";

        //Ordered according to Muse feature enum
        public static string[] PATHS = { EEG_PATH, EEG_VARIANCE_PATH, NOTCH_FILTERED_EEG_PATH, NOTCH_FILTERED_EEG_VARIANCE_PATH, ACCELEROMETER_PATH, GYROSCOPE_PATH };

        public static string GetPathFormatted (string deviceName, Feature feature)
        {
            return string.Format("{0}/{1}", deviceName, PATHS[(int)feature]);
        }
    }
}