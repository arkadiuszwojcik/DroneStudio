using System.Runtime.InteropServices;

namespace DroneStudio.Modules.Settings.Eeprom
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MulticopterEeprom
    {
        [EepromField(0, typeof(float), "GYRO_OFFSET_X")]
        float GyroscopeOffsetX;
        [EepromField(4, typeof(float), "GYRO_OFFSET_Y")]
        float GyroscopeOffsetY;
        [EepromField(8, typeof(float), "GYRO_OFFSET_Z")]
        float GyroscopeOffsetZ;
        [EepromField(12, typeof(float), "ACC_OFFSET_X")]
        float AccelerometerOffsetX;
        [EepromField(16, typeof(float), "ACC_OFFSET_Y")]
        float AccelerometerOffsetY;
        [EepromField(20, typeof(float), "ACC_OFFSET_Z")]
        float AccelerometerOffsetZ;
        [EepromField(24, typeof(float), "MAGN_OFFSET_X")]
        float MagnetometerOffsetX;
        [EepromField(28, typeof(float), "MAGN_OFFSET_Y")]
        float MagnetometerOffsetY;
        [EepromField(32, typeof(float), "MAGN_OFFSET_Z")]
        float MagnetometerOffsetZ;
        [EepromField(36, typeof(float), "MAGN_DECLINATION")]
        float MagnetometerDeclination;
        [EepromField(40, typeof(float), "STAB_ROLL_PID_P")]
        float StabilizeRollP;
        [EepromField(44, typeof(float), "STAB_ROLL_PID_I")]
        float StabilizeRollI;
        [EepromField(48, typeof(float), "STAB_ROLL_PID_D")]
        float StabilizeRollD;
        [EepromField(52, typeof(float), "STAB_ROLL_PID_I_MAX")]
        float StabilizeRollIMax;
        [EepromField(56, typeof(float), "RATE_ROLL_PID_P")]
        float RateRollP;
        [EepromField(60, typeof(float), "RATE_ROLL_PID_I")]
        float RateRollI;
        [EepromField(64, typeof(float), "RATE_ROLL_PID_D")]
        float RateRollD;
        [EepromField(68, typeof(float), "RATE_ROLL_PID_I_MAX")]
        float RateRollIMax;
        [EepromField(72, typeof(float), "STAB_PITCH_PID_P")]
        float StabilizePitchP;
        [EepromField(76, typeof(float), "STAB_PITCH_PID_I")]
        float StabilizePitchI;
        [EepromField(80, typeof(float), "STAB_PITCH_PID_D")]
        float StabilizePitchD;
        [EepromField(84, typeof(float), "STAB_PITCH_PID_I_MAX")]
        float StabilizePitchIMax;
        [EepromField(88, typeof(float), "RATE_PITCH_PID_P")]
        float RatePitchP;
        [EepromField(92, typeof(float), "RATE_PITCH_PID_I")]
        float RatePitchI;
        [EepromField(96, typeof(float), "RATE_PITCH_PID_D")]
        float RatePitchD;
        [EepromField(100, typeof(float), "RATE_PITCH_PID_I_MAX")]
        float RatePitchIMax;
        [EepromField(104, typeof(float), "STAB_YAW_PID_P")]
        float StabilizeYawP;
        [EepromField(108, typeof(float), "STAB_YAW_PID_I")]
        float StabilizeYawI;
        [EepromField(112, typeof(float), "STAB_YAW_PID_D")]
        float StabilizeYawD;
        [EepromField(116, typeof(float), "STAB_YAW_PID_I_MAX")]
        float StabilizeYawIMax;
        [EepromField(120, typeof(float), "RATE_YAW_PID_P")]
        float RateYawP;
        [EepromField(124, typeof(float), "RATE_YAW_PID_I")]
        float RateYawI;
        [EepromField(128, typeof(float), "RATE_YAW_PID_D")]
        float RateYawD;
        [EepromField(132, typeof(float), "RATE_YAW_PID_I_MAX")]
        float RateYawIMax;
        [EepromField(136, typeof(float), "PID_MIN_VALUE")]
        float MinPidValue;
        [EepromField(140, typeof(float), "PID_MAX_VALUE")]
        float MaxPidValue;
        [EepromField(144, typeof(short), "MOTOR_MIN_VALUE")]
        ushort MotorMinSignal;
        [EepromField(146, typeof(short), "MOTOR_MAX_VALUE")]
        ushort MotorMaxSignal;
    }
}
