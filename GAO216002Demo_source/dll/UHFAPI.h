// ���� ifdef ���Ǵ���ʹ�� DLL �������򵥵�
// ��ı�׼�������� DLL �е������ļ��������������϶���� UHFAPI_EXPORTS
// ���ű���ġ���ʹ�ô� DLL ��
// �κ�������Ŀ�ϲ�Ӧ����˷��š�������Դ�ļ��а������ļ����κ�������Ŀ���Ὣ
// UHFAPI_API ������Ϊ�Ǵ� DLL ����ģ����� DLL ���ô˺궨���
// ������Ϊ�Ǳ������ġ�
#ifdef UHFAPI_EXPORTS
#define UHFAPI_API __declspec(dllexport)
#else
#define UHFAPI_API __declspec(dllimport)
#endif

// �����Ǵ� UHFAPI.dll ������
class UHFAPI_API CUHFAPI {
public:
	CUHFAPI(void);
	// TODO: �ڴ�������ķ�����
};

extern UHFAPI_API int nUHFAPI;

UHFAPI_API int fnUHFAPI(void);


extern "C"  UHFAPI_API int TCPConnect(const char * hostaddr,int hostport);
extern "C"  UHFAPI_API void TCPDisconnect();
/**********************************************************************************************************
* ���ܣ��򿪴���
* ���룺port--���ں�
*********************************************************************************************************/

extern "C"  UHFAPI_API int ComOpen(int port);


/**********************************************************************************************************
* ���ܣ��رմ���
*********************************************************************************************************/
extern "C" UHFAPI_API void ClosePort();



/**********************************************************************************************************
* ���ܣ���ȡӲ���汾��
* �����version[0]--�汾�ų��� ,  version[1--x]--�汾��
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetHardwareVersion(unsigned char *version);


/**********************************************************************************************************
* ���ܣ���ȡ����汾��
* �����version[0]--�汾�ų��� ,  version[1--x]--�汾��
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetSoftwareVersion(unsigned char *version);



/**********************************************************************************************************
* ���ܣ���ȡID��
* �����id--����ID��
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetDeviceID(unsigned int *id);


/**********************************************************************************************************
* ���ܣ����ù���
* ���룺saveflag  -- 1:��������   0��������
* ���룺uPower -- ���ʣ�DB��
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetPower ( unsigned char saveflag,unsigned char uPower);



/**********************************************************************************************************
* ���ܣ���ȡ����
* �����uPower -- ���ʣ�DB��
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetPower (unsigned char *uPower);


/**********************************************************************************************************
* ���ܣ�������Ƶ
* ���룺nums -- ��Ƶ����
* ���룺Freqbuf--Ƶ�����飨���ͣ� ����920125��921250.....
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetJumpFrequency( unsigned char nums,unsigned int *Freqbuf);




/**********************************************************************************************************
* ���ܣ���ȡ��Ƶ
* �����Freqbuf[0]--Ƶ������� Freqbuf[1]..[x]--Ƶ�����飨���ͣ�
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetJumpFrequency( unsigned int *Freqbuf);





/**********************************************************************************************************
* ���ܣ�����Gen2����
* ���룺
**********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetGen2 (unsigned char Target,unsigned char Action, unsigned char T,unsigned char Q,
								unsigned char StartQ,unsigned char MinQ,
								unsigned char MaxQ,unsigned char D,unsigned char C,unsigned char P,
								unsigned char Sel,unsigned char Session,unsigned char G,unsigned char LF);

/**********************************************************************************************************
* ���ܣ���ȡGen2����
* ���룺
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetGen2 (unsigned char *Target, unsigned char *Action,unsigned char *T,unsigned char *Q,
					unsigned char *StartQ,unsigned char *MinQ,
					unsigned char *MaxQ,unsigned char *D, unsigned char *Coding,unsigned char *P,
					unsigned char *Sel,unsigned char *Session,unsigned char *G,unsigned char *LF);









/**********************************************************************************************************
* ���ܣ�����CW
* ���룺flag -- 1:��CW��  0����CW
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetCW( unsigned char flag);


/**********************************************************************************************************
* ���ܣ���ȡCW
* �����flag -- 1:��CW��  0����CW
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetCW( unsigned char *flag);


/**********************************************************************************************************
* ���ܣ���������
* ���룺saveflag -- 1:���籣�棬  0��������
* ���룺buf--2bytes, ��16bits, ÿbit ��1ѡ���Ӧ����
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetANT( unsigned char saveflag,unsigned char *buf);


/**********************************************************************************************************
* ���ܣ���ȡ��������
* �����buf--2bytes, ��16bits,
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetANT( unsigned char *buf);

/**********************************************************************************************************
* ���ܣ���������
* ���룺saveflag -- 1:���籣�棬  0��������
* ���룺region -- 0x01(China1),0x02(China2),0x04(Europe),0x08(USA),0x16(Korea),0x32(Japan)
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetRegion( unsigned char saveflag, unsigned char region);

/**********************************************************************************************************
* ���ܣ���ȡ��������
* �����region -- 0x01(China1),0x02(China2),0x04(Europe),0x08(USA),0x16(Korea),0x32(Japan)
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetRegion( unsigned char *region);

/**********************************************************************************************************
* ���ܣ���ȡ��ǰ�¶�
* �����temperature -- ����
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetTemperature( unsigned int *temperature);


/**********************************************************************************************************
* ���ܣ������¶ȱ���
* ���룺flag -- 1:�¶ȱ����� 0�����¶ȱ���
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetTemperatureProtect( unsigned char flag);


/**********************************************************************************************************
* ���ܣ���ȡ�¶ȱ���
* �����flag -- 1:�¶ȱ����� 0�����¶ȱ���
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetTemperatureProtect( unsigned char *flag);


/**********************************************************************************************************
* ���ܣ��������߹���ʱ��
* ���룺antnum -- ���ߺ�
* ���룺saveflag -- 1:���籣�棬 0��������
* ���룺WorkTime -- ����ʱ�� ����λms, ��Χ 10-65535ms
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetANTWorkTime(unsigned char antnum,unsigned char saveflag,unsigned int WorkTime);


/**********************************************************************************************************
* ���ܣ���ȡ���߹���ʱ��
* ���룺antnum -- ���ߺ�
* �����WorkTime -- ����ʱ�� ����λms, ��Χ 10-65535ms
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetANTWorkTime(unsigned char antnum,unsigned int *WorkTime);


/**********************************************************************************************************
* ���ܣ�������·���
* ���룺saveflag -- 1:���籣�棬 0��������
* ���룺mode --  0:DSB_ASK/FM0/40KHZ , 1:PR_ASK/Miller4/250KHZ , 2:PR_ASK/Miller4/300KHZ, 3:DSB_ASK/FM0/400KHZ
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetRFLink ( unsigned char saveflag,unsigned char mode);


/**********************************************************************************************************
* ���ܣ���ȡ��·���
* �����mode --  0:DSB_ASK/FM0/40KHZ , 1:PR_ASK/Miller4/250KHZ , 2:PR_ASK/Miller4/300KHZ, 3:DSB_ASK/FM0/400KHZ
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetRFLink (unsigned char* uMode);


/**********************************************************************************************************
* ���ܣ�����FastID����
* ���룺flag -- 1:������ 0���ر�
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetFastID(unsigned char flag);


/**********************************************************************************************************
* ���ܣ���ȡFastID����
* �����flag -- 1:������ 0���ر�
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetFastID(unsigned char *flag);


/**********************************************************************************************************
* ���ܣ�����Tagfocus����
* ���룺flag -- 1:������ 0���ر�
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetTagfocus(unsigned char flag);


/**********************************************************************************************************
* ���ܣ���ȡTagfocus����
* �����flag -- 1:������ 0���ر�
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetTagfocus(unsigned char *flag);


/**********************************************************************************************************
* ���ܣ����������λ
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetSoftReset(void);


/**********************************************************************************************************
* ���ܣ�����Dual��Singelģʽ
* ���룺saveflag -- 1:���籣�棬 0��������
* ���룺mode -- 1:����Singelģʽ�� 0������Dualģʽ
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetDualSingelMode(unsigned char saveflag,unsigned char mode);


/**********************************************************************************************************
* ���ܣ���ȡDual��Singelģʽ
* �����mode -- 1:����Singelģʽ�� 0������Dualģʽ
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetDualSingelMode(unsigned char *mode);


/**********************************************************************************************************
* ���ܣ�����Ѱ��ǩ��������
* ���룺saveflag -- 1:���籣�棬 0��������
* ���룺bank --  0x01:EPC , 0x02:TID, 0x03:USR
* ���룺startaddr ��ʼ��ַ����λ���ֽ�
* ���룺datalen ���ݳ��ȣ� ��λ:�ֽ�
* ���룺databuf ����
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetFilter(unsigned char saveflag,unsigned char bank,unsigned int startaddr,unsigned int datalen,unsigned char *databuf);



/**********************************************************************************************************
* ���ܣ�����EPC��TIDģʽ
* ���룺saveflag -- 1:���籣�棬 0��������
* ���룺mode -- 1������EPC��TID�� 0:�ر�
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetEPCTIDMode(unsigned char saveflag,unsigned char mode);


/**********************************************************************************************************
* ���ܣ���ȡEPC��TIDģʽ
* �����mode -- 1������EPC��TID�� 0:�ر�
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetEPCTIDMode(unsigned char  *mode);



/**********************************************************************************************************
* ���ܣ��ָ���������
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetDefaultMode();



/**********************************************************************************************************
* ���ܣ������̴��ǩ
* �����uLenUii -- UII����
* �����uUii -- UII����
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFInventorySingle (unsigned char* uLenUii, unsigned char* uUii );


/**********************************************************************************************************
* ���ܣ������̴��ǩ
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFInventory();


/**********************************************************************************************************
* ���ܣ�ֹͣ�̴��ǩ
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFStopGet();


/**********************************************************************************************************
* ���ܣ���ȡ�����̴��ǩ����
* �����uLenUii -- UII����
* �����uUii -- UII����
*********************************************************************************************************/
extern "C" UHFAPI_API int UHF_GetReceived_EX(int* uLenUii, unsigned char* uUii);


/**********************************************************************************************************
* ���ܣ�����ǩ������
* ���룺uAccessPwd -- 4�ֽ�����
* ���룺FilterBank -- �������˵�bank�ţ� 1��EPC, 2:TID, 3:USR
* ���룺FilterStartaddr -- �������˵���ʼ��ַ�� ��λ��bit
* ���룺FilterLen -- �������˵ĳ��ȣ� ��λ��bit
* ���룺FilterData -- �������˵�����
* ���룺uBank -- ��ȡ���ݵ�bank
* ���룺uPtr --  ��ȡ���ݵ���ʼ��ַ�� ��λ����
* ���룺uCnt --  ��ȡ���ݵĳ��ȣ� ��λ����
* �����uReadDatabuf --  ��ȡ��������
* �����uReadDataLen --  ��ȡ�������ݳ���
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFReadData (unsigned char* uAccessPwd, unsigned char FilterBank,unsigned int FilterStartaddr, unsigned int FilterLen, unsigned char *FilterData,
									                              unsigned char uBank,unsigned int uPtr, unsigned char uCnt, unsigned char* uReadDatabuf, unsigned int* uReadDataLen);




/**********************************************************************************************************
* ���ܣ�д��ǩ������
* ���룺uAccessPwd -- 4�ֽ�����
* ���룺FilterBank -- �������˵�bank�ţ� 1��EPC, 2:TID, 3:USR
* ���룺FilterStartaddr -- �������˵���ʼ��ַ�� ��λ��bit
* ���룺FilterLen -- �������˵ĳ��ȣ� ��λ��bit
* ���룺FilterData -- �������˵�����  ��λ���ֽ�
* ���룺uBank -- ��ȡ���ݵ�bank
* ���룺uPtr --  ��ȡ���ݵ���ʼ��ַ�� ��λ����
* ���룺uCnt --  ��ȡ���ݵĳ��ȣ� ��λ����
* ���룺uWriteDatabuf --  д�������
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFWriteData (unsigned char* uAccessPwd, unsigned char FilterBank,unsigned int FilterStartaddr, unsigned int FilterLen, unsigned char *FilterData,
									                              unsigned char uBank,unsigned int uPtr, unsigned char uCnt,unsigned char *uWriteDatabuf);



/**********************************************************************************************************
* ���ܣ�LOCK��ǩ
* ���룺uAccessPwd -- 4�ֽ�����
* ���룺FilterBank -- �������˵�bank�ţ� 1��EPC, 2:TID, 3:USR
* ���룺FilterStartaddr -- �������˵���ʼ��ַ�� ��λ���ֽ�
* ���룺FilterLen -- �������˵ĳ��ȣ� ��λ���ֽ�
* ���룺FilterData -- �������˵�����
* ���룺lockbuf --  3�ֽڣ���0-9λΪActionλ�� ��10-19λΪMaskλ
*********************************************************************************************************/
extern "C" UHFAPI_API bool UHFLockTag(unsigned char* uAccessPwd, unsigned char FilterBank,unsigned int FilterStartaddr, unsigned int FilterLen, unsigned char *FilterData,
									                              unsigned char *lockbuf);


