// 下列 ifdef 块是创建使从 DLL 导出更简单的
// 宏的标准方法。此 DLL 中的所有文件都是用命令行上定义的 UHFAPI_EXPORTS
// 符号编译的。在使用此 DLL 的
// 任何其他项目上不应定义此符号。这样，源文件中包含此文件的任何其他项目都会将
// UHFAPI_API 函数视为是从 DLL 导入的，而此 DLL 则将用此宏定义的
// 符号视为是被导出的。
#ifdef UHFAPI_EXPORTS
#define UHFAPI_API __declspec(dllexport)
#else
#define UHFAPI_API __declspec(dllimport)
#endif

// 此类是从 UHFAPI.dll 导出的
class UHFAPI_API CUHFAPI {
public:
	CUHFAPI(void);
	// TODO: 在此添加您的方法。
};

extern UHFAPI_API int nUHFAPI;

UHFAPI_API int fnUHFAPI(void);


extern "C"  UHFAPI_API int TCPConnect(const char * hostaddr,int hostport);
extern "C"  UHFAPI_API void TCPDisconnect();
/**********************************************************************************************************
* 功能：打开串口
* 输入：port--串口号
*********************************************************************************************************/

extern "C"  UHFAPI_API int ComOpen(int port);


/**********************************************************************************************************
* 功能：关闭串口
*********************************************************************************************************/
extern "C" UHFAPI_API void ClosePort();



