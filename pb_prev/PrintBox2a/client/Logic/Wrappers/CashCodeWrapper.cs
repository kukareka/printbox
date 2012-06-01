using CashCodeLib;
using log4net;

namespace PrintBox.Logic.Wrappers
{
    public class CashCodeWrapper
    {
        ILog log = LogManager.GetLogger(typeof(CashCodeWrapper));
        public CashCode cashCode;

        private bool _cashCodeEnabled = false;
        public bool CashCodeEnabled
        {
            get { return _cashCodeEnabled; }
            set
            {
                if (!PrintBoxApp.instance.runOptions.testMode)
                {
                    if (value) cashCode.Enable();
                    else cashCode.Disable();
                }
                else
                {
                    PrintBoxApp.instance.guiManager.EnableCashCode(value);
                }
                _cashCodeEnabled = value;
            }
        }

        public CashCodeWrapper()
        {
            if (!PrintBoxApp.instance.runOptions.testMode)
            {
                log.Debug("Initializing cashcode");
                cashCode = new CashCode(PrintBoxApp.instance.config.CashCodePort);
                cashCode.BillStacked += new BillStackedEventHandler(cashCode_BillStacked);
                cashCode.Reset();
            }
        }

        public void Tick()
        {
            if (!PrintBoxApp.instance.runOptions.testMode && CashCodeEnabled)
            {
                cashCode.Poll();
            }
        }

        public void cashCode_BillStacked(object sender, BillStackedEventArgs e)
        {
            PrintBoxApp.instance.MoneyIn(e.denomination);
        }
    }
}
