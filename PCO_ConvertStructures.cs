using System;
using System.Collections.Generic;
using System.Text;

//Added References For StructLayout

using System.Runtime.InteropServices;
//

namespace PCOConvertStructures
{
    public unsafe class PCO_ConvertStructures
    {
        public const int BAYER_UPPER_LEFT_IS_RED = 0x000000000;
        public const int BAYER_UPPER_LEFT_IS_GREEN_RED = 0x000000001;
        public const int BAYER_UPPER_LEFT_IS_GREEN_BLUE = 0x000000002;
        public const int BAYER_UPPER_LEFT_IS_BLUE = 0x000000003;

        [StructLayout(LayoutKind.Sequential)]
        public struct SRGBCOLCORRCOEFF
        {
            public double da11, da12, da13;
            public double da21, da22, da23;
            public double da31, da32, da33;
        }//sRGB_color_correction_coefficients


        [StructLayout(LayoutKind.Sequential)]
        public struct PCO_SensorInfo
        {
            public ushort wSize;
            public ushort wDummy;
            public int iConversionFactor;              // Conversion factor of sensor in 1/100 e/count
            public int iDataBits;                      // Bit resolution of sensor
            public int iSensorInfoBits;                // Flags:
            // 0x00000001: Input is a color image (see Bayer struct!)
            // 0x00000002: Input is upper aligned
            public int iDarkOffset;                    // Hardware dark offset
            public int dwzzDummy0;
            public SRGBCOLCORRCOEFF strColorCoeff;      // 9 double -> 18int // 24 int
            public int iCamNum;                        // Camera number (enumeration of cameras controlled by app)
            public int hCamera;                      // Handle of the camera loaded, future use; set to zero.
            public fixed UInt32 dwzzDummy1[38];
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct PCO_Display
        {
            public ushort wSize;
            public ushort wDummy;
            public int iScale_maxmax;          // Maximum value for max 
            public int iScale_min;             // Lowest value for processing
            public int iScale_max;             // Highest value for processing
            public int iColor_temp;            // Color temperature  3500...20000
            public int iColor_tint;            // Color correction  -100...100 // 5 int
            public int iColor_saturation;      // Color saturation  -100...100
            public int iColor_vibrance;        // Color dynamic saturation  -100...100
            public int iContrast;              // Contrast  -100...100
            public int iGamma;                 // Gamma  -100...100
            public int iSRGB;				  // sRGB mode
            public byte* pucLut;                // Pointer auf Lookup-Table // 10 int
            public fixed UInt32 dwzzDummy1[52];
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct PCO_Bayer
        {
            public ushort wSize;
            public ushort wDummy;
            public int iKernel;
            public int iColorMode;
            public fixed UInt32 dwzzDummy1[61];
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct PCO_Filter
        {
            public ushort wSize;
            public ushort wDummy;
            public int iMode;
            public int iType;
            public int iSharpen;
            public fixed UInt32 dwzzDummy1[60];
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct PCO_Convert
        {
            public ushort wSize;
            public fixed ushort wDummy[3];
            public PCO_Display str_Display;     // Process settings for output image // 66 int
            public PCO_Bayer str_Bayer;       // Bayer processing settings // 130 int
            public PCO_Filter str_Filter;      // Filter processing settings // 198 int
            public PCO_SensorInfo str_SensorInfo;  // Sensor parameter // 258 int
            public int iData_Bits_Out;

            public uint dwModeBitsDataOut;
            public int iGPU_Processing_mode;// Mode for processing: 0->CPU, 1->GPU // 261 int
            public int iConvertType;
            public fixed UInt32 dwzzDummy1[58];             // 64 int
        };

        public const int PCO_CNV_DLG_CMD_CLOSING      = 0x0001; // Dialog is closing (bye, bye)
        public const int PCO_CNV_DLG_CMD_UPDATE       = 0x0002; // Changed values in dialog
        public const int PCO_CNV_DLG_CMD_WHITEBALANCE = 0x0010; // White balance button pressed
        public const int PCO_CNV_DLG_CMD_MINMAX       = 0x0011; // Minmax button pressed
        public const int PCO_CNV_DLG_CMD_MINMAXSMALL  = 0x0012; // Minmax small button pressed
        [StructLayout(LayoutKind.Sequential)]
        public struct PCO_ConvDlg_Message
        {
          public ushort wCommand;              // Command sent to the main application
          public PCO_Convert* pstrConvert;     // Pointer to the controlled PCO_Convert
          public int iXPos;                    // Actual left position
          public int iYPos;                    // Actual upper position
          public fixed UInt32 iReserved[10];   // Reserved for future use, set to zero.
        };

    }


}