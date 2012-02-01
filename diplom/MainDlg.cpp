// MainDlg.cpp : implementation of the CMainDlg class
//
/////////////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "resource.h"

#include "MainDlg.h"
byte bBmpDat[10000];

LRESULT CMainDlg::OnInitDialog(UINT /*uMsg*/, WPARAM /*wParam*/, LPARAM /*lParam*/, BOOL& /*bHandled*/)
{
	// center the dialog on the screen
	CenterWindow();

	// set icons
	HICON hIcon = (HICON)::LoadImage(_Module.GetResourceInstance(), MAKEINTRESOURCE(IDR_MAINFRAME), 
		IMAGE_ICON, ::GetSystemMetrics(SM_CXICON), ::GetSystemMetrics(SM_CYICON), LR_DEFAULTCOLOR);
	SetIcon(hIcon, TRUE);
	HICON hIconSmall = (HICON)::LoadImage(_Module.GetResourceInstance(), MAKEINTRESOURCE(IDR_MAINFRAME), 
		IMAGE_ICON, ::GetSystemMetrics(SM_CXSMICON), ::GetSystemMetrics(SM_CYSMICON), LR_DEFAULTCOLOR);
	SetIcon(hIconSmall, FALSE);
	init();

	return TRUE;
}

LRESULT CMainDlg::OnAppAbout(WORD /*wNotifyCode*/, WORD /*wID*/, HWND /*hWndCtl*/, BOOL& /*bHandled*/)
{
	CSimpleDialog<IDD_ABOUTBOX, FALSE> dlg;
	dlg.DoModal();
	return 0;
}

LRESULT CMainDlg::OnOK(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& /*bHandled*/)
{
	// TODO: Add validation code 
	EndDialog(wID);
	return 0;
}

LRESULT CMainDlg::OnCancel(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& /*bHandled*/)
{
	EndDialog(wID);
	return 0;
}
void CMainDlg::LoadFile(void)
{
	DWORD dwRead;	
	HANDLE hFile = CreateFile("..\\img\\input.bmp",GENERIC_READ,0,NULL,OPEN_EXISTING,
		FILE_ATTRIBUTE_NORMAL,0);
	ReadFile(hFile, &bBmpDat, sizeof(bBmpDat), &dwRead,NULL);
	CloseHandle(hFile);
	
	
}
void CMainDlg::SaveFile(void)
{
	DWORD dwWriten;
	HANDLE hFile = CreateFile("..\\img\\output.bmp",GENERIC_WRITE,0,NULL,
		CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL,0);
	WriteFile(hFile, &bBmpDat, sizeof(bBmpDat), &dwWriten, NULL);
	CloseHandle(hFile);

}
LRESULT CMainDlg::OnBnClickedOpen(WORD /*wNotifyCode*/, WORD /*wID*/, HWND /*hWndCtl*/, BOOL& /*bHandled*/)
{	
	/*void SaveFile()
	{
		DWORD NumWritten;	
		HANDLE hFile = CreateFile("Data.dat",GENERIC_WRITE,
			0,NULL,CREATE_ALWAYS,FILE_ATTRIBUTE_NORMAL,0);	
		WriteFile(hFile,&Base,sizeof(Base),&NumWritten,NULL);		
		CloseHandle(hFile);		
	}
	void LoadFile()
	{
		DWORD NumRead;
		HANDLE hFile = CreateFile("Data.dat",GENERIC_READ,
			0,NULL,OPEN_EXISTING,FILE_ATTRIBUTE_NORMAL,0);
		ReadFile(hFile,&Base,sizeof(Base),&NumRead,NULL);
		CloseHandle(hFile);

	}*/

	LoadFile();
	SaveFile();
	MessageBox("Save/Load Done", "Test", MB_OK);
	// TODO: Add your control notification handler code here
	return 0;
}
void CMainDlg::init(void)
{
	CxImage cxImg, cxImg2;
	long sizeximg = 0;
	BYTE* ximgbuffer =0;
//	bool iload = cxImg.Load("..\\img\\input.bmp",CXIMAGE_FORMAT_BMP);
	bool iload = cxImg.Load("input.bmp",CXIMAGE_FORMAT_BMP);
	//if(iload==true)
	//{	
		cxImg.Encode(ximgbuffer, sizeximg, CXIMAGE_FORMAT_BMP);
		//////////////////////////////////////////////////////////////////////////
		cxImg.GetDIB();
		//////////////////////////////////////////////////////////////////////////
		
		cxImg2.Decode(ximgbuffer, sizeximg, CXIMAGE_FORMAT_BMP);
//		cxImg.Save("..\\img\\out.jp2", CXIMAGE_FORMAT_JP2);	
		cxImg2.Save("out.jp2", CXIMAGE_FORMAT_JP2);	
	//}
}