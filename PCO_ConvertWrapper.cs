using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using PCOConvertStructures;

namespace PCOConvertDll
{

    public unsafe class PCO_Convert_LibWrapper
    {
        #region Class Members
        public const int PCO_BW_CONVERT = 0;
        public const int PCO_COLOR_CONVERT = 2;
        public const int PCO_PSEUDO_CONVERT = 3;
        public const int PCO_COLOR16_CONVERT = 4;
        #endregion

        /**************************************************************************************************************************
         * PCO Convert Object API Calls
         * ***********************************************************************************************************************/
        #region PCO Convert Object API Calls

        /// <summary>
        /// Creates a new convert object based on the PCO_SensorInfor structure. Convert structure handle will be used during conversion.
        /// Call PCO_ConvertDelete to unload convert dll.
        /// </summary>
        /// <DEFANGED_param name="pHandle">Int handle to store the address of the created convert object</DEFANGED_param>
        /// <DEFANGED_param name="pSensorInfo">Pass by Ref SensorInfo structure</DEFANGED_param>
        /// <DEFANGED_param name="iConvertType">Int variable to determine the conversion type</DEFANGED_param>
        /// <returns>Int error code value</returns>
        [DllImport("PCO_Conv.dll", EntryPoint = "PCO_ConvertCreate",
            ExactSpelling = false)]
        public static extern int PCO_ConvertCreate(ref int pHandle, ref PCO_ConvertStructures.PCO_SensorInfo pSensorInfo, int iConvertType);
        /* int PCOCONVERT_API PCO_ConvertCreate((HANDLE* ph, PCO_SensorInfor* strSensor, int iConvertType - C++ function signature */

        /// <summary>
        /// Deletes a previously created convert object. Mandatory to call this before closing application
        /// </summary>
        /// <DEFANGED_param name="pHandle">Int handle to a previously created convert object</DEFANGED_param>
        /// <returns>Int error code value</returns>
        [DllImport("PCO_Conv.dll", EntryPoint = "PCO_ConvertDelete",
            ExactSpelling = false)]
        public static extern int PCO_ConvertDelete(int pHandle);
        /* int PCOCONVERT_API PCO_ConvertDelete(HANDLE ph) - C++ function signature */

        /// <summary>
        /// Gets all the values of a previously created convert object
        /// </summary>
        /// <DEFANGED_param name="pHandle">Int handle to a previously created object</DEFANGED_param>
        /// <DEFANGED_param name="pConvert">Pass by Ref Convert structure</DEFANGED_param>
        /// <returns></returns>
        [DllImport("PCO_Conv.dll", EntryPoint = "PCO_ConvertGet", ExactSpelling = false)]
        public static extern int PCO_ConvertGet(int pHandle, ref PCO_ConvertStructures.PCO_Convert pConvert);
        /* int PCOCONVERT_API PCO_ConvertGet(HANDLE ph, PCO_Convert* pstrConvert) - C++ function signature */

        #endregion


        [DllImport("PCO_Conv.dll", EntryPoint = "PCO_ConvertGetDisplay",
                    ExactSpelling = false)]
        public static extern int PCO_ConvertGetDisplay(int pHandle, ref PCO_ConvertStructures.PCO_Display pDisplay);


        [DllImport("PCO_Conv.dll", EntryPoint = "PCO_ConvertSetDisplay",
            ExactSpelling = false)]
        public static extern int PCO_ConvertSetDisplay(int pHandle, ref PCO_ConvertStructures.PCO_Display pDisplay);



        /* Jiajun Start Add */
        /// <summary>
        /// Converts the camera raw 16 bit data to 8 bit b/w format
        /// </summary>
        /// <DEFANGED_param name="pHandle">Handle to a previously created convert object</DEFANGED_param>
        /// <DEFANGED_param name="imode">Mode parameter</DEFANGED_param>
        /// <DEFANGED_param name="icolormode">Color mode parameter</DEFANGED_param>
        /// <DEFANGED_param name="width">Width of the image to convert</DEFANGED_param>
        /// <DEFANGED_param name="height">Height of the image to convert</DEFANGED_param>
        /// <DEFANGED_param name="rawImagePointer">Pointer to the raw image</DEFANGED_param>
        /// <DEFANGED_param name="resultingImagePointer">Pointer to allocated memory to store the resulting image</DEFANGED_param>
        /// <DEFANGED_returns>Int error code value</DEFANGED_returns>
        [DllImport("PCO_Conv.dll", EntryPoint = "PCO_Convert16TO8",
            ExactSpelling = false)]
        public static extern int PCO_Convert16TO8(int pHandle, int imode, int icolormode, int width, int height, ushort* rawImagePointer, byte* resultingImagePointer);
        [DllImport("PCO_Conv.dll", EntryPoint = "PCO_Convert16TOCOL",
            ExactSpelling = false)]
        public static extern int PCO_Convert16TOCOL(int pHandle, int imode, int icolormode, int width, int height, ushort* rawImagePointer, byte* resultingImagePointer);
        /* int PCOCONVERT_API PCO_Convert(HANDLE ph, int imode, int icolormode, int width, int height, word* b16 , byte* resultImg) - C++ function signature  */

        /// <DEFANGED_summary>
        /// Sets the PCO_SensorInfo structure for a previously created convert object
        /// </DEFANGED_summary>
        /// <DEFANGED_param name="pHandle">Handle to a previously created convert object</DEFANGED_param>
        /// <DEFANGED_param name="pSensorInfo">Pass by Ref Sensor information structure. Do not forget to set pSensorInfo.wSize</DEFANGED_param>
        /// <DEFANGED_returns>Int error code value</DEFANGED_returns>
        [DllImport("PCO_Conv.dll", EntryPoint = "PCO_ConvertSetSensorInfo",
            ExactSpelling = false)]
        public static extern int PCO_ConvertSetSensorInfo(int pHandle, ref PCO_ConvertStructures.PCO_SensorInfo pSensorInfo);
        /* int PCO_CONVERT_API PCO_ConvertSetSensorInfo(HANDLE ph, PCO_SensorInfo * strSensor - C++ function signature */

        [DllImport("PCO_CDlg.dll", EntryPoint = "PCO_OpenConvertDialog",
            ExactSpelling = false)]
        public static extern int PCO_OpenConvertDialog(ref int hLutDialog, IntPtr parent, [MarshalAs(UnmanagedType.LPStr)]string title, int msg_id, int hlut, int xpos, int ypos);

        [DllImport("PCO_CDlg.dll", EntryPoint = "PCO_CloseConvertDialog",
            ExactSpelling = false)]
        public static extern int PCO_CloseConvertDialog(int hLutDialog);

        /// <DEFANGED_summary>
        /// Sets the converted and raw image data to the convert dialog. This will update the histogram diagrams shown in the dialog
        /// </DEFANGED_summary>
        /// <DEFANGED_param name="hLutDialog">Handle of a previously created dialog</DEFANGED_param>
        /// <DEFANGED_param name="ixres">Width of the image data transferred</DEFANGED_param>
        /// <DEFANGED_param name="iyres">Height of the image data transferred</DEFANGED_param>
        /// <DEFANGED_param name="b16_image">Pointer to the raw data</DEFANGED_param>
        /// <DEFANGED_param name="rgb_image">Pointer to the converted data</DEFANGED_param>
        /// <DEFANGED_returns></DEFANGED_returns>
        [DllImport("PCO_CDlg.dll", EntryPoint = "PCO_SetDataToDialog",
            ExactSpelling = false)]
        public static extern int PCO_SetDataToDialog(int hLutDialog, int ixres, int iyres, ref IntPtr b16_image,
             ref IntPtr rgb_image);

      
    }
}