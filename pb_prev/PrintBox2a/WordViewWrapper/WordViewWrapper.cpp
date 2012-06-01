// WordViewWrapper.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"

HANDLE wordProcess = NULL;

extern "C"
{
	__declspec(dllexport) void CloseWord()
	{
		HWND wndApp = FindWindow("OpusApp", NULL);
		SendMessage(wndApp, WM_CLOSE, 0, 0);
	}

	__declspec(dllexport) void HideWord()
	{
		HWND wndApp = FindWindow("OpusApp", NULL);
		SetWindowPos(wndApp, NULL, 2000, 2000, 0, 0, SWP_NOSIZE);
	}

	__declspec(dllexport) bool EmbedWord(HWND parent)
	{
		CloseWord();

		STARTUPINFO si = {0};
		PROCESS_INFORMATION pi;
		si.cb = sizeof (si);

		if (CreateProcess(NULL, "C:\\Program Files\\WordViewer\\OFFICE11\\wordview.exe d:\\blank.doc", NULL, NULL, FALSE, 0, NULL, "d:\\", &si, &pi))
		{
			CloseHandle(pi.hThread);			
			CloseHandle(pi.hProcess);

			Sleep(500);

			HWND wndApp = FindWindow("OpusApp", NULL);
			HWND wndDoc, wndDocs = NULL;
			do
			{
				wndDocs = FindWindowEx(wndApp, wndDocs, "_WwF", NULL);
				wndDoc = FindWindowEx(wndDocs, NULL, "_WwB", "blank.doc");			
			}
			while ((wndDoc == NULL) && (wndDocs != NULL));
			if (wndDoc != NULL)
			{
				HWND wndPanel = FindWindowEx(wndDoc, NULL, "_WwG", NULL);
				SetParent(wndPanel, parent);
				HideWord();
				return true;
			}		
		}

		return false;
	}
}