using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace UHFAPP
{
    public class UHFAPI
    {

 

        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static int UHFSetTempVal(byte tempVal);
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static int UHFGetTempVal(byte[] tempVal);


        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static int UHFSetIp(byte[] ip, byte[] port);
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static int UHFGetIp(byte[] ip, byte[] port);

        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static int UHFSetDestIp(byte[] ip, byte[] port);
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static int UHFGetDestIp(byte[] ip, byte[] port);

        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static int UHFSetWorkMode(byte mode);
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static int UHFGetWorkMode(byte[] mode);

        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static int UHFSetBeep(byte mode);
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static int UHFGetBeep(byte[] mode);
 
 

        [DllImport("UHFAPI.dll",CallingConvention = CallingConvention.Cdecl)]
        private extern static int TCPConnect(StringBuilder ip, uint hostport);
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static void TCPDisconnect();

          //

        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static int ComOpen(int comName);
          //
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static void ClosePort();
    
          /**********************************************************************************************************
             
             *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFGetHardwareVersion(byte[] version);
          /**********************************************************************************************************
            
            *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFGetSoftwareVersion(byte[] version);
          /**********************************************************************************************************
            
             *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFGetDeviceID(ref int id);

          /**********************************************************************************************************
          * 
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFSetPower(byte save, byte uPower);
          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFGetPower(ref byte uPower);
          /**********************************************************************************************************
          
         *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFSetJumpFrequency(byte nums, int[] Freqbuf);
          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFGetJumpFrequency(int[] Freqbuf);
          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFSetGen2(byte Target, byte Action, byte T, byte Q, byte StartQ, byte MinQ, byte MaxQ, byte D, byte C, byte P, byte Sel, byte Session, byte G, byte LF);
          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFGetGen2(ref byte Target, ref byte Action, ref byte T, ref byte Q, ref byte StartQ, ref byte MinQ, ref byte MaxQ, ref byte D, ref byte Coding, ref byte P, ref byte Sel, ref byte Session, ref byte G, ref byte LF);
          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFSetCW(byte flag);
          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFGetCW(ref byte flag);

          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFSetANT(byte saveflag, byte[] buf);

          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFGetANT(byte[] buf);

          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFSetRegion(byte saveflag, byte region);

          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFGetRegion(ref byte region);

          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFGetTemperature(ref int temperature);

          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFSetTemperatureProtect(byte flag);
          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFGetTemperatureProtect(ref byte flag);
          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFSetANTWorkTime(byte antnum, byte saveflag, int WorkTime);
          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFGetANTWorkTime(byte antnum, ref int WorkTime);
          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFSetRFLink(byte saveflag, byte mode);

          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFGetRFLink(ref byte uMode);
          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFSetFastID(byte flag);
          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFGetFastID(ref byte flag);
          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFSetTagfocus(byte flag);
          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFGetTagfocus(ref byte flag);
          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFSetSoftReset();
          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFSetDualSingelMode(byte saveflag, byte mode);
          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFGetDualSingelMode(ref byte mode);
          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFSetFilter(byte saveflag, byte bank, int startaddr, int datalen, byte[] databuf);
          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFSetEPCTIDMode(byte saveflag, byte mode);
          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll")]
          private static extern int UHFGetEPCTIDMode(ref byte mode);

          /**********************************************************************************************************
         *
         *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFSetDefaultMode();
          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFInventorySingle(ref byte uLenUii, byte[] uUii);
          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFInventory();
          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFStopGet();
          /**********************************************************************************************************
            
            *********************************************************************************************************/
         [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHF_GetReceived_EX(ref int uLenUii, byte[] uUii);
         /**********************************************************************************************************
         
         *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
         private static extern int UHFReadData(byte[] uAccessPwd, 
              byte FilterBank, 
              int FilterStartaddr,
              int FilterLen, 
              byte[] FilterData, 
              byte uBank,
              int uPtr,
              int uCnt, 
              byte[] uReadDatabuf,
              ref int uReadDataLen);
          
        /**********************************************************************************************************
         
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFWriteData(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData, byte uBank, int uPtr, byte uCnt, byte[] uDatabuf);
          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFLockTag(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData, byte[] lockbuf);

          /**********************************************************************************************************
          
          *********************************************************************************************************/          
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFKillTag(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData);

          /**********************************************************************************************************
          
            *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFBlockWriteData(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData, byte uBank, int uPtr, int uCnt, byte[] uDatabuf);

          /**********************************************************************************************************
          
          *********************************************************************************************************/       
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFBlockEraseData(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData, byte uBank, int uPtr, byte uCnt);
          /**********************************************************************************************************
          
          *********************************************************************************************************/
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFSetQT(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData, byte QTData);
          /**********************************************************************************************************
          
          *********************************************************************************************************/        
          [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFGetQT(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData, ref byte QTData);
          /**********************************************************************************************************
          
          *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
          private static extern int UHFReadQT(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData, byte QTData, byte uBank, int uPtr, byte uCnt, byte[] uReadDatabuf, ref byte uReadDataLen);
        /**********************************************************************************************************
        * 
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int UHFWriteQT(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData, byte QTData, byte uBank, int uPtr, byte uCnt, byte[] uDatabuf);
        /**********************************************************************************************************
        
        *********************************************************************************************************/        
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int UHFBlockPermalock(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData, byte ReadLock, byte uBank, int uPtr, byte uRange, byte[] uMaskbuf);

        /**********************************************************************************************************
        
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
         private static extern  int UHFDeactivate (int cmd,byte[] uAccessPwd, byte FilterBank,int FilterStartaddr,int FilterLen, byte[] FilterData);

        /**********************************************************************************************************
        

        *********************************************************************************************************/
         [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
         private static extern  int  UHFGetProtocolType(byte[] type);

        
        /**********************************************************************************************************
        
        * 
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern  int UHFSetProtocolType(byte type);
        /**********************************************************************************************************
        
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern  int UHFGBTagLock(byte[] uAccessPwd, byte FilterBank,int FilterStartaddr,int FilterLen,byte[] FilterData,byte memory, byte config, byte action);



        /**********************************************************************************************************
        
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern  int UHFGetIOControl (byte[] inputData);

        /**********************************************************************************************************
        
        * 
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern  int UHFSetIOControl(byte output1, byte output2 ,byte outStatus);

          private static UHFAPI uhf = null;
          private UHFAPI() { }
          public static UHFAPI getInstance()
          {
              if (uhf == null)
                  uhf = new UHFAPI();
              return uhf;
          }



#region protocol
          public bool SetProtocol(byte type)
          {
              if (UHFSetProtocolType(type) == 0)
              {
                  return true;
              }
              return false;
          }
          public int GetProtocol() {
              byte[] type = new byte[1];
              if (UHFGetProtocolType(type) == 0)
              {
                  return type[0];
              }
              return -1;
          }
#endregion


#region  domestictagLock

  
         
          /// 
         /// <summary>
          /// 
         /// </summary>
          
         /// <param name="memory"></param>
         /// <param name="config"></param>
         /// <param name="action"></param>
         /// <returns></returns>
          public bool GBTagLock(byte[] uAccessPwd, byte FilterBank,int FilterStartaddr,int FilterLen,byte[] FilterData,byte memory, byte config, byte action)
          {
              if (UHFGBTagLock(uAccessPwd, FilterBank, FilterStartaddr, FilterLen, FilterData, memory, config, action) == 0)
              {
                  return true;
              }
              return false;
          }

#endregion



          #region TCPIP
          /// <summary>

          /// </summary>

          public bool TcpConnect(string ip, uint port)
          {

              if (ip == null || ip == "")
              {
                  return false;
              }
              ip = ip.Trim();

              if (!StringUtils.isIP(ip))
              {
                  return false;
              }
              StringBuilder bIp = new StringBuilder();
              bIp.Append(ip);

              int result = TCPConnect(bIp, port);
              if (result == 0)
              {
                  return true;
              }
              return false;
          }
          /// <summary>
          /// </summary>
          /// <returns></returns>
          public void TcpDisconnect()
          {
              TCPDisconnect();
          }
 


          public bool UHFSetBuzzer(byte mode)
          {
              if (UHFSetBeep(mode) == 0)
              {
                  return true;
              }
              else
              {
                  return false;
              }
            
          }

          public bool UHFGetBuzzer(byte[] mode)
          {
              if (UHFGetBeep(mode) == 0)
              {
                  return true;
              }
              else
              {
                  return false;
              }

          }

          public bool SetLocalIP(string ip, int port)
          {
              if (ip == null || ip == "")
              {
                  return false;
              }
              ip = ip.Trim();

              if (!StringUtils.isIP(ip))
              {
                  return false;
              }
              byte[] bPort = new byte[2];
              byte[] bIP = new byte[4];
 
              string hexPort = DataConvert.DecimalToHexString(port);
              bPort = DataConvert.HexStringToByteArray("0000".Substring(0, 4 - hexPort.Length) + hexPort);

              string[] strIp = ip.Split('.');
              for (int k = 0; k < strIp.Length; k++)
              {
                  bIP[k] = byte.Parse(strIp[k]);
              }


              if (UHFSetIp(bIP, bPort) == 0)
              {
                  return true;
              }
              else
              {
                  return false;
              }
          }

          public bool GetLocalIP(StringBuilder ip, StringBuilder port)
          {          
              byte[] sIP = new  byte[4];
              byte[] sPort = new byte[2];

              int startTime = Environment.TickCount;
              if (UHFGetIp(sIP, sPort) == 0)
              {
                 // MessageBoxEx.Show((Environment.TickCount-startTime)+"");


                  if (ip != null) {
                      ip.Append(sIP[0]);
                      ip.Append(".");
                      ip.Append(sIP[1]);
                      ip.Append(".");
                      ip.Append(sIP[2]);
                      ip.Append(".");
                      ip.Append(sIP[3]);
                  }
                  if (port != null)
                  {
                      string hexPort = DataConvert.ByteArrayToHexString(sPort).Replace(" ","") ;
                      int iPort = Convert.ToInt32(hexPort, 16);
                      port.Append(iPort);
                  }
                  return true;
              }
              else
              {
                  return false;
              }
          }

          public bool SetDestIP(string ip, int port)
          {
              if (ip == null || ip == "")
              {
                  return false;
              }
              ip = ip.Trim();

              if (!StringUtils.isIP(ip))
              {
                  return false;
              }
              byte[] bPort = new byte[2];
              byte[] bIP = new byte[4];

              string hexPort = DataConvert.DecimalToHexString(port);
              bPort = DataConvert.HexStringToByteArray("0000".Substring(0, 4 - hexPort.Length) + hexPort);

              string[] strIp = ip.Split('.');
              for (int k = 0; k < strIp.Length; k++)
              {
                  bIP[k] = byte.Parse(strIp[k]);
              }


              if (UHFSetDestIp(bIP, bPort) == 0)
              {
                  return true;
              }
              else
              {
                  return false;
              }
          }

          public bool GetDestIP(StringBuilder ip, StringBuilder port)
          {
              byte[] sIP = new byte[4];
              byte[] sPort = new byte[2];

              if (UHFGetDestIp(sIP, sPort) == 0)
              {
                  if (ip != null)
                  {
                      ip.Append(sIP[0]);
                      ip.Append(".");
                      ip.Append(sIP[1]);
                      ip.Append(".");
                      ip.Append(sIP[2]);
                      ip.Append(".");
                      ip.Append(sIP[3]);
                  }
                  if (port != null)
                  {
                      string hexPort = DataConvert.ByteArrayToHexString(sPort).Replace(" ", "");
                      int iPort = Convert.ToInt32(hexPort, 16);
                      port.Append(iPort);
                  }
                  return true;
              }
              else
              {
                  return false;
              }
          }

 
  #endregion

  #region SerialportVersionID
          /// <summary>
           /// </summary>
           /// <param name="com">0,1,2....</param>
           /// <returns></returns>
          public bool Open(int comName)
          {
              int result=ComOpen(comName);
              if (result == 0)
              {
                  return true;
              }
              return false;
          }
            /// <summary>

            /// </summary>
            /// <returns></returns>
          public bool Close() {
              ClosePort();  
              return true;
          }



        
          /// <summary>

          /// </summary>
          /// <returns></returns>
          public string GetHardwareVersion()
          {
              byte[] version = new byte[50];
              if (UHFGetHardwareVersion(version) == 0)
              {
                  int len = version[0];
                  byte[] versionTemp = new byte[len];
                  Array.Copy(version, 1, versionTemp,0,len);
                  return System.Text.Encoding.ASCII.GetString(versionTemp);// DataConvert.ByteArrayToHexString(versionTemp);
              }
              return string.Empty;
          }
          /// <summary>

          /// </summary>
          /// <returns></returns>
          public string GetSoftwareVersion()
          {
              byte[] version = new byte[50];
              if (UHFGetSoftwareVersion(version) == 0)
              {
                  int len = version[0];
                  byte[] versionTemp = new byte[len];
                  Array.Copy(version, 1, versionTemp, 0, len);
                  return System.Text.Encoding.ASCII.GetString(versionTemp) ;//DataConvert.ByteArrayToHexString(versionTemp);
              }
              return string.Empty;
          }
          /// <summary>

          /// </summary>

          public int GetUHFGetDeviceID()
          {
               int id=-1;
               UHFGetDeviceID(ref id);
               return id;
          }
  #endregion

  #region FrequencyPower
          /// <summary>
          /// </summary>
         /// <returns></returns>
          public bool SetPower(byte save, byte uPower) {
              if (UHFSetPower(save, uPower) == 0)
                  return true;
              return false;
          }
        /// <summary>
        /// </summary>
        /// <returns></returns>
          public bool GetPower(ref byte uPower) {
              if (UHFGetPower(ref uPower) == 0)
              {
                  return true;
              }
              return false;
          }
          /// <summary>
          /// </summary>
          /// <returns></returns>
          public bool GetJumpFrequency(ref int[] Freqbuf)
          {
              int[] temp=new int[512];
              if (UHFGetJumpFrequency(temp) == 0)
              {
                  int len=temp[0];
                  int[] freqData = new int[len];
                  Array.Copy(temp,1,freqData,0,len);
                  Freqbuf = freqData;
                  return true;
              }
              return false;
          }
          /// <summary>
          /// </summary>
          /// <returns></returns>
          public bool SetJumpFrequency(byte nums, int[] Freqbuf)
          {
              if (UHFSetJumpFrequency(nums, Freqbuf) == 0)
              {
                  return true;
              }
              return false;
          }
 #endregion

  #region session
        /// <summary>
        /// </summary>
        /// <param name="Target"></param>
        /// <param name="Action"></param>
        /// <param name="T"></param>
        /// <param name="Q"></param>
        /// <param name="StartQ"></param>
        /// <param name="MinQ"></param>
        /// <param name="MaxQ"></param>
        /// <param name="D"></param>
        /// <param name="C"></param>
        /// <param name="P"></param>
        /// <param name="Sel"></param>
        /// <param name="Session"></param>
        /// <param name="G"></param>
        /// <param name="LF"></param>
        /// <returns></returns>
          public bool SetGen2(byte Target, byte Action, byte T, byte Q,
                                byte StartQ, byte MinQ,
                                byte MaxQ, byte D, byte C, byte P,
                                byte Sel, byte Session, byte G, byte LF)
          {
              if (UHFSetGen2(Target, Action, T, Q, StartQ, MinQ, MaxQ, D, C, P, Sel, Session, G, LF) == 0)
              {
                  return true;
              }
              return false;
          }
          /// <summary>
          /// </summary>
          /// <param name="Target"></param>
          /// <param name="Action"></param>
          /// <param name="T"></param>
          /// <param name="Q"></param>
          /// <param name="StartQ"></param>
          /// <param name="MinQ"></param>
          /// <param name="MaxQ"></param>
          /// <param name="D"></param>
          /// <param name="Coding"></param>
          /// <param name="P"></param>
          /// <param name="Sel"></param>
          /// <param name="Session"></param>
          /// <param name="G"></param>
          /// <param name="LF"></param>
          /// <returns></returns>
          public bool GetGen2(ref byte Target, ref byte Action, ref byte T, ref byte Q,
                     ref byte StartQ, ref byte MinQ,
                     ref byte MaxQ, ref byte D, ref byte Coding, ref byte P,
                     ref byte Sel, ref byte Session, ref byte G, ref byte LF)
          {
              if (UHFGetGen2(ref Target, ref Action, ref T, ref Q, ref StartQ, ref MinQ, ref MaxQ, ref D, ref Coding, ref P, ref Sel, ref Session, ref G, ref LF) == 0)
              {
                  return true;
              }
              return false;
          }
  #endregion

          /// <summary>
          /// </summary>
          /// <returns></returns>
          public bool SetCW(byte flag)
          {
              if (UHFSetCW(flag) == 0)
              {
                  return true;
              }
              return false;
          }
           /// <summary>
           /// </summary>
           /// <returns></returns>
          public bool GetCW(ref byte flag)
          {
              if (UHFGetCW(ref flag) == 0)
              {
                  return true;
              }
              return false;
          }
           /// <summary>
          /// </summary>
          /// <returns></returns>
          public bool SetANT(byte saveflag, byte[] buf)
          {
              if (UHFSetANT( saveflag,  buf) == 0)
              {
                  return true;
              }
              return false;
          }
           /// <summary>
           /// </summary>
          /// <param name="buf">buf--2bytes, 16bits</param>
           /// <returns></returns>
          public bool GetANT(byte[] buf)
          {
              if (UHFGetANT(buf) == 0)
              {
                  return true;
              }
              return false;
          }
           /// <summary>
           /// </summary>
          /// <param name="region">0x01(China1),0x02(China2),0x04(Europe),0x08(USA),0x16(Korea),0x32(Japan)</param>
           /// <returns></returns>
          public bool SetRegion(byte saveflag, byte region)
          {
              if (UHFSetRegion(saveflag, region) == 0)
              {
                  return true;
              }
              return false;
          }
           /// <summary>
           /// </summary>
          /// <param name="region"> 0x01(China1),0x02(China2),0x04(Europe),0x08(USA),0x16(Korea),0x32(Japan)</param>
           /// <returns></returns>
          public bool GetRegion(ref byte region)
          {
              if (UHFGetRegion(ref region) == 0)
              {
                  return true;
              }
              return false;
          }
          /// <summary>
          /// </summary>
          public string GetTemperature()
          {
              int temperature = 0;
              if (UHFGetTemperature(ref temperature) == 0)
              {
                  return temperature.ToString();
              }
              return string.Empty;
          }
           /// <summary>
          /// </summary>
          /// <returns></returns>
          public bool SetTemperatureProtect(byte flag)
          {
              if (UHFSetTemperatureProtect(flag) == 0)
              {
                  return true;
              }
              return false;
          }
           /// <summary>
           /// </summary>
           /// <returns></returns>
          public bool GetTemperatureProtect(ref byte flag)
          {
              if (UHFGetTemperatureProtect(ref flag) == 0)
              {
                  return true;
              }
              return false;
          }
           /// <summary>
           /// </summary>
           /// <returns></returns>
          public bool SetANTWorkTime(byte antnum, byte saveflag, int WorkTime)
          {
              if (UHFSetANTWorkTime(antnum, saveflag, WorkTime) == 0)
              {
                  return true;
              }
              return false;
          }
           /// <summary>
           /// </summary>
           /// <returns></returns>
          public bool GetANTWorkTime(byte antnum, ref int WorkTime)
          {
              if (UHFGetANTWorkTime(antnum, ref   WorkTime) == 0)
              {
                  return true;
              }
              return false;
          }
           /// <summary>
           /// </summary>
           /// <returns></returns>
          public bool SetRFLink(byte saveflag, byte mode)
          {

              if (UHFSetRFLink(saveflag, mode) == 0)
              {
                  return true;
              }
              return false;
          }
           /// <summary>
           /// </summary>
          /// <param name="uMode">0:DSB_ASK/FM0/40KHZ , 1:PR_ASK/Miller4/250KHZ , 2:PR_ASK/Miller4/300KHZ, 3:DSB_ASK/FM0/400KHZ</param>
           /// <returns></returns>
          public bool GetRFLink(ref byte uMode)
          {
              if (UHFGetRFLink(ref uMode) == 0)
                  return true;

              return false;
          }
          /// <summary>
          /// </summary>
         /// <returns></returns>
        public bool SetFastID(byte flag)
        {
            if (UHFSetFastID(flag) == 0)
            {
                return true;
            }
            return false;
        }
          /// <summary>
          /// </summary>
          /// <returns></returns>
        public bool GetFastID(ref byte flag)
        {
            if (UHFGetFastID(ref   flag) == 0)
                return true;
            return false;

        }
        /// <summary>
        /// </summary>
        /// <returns></returns>
          public bool SetTagfocus(byte flag)
          {
              if (UHFSetTagfocus(flag) == 0)
              {
                  return true;
              }
              return false;
          }
           /// <summary>
           /// </summary>
           /// <returns></returns>
          public bool GetTagfocus(ref byte flag)
          {
              if (UHFGetTagfocus(ref  flag) == 0)
              {
                  return true;
              }
              return false;
          }
           /// <summary>
         /// </summary>
         /// <returns></returns>
        public bool SetSoftReset() {
              if (UHFSetSoftReset() == 0)
                  return true;
              return false;
          }
           /// <summary>
           /// </summary>
           /// <returns></returns>
          public bool SetDualSingelMode(byte saveflag, byte mode)
          {
              if (UHFSetDualSingelMode(saveflag, mode) == 0)
                  return true;
              return false;
          }
           /// <summary>
           /// </summary>
           /// <returns></returns>
          public bool GetDualSingelMode(ref byte mode)
          {
              if (UHFGetDualSingelMode(ref  mode) == 0)
                  return true;
              return false;
          }
           /// <summary>
           /// <returns></returns>
          public bool SetFilter(byte saveflag, byte bank, int startaddr, int datalen, byte[] databuf)
          {
              if (UHFSetFilter(saveflag, bank, startaddr, datalen, databuf)==0)
              {
                  return true;
              }
              return false;
          }
           /// <summary>
           /// </summary>
          /// <returns></returns>
          public bool SetEPCTIDMode(byte saveflag, byte mode)
          {
              if (UHFSetEPCTIDMode(saveflag, mode) == 0)
                  return true;
              return false;
          }
           /// <summary>
           /// </summary>
           /// <returns></returns>
          public bool GetEPCTIDMode(ref byte mode)
          {
              if (UHFGetEPCTIDMode(ref mode) == 0)
              {
                  return true;
              }
              return false;
          }
           /// <summary>
           /// </summary>
           /// <returns></returns>
          public bool SetDefaultMode()
          {
              if (UHFSetDefaultMode() == 0)
                  return true;
              return false;
          }
            /// <summary>
            /// </summary>
            /// <returns></returns>
          private bool InventorySingle(ref byte uLenUii,ref byte[] uUii)
          {
              if (UHFInventorySingle(ref uLenUii, uUii) == 0)
                  return true;
              return false;
          }
           /// <summary>
           /// </summary>
           /// <returns></returns>
          public bool Inventory() {

              int result=UHFInventory();
              if (result == 0)
                  return true;
              else
                  return false;
          }
           /// <summary>
           /// </summary>
           /// <returns></returns>
          public bool StopGet() {

              if (UHFStopGet() == 0)
                  return true;
              else
                  return false;
                
           }
          /// <summary>
          /// </summary>
         /// <returns></returns>
          public bool GetReceived_EX(ref int uLenUii, ref byte[] uUii) {    
               if(UHF_GetReceived_EX(ref uLenUii, uUii)==0){
                      return true;
               }
             return false;
          }
          /// <summary>
          /// </summary>
          public string ReadData(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData, byte uBank, int uPtr, int uCnt)
          {
              try
              {
                  byte[] uReadDatabuf = new byte[2048]; ;
                  int uReadDataLen = 0;

                  StringBuilder sb = new StringBuilder();
                  sb.Append("\r\npassword:"+DataConvert.ByteArrayToHexString(uAccessPwd));
                  sb.Append("\r\nfilter datablock（ 1：EPC, 2:TID, 3:USR）：" + FilterBank);
                  sb.Append("\r\nfilter start：" + FilterStartaddr);
                  sb.Append("\r\nfilter length：" + FilterLen);
                  sb.Append("\r\nfilter data：" + DataConvert.ByteArrayToHexString(FilterData));
                  sb.Append("\r\n");
                  sb.Append("\r\nRead block：" + uBank);
                  sb.Append("\r\nRead start：" + uPtr);
                  sb.Append("\r\nRead length：" + uCnt);
                  sb.Append("\r\n");

                  FileManage.WriterFile("C:\\Users\\Administrator\\Desktop\\UHFLog.txt", sb.ToString(), true);

                  int result=UHFReadData(uAccessPwd, FilterBank, FilterStartaddr, FilterLen, FilterData, uBank, uPtr, uCnt, uReadDatabuf, ref   uReadDataLen);
                  if (result == 0)
                  {
                      return DataConvert.ByteArrayToHexString(uReadDatabuf, uReadDataLen);
                  }
              }
              catch (Exception ex) { 
              
              }
          
              return string.Empty ;
          }

   
           /// <summary>
           /// </summary>
           /// <returns></returns>
          public bool WriteData(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData, byte uBank, int uPtr, byte uCnt, byte[] uDatabuf)
          {      
              if (UHFWriteData(uAccessPwd, FilterBank, FilterStartaddr, FilterLen, FilterData, uBank, uPtr, uCnt, uDatabuf) == 0)
              {
                  return true;
              }
              return false;
          } 
             /// <summary>
             /// </summary>
            /// <returns></returns>
          public bool LockTag(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData, byte[] lockbuf)
          {
              if (UHFLockTag(uAccessPwd, FilterBank, FilterStartaddr, FilterLen, FilterData, lockbuf) == 0)
              {
                  return true;
              }
              return false;
          }
           /// <summary>
           /// </summary>
           /// <returns></returns>
          public bool KillTag(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData)
          {
              if (UHFKillTag(uAccessPwd, FilterBank, FilterStartaddr, FilterLen, FilterData) == 0)
              {

                  return true;
              }
              return false;

          }
           /// <summary>
           /// </summary>
           /// <returns></returns>
          public bool BlockWriteData(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData, byte uBank, int uPtr, int uCnt, byte[] uDatabuf)
          {
              StringBuilder sb = new StringBuilder();
              sb.Append("\r\nUHFBlockWriteData================>");
              sb.Append("\r\npassword：" + DataConvert.ByteArrayToHexString(uAccessPwd));
              sb.Append("\r\nfilter data（ 1：EPC, 2:TID, 3:USR）：" + FilterBank);
              sb.Append("\r\nfilter start：" + FilterStartaddr);
              sb.Append("\r\nfilter length：" + FilterLen);
              sb.Append("\r\nfilter data：" + DataConvert.ByteArrayToHexString(FilterData));
              sb.Append("\r\n");
              sb.Append("\r\nWritten block：" + uBank);
              sb.Append("\r\nwritten start：" + uPtr);
              sb.Append("\r\nWritten length：" + uCnt);
              sb.Append("\r\nWritten data：" + DataConvert.ByteArrayToHexString(uDatabuf));
              sb.Append("\r\n");

              FileManage.WriterFile("C:\\Users\\Administrator\\Desktop\\UHFLog.txt", sb.ToString(), true);

              if (UHFBlockWriteData(uAccessPwd, FilterBank, FilterStartaddr, FilterLen, FilterData, uBank, uPtr, uCnt, uDatabuf) == 0)
              {
                  return true;
              }
              return false;
          }
            /// <summary>
          /// </summary>
            /// <returns></returns>
          public bool BlockEraseData(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData, byte uBank, int uPtr, byte uCnt)
          {
              if (UHFBlockEraseData(uAccessPwd, FilterBank, FilterStartaddr, FilterLen, FilterData, uBank, uPtr, uCnt) == 0)
              {

                  return true;
              }
              return false;
          }
 #region QT
           /// <summary>
           /// </summary>
           /// <returns></returns>
          public bool SetQT(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData, byte QTData)
          {
              if (UHFSetQT(uAccessPwd, FilterBank, FilterStartaddr, FilterLen, FilterData, QTData) == 0) { return true; }
              return false;

          } 
            /// <summary>
            /// </summary>
            /// <returns></returns>
          public bool GetQT(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData,ref byte QTData)
          {
              if (UHFGetQT(uAccessPwd, FilterBank, FilterStartaddr, FilterLen, FilterData, ref QTData) == 0)
              {
                  return true;
              }
              return false;
          }
             /// <summary>
             /// </summary>
             /// <returns></returns>
          public string ReadQT(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData, byte QTData, byte uBank, int uPtr, byte uCnt)
          {
              byte[] uReadDatabuf=new byte[512];
              byte uReadDataLen = 0;
              if (UHFReadQT(uAccessPwd, FilterBank, FilterStartaddr, FilterLen, FilterData, QTData, uBank, uPtr, uCnt, uReadDatabuf, ref uReadDataLen) == 0)
              {
                  string strData = DataConvert.ByteArrayToHexString(uReadDatabuf, uReadDataLen); //BitConverter.ToString(uReadDatabuf, 0, uReadDataLen).Replace("-", "");
                  return strData;
              }
              return string.Empty;
          }
             /// <summary>
             /// </summary>
             /// <returns></returns>
          public bool WriteQT(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData, byte QTData, byte uBank, int uPtr, byte uCnt, byte[] uDatabuf)
          {
              if (UHFWriteQT(uAccessPwd, FilterBank, FilterStartaddr, FilterLen, FilterData, QTData, uBank, uPtr, uCnt, uDatabuf) == 0)
              {
                  return true;
              }
              return false;
          }
 #endregion 
           /// <summary>
           /// </summary>
           /// <returns></returns>
          public bool  BlockPermalock(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData, byte ReadLock, byte uBank, int uPtr, byte uRange, byte[] uMaskbuf)
          {
              if (UHFBlockPermalock(uAccessPwd, FilterBank, FilterStartaddr, FilterLen, FilterData, ReadLock, uBank, uPtr, uRange, uMaskbuf) == 0)
              {
                  return true;

              }
              return false;
          }
         
          public bool uhfGetReceived(ref string epc, ref string tid, ref string rssi, ref string ant)
          {
              int  uLen = 0;
              byte[] bufData = new byte[150];
              if (GetReceived_EX(ref uLen, ref bufData))
              {
                  string epc_data = string.Empty;
                  string uii_data = string.Empty;
                  string tid_data = string.Empty;
                  string rssi_data = string.Empty;
                  string ant_data = string.Empty;

                  int uii_len = bufData[0];
                  int tid_leng = bufData[uii_len + 1];
                  int tid_idex = uii_len + 2;
                  int rssi_index = 1 + uii_len + 1 + tid_leng;
                  int ant_index = rssi_index + 2;

                  string strData = BitConverter.ToString(bufData, 0, uLen).Replace("-", "");
                  epc_data = strData.Substring(6, uii_len * 2 - 4);  //Epc
                  tid_data = strData.Substring(tid_idex * 2, tid_leng * 2); //Tid
                  string temp = strData.Substring(rssi_index * 2, 4);
                  rssi_data = ((Convert.ToInt32(temp, 16) - 65535) / 10).ToString();// RSSI  =  (0xFED6   -65535)/10
                  ant_data = Convert.ToInt32((strData.Substring(ant_index * 2, 2)), 16).ToString();

                  epc = epc_data;
                  tid = tid_data;
                  rssi = rssi_data;
                  ant = ant_data;
                  return true;
              }
              else
              {
                  return false;
              }
          }
          public bool InventorySingle(ref string epc)
          {
              string tid = string.Empty;
              string rssi = string.Empty;
              byte  uLen = 0;
              byte[] bufData = new byte[150];
              if (UHFInventorySingle(ref uLen,  bufData)==0)
              {
                  
                  string epc_data = string.Empty;
                  string uii_data = string.Empty;
                  string tid_data = string.Empty;
                  string rssi_data = string.Empty;


                  int epclen = ((bufData[0] >> 3)) * 2;
                 // int tid_leng = bufData[uii_len + 1];
                //  int tid_idex = uii_len + 2;
                 // int rssi_index = 1 + uii_len + 1 + tid_leng;

                  string strData = BitConverter.ToString(bufData, 0, uLen).Replace("-", "");
                  epc_data = strData.Substring(4, epclen*2);  //Epc
               //   tid_data = strData.Substring(tid_idex * 2, tid_leng * 2); //Tid
              //    string temp = strData.Substring(rssi_index * 2, 4);
              //    rssi_data = ((Convert.ToInt32(temp, 16) - 65535) / 10).ToString();// RSSI  =  (0xFED6   -65535)/10

                  epc = epc_data;
                //  tid = tid_data;
                //  rssi = rssi_data;
                  return true;
              }
              else
              {
                  return false;
              }
          }

    
            /// <summary>
            /// </summary>
            /// <param name="cmd"></param>
            /// <returns></returns>
          public bool Deactivate(int cmd, byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData)
          {
              if (UHFDeactivate(cmd, uAccessPwd, FilterBank, FilterStartaddr, FilterLen, FilterData) == 0)
                  return true;
              else
                  return false;

          }

          public bool SetWorkMode(byte mode)
          {
              if (UHFSetWorkMode(mode) == 0)
              {
                  return true;
              }
              else
              {
                  return false;
              }
          }
          public bool GetWorkMode(byte[] mode)
          {
              if (UHFGetWorkMode(mode) == 0)
              {
                  return true;
              }
              else
              {
                  return false;
              }
          }
          
           /// <summary>
          /// </summary>
          /// <param name="tempVal">50-75</param>
          /// <returns></returns>
          public bool SetTemperatureVal(byte tempVal)
          {
              if (tempVal < 50 || tempVal > 75)
                  return false;

              if (UHFSetTempVal(tempVal) == 0)
              {
                  return true;
              }
              else
              {
                  return false;
              }
          }
         
          /// <summary>
          /// </summary>
          /// <returns></returns>
          public int GetTemperatureVal()
          {
              byte[] tempVal = new byte[5];
              if (UHFGetTempVal(tempVal) == 0)
              {
                  return tempVal[0];
              }
              else
              {
                  return -1;
              }
          }
        
          /// <summary>
          /// </summary>
          /// <param name="outData">
          /// 
          /// </param>
          /// <returns></returns>
          public bool getIOControl(byte[] outData)
          {
              byte[] tempVal = new byte[5];
              if (UHFGetIOControl(tempVal) == 0)
              {
                  if (outData != null && outData.Length >= 2)
                  {
                      outData[0] = tempVal[0];
                      outData[1] = tempVal[1];
                  }
                  return true;
              }
              else
              {
                  return false;
              }
          }
          /// <summary>
          /// </summary>
          /// <returns></returns>
          public bool setIOControl(byte ouput1, byte ouput2, byte outStatus)
          {
              if (ouput1 != 0 && ouput1 != 1)
              {
                  return false;
              }
              if (ouput2 != 0 && ouput2 != 1)
              {
                  return false;
              }
              if (outStatus != 0 && outStatus != 1)
              {
                  return false;
              }
              if (UHFSetIOControl(ouput1, ouput2, outStatus) == 0)
              {
                  return true;
              }
              else
              {
                  return false;
              }
          }
      
    }
}
