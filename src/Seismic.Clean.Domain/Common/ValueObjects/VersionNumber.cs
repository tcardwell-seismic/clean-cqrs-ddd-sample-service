namespace Seismic.Clean.Domain.Common.ValueObjects
{
    public class VersionNumber
    {
        public int MajorVersion { get; private set; }
        public int MinorVersion { get; private set; }

        public static VersionNumber InitialVersion = new VersionNumber(1, 0);

        private VersionNumber() { }
        private VersionNumber(int majorVersion, int minorVersion)
        {
            MajorVersion = majorVersion;
            MinorVersion = minorVersion;
        }

        public static VersionNumber From(int majorVersion, int minorVersion)
        {
            if (majorVersion < 0) majorVersion = 0;
            if (minorVersion < 0) minorVersion = 0;
            return new VersionNumber(majorVersion, minorVersion);
        }

        public VersionNumber GetNextMajorVersion()
        {
            return new VersionNumber(MajorVersion + 1, 0);
        }

        public VersionNumber GetNextMinorVersion()
        {
            return new VersionNumber(MajorVersion, MinorVersion + 1);
        }

        // TODO Add comparator here
    }
}