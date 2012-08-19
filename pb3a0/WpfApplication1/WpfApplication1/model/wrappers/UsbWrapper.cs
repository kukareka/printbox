using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Management;
using System.Windows;

namespace WpfApplication1
{
    public class UsbWrapper
    {
        public class DriveEventArgs : EventArgs
        {
            public string driveLetter;
            public DriveEventArgs(string driveLetter)
            {
                this.driveLetter = driveLetter;
            }
        }

        ILog log = LogManager.GetLogger(typeof(UsbWrapper));

        public string currentDrive = null;

        public event EventHandler OnDriveIn = null, OnDriveOut = null;

        ManagementEventWatcher eventWatcher;

        public UsbWrapper()
        {
            WqlEventQuery q = new WqlEventQuery("__InstanceOperationEvent", "TargetInstance ISA 'Win32_LogicalDisk'");
            q.WithinInterval = TimeSpan.FromSeconds(1);
            eventWatcher = new ManagementEventWatcher(q);
            eventWatcher.EventArrived += new EventArrivedEventHandler(OnUsbEvent);
            eventWatcher.Start();
            App.Current.Exit += new ExitEventHandler(OnAppExit);
        }

        public void OnAppExit(object sender, ExitEventArgs e)
        {
            eventWatcher.Stop();
        }

        public void OnUsbEvent(object sender, EventArrivedEventArgs e)
        {
            if (e.NewEvent.ClassPath.ClassName.Contains("__InstanceCreationEvent"))
            {
                ManagementBaseObject o = e.NewEvent["TargetInstance"] as ManagementBaseObject;
                string letter = o.GetPropertyValue("Name").ToString();
                App.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                    new Action(() => DriveIn(letter)));
            }
            else if (e.NewEvent.ClassPath.ClassName.Contains("__InstanceDeletionEvent"))
            {
                App.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                    new Action(() => DriveOut()));
            }
        }

        public void DriveIn(string driveLetter)
        {
            if (OnDriveIn != null) OnDriveIn(this, new DriveEventArgs(driveLetter));
        }

        public void DriveOut()
        {
            if (OnDriveOut != null) OnDriveOut(this, null);
        }
    }
}