/**********************************************************************************************************
* 功能：获取硬件版本号
* 输出：version[0]--版本号长度 ,  version[1--x]--版本号
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetHardwareVersion(unsigned char *version);


/**********************************************************************************************************
* 功能：获取软件版本号
* 输出：version[0]--版本号长度 ,  version[1--x]--版本号
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetSoftwareVersion(unsigned char *version);



/**********************************************************************************************************
* 功能：获取ID号
* 输出：id--整型ID号
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetDeviceID(unsigned int *id);


/**********************************************************************************************************
* 功能：设置功率
* 输入：saveflag  -- 1:保存设置   0：不保存
* 输入：uPower -- 功率（DB）
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetPower ( unsigned char saveflag,unsigned char uPower);



/**********************************************************************************************************
* 功能：获取功率
* 输出：uPower -- 功率（DB）
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetPower (unsigned char *uPower);


/**********************************************************************************************************
* 功能：设置跳频
* 输入：nums -- 跳频个数
* 输入：Freqbuf--频点数组（整型） ，如920125，921250.....
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetJumpFrequency( unsigned char nums,unsigned int *Freqbuf);




/**********************************************************************************************************
* 功能：获取跳频
* 输出：Freqbuf[0]--频点个数， Freqbuf[1]..[x]--频点数组（整型）
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetJumpFrequency( unsigned int *Freqbuf);





/**********************************************************************************************************
* 功能：设置Gen2参数
* 输入：
**********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetGen2 (unsigned char Target,unsigned char Action, unsigned char T,unsigned char Q,
								unsigned char StartQ,unsigned char MinQ,
								unsigned char MaxQ,unsigned char D,unsigned char C,unsigned char P,
								unsigned char Sel,unsigned char Session,unsigned char G,unsigned char LF);

/**********************************************************************************************************
* 功能：获取Gen2参数
* 输入：
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetGen2 (unsigned char *Target, unsigned char *Action,unsigned char *T,unsigned char *Q,
					unsigned char *StartQ,unsigned char *MinQ,
					unsigned char *MaxQ,unsigned char *D, unsigned char *Coding,unsigned char *P,
					unsigned char *Sel,unsigned char *Session,unsigned char *G,unsigned char *LF);









/**********************************************************************************************************
* 功能：设置CW
* 输入：flag -- 1:开CW，  0：关CW
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetCW( unsigned char flag);


/**********************************************************************************************************
* 功能：获取CW
* 输出：flag -- 1:开CW，  0：关CW
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetCW( unsigned char *flag);


/**********************************************************************************************************
* 功能：天线设置
* 输入：saveflag -- 1:掉电保存，  0：不保存
* 输入：buf--2bytes, 共16bits, 每bit 置1选择对应天线
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetANT( unsigned char saveflag,unsigned char *buf);


/**********************************************************************************************************
* 功能：获取天线设置
* 输出：buf--2bytes, 共16bits,
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetANT( unsigned char *buf);

/**********************************************************************************************************
* 功能：区域设置
* 输入：saveflag -- 1:掉电保存，  0：不保存
* 输入：region -- 0x01(China1),0x02(China2),0x04(Europe),0x08(USA),0x16(Korea),0x32(Japan)
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetRegion( unsigned char saveflag, unsigned char region);

/**********************************************************************************************************
* 功能：获取区域设置
* 输出：region -- 0x01(China1),0x02(China2),0x04(Europe),0x08(USA),0x16(Korea),0x32(Japan)
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetRegion( unsigned char *region);

/**********************************************************************************************************
* 功能：获取当前温度
* 输出：temperature -- 整型
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetTemperature( unsigned int *temperature);


/**********************************************************************************************************
* 功能：设置温度保护
* 输入：flag -- 1:温度保护， 0：无温度保护
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetTemperatureProtect( unsigned char flag);


/**********************************************************************************************************
* 功能：获取温度保护
* 输出：flag -- 1:温度保护， 0：无温度保护
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetTemperatureProtect( unsigned char *flag);


/**********************************************************************************************************
* 功能：设置天线工作时间
* 输入：antnum -- 天线号
* 输入：saveflag -- 1:掉电保存， 0：不保存
* 输入：WorkTime -- 工作时间 ，单位ms, 范围 10-65535ms
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetANTWorkTime(unsigned char antnum,unsigned char saveflag,unsigned int WorkTime);


/**********************************************************************************************************
* 功能：获取天线工作时间
* 输入：antnum -- 天线号
* 输出：WorkTime -- 工作时间 ，单位ms, 范围 10-65535ms
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetANTWorkTime(unsigned char antnum,unsigned int *WorkTime);


/**********************************************************************************************************
* 功能：设置链路组合
* 输入：saveflag -- 1:掉电保存， 0：不保存
* 输入：mode --  0:DSB_ASK/FM0/40KHZ , 1:PR_ASK/Miller4/250KHZ , 2:PR_ASK/Miller4/300KHZ, 3:DSB_ASK/FM0/400KHZ
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetRFLink ( unsigned char saveflag,unsigned char mode);


/**********************************************************************************************************
* 功能：获取链路组合
* 输出：mode --  0:DSB_ASK/FM0/40KHZ , 1:PR_ASK/Miller4/250KHZ , 2:PR_ASK/Miller4/300KHZ, 3:DSB_ASK/FM0/400KHZ
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetRFLink (unsigned char* uMode);


/**********************************************************************************************************
* 功能：设置FastID功能
* 输入：flag -- 1:开启， 0：关闭
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetFastID(unsigned char flag);


/**********************************************************************************************************
* 功能：获取FastID功能
* 输出：flag -- 1:开启， 0：关闭
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetFastID(unsigned char *flag);


/**********************************************************************************************************
* 功能：设置Tagfocus功能
* 输入：flag -- 1:开启， 0：关闭
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetTagfocus(unsigned char flag);


/**********************************************************************************************************
* 功能：获取Tagfocus功能
* 输出：flag -- 1:开启， 0：关闭
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetTagfocus(unsigned char *flag);


/**********************************************************************************************************
* 功能：设置软件复位
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetSoftReset(void);


/**********************************************************************************************************
* 功能：设置Dual和Singel模式
* 输入：saveflag -- 1:掉电保存， 0：不保存
* 输入：mode -- 1:设置Singel模式， 0：设置Dual模式
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetDualSingelMode(unsigned char saveflag,unsigned char mode);


/**********************************************************************************************************
* 功能：获取Dual和Singel模式
* 输出：mode -- 1:设置Singel模式， 0：设置Dual模式
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetDualSingelMode(unsigned char *mode);


/**********************************************************************************************************
* 功能：设置寻标签过滤设置
* 输入：saveflag -- 1:掉电保存， 0：不保存
* 输入：bank --  0x01:EPC , 0x02:TID, 0x03:USR
* 输入：startaddr 起始地址，单位：字节
* 输入：datalen 数据长度， 单位:字节
* 输入：databuf 数据
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetFilter(unsigned char saveflag,unsigned char bank,unsigned int startaddr,unsigned int datalen,unsigned char *databuf);



/**********************************************************************************************************
* 功能：设置EPC和TID模式
* 输入：saveflag -- 1:掉电保存， 0：不保存
* 输入：mode -- 1：开启EPC和TID， 0:关闭
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetEPCTIDMode(unsigned char saveflag,unsigned char mode);


/**********************************************************************************************************
* 功能：获取EPC和TID模式
* 输出：mode -- 1：开启EPC和TID， 0:关闭
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetEPCTIDMode(unsigned char  *mode);



/**********************************************************************************************************
* 功能：恢复出厂设置
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetDefaultMode();



/**********************************************************************************************************
* 功能：单次盘存标签
* 输出：uLenUii -- UII长度
* 输出：uUii -- UII数据
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFInventorySingle (unsigned char* uLenUii, unsigned char* uUii );


/**********************************************************************************************************
* 功能：连续盘存标签
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFInventory();


/**********************************************************************************************************
* 功能：停止盘存标签
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFStopGet();


/**********************************************************************************************************
* 功能：获取连续盘存标签数据
* 输出：uLenUii -- UII长度
* 输出：uUii -- UII数据
*********************************************************************************************************/
extern "C" UHFAPI_API int UHF_GetReceived_EX(int* uLenUii, unsigned char* uUii);


/**********************************************************************************************************
* 功能：读标签数据区
* 输入：uAccessPwd -- 4字节密码
* 输入：FilterBank -- 启动过滤的bank号， 1：EPC, 2:TID, 3:USR
* 输入：FilterStartaddr -- 启动过滤的起始地址， 单位：bit
* 输入：FilterLen -- 启动过滤的长度， 单位：bit
* 输入：FilterData -- 启动过滤的数据
* 输入：uBank -- 读取数据的bank
* 输入：uPtr --  读取数据的起始地址， 单位：字
* 输入：uCnt --  读取数据的长度， 单位：字
* 输出：uReadDatabuf --  读取到的数据
* 输出：uReadDataLen --  读取到的数据长度
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFReadData (unsigned char* uAccessPwd, unsigned char FilterBank,unsigned int FilterStartaddr, unsigned int FilterLen, unsigned char *FilterData,
									                              unsigned char uBank,unsigned int uPtr, unsigned char uCnt, unsigned char* uReadDatabuf, unsigned int* uReadDataLen);




/**********************************************************************************************************
* 功能：写标签数据区
* 输入：uAccessPwd -- 4字节密码
* 输入：FilterBank -- 启动过滤的bank号， 1：EPC, 2:TID, 3:USR
* 输入：FilterStartaddr -- 启动过滤的起始地址， 单位：bit
* 输入：FilterLen -- 启动过滤的长度， 单位：bit
* 输入：FilterData -- 启动过滤的数据  单位：字节
* 输入：uBank -- 读取数据的bank
* 输入：uPtr --  读取数据的起始地址， 单位：字
* 输入：uCnt --  读取数据的长度， 单位：字
* 输入：uWriteDatabuf --  写入的数据
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFWriteData (unsigned char* uAccessPwd, unsigned char FilterBank,unsigned int FilterStartaddr, unsigned int FilterLen, unsigned char *FilterData,
									                              unsigned char uBank,unsigned int uPtr, unsigned char uCnt,unsigned char *uWriteDatabuf);



/**********************************************************************************************************
* 功能：LOCK标签
* 输入：uAccessPwd -- 4字节密码
* 输入：FilterBank -- 启动过滤的bank号， 1：EPC, 2:TID, 3:USR
* 输入：FilterStartaddr -- 启动过滤的起始地址， 单位：字节
* 输入：FilterLen -- 启动过滤的长度， 单位：字节
* 输入：FilterData -- 启动过滤的数据
* 输入：lockbuf --  3字节，第0-9位为Action位， 第10-19位为Mask位
*********************************************************************************************************/
extern "C" UHFAPI_API bool UHFLockTag(unsigned char* uAccessPwd, unsigned char FilterBank,unsigned int FilterStartaddr, unsigned int FilterLen, unsigned char *FilterData,
									                              unsigned char *lockbuf);


/**********************************************************************************************************
* 功能：KILL标签
* 输入：uAccessPwd -- 4字节密码
* 输入：FilterBank -- 启动过滤的bank号， 1：EPC, 2:TID, 3:USR
* 输入：FilterStartaddr -- 启动过滤的起始地址， 单位：字节
* 输入：FilterLen -- 启动过滤的长度， 单位：字节
* 输入：FilterData -- 启动过滤的数据
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFKillTag(unsigned char* uAccessPwd, unsigned char FilterBank,unsigned int FilterStartaddr, unsigned int FilterLen, unsigned char *FilterData);





/**********************************************************************************************************
* 功能：BlockWrite 特定长度的数据到标签的特定地址
* 输入：uAccessPwd -- 4字节密码
* 输入：FilterBank -- 启动过滤的bank号， 1：EPC, 2:TID, 3:USR
* 输入：FilterStartaddr -- 启动过滤的起始地址， 单位：字节
* 输入：FilterLen -- 启动过滤的长度， 单位：字节
* 输入：FilterData -- 启动过滤的数据
* 输入：uBank -- 块号  1：EPC, 2:TID, 3:USR
* 输入：uPtr --  读取数据的起始地址， 单位：字
* 输入：uCnt --  读取数据的长度， 单位：字
* 输入：uWriteDatabuf --  写入的数据
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFBlockWriteData (unsigned char* uAccessPwd, unsigned char FilterBank,unsigned int FilterStartaddr, unsigned int FilterLen, unsigned char *FilterData,
									                              unsigned char uBank,unsigned int uPtr, unsigned char uCnt,unsigned char *uWriteDatabuf);



/**********************************************************************************************************
* 功能：BlockErase 特定长度的数据到标签的特定地址
* 输入：uAccessPwd -- 4字节密码
* 输入：FilterBank -- 启动过滤的bank号， 1：EPC, 2:TID, 3:USR
* 输入：FilterStartaddr -- 启动过滤的起始地址， 单位：字节
* 输入：FilterLen -- 启动过滤的长度， 单位：字节
* 输入：FilterData -- 启动过滤的数据
* 输入：uBank -- 块号  1：EPC, 2:TID, 3:USR
* 输入：uPtr --  读取数据的起始地址， 单位：字
* 输入：uCnt --  读取数据的长度， 单位：字
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFBlockEraseData (unsigned char* uAccessPwd, unsigned char FilterBank,unsigned int FilterStartaddr, unsigned int FilterLen, unsigned char *FilterData,
									                              unsigned char uBank,unsigned int uPtr, unsigned char uCnt);



/**********************************************************************************************************
* 功能：设置QT命令参数
* 输入：uAccessPwd -- 4字节密码
* 输入：FilterBank -- 启动过滤的bank号， 1：EPC, 2:TID, 3:USR
* 输入：FilterStartaddr -- 启动过滤的起始地址， 单位：字节
* 输入：FilterLen -- 启动过滤的长度， 单位：字节
* 输入：FilterData -- 启动过滤的数据
* 输入：QTData --  bit0：（0：表示无近距离控制 ， 1：表示启用近距离控制）  bit1：(0:表示启用private Memory map, 1：启用public memory map)
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetQT (unsigned char* uAccessPwd, unsigned char FilterBank,unsigned int FilterStartaddr, unsigned int FilterLen, unsigned char *FilterData,
									                              unsigned char QTData);



/**********************************************************************************************************
* 功能：获取QT命令参数
* 输入：uAccessPwd -- 4字节密码
* 输入：FilterBank -- 启动过滤的bank号， 1：EPC, 2:TID, 3:USR
* 输入：FilterStartaddr -- 启动过滤的起始地址， 单位：字节
* 输入：FilterLen -- 启动过滤的长度， 单位：字节
* 输入：FilterData -- 启动过滤的数据
* 输出：QTData --  bit0：（0：表示无近距离控制 ， 1：表示启用近距离控制）  bit1：(0:表示启用private Memory map, 1：启用public memory map)
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetQT (unsigned char* uAccessPwd, unsigned char FilterBank,unsigned int FilterStartaddr, unsigned int FilterLen, unsigned char *FilterData,
									                              unsigned char *QTData);




/**********************************************************************************************************
* 功能：QT标签读操作
* 输入：uAccessPwd -- 4字节密码
* 输入：FilterBank -- 启动过滤的bank号， 1：EPC, 2:TID, 3:USR
* 输入：FilterStartaddr -- 启动过滤的起始地址， 单位：字节
* 输入：FilterLen -- 启动过滤的长度， 单位：字节
* 输入：FilterData -- 启动过滤的数据
* 输入：QTData --  bit0：（0：表示无近距离控制 ， 1：表示启用近距离控制）  
* 输入：uBank -- 块号  1：EPC, 2:TID, 3:USR
* 输入：uPtr --  读取数据的起始地址， 单位：字
* 输入：uCnt --  读取数据的长度， 单位：字
* 输出：uReadDatabuf --  读出的数据
* 输出：uReadDataLen --  读出的数据长度
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFReadQT(unsigned char* uAccessPwd, unsigned char FilterBank,unsigned int FilterStartaddr, unsigned int FilterLen, unsigned char *FilterData,
									 unsigned char QTData,unsigned char uBank,unsigned int uPtr, unsigned char uCnt, unsigned  char *uReadDatabuf,unsigned char *uReadDataLen);



/**********************************************************************************************************
* 功能：QT标签写操作
* 输入：uAccessPwd -- 4字节密码
* 输入：FilterBank -- 启动过滤的bank号， 1：EPC, 2:TID, 3:USR
* 输入：FilterStartaddr -- 启动过滤的起始地址， 单位：字节
* 输入：FilterLen -- 启动过滤的长度， 单位：字节
* 输入：FilterData -- 启动过滤的数据
* 输入：QTData --  bit0：（0：表示无近距离控制 ， 1：表示启用近距离控制）  
* 输入：uBank -- 块号  1：EPC, 2:TID, 3:USR
* 输入：uPtr --  读取数据的起始地址， 单位：字
* 输入：uCnt --  读取数据的长度， 单位：字
* 输入：uWriteDatabuf --  写入的数据
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFWriteQT(unsigned char* uAccessPwd, unsigned char FilterBank,unsigned int FilterStartaddr, unsigned int FilterLen, unsigned char *FilterData,
									 unsigned char QTData,unsigned char uBank,unsigned int uPtr, unsigned char uCnt,unsigned char *uWriteDatabuf);




/**********************************************************************************************************
* 功能：Block Permalock操作
* 输入：uAccessPwd -- 4字节密码
* 输入：FilterBank -- 启动过滤的bank号， 1：EPC, 2:TID, 3:USR
* 输入：FilterStartaddr -- 启动过滤的起始地址， 单位：字节
* 输入：FilterLen -- 启动过滤的长度， 单位：字节
* 输入：FilterData -- 启动过滤的数据
* 输入：ReadLock --  bit0：（0：表示Read ， 1：表示Permalock）  
* 输入：uBank -- 块号  1：EPC, 2:TID, 3:USR
* 输入：uPtr --  Block起始地址 ，单位为16个块
* 输入：uRange --  Block范围，单位为16个块
* 输入：uMaskbuf -- 块掩码数据，2个字节，16bit 对应16个块
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFBlockPermalock(unsigned char* uAccessPwd, unsigned char FilterBank,unsigned int FilterStartaddr, unsigned int FilterLen, unsigned char *FilterData,
									 unsigned char ReadLock,unsigned char uBank,unsigned int uPtr, unsigned char uRange,unsigned char *uMaskbuf);






/**********************************************************************************************************
* 功能：激活或失效EM4124标签
* 输入：cmd --整形
* 输入：uAccessPwd -- 4字节密码
* 输入：FilterBank -- 启动过滤的bank号， 1：EPC, 2:TID, 3:USR
* 输入：FilterStartaddr -- 启动过滤的起始地址， 单位：字节
* 输入：FilterData -- 启动过滤的数据

*********************************************************************************************************/
extern "C" UHFAPI_API int UHFDeactivate (unsigned int cmd,unsigned char* uAccessPwd, unsigned char FilterBank,unsigned int FilterStartaddr,unsigned int FilterLen,  unsigned char *FilterData);

extern "C" UHFAPI_API int UHFDwell (unsigned int dwell, unsigned int count);






extern "C" UHFAPI_API int UHFSetIp (unsigned char* ipbuf, unsigned char *postbuf);
extern "C" UHFAPI_API int UHFGetIp (unsigned char* ipbuf, unsigned char *postbuf);
extern "C" UHFAPI_API int UHFSetDestIp (unsigned char* ipbuf, unsigned char *postbuf);
extern "C" UHFAPI_API int UHFGetDestIp (unsigned char* ipbuf, unsigned char *postbuf);
extern "C" UHFAPI_API int UHFSetWorkMode (unsigned char mode);
extern "C" UHFAPI_API int UHFGetWorkMode(unsigned char* mode);
extern "C" UHFAPI_API int UHFSetBeep(unsigned char mode);
extern "C" UHFAPI_API int UHFGetBeep(unsigned char* mode);