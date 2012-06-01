using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using log4net;
using PrintBoxMain;
using PrintBox.Logic;
using PrintBox.Logic.Wrappers;

namespace PrintBox.GUI.Forms
{
    public partial class PrePrintForm : Form
    {
        ILog log = LogManager.GetLogger(typeof(PrePrintForm));

        private System.ComponentModel.ComponentResourceManager resources;
                
        public const int WORD_PANEL_WIDTH_NORMAL = 600;
        public const int WORD_PANEL_HEIGHT_NORMAL = 740;
        
        public PrePrintForm()
        {
            WinApi.SuspendDrawing(this);
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            resources = new ComponentResourceManager(typeof(PrePrintForm));
            ExecEmbedWordWindow += EmbedWordWindow;
            InitForm();
            btnRemindPassword.Text = "Нагадати\r\n  пароль";

            WinApi.ResumeDrawing(this);
        }

        private void InitForm()
        {
            pnlWord.Left = 26;
            pnlWord.Top = 116;
            pnlWord.Width = WORD_PANEL_WIDTH_NORMAL;
            pnlWord.Height = WORD_PANEL_HEIGHT_NORMAL;
            this.BackColor = Color.FromArgb(236, 244, 251);

            lblBoxID.Text = ResourcesMessages.txtBoxID.Replace("<!--BoxID-->", PrintBoxApp.instance.config.BoxID.ToString());


            pnlPrePrint.Height = pnlMoneyInput.Height = 855;
            pnlPrePrint.Width = pnlMoneyInput.Width = 454;

            pnlPrePrint.Visible = pnlMoneyInput.Visible = false;

            PrintBoxApp.instance.pdfWrapper.SetReader(pdfReader);

        }

        private void StepForward()
        {
            if (!PrintBoxApp.instance.printOptions.valid)
            {
                PrintBoxApp.instance.guiManager.ShowError(ResourcesMessages.msgInvalidPrintParams);
                return;
            }
            int pagesToPrint = PrintBoxApp.instance.printOptions.pagesToPrint;
            if (pagesToPrint > 150)
            {
                PrintBoxApp.instance.guiManager.ShowError(ResourcesMessages.msgMoreThan150PagesForPrint);
                return;
            }
            if (pagesToPrint > PrintBoxApp.instance.state.PaperInside)
            {
                PrintBoxApp.instance.guiManager.ShowError(ResourcesMessages.msgNotEnoughPagesForPrint, PrintBoxApp.instance.state.PaperInside.ToString());
                return;
            }
            if (!PrintBoxApp.instance.printerWrapper.OK())
            {
                PrintBoxApp.instance.guiManager.ShowError(ResourcesMessages.msgPrinterIsNotReady);
                return;
            }

            WinApi.SuspendDrawing(pnlNavigationButtons);
            btnBack.Visible = true;
            btnNext.Visible = false;
            WinApi.ResumeDrawing(pnlNavigationButtons);

            InvalidateUser();
            pnlPrePrint.Visible = false;
            pnlMoneyInput.Visible = true;
        }

        public void StepBackward()
        {
            WinApi.SuspendDrawing(pnlNavigationButtons);
            btnBack.Visible = false;
            btnPrint.Visible = false;
            btnNext.Visible = true;
            WinApi.ResumeDrawing(pnlNavigationButtons);

            pnlMoneyInput.Visible = false;
            pnlPrePrint.Visible = true;
            PrintBoxApp.instance.cashCodeWrapper.CashCodeEnabled = false;
        }

