using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;
using log4net;

namespace PrintBox.Logic.Wrappers
{
    public class UsbWrapper
    {
        ILog log = LogManager.GetLogger(typeof(UsbWrapper));
        IntPtr notifyHandle;
        private bool deviceInProgress = false;
        private char deviceInProgressLetter;
        private DateTime deviceInProgressInsertTime;

        public string currentDrive = null;

        public UsbWrapper()
        {
            log.Debug("Initializing usbWrapper");
            notifyHandle = RegisterDeviceNotification(PrintBoxApp.instance.guiManager.GetMainFormHandle());
        }

        public void Stop()
        {
            log.Debug("Stopping UsbWrapper");
            WinApi.UnregisterDeviceNotification(notifyHandle);
        }

        public void Tick()
        {
            if (deviceInProgress)
            {
                TimeSpan timeToWait = new TimeSpan(0, 0, PrintBoxApp.instance.config.UsbTimeout);
                if (DateTime.Now - deviceInProgressInsertTime >= timeToWait)
                {
                    string drivePath = String.Format(@"{0}:\", this.deviceInProgressLetter);
                    deviceInProgress = false;
                    if (!Directory.Exists(drivePath))
                    {
                        PrintBoxApp.instance.DriveOut();
                    }
                }
            }
        }

        public void ProcessMessage(Message m)
        {
            if ((m.Msg == WinApi.WM_DEVICECHANGE) && !deviceInProgress)
            {
                if (m.WParam.ToInt32() == WinApi.DBT_DEVICEARRIVAL)
                {
                    WinApi.DEV_BROADCAST_HDR hdr = (WinApi.DEV_BROADCAST_HDR)Marshal.PtrToStructure(m.LParam, typeof(WinApi.DEV_BROADCAST_HDR));
                    if (hdr.dbch_devicetype == WinApi.DBT_DEVTYP_VOLUME)
                    {
                        WinApi.DEV_BROADCAST_VOLUME vol = (WinApi.DEV_BROADCAST_VOLUME)Marshal.PtrToStructure(m.LParam, typeof(WinApi.DEV_BROADCAST_VOLUME));
                        char driveLetter = GetDriveLetter(vol.dbcv_unitmask);
                        if (driveLetter != '-')
                        {
                            log.DebugFormat("Reported drive in: {0}", driveLetter);
                            string drivePath = String.Format(@"{0}:\", driveLetter);
                            if (Directory.Exists(drivePath))
                            {
                                deviceInProgress = true;
                                this.deviceInProgressLetter = driveLetter;
                                this.deviceInProgressInsertTime = DateTime.Now;
                                PrintBoxApp.instance.DriveIn(drivePath);
                            }
                        }
                    }
                }
                else if (m.WParam.ToInt32() == WinApi.DBT_DEVICEREMOVECOMPLETE)
                {
                    log.DebugFormat("Drive out");
                    if (currentDrive != null)
                    {
                        currentDrive = null;
                        PrintBoxApp.instance.DriveOut();
                    }
                }
            }
        }

        private static IntPtr RegisterDeviceNotification(IntPtr formHandle)
        {
            WinApi.DEV_BROADCAST_DEVICEINTERFACE filter = new WinApi.DEV_BROADCAST_DEVICEINTERFACE();
            filter.dbcc_size = Marshal.SizeOf(filter);
            filter.dbcc_devicetype = WinApi.DBT_DEVTYP_DEVICEINTERFACE;
            IntPtr buffer = Marshal.AllocHGlobal((int)filter.dbcc_size);
            Marshal.StructureToPtr(filter, buffer, false);
            return WinApi.RegisterDeviceNotification(formHandle, buffer,
                WinApi.DEVICE_NOTIFY_WINDOW_HANDLE | WinApi.DEVICE_NOTIFY_ALL_INTERFACE_CLASSES);
        }

        private static char GetDriveLetter(uint unitmask)
        {
            char driveLetter = 'A';
            for (; driveLetter <= 'Z'; ++driveLetter, unitmask = unitmask >> 1)
                if ((unitmask & 0x1) == 1) return driveLetter;
            return '-';
        }
    }
}
