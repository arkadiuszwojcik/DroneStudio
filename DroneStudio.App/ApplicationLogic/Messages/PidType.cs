namespace DroneStudio.ApplicationLogic.Messages
{
    public enum PidType
    {
        StabilizeYaw,
        StabilizeRoll,
        StabilizePitch,
        RateYaw,
        RateRoll,
        RatePitch,
        Unknown,
    }

    public static class PidTypeExtensions
    {
        public static string FormatToString(this PidType pidType)
        {
            switch (pidType)
            {
                case PidType.StabilizeRoll:
                    return "A";
                case PidType.StabilizePitch:
                    return "B";
                case PidType.StabilizeYaw:
                    return "C";
                case PidType.RateRoll:
                    return "D";
                case PidType.RatePitch:
                    return "E";
                case PidType.RateYaw:
                    return "F";
                default:
                    return "?";
            }
        }

        public static PidType ToPidType(this string str)
        {
            switch (str)
            {
                case "A":
                    return PidType.StabilizeRoll;
                case "B":
                    return PidType.StabilizePitch;
                case "C":
                    return PidType.StabilizeYaw;
                case "D":
                    return PidType.RateRoll;
                case "E":
                    return PidType.RatePitch;
                case "F":
                    return PidType.RateYaw;
                default:
                    return PidType.Unknown;
            }
        }
    }
}