        public void EnableNavigationButtons(bool flag)
        {
            if (flag)
            {
                btnCancelPrint.Enabled = true;
                btnNext.Enabled = true;
                btnScrollDown.Enabled = true;
                btnScrollUp.Enabled = true;
                btnScrollDown.NormalImage = ((System.Drawing.Image)(ResourcesMessages.scroll_button_down));
                btnScrollUp.NormalImage = ((System.Drawing.Image)(ResourcesMessages.scroll_button_up));
                btnCancelPrint.NormalImage = ((System.Drawing.Image)(ResourcesMessages.preprint_cancel));
                btnNext.NormalImage = ((System.Drawing.Image)(ResourcesMessages.preprint_next));
            }
            else
            {
                btnCancelPrint.Enabled = false;
                btnNext.Enabled = false;
                btnScrollDown.Enabled = false;
                btnScrollUp.Enabled = false;
                btnScrollDown.NormalImage = ((System.Drawing.Image)(ResourcesMessages.scroll_button_down_disabled));
                btnScrollUp.NormalImage = ((System.Drawing.Image)(ResourcesMessages.scroll_button_up_disabled));
                btnCancelPrint.NormalImage = ((System.Drawing.Image)(ResourcesMessages.preprint_cancel_disabled));
                btnNext.NormalImage = ((System.Drawing.Image)(ResourcesMessages.preprint_next_disabled));
            }
        }

        public void EnableAllVisibleButtons(bool flag)
        {
            if (flag)
            {
                if (btnCancelPrint.Visible)
                {
                    //TODO Убрать эти тупые макароны EnableAllVisibleButtons
                    WinApi.SuspendDrawing(btnCancelPrint);
                    btnCancelPrint.Enabled = true;
                    btnCancelPrint.NormalImage = ((System.Drawing.Image)(ResourcesMessages.preprint_cancel));
                    WinApi.ResumeDrawing(btnCancelPrint);
                }
                if (btnNext.Visible)
                {
                    WinApi.SuspendDrawing(btnNext);
                    btnNext.Enabled = true;
                    btnNext.NormalImage = ((System.Drawing.Image)(ResourcesMessages.preprint_next));
                    WinApi.ResumeDrawing(btnNext);
                }
                if (btnScrollDown.Visible)
                {
                    WinApi.SuspendDrawing(btnScrollDown);
                    btnScrollDown.Enabled = true;
                    btnScrollDown.NormalImage = ((System.Drawing.Image)(ResourcesMessages.scroll_button_down));
                    WinApi.ResumeDrawing(btnScrollDown);
                }
                if (btnScrollUp.Visible)
                {
                    WinApi.SuspendDrawing(btnScrollUp);
                    btnScrollUp.Enabled = true;
                    btnScrollUp.NormalImage = ((System.Drawing.Image)(ResourcesMessages.scroll_button_up));
                    WinApi.ResumeDrawing(btnScrollUp);
                }
                if (btnPrint.Visible)
                {
                    WinApi.SuspendDrawing(btnPrint);
                    btnPrint.Enabled = true;
                    btnPrint.NormalImage = ((System.Drawing.Image)(ResourcesMessages.preprint_print));
                    WinApi.ResumeDrawing(btnPrint);
                }
                if (btnBack.Visible)
                {
                    WinApi.SuspendDrawing(btnBack);
                    btnBack.Enabled = true;
                    btnBack.NormalImage = ((System.Drawing.Image)(ResourcesMessages.preprint_back));
                    WinApi.ResumeDrawing(btnBack);
                }
            }
            else
            {
                if (btnCancelPrint.Visible)
                {
                    WinApi.SuspendDrawing(btnCancelPrint);
                    btnCancelPrint.Enabled = false;
                    btnCancelPrint.NormalImage = ((System.Drawing.Image)(ResourcesMessages.preprint_cancel_disabled));
                    WinApi.ResumeDrawing(btnCancelPrint);
                }
                if (btnNext.Visible)
                {
                    WinApi.SuspendDrawing(btnNext);
                    btnNext.Enabled = false;
                    btnNext.NormalImage = ((System.Drawing.Image)(ResourcesMessages.preprint_next_disabled));
                    WinApi.ResumeDrawing(btnNext);
                }
                if (btnScrollDown.Visible)
                {
                    WinApi.SuspendDrawing(btnScrollDown);
                    btnScrollDown.Enabled = false;
                    btnScrollDown.NormalImage = ((System.Drawing.Image)(ResourcesMessages.scroll_button_down_disabled));
                    WinApi.ResumeDrawing(btnScrollDown);
                }
                if (btnScrollUp.Visible)
                {
                    WinApi.SuspendDrawing(btnScrollUp);
                    btnScrollUp.Enabled = false;
                    btnScrollUp.NormalImage = ((System.Drawing.Image)(ResourcesMessages.scroll_button_up_disabled));
                    WinApi.ResumeDrawing(btnScrollUp);
                }
                if (btnPrint.Visible)
                {
                    WinApi.SuspendDrawing(btnPrint);
                    btnPrint.Enabled = false;
                    btnPrint.NormalImage = ((System.Drawing.Image)(ResourcesMessages.preprint_print_disabled));
                    WinApi.ResumeDrawing(btnPrint);
                }
                if (btnBack.Visible)
                {
                    WinApi.SuspendDrawing(btnBack);
                    btnBack.Enabled = false;
                    btnBack.NormalImage = ((System.Drawing.Image)(ResourcesMessages.preprint_back_disabled));
                    WinApi.ResumeDrawing(btnBack);
                }
            }
        }

        public void UpdatePageNumber()
        {
            lblCurrentPageInfo.Text = 
                ResourcesMessages.txtCurrentPageInfo.Replace("<!--currentPage-->", PrintBoxApp.instance.sessionInfo.CurrentPage.ToString()).
                Replace("<!--totalPagesInDocument-->", PrintBoxApp.instance.sessionInfo.pagesInDoc.ToString());
        }

        private void btnScrollUp_MouseDown(object sender, MouseEventArgs e)
        {
            PrintBoxApp.instance.sessionInfo.CurrentPage -= 1;
            UpdatePageNumber();
        }

        private void btnScrollDown_MouseDown(object sender, MouseEventArgs e)
        {
            PrintBoxApp.instance.sessionInfo.CurrentPage += 1;
            UpdatePageNumber();
        }

        private void btnBack_MouseDown(object sender, MouseEventArgs e)
        {
            StepBackward();
        }

        public void btnCancelPrint_MouseDown(object sender, MouseEventArgs e)
        {
            PrintBoxApp.instance.cashCodeWrapper.CashCodeEnabled = false;
            PrintBoxApp.instance.OpenFileList(null);
        }

        private void btnNext_MouseDown(object sender, MouseEventArgs e)
        {
            StepForward();
        }

        private void btnPrint_MouseDown(object sender, MouseEventArgs e)
        {
            PrintBoxApp.instance.cashCodeWrapper.CashCodeEnabled = false;
            if (PrintBoxApp.instance.sessionInfo == null) return;
            if (PrintBoxApp.instance.printOptions.printCost > PrintBoxApp.instance.sessionInfo.userMoney)
            {
                PrintBoxApp.instance.guiManager.ShowError(ResourcesMessages.msgNotEnoughMoney);
                return;
            }
            
            PrintBoxApp.instance.PrintDoc();
        }

        public void ShowPrintButton(bool flag)
        {
            btnPrint.Visible = flag;
        }

        private void PrePrintForm_Activated(object sender, EventArgs e)
        {
            if (pnlPrePrint.Visible) ActiveControl = btnNext;
            checkAcceptMoney.Checked = true;
            log.Debug("activated");            
        }

        private void PrePrintForm_Deactivate(object sender, EventArgs e)
        {
            log.Debug("deactivated");
        }

        public delegate void EmbedWordWindowDelegate(int hwnd);

        public EmbedWordWindowDelegate ExecEmbedWordWindow;

        public void EmbedWordWindow(int wordWnd)
        {
            WinApi.SetParent(wordWnd, pnlWordInner.Handle.ToInt32());
        }

        public void LoadDocument()
        {
            UpdatePageNumber();
            LoadPrintOptions();
            if (pnlMoneyInput.Visible || !pnlPrePrint.Visible) StepBackward();
            InvalidateUser();
        }

        public void RefreshMoney()
        {
            UpdateMoneyParams();
        }

        internal void InvalidateUser()
        {
            SetMoneyInputParamsDefaults();
        }

        public void LoadPrintOptions()
        {
            string fullName = PrintBoxApp.instance.sessionInfo.docName;
            string docName = fullName;
            int maxWidth = txtDocName.Width + txtDocName.Padding.Horizontal;
            int maxLength = docName.Length;
            while (TextRenderer.MeasureText(docName, txtDocName.Font).Width > maxWidth)
            {
                maxLength--;
                docName = fullName.Substring(0, maxLength) + "...";
            }

            txtDocName.Text = docName;
            txtPagesTotal.Text = PrintBoxApp.instance.sessionInfo.pagesInDoc.ToString();
            txtCopyNumber.Text = "1";
            txtFrom.Text = "1";
            txtTo.Text = PrintBoxApp.instance.sessionInfo.pagesInDoc.ToString();
            txtOnePagePrintCost.Text = (PrintBoxApp.instance.config.PageCost * 0.01F).ToString("F2");
            PagesPerSheet = 1;
            btnTwoPages.Enabled = btnFourPages.Enabled = PrintBoxApp.instance.sessionInfo.documentWrapper.PrintZoomEnabled();
            RecalcPrice();
        }

        private static int CalcPages(int copies, int from, int to, int pps)
        {
            return copies * ((to - from + pps) / pps);
        }

        private void RecalcPrice()
        {
            if (PagesPerSheet == 0) return;
            try
            {
                PrintBoxApp.instance.printOptions.pagesPerSheet = PagesPerSheet;
                PrintBoxApp.instance.printOptions.copies = Convert.ToInt32(txtCopyNumber.Text);
                if (PrintBoxApp.instance.printOptions.copies > 150) throw new FormatException();
                PrintBoxApp.instance.printOptions.from = Convert.ToInt32(txtFrom.Text);
                PrintBoxApp.instance.printOptions.to = Convert.ToInt32(txtTo.Text);
                if (PrintBoxApp.instance.printOptions.to < PrintBoxApp.instance.printOptions.from) throw new FormatException();
                PrintBoxApp.instance.printOptions.pagesToPrint = CalcPages(PrintBoxApp.instance.printOptions.copies,
                    PrintBoxApp.instance.printOptions.from,
                    PrintBoxApp.instance.printOptions.to,
                     PrintBoxApp.instance.printOptions.pagesPerSheet);
                PrintBoxApp.instance.printOptions.printCost =
                    ((float)PrintBoxApp.instance.printOptions.pagesToPrint * (float)PrintBoxApp.instance.config.PageCost * 0.01F);
                PrintBoxApp.instance.printOptions.valid = true;

                txtPagesTotalForPrint.Text = PrintBoxApp.instance.printOptions.pagesToPrint.ToString();
                txtPrintCost.Text = PrintBoxApp.instance.printOptions.printCost.ToString("F2");
            }
            catch (FormatException)
            {
                txtPagesTotalForPrint.Text = txtPrintCost.Text = "";
                PrintBoxApp.instance.printOptions.valid = false;
            }
        }

        private void NumberUpDown_TextChanged(object sender, EventArgs e)
        {
            TextBox senderTextBox = sender as TextBox;
            if (senderTextBox.Text.Length > 0)
            {
                int num = 1;
                try { num = Convert.ToInt32(senderTextBox.Text); }
                catch (FormatException) { }
                if (num < 1) num = 1;

                if ((senderTextBox == txtFrom) || (senderTextBox == txtTo))
                {
                    int maxValue = PrintBoxApp.instance.sessionInfo.pagesInDoc;
                    if (num > maxValue) num = maxValue;
                    if ((senderTextBox == txtFrom) && (num != 1)) PagesPerSheet = 1;
                    if ((senderTextBox == txtTo) && (num != maxValue)) PagesPerSheet = 1;
                }
                senderTextBox.Text = num.ToString();
            }
            RecalcPrice();
            FocusTextBox(senderTextBox);
        }

        private void btnOnePage_Click(object sender, EventArgs e)
        {
            PagesPerSheet = 1;
        }

        private void btnTwoPages_Click(object sender, EventArgs e)
        {
            PagesPerSheet = 2;
        }

        private void btnFourPages_Click(object sender, EventArgs e)
        {
            PagesPerSheet = 4;
        }


        private void btnInstruction_MouseDown(object sender, MouseEventArgs e)
        {
            PrintBoxApp.instance.guiManager.ShowInstruction();
        }

        private void btnIncrease_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox box = null;
            if (sender == btnIncreaseCopyNumber) box = txtCopyNumber;
            else if (sender == btnIncreaseFrom) box = txtFrom;
            else if (sender == btnIncreaseTo) box = txtTo;

            try
            {
                int num = Convert.ToInt32(box.Text);
                box.Text = (++num).ToString();
            }
            catch (FormatException)
            {
            }
        }

        private void btnDecrease_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox box = null;
            if (sender == btnDecreaseCopyNumber)
            {
                box = txtCopyNumber;
            }
            else if (sender == btnDecreaseFrom)
            {
                box = txtFrom;
            }
            else if (sender == btnDecreaseTo)
            {
                box = txtTo;
            }
            try
            {
                int num = Convert.ToInt32(box.Text);
                box.Text = (--num).ToString();
            }
            catch (FormatException)
            {
            }
        }

        private void kBtn_MouseDown(object sender, MouseEventArgs e)
        {
            if (CurrentTextBox.Text.Length < 4)
            {
                CurrentTextBox.Text += (sender as ImageButton).Text;
            }
        }

        private void kBtnOkCancel_MouseDown(object sender, MouseEventArgs e)
        {
            if ((sender == kBtnCancel) || (CurrentTextBox.Text.Length == 0)) CurrentTextBox.Text = CurrentTextBoxPrevValue;
            kPanel.Visible = false;
            ShowHidePrintCostInfo(true);
        }

        private void kBtnBackspace_MouseDown(object sender, MouseEventArgs e)
        {
            if (CurrentTextBox.Text.Length > 0) CurrentTextBox.Text = CurrentTextBox.Text.Substring(0, CurrentTextBox.Text.Length - 1);
        }

        private void ShowHidePrintCostInfo(bool flag)
        {
            lblOnePagePrintCost.Visible = flag;
            lblPrintCost.Visible = flag;
            pnlOnePagePrintCost.Visible = flag;
            pnlPrintCost.Visible = flag;
        }

        private void FocusTextBox(TextBox textBox)
        {
            textBox.SelectionStart = textBox.Text.Length;
            textBox.SelectionLength = 0;
            textBox.Focus();
        }

        private void ShowKPanel(object sender, MouseEventArgs e)
        {
            ShowHidePrintCostInfo(false);
            CurrentTextBox = sender as TextBox;
            FocusTextBox(CurrentTextBox);
            kPanel.Visible = true;
        }

        private TextBox _currentTextBox;
        private string _currentTextBoxPrevValue;

        private string CurrentTextBoxPrevValue { get { return _currentTextBoxPrevValue; } }
        private TextBox CurrentTextBox
        {
            get { return _currentTextBox; }
            set
            {
                _currentTextBox = value;
                _currentTextBoxPrevValue = _currentTextBox.Text;
            }
        } //for kpanel

        private int _pagesPerSheet = 0;
        private int PagesPerSheet
        {
            get { return _pagesPerSheet; }
            set
            {
                if (_pagesPerSheet != value)
                {
                    _pagesPerSheet = value;
                    string imgOff = "NormalImage", imgOn = "DownImage", img1, img2, img4;
                    int tag1, tag2, tag4;
                    img1 = img2 = img4 = imgOff;
                    tag1 = tag2 = tag4 = 0;
                    if (value == 1) { img1 = imgOn; tag1 = 1; }
                    else if (value == 2) { img2 = imgOn; tag2 = 1; }
                    else if (value == 4) { img4 = imgOn; tag4 = 1; }
                    btnOnePage.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnOnePage." + img1)));
                    btnTwoPages.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnTwoPages." + img2)));
                    btnFourPages.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnFourPages." + img4)));
                    btnOnePage.Tag = tag1;
                    btnTwoPages.Tag = tag2;
                    btnFourPages.Tag = tag4;
                    if (value != 1)
                    {
                        txtFrom.Text = "1";
                        txtTo.Text = PrintBoxApp.instance.sessionInfo.pagesInDoc.ToString();
                    }
                    RecalcPrice();
                }
            }
        }

        public void SetMoneyInputParamsDefaults()
        {
            SetPhoneTooltip();
            txtPhoneNumber.Text = string.Empty;
            pnlOuterPhoneNumber.Visible = false;
            txtDeposit.Text = "0";
            lblPrintCost2.Text = "0";
            txtLeftToDeposit.Text = string.Empty;
            pnlBalanceInfo.Visible = false;
            keyboardPassword.Reset();
            btnRemindPassword.Visible = keyboardPassword.Visible = false;
            keyboardPhone.Reset();
            keyboardPhone.Visible = true;
        }

        public void UpdateAllParams()
        {
            lblCopyNumber2.Text = ResourcesMessages.txtCopyNumber.Replace("<!--copyNumber-->",
                PrintBoxApp.instance.printOptions.copies.ToString());
            lblPrintPagesFromTo.Text = ResourcesMessages.txtPrintPagesFromTo.Replace("<!--pageFrom-->",
                PrintBoxApp.instance.printOptions.from.ToString()).
                Replace("<!--pageTo-->", PrintBoxApp.instance.printOptions.to.ToString());
            lblPagesTotalForPrint2.Text = ResourcesMessages.txtPagesTotal.Replace("<!--pagesTotal-->",
                PrintBoxApp.instance.printOptions.pagesToPrint.ToString());
            lblPagesPerSheet.Text = ResourcesMessages.txtPagesPerSheet.Replace("<!--pagesPerSheet-->",
                PrintBoxApp.instance.printOptions.pagesPerSheet.ToString());
            lblPrintCost2.Text = PrintBoxApp.instance.printOptions.printCost.ToString("F2");
            UpdateMoneyParams();
        }

        public void UpdateMoneyParams()
        {
            if ((PrintBoxApp.instance.sessionInfo == null) || (PrintBoxApp.instance.sessionInfo.userPhone == null)) return;
            txtDeposit.Text = PrintBoxApp.instance.sessionInfo.userMoney.ToString("F2");
            bool mayPrint = PrintBoxApp.instance.printOptions.printCost <= PrintBoxApp.instance.sessionInfo.userMoney;
            if (mayPrint)
            {
                txtLeftToDeposit.ForeColor = Color.Green;
                txtDeposit.ForeColor = Color.Green;
                lblLeftToDeposit.Text = "Залишок на рахунку:";
                double leftToDeposit = PrintBoxApp.instance.sessionInfo.userMoney - PrintBoxApp.instance.printOptions.printCost;
                txtLeftToDeposit.Text = leftToDeposit.ToString("F2");                
            }
            else
            {
                txtLeftToDeposit.ForeColor = Color.Red;
                txtDeposit.ForeColor = Color.Red;
                lblLeftToDeposit.Text = "Залишилось внести:";
                double leftToDeposit = PrintBoxApp.instance.printOptions.printCost - PrintBoxApp.instance.sessionInfo.userMoney;
                txtLeftToDeposit.Text = leftToDeposit.ToString("F2");                
            }

            ShowPrintButton(checkAcceptMoney.Checked && mayPrint);
        }

        private void keyboardPhone_OkButtonClicked(object sender, EventArgs e)
        {
            string phoneNumber = keyboardPhone.Value;
            PrintBoxApp.instance.guiManager.StartLoading();
            try
            {
                if (PrintBoxApp.instance.tools.IsExistingUser(phoneNumber))
                {
                    SetPasswordGeneralTooltip();
                }
                else
                {
                    PrintBoxApp.instance.guiManager.ShowMessage(ResourcesMessages.msgSmsWithPassSent, keyboardPhone.Text);
                    SetPasswordFirstTimeTooltip();
                }
                PrepareKeyboardForPasswordInput();
            }
            catch
            {
                Activate();
                Application.DoEvents();
                PrintBoxApp.instance.guiManager.ShowError(ResourcesMessages.msgServerUnavailable);
                return;
            }
            Activate();
        }

        private void PrepareKeyboardForPasswordInput()
        {
            pnlOuterPhoneNumber.Visible = true;
            txtPhoneNumber.Text = keyboardPhone.Text;
            keyboardPhone.Visible = false;
            keyboardPassword.Visible = true;
        }

        private void keyboardPassword_CancelButtonClicked(object sender, EventArgs e)
        {
            keyboardPassword.Visible = false;
            SetKeyboardPhoneDefaults();
            keyboardPhone.Visible = true;
            txtPhoneNumber.Text = string.Empty;
            pnlOuterPhoneNumber.Visible = false;
            SetPhoneTooltip();
        }

        private void SetKeyboardPhoneDefaults()
        {
            keyboardPhone.Reset();
        }

        private void keyboardPassword_OkButtonClicked(object sender, EventArgs e)
        {
            if (!PrintBoxApp.instance.tools.AuthorizeUser(keyboardPhone.Value, keyboardPassword.Value))
            {
                PrintBoxApp.instance.guiManager.ShowError(ResourcesMessages.msgWrongPassword);
            }
            else
            {
                ShowAccountBalance();
            }
        }

        private void SetPhoneTooltip()
        {
            pnlTooltip.Visible = true;
            lblTooltip.Text = ResourcesMessages.txtPhoneTooltip;
            lblTooltip.Left = 5;
            lblTooltip.Top = 5;
            lblTooltip.Height = 100;
            lblAttention.Text = ResourcesMessages.txtAttentionPhone;
            lblAttention.Left = 5;
            lblAttention.Top = lblTooltip.Bottom;
            lblAttention.Height = 125;
            pnlTooltip.Height = 10 + lblTooltip.Height + lblAttention.Height;
        }

        private void SetPasswordFirstTimeTooltip()
        {
            lblTooltip.Text = ResourcesMessages.txtPasswordFirstTimeTooltip;
            lblTooltip.Left = 5;
            lblTooltip.Top = 5;
            lblTooltip.Height = 50;
            lblAttention.Text = ResourcesMessages.txtAttentionGeneral;
            lblAttention.Left = 5;
            lblAttention.Top = lblTooltip.Bottom;
            lblAttention.Height = 75;
            pnlTooltip.Height = 10 + lblTooltip.Height + lblAttention.Height;
        }

        private void SetPasswordGeneralTooltip()
        {
            lblTooltip.Text = ResourcesMessages.txtPasswordGeneralTooltip;
            lblTooltip.Left = 5;
            lblTooltip.Top = 5;
            lblTooltip.Height = 25;
            lblAttention.Text = ResourcesMessages.txtAttentionGeneral;
            lblAttention.Left = 5;
            lblAttention.Top = lblTooltip.Bottom;
            lblAttention.Height = 75;
            pnlTooltip.Height = 10 + lblTooltip.Height + lblAttention.Height;
        }

        private void checkAcceptMoney_CheckedChanged(object sender, EventArgs e)
        {
            UpdateMoneyParams();
        }

        public void ShowAccountBalance()
        {
            pnlTooltip.Visible = false;
            keyboardPassword.Visible = false;
            pnlBalanceInfo.Visible = true;
            UpdateAllParams();
            Application.DoEvents();
            PrintBoxApp.instance.cashCodeWrapper.CashCodeEnabled = true;
        }

        private void keyboardPassword_VisibleChanged(object sender, EventArgs e)
        {
            btnRemindPassword.Visible = keyboardPassword.Visible;
        }

        private void btnRemindPassword_MouseDown(object sender, MouseEventArgs e)
        {
            string phoneNumber = keyboardPhone.Value;
            PrintBoxApp.instance.guiManager.StartLoading();
            Application.DoEvents();
            try
            {
                if (PrintBoxApp.instance.server.RemindPassword(phoneNumber))
                {
                    PrintBoxApp.instance.guiManager.ShowMessage(ResourcesMessages.msgSmsWithPassSent, keyboardPhone.Text);
                }
                else
                {
                    throw new Exception("Failed to remind password");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                PrintBoxApp.instance.guiManager.EndLoading();
                Application.DoEvents();
                PrintBoxApp.instance.guiManager.ShowError(ResourcesMessages.msgServerUnavailable);
                return;
            }
            PrintBoxApp.instance.guiManager.EndLoading();

        }
    }
}