/**********************************************************************************************************
* ���ܣ�KILL��ǩ
* ���룺uAccessPwd -- 4�ֽ�����
* ���룺FilterBank -- �������˵�bank�ţ� 1��EPC, 2:TID, 3:USR
* ���룺FilterStartaddr -- �������˵���ʼ��ַ�� ��λ���ֽ�
* ���룺FilterLen -- �������˵ĳ��ȣ� ��λ���ֽ�
* ���룺FilterData -- �������˵�����
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFKillTag(unsigned char* uAccessPwd, unsigned char FilterBank,unsigned int FilterStartaddr, unsigned int FilterLen, unsigned char *FilterData);





/**********************************************************************************************************
* ���ܣ�BlockWrite �ض����ȵ����ݵ���ǩ���ض���ַ
* ���룺uAccessPwd -- 4�ֽ�����
* ���룺FilterBank -- �������˵�bank�ţ� 1��EPC, 2:TID, 3:USR
* ���룺FilterStartaddr -- �������˵���ʼ��ַ�� ��λ���ֽ�
* ���룺FilterLen -- �������˵ĳ��ȣ� ��λ���ֽ�
* ���룺FilterData -- �������˵�����
* ���룺uBank -- ���  1��EPC, 2:TID, 3:USR
* ���룺uPtr --  ��ȡ���ݵ���ʼ��ַ�� ��λ����
* ���룺uCnt --  ��ȡ���ݵĳ��ȣ� ��λ����
* ���룺uWriteDatabuf --  д�������
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFBlockWriteData (unsigned char* uAccessPwd, unsigned char FilterBank,unsigned int FilterStartaddr, unsigned int FilterLen, unsigned char *FilterData,
									                              unsigned char uBank,unsigned int uPtr, unsigned char uCnt,unsigned char *uWriteDatabuf);



/**********************************************************************************************************
* ���ܣ�BlockErase �ض����ȵ����ݵ���ǩ���ض���ַ
* ���룺uAccessPwd -- 4�ֽ�����
* ���룺FilterBank -- �������˵�bank�ţ� 1��EPC, 2:TID, 3:USR
* ���룺FilterStartaddr -- �������˵���ʼ��ַ�� ��λ���ֽ�
* ���룺FilterLen -- �������˵ĳ��ȣ� ��λ���ֽ�
* ���룺FilterData -- �������˵�����
* ���룺uBank -- ���  1��EPC, 2:TID, 3:USR
* ���룺uPtr --  ��ȡ���ݵ���ʼ��ַ�� ��λ����
* ���룺uCnt --  ��ȡ���ݵĳ��ȣ� ��λ����
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFBlockEraseData (unsigned char* uAccessPwd, unsigned char FilterBank,unsigned int FilterStartaddr, unsigned int FilterLen, unsigned char *FilterData,
									                              unsigned char uBank,unsigned int uPtr, unsigned char uCnt);



/**********************************************************************************************************
* ���ܣ�����QT�������
* ���룺uAccessPwd -- 4�ֽ�����
* ���룺FilterBank -- �������˵�bank�ţ� 1��EPC, 2:TID, 3:USR
* ���룺FilterStartaddr -- �������˵���ʼ��ַ�� ��λ���ֽ�
* ���룺FilterLen -- �������˵ĳ��ȣ� ��λ���ֽ�
* ���룺FilterData -- �������˵�����
* ���룺QTData --  bit0����0����ʾ�޽�������� �� 1����ʾ���ý�������ƣ�  bit1��(0:��ʾ����private Memory map, 1������public memory map)
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFSetQT (unsigned char* uAccessPwd, unsigned char FilterBank,unsigned int FilterStartaddr, unsigned int FilterLen, unsigned char *FilterData,
									                              unsigned char QTData);



/**********************************************************************************************************
* ���ܣ���ȡQT�������
* ���룺uAccessPwd -- 4�ֽ�����
* ���룺FilterBank -- �������˵�bank�ţ� 1��EPC, 2:TID, 3:USR
* ���룺FilterStartaddr -- �������˵���ʼ��ַ�� ��λ���ֽ�
* ���룺FilterLen -- �������˵ĳ��ȣ� ��λ���ֽ�
* ���룺FilterData -- �������˵�����
* �����QTData --  bit0����0����ʾ�޽�������� �� 1����ʾ���ý�������ƣ�  bit1��(0:��ʾ����private Memory map, 1������public memory map)
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFGetQT (unsigned char* uAccessPwd, unsigned char FilterBank,unsigned int FilterStartaddr, unsigned int FilterLen, unsigned char *FilterData,
									                              unsigned char *QTData);




/**********************************************************************************************************
* ���ܣ�QT��ǩ������
* ���룺uAccessPwd -- 4�ֽ�����
* ���룺FilterBank -- �������˵�bank�ţ� 1��EPC, 2:TID, 3:USR
* ���룺FilterStartaddr -- �������˵���ʼ��ַ�� ��λ���ֽ�
* ���룺FilterLen -- �������˵ĳ��ȣ� ��λ���ֽ�
* ���룺FilterData -- �������˵�����
* ���룺QTData --  bit0����0����ʾ�޽�������� �� 1����ʾ���ý�������ƣ�  
* ���룺uBank -- ���  1��EPC, 2:TID, 3:USR
* ���룺uPtr --  ��ȡ���ݵ���ʼ��ַ�� ��λ����
* ���룺uCnt --  ��ȡ���ݵĳ��ȣ� ��λ����
* �����uReadDatabuf --  ����������
* �����uReadDataLen --  ���������ݳ���
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFReadQT(unsigned char* uAccessPwd, unsigned char FilterBank,unsigned int FilterStartaddr, unsigned int FilterLen, unsigned char *FilterData,
									 unsigned char QTData,unsigned char uBank,unsigned int uPtr, unsigned char uCnt, unsigned  char *uReadDatabuf,unsigned char *uReadDataLen);



/**********************************************************************************************************
* ���ܣ�QT��ǩд����
* ���룺uAccessPwd -- 4�ֽ�����
* ���룺FilterBank -- �������˵�bank�ţ� 1��EPC, 2:TID, 3:USR
* ���룺FilterStartaddr -- �������˵���ʼ��ַ�� ��λ���ֽ�
* ���룺FilterLen -- �������˵ĳ��ȣ� ��λ���ֽ�
* ���룺FilterData -- �������˵�����
* ���룺QTData --  bit0����0����ʾ�޽�������� �� 1����ʾ���ý�������ƣ�  
* ���룺uBank -- ���  1��EPC, 2:TID, 3:USR
* ���룺uPtr --  ��ȡ���ݵ���ʼ��ַ�� ��λ����
* ���룺uCnt --  ��ȡ���ݵĳ��ȣ� ��λ����
* ���룺uWriteDatabuf --  д�������
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFWriteQT(unsigned char* uAccessPwd, unsigned char FilterBank,unsigned int FilterStartaddr, unsigned int FilterLen, unsigned char *FilterData,
									 unsigned char QTData,unsigned char uBank,unsigned int uPtr, unsigned char uCnt,unsigned char *uWriteDatabuf);




/**********************************************************************************************************
* ���ܣ�Block Permalock����
* ���룺uAccessPwd -- 4�ֽ�����
* ���룺FilterBank -- �������˵�bank�ţ� 1��EPC, 2:TID, 3:USR
* ���룺FilterStartaddr -- �������˵���ʼ��ַ�� ��λ���ֽ�
* ���룺FilterLen -- �������˵ĳ��ȣ� ��λ���ֽ�
* ���룺FilterData -- �������˵�����
* ���룺ReadLock --  bit0����0����ʾRead �� 1����ʾPermalock��  
* ���룺uBank -- ���  1��EPC, 2:TID, 3:USR
* ���룺uPtr --  Block��ʼ��ַ ����λΪ16����
* ���룺uRange --  Block��Χ����λΪ16����
* ���룺uMaskbuf -- ���������ݣ�2���ֽڣ�16bit ��Ӧ16����
*********************************************************************************************************/
extern "C" UHFAPI_API int UHFBlockPermalock(unsigned char* uAccessPwd, unsigned char FilterBank,unsigned int FilterStartaddr, unsigned int FilterLen, unsigned char *FilterData,
									 unsigned char ReadLock,unsigned char uBank,unsigned int uPtr, unsigned char uRange,unsigned char *uMaskbuf);






/**********************************************************************************************************
* ���ܣ������ʧЧEM4124��ǩ
* ���룺cmd --����
* ���룺uAccessPwd -- 4�ֽ�����
* ���룺FilterBank -- �������˵�bank�ţ� 1��EPC, 2:TID, 3:USR
* ���룺FilterStartaddr -- �������˵���ʼ��ַ�� ��λ���ֽ�
* ���룺FilterData -- �������˵�����

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