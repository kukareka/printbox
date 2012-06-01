namespace PrintBox.GUI.Forms
{
    partial class ControlForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlForm));
            this.buttonLoadTestDoc = new System.Windows.Forms.Button();
            this.pnlCashCode = new System.Windows.Forms.Panel();
            this.btn1uah = new System.Windows.Forms.Button();
            this.btn10uah = new System.Windows.Forms.Button();
            this.buttonOpenDrive = new System.Windows.Forms.Button();
            this.buttonSendPing = new System.Windows.Forms.Button();
            this.buttonSend10uah = new System.Windows.Forms.Button();
            this.buttonLogin1 = new System.Windows.Forms.Button();
            this.buttonSend10pages = new System.Windows.Forms.Button();
            this.textUser = new System.Windows.Forms.TextBox();
            this.textPwd = new System.Windows.Forms.TextBox();
            this.checkNewUser = new System.Windows.Forms.CheckBox();
            this.textBalance = new System.Windows.Forms.TextBox();
            this.buttonJamPaper = new System.Windows.Forms.Button();
            this.buttonFixErrors = new System.Windows.Forms.Button();
            this.buttonShowInstruction = new System.Windows.Forms.Button();
            this.buttonMessage = new System.Windows.Forms.Button();
            this.buttonFixJam = new System.Windows.Forms.Button();
            this.buttonFixNoPaper = new System.Windows.Forms.Button();
            this.buttonNoPaper = new System.Windows.Forms.Button();
            this.buttonCloseDrive = new System.Windows.Forms.Button();
            this.buttonPrinterStatus = new System.Windows.Forms.Button();
            this.textPrinterStatus = new System.Windows.Forms.TextBox();
            this.textPrinterPages = new System.Windows.Forms.TextBox();
            this.textPrinterToner = new System.Windows.Forms.TextBox();
            this.groupBoxPrinter = new System.Windows.Forms.GroupBox();
            this.buttonPrinterCancelJob = new System.Windows.Forms.Button();
            this.groupBoxCashcode = new System.Windows.Forms.GroupBox();
            this.textCashCodeStatus = new System.Windows.Forms.TextBox();
            this.buttonCashCodeDisable = new System.Windows.Forms.Button();
            this.buttonCashcodeEnable = new System.Windows.Forms.Button();
            this.buttonPoll = new System.Windows.Forms.Button();
            this.buttonCashcodeReset = new System.Windows.Forms.Button();
            this.groupThermoPrinter = new System.Windows.Forms.GroupBox();
            this.textThermoStatus = new System.Windows.Forms.TextBox();
            this.buttonPrintErrorCheck = new System.Windows.Forms.Button();
            this.buttonThermoTest = new System.Windows.Forms.Button();
            this.buttonThermoStatus = new System.Windows.Forms.Button();
            this.buttonMaintenance = new System.Windows.Forms.Button();
            this.buttonCustomTest = new System.Windows.Forms.Button();
            this.textTime = new System.Windows.Forms.TextBox();
            this.groupCheckCode = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textPhone = new System.Windows.Forms.TextBox();
            this.textCode = new System.Windows.Forms.TextBox();
            this.textBalanceA = new System.Windows.Forms.TextBox();
            this.textMoneyIn = new System.Windows.Forms.TextBox();
            this.textError = new System.Windows.Forms.TextBox();
            this.textTerminal = new System.Windows.Forms.TextBox();
            this.buttonError = new System.Windows.Forms.Button();
            this.buttonLoadPDF = new System.Windows.Forms.Button();
            this.pdfReader = new AxAcroPDFLib.AxAcroPDF();
            this.buttonTrySSL = new System.Windows.Forms.Button();
            this.btnHang = new System.Windows.Forms.Button();
            this.btnHideTaskbar = new System.Windows.Forms.Button();
            this.btnMinus10pages = new System.Windows.Forms.Button();
            this.pnlCashCode.SuspendLayout();
            this.groupBoxPrinter.SuspendLayout();
            this.groupBoxCashcode.SuspendLayout();
            this.groupThermoPrinter.SuspendLayout();
            this.groupCheckCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pdfReader)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLoadTestDoc
            // 
            this.buttonLoadTestDoc.Location = new System.Drawing.Point(12, 41);
            this.buttonLoadTestDoc.Name = "buttonLoadTestDoc";
            this.buttonLoadTestDoc.Size = new System.Drawing.Size(260, 23);
            this.buttonLoadTestDoc.TabIndex = 0;
            this.buttonLoadTestDoc.Text = "Загрузить тестовый документ";
            this.buttonLoadTestDoc.UseVisualStyleBackColor = true;
            this.buttonLoadTestDoc.Click += new System.EventHandler(this.buttonLoadTestDoc_Click);
            // 
            // pnlCashCode
            // 
            this.pnlCashCode.Controls.Add(this.btn1uah);
            this.pnlCashCode.Controls.Add(this.btn10uah);
            this.pnlCashCode.Enabled = false;
            this.pnlCashCode.Location = new System.Drawing.Point(12, 70);
            this.pnlCashCode.Name = "pnlCashCode";
            this.pnlCashCode.Size = new System.Drawing.Size(82, 58);
            this.pnlCashCode.TabIndex = 1;
            // 
            // btn1uah
            // 
            this.btn1uah.Location = new System.Drawing.Point(3, 3);
            this.btn1uah.Name = "btn1uah";
            this.btn1uah.Size = new System.Drawing.Size(75, 23);
            this.btn1uah.TabIndex = 0;
            this.btn1uah.Text = "+1 грн";
            this.btn1uah.UseVisualStyleBackColor = true;
            this.btn1uah.Click += new System.EventHandler(this.btn1uah_Click);
            // 
            // btn10uah
            // 
            this.btn10uah.Location = new System.Drawing.Point(3, 32);
            this.btn10uah.Name = "btn10uah";
            this.btn10uah.Size = new System.Drawing.Size(75, 23);
            this.btn10uah.TabIndex = 0;
            this.btn10uah.Text = "+10 грн";
            this.btn10uah.UseVisualStyleBackColor = true;
            this.btn10uah.Click += new System.EventHandler(this.btn10uah_Click);
            // 
            // buttonOpenDrive
            // 
            this.buttonOpenDrive.Location = new System.Drawing.Point(12, 12);
            this.buttonOpenDrive.Name = "buttonOpenDrive";
            this.buttonOpenDrive.Size = new System.Drawing.Size(135, 23);
            this.buttonOpenDrive.TabIndex = 0;
            this.buttonOpenDrive.Text = "Открыть D:\\";
            this.buttonOpenDrive.UseVisualStyleBackColor = true;
            this.buttonOpenDrive.Click += new System.EventHandler(this.buttonOpenDrive_Click);
            // 
            // buttonSendPing
            // 
            this.buttonSendPing.Location = new System.Drawing.Point(584, 69);
            this.buttonSendPing.Name = "buttonSendPing";
            this.buttonSendPing.Size = new System.Drawing.Size(75, 23);
            this.buttonSendPing.TabIndex = 2;
            this.buttonSendPing.Text = "Пинг";
            this.buttonSendPing.UseVisualStyleBackColor = true;
            this.buttonSendPing.Click += new System.EventHandler(this.buttonSendPing_Click);
            // 
            // buttonSend10uah
            // 
            this.buttonSend10uah.Location = new System.Drawing.Point(665, 69);
            this.buttonSend10uah.Name = "buttonSend10uah";
            this.buttonSend10uah.Size = new System.Drawing.Size(75, 23);
            this.buttonSend10uah.TabIndex = 2;
            this.buttonSend10uah.Text = "Отпр 10грн";
            this.buttonSend10uah.UseVisualStyleBackColor = true;
            this.buttonSend10uah.Click += new System.EventHandler(this.buttonSend10uah_Click);
            // 
            // buttonLogin1
            // 
            this.buttonLogin1.Location = new System.Drawing.Point(693, 12);
            this.buttonLogin1.Name = "buttonLogin1";
            this.buttonLogin1.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin1.TabIndex = 2;
            this.buttonLogin1.Text = "Логин1";
            this.buttonLogin1.UseVisualStyleBackColor = true;
            this.buttonLogin1.Click += new System.EventHandler(this.buttonLogin1_Click);
            // 
            // buttonSend10pages
            // 
            this.buttonSend10pages.Location = new System.Drawing.Point(584, 98);
            this.buttonSend10pages.Name = "buttonSend10pages";
            this.buttonSend10pages.Size = new System.Drawing.Size(75, 23);
            this.buttonSend10pages.TabIndex = 2;
            this.buttonSend10pages.Text = "Отпр 10стр";
            this.buttonSend10pages.UseVisualStyleBackColor = true;
            this.buttonSend10pages.Click += new System.EventHandler(this.buttonSend10pages_Click);
            // 
            // textUser
            // 
            this.textUser.Location = new System.Drawing.Point(587, 15);
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(100, 20);
            this.textUser.TabIndex = 3;
            this.textUser.Text = "Логин";
            // 
            // textPwd
            // 
            this.textPwd.Location = new System.Drawing.Point(587, 41);
            this.textPwd.Name = "textPwd";
            this.textPwd.Size = new System.Drawing.Size(100, 20);
            this.textPwd.TabIndex = 3;
            this.textPwd.Text = "Пароль";
            // 
            // checkNewUser
            // 
            this.checkNewUser.AutoSize = true;
            this.checkNewUser.Location = new System.Drawing.Point(693, 41);
            this.checkNewUser.Name = "checkNewUser";
            this.checkNewUser.Size = new System.Drawing.Size(60, 17);
            this.checkNewUser.TabIndex = 4;
            this.checkNewUser.Text = "Новый";
            this.checkNewUser.UseVisualStyleBackColor = true;
            // 
            // textBalance
            // 
            this.textBalance.Location = new System.Drawing.Point(753, 40);
            this.textBalance.Name = "textBalance";
            this.textBalance.Size = new System.Drawing.Size(91, 20);
            this.textBalance.TabIndex = 5;
            this.textBalance.Text = "Баланс";
            // 
            // buttonJamPaper
            // 
            this.buttonJamPaper.Location = new System.Drawing.Point(314, 12);
            this.buttonJamPaper.Name = "buttonJamPaper";
            this.buttonJamPaper.Size = new System.Drawing.Size(152, 23);
            this.buttonJamPaper.TabIndex = 6;
            this.buttonJamPaper.Text = "Замять бумагу";
            this.buttonJamPaper.UseVisualStyleBackColor = true;
            this.buttonJamPaper.Click += new System.EventHandler(this.buttonJamPaper_Click);
            // 
            // buttonFixErrors
            // 
            this.buttonFixErrors.Location = new System.Drawing.Point(314, 73);
            this.buttonFixErrors.Name = "buttonFixErrors";
            this.buttonFixErrors.Size = new System.Drawing.Size(233, 23);
            this.buttonFixErrors.TabIndex = 6;
            this.buttonFixErrors.Text = "Исправить все ошибки";
            this.buttonFixErrors.UseVisualStyleBackColor = true;
            this.buttonFixErrors.Click += new System.EventHandler(this.buttonFixErrors_Click);
            // 
            // buttonShowInstruction
            // 
            this.buttonShowInstruction.Location = new System.Drawing.Point(665, 98);
            this.buttonShowInstruction.Name = "buttonShowInstruction";
            this.buttonShowInstruction.Size = new System.Drawing.Size(75, 23);
            this.buttonShowInstruction.TabIndex = 7;
            this.buttonShowInstruction.Text = "Инструкция";
            this.buttonShowInstruction.UseVisualStyleBackColor = true;
            this.buttonShowInstruction.Click += new System.EventHandler(this.buttonShowInstruction_Click);
            // 
            // buttonMessage
            // 
            this.buttonMessage.Location = new System.Drawing.Point(769, 69);
            this.buttonMessage.Name = "buttonMessage";
            this.buttonMessage.Size = new System.Drawing.Size(75, 23);
            this.buttonMessage.TabIndex = 7;
            this.buttonMessage.Text = "Сообщение";
            this.buttonMessage.UseVisualStyleBackColor = true;
            this.buttonMessage.Click += new System.EventHandler(this.buttonMessage_Click);
            // 
            // buttonFixJam
            // 
            this.buttonFixJam.Location = new System.Drawing.Point(472, 12);
            this.buttonFixJam.Name = "buttonFixJam";
            this.buttonFixJam.Size = new System.Drawing.Size(75, 23);
            this.buttonFixJam.TabIndex = 8;
            this.buttonFixJam.Text = "Исправить";
            this.buttonFixJam.UseVisualStyleBackColor = true;
            this.buttonFixJam.Click += new System.EventHandler(this.buttonFixJam_Click);
            // 
            // buttonFixNoPaper
            // 
            this.buttonFixNoPaper.Location = new System.Drawing.Point(472, 41);
            this.buttonFixNoPaper.Name = "buttonFixNoPaper";
            this.buttonFixNoPaper.Size = new System.Drawing.Size(75, 23);
            this.buttonFixNoPaper.TabIndex = 10;
            this.buttonFixNoPaper.Text = "Исправить";
            this.buttonFixNoPaper.UseVisualStyleBackColor = true;
            this.buttonFixNoPaper.Click += new System.EventHandler(this.buttonFixNoPaper_Click);
            // 
            // buttonNoPaper
            // 
            this.buttonNoPaper.Location = new System.Drawing.Point(314, 41);
            this.buttonNoPaper.Name = "buttonNoPaper";
            this.buttonNoPaper.Size = new System.Drawing.Size(152, 23);
            this.buttonNoPaper.TabIndex = 9;
            this.buttonNoPaper.Text = "Закончить бумагу";
            this.buttonNoPaper.UseVisualStyleBackColor = true;
            this.buttonNoPaper.Click += new System.EventHandler(this.buttonNoPaper_Click);
            // 
            // buttonCloseDrive
            // 
            this.buttonCloseDrive.Location = new System.Drawing.Point(153, 12);
            this.buttonCloseDrive.Name = "buttonCloseDrive";
            this.buttonCloseDrive.Size = new System.Drawing.Size(119, 23);
            this.buttonCloseDrive.TabIndex = 11;
            this.buttonCloseDrive.Text = "Закрыть D:\\";
            this.buttonCloseDrive.UseVisualStyleBackColor = true;
            this.buttonCloseDrive.Click += new System.EventHandler(this.buttonCloseDrive_Click);
            // 
            // buttonPrinterStatus
            // 
            this.buttonPrinterStatus.Location = new System.Drawing.Point(23, 18);
            this.buttonPrinterStatus.Name = "buttonPrinterStatus";
            this.buttonPrinterStatus.Size = new System.Drawing.Size(132, 23);
            this.buttonPrinterStatus.TabIndex = 12;
            this.buttonPrinterStatus.Text = "Обновить статус";
            this.buttonPrinterStatus.UseVisualStyleBackColor = true;
            this.buttonPrinterStatus.Click += new System.EventHandler(this.buttonPrinterStatus_Click);
            // 
            // textPrinterStatus
            // 
            this.textPrinterStatus.Location = new System.Drawing.Point(23, 50);
            this.textPrinterStatus.Name = "textPrinterStatus";
            this.textPrinterStatus.Size = new System.Drawing.Size(132, 20);
            this.textPrinterStatus.TabIndex = 13;
            this.textPrinterStatus.Text = "Статус";
            // 
            // textPrinterPages
            // 
            this.textPrinterPages.Location = new System.Drawing.Point(23, 76);
            this.textPrinterPages.Name = "textPrinterPages";
            this.textPrinterPages.Size = new System.Drawing.Size(132, 20);
            this.textPrinterPages.TabIndex = 13;
            this.textPrinterPages.Text = "Страницы";
            // 
            // textPrinterToner
            // 
            this.textPrinterToner.Location = new System.Drawing.Point(23, 102);
            this.textPrinterToner.Name = "textPrinterToner";
            this.textPrinterToner.Size = new System.Drawing.Size(132, 20);
            this.textPrinterToner.TabIndex = 13;
            this.textPrinterToner.Text = "Тонер";
            // 
            // groupBoxPrinter
            // 
            this.groupBoxPrinter.Controls.Add(this.textPrinterToner);
            this.groupBoxPrinter.Controls.Add(this.textPrinterPages);
            this.groupBoxPrinter.Controls.Add(this.textPrinterStatus);
            this.groupBoxPrinter.Controls.Add(this.buttonPrinterCancelJob);
            this.groupBoxPrinter.Controls.Add(this.buttonPrinterStatus);
            this.groupBoxPrinter.Location = new System.Drawing.Point(12, 173);
            this.groupBoxPrinter.Name = "groupBoxPrinter";
            this.groupBoxPrinter.Size = new System.Drawing.Size(179, 171);
            this.groupBoxPrinter.TabIndex = 14;
            this.groupBoxPrinter.TabStop = false;
            this.groupBoxPrinter.Text = "Принтер";
            // 
            // buttonPrinterCancelJob
            // 
            this.buttonPrinterCancelJob.Location = new System.Drawing.Point(23, 133);
            this.buttonPrinterCancelJob.Name = "buttonPrinterCancelJob";
            this.buttonPrinterCancelJob.Size = new System.Drawing.Size(132, 23);
            this.buttonPrinterCancelJob.TabIndex = 12;
            this.buttonPrinterCancelJob.Text = "Очистить очередь";
            this.buttonPrinterCancelJob.UseVisualStyleBackColor = true;
            this.buttonPrinterCancelJob.Click += new System.EventHandler(this.buttonPrinterCancelJob_Click);
            // 
            // groupBoxCashcode
            // 
            this.groupBoxCashcode.Controls.Add(this.textCashCodeStatus);
            this.groupBoxCashcode.Controls.Add(this.buttonCashCodeDisable);
            this.groupBoxCashcode.Controls.Add(this.buttonCashcodeEnable);
            this.groupBoxCashcode.Controls.Add(this.buttonPoll);
            this.groupBoxCashcode.Controls.Add(this.buttonCashcodeReset);
            this.groupBoxCashcode.Location = new System.Drawing.Point(209, 173);
            this.groupBoxCashcode.Name = "groupBoxCashcode";
            this.groupBoxCashcode.Size = new System.Drawing.Size(166, 172);
            this.groupBoxCashcode.TabIndex = 15;
            this.groupBoxCashcode.TabStop = false;
            this.groupBoxCashcode.Text = "CashCode";
            // 
            // textCashCodeStatus
            // 
            this.textCashCodeStatus.Location = new System.Drawing.Point(18, 133);
            this.textCashCodeStatus.Name = "textCashCodeStatus";
            this.textCashCodeStatus.Size = new System.Drawing.Size(132, 20);
            this.textCashCodeStatus.TabIndex = 13;
            this.textCashCodeStatus.Text = "Статус";
            // 
            // buttonCashCodeDisable
            // 
            this.buttonCashCodeDisable.Location = new System.Drawing.Point(18, 75);
            this.buttonCashCodeDisable.Name = "buttonCashCodeDisable";
            this.buttonCashCodeDisable.Size = new System.Drawing.Size(132, 23);
            this.buttonCashCodeDisable.TabIndex = 12;
            this.buttonCashCodeDisable.Text = "Disable";
            this.buttonCashCodeDisable.UseVisualStyleBackColor = true;
            this.buttonCashCodeDisable.Click += new System.EventHandler(this.buttonCashCodeDisable_Click);
            // 
            // buttonCashcodeEnable
            // 
            this.buttonCashcodeEnable.Location = new System.Drawing.Point(18, 48);
            this.buttonCashcodeEnable.Name = "buttonCashcodeEnable";
            this.buttonCashcodeEnable.Size = new System.Drawing.Size(132, 23);
            this.buttonCashcodeEnable.TabIndex = 12;
            this.buttonCashcodeEnable.Text = "Enable";
            this.buttonCashcodeEnable.UseVisualStyleBackColor = true;
            this.buttonCashcodeEnable.Click += new System.EventHandler(this.buttonCashcodeEnable_Click);
            // 
            // buttonPoll
            // 
            this.buttonPoll.Location = new System.Drawing.Point(18, 104);
            this.buttonPoll.Name = "buttonPoll";
            this.buttonPoll.Size = new System.Drawing.Size(132, 23);
            this.buttonPoll.TabIndex = 12;
            this.buttonPoll.Text = "Poll";
            this.buttonPoll.UseVisualStyleBackColor = true;
            this.buttonPoll.Click += new System.EventHandler(this.buttonPoll_Click);
            // 
            // buttonCashcodeReset
            // 
            this.buttonCashcodeReset.Location = new System.Drawing.Point(18, 21);
            this.buttonCashcodeReset.Name = "buttonCashcodeReset";
            this.buttonCashcodeReset.Size = new System.Drawing.Size(132, 23);
            this.buttonCashcodeReset.TabIndex = 12;
            this.buttonCashcodeReset.Text = "Reset";
            this.buttonCashcodeReset.UseVisualStyleBackColor = true;
            this.buttonCashcodeReset.Click += new System.EventHandler(this.buttonCashcodeReset_Click);
            // 
            // groupThermoPrinter
            // 
            this.groupThermoPrinter.Controls.Add(this.textThermoStatus);
            this.groupThermoPrinter.Controls.Add(this.buttonPrintErrorCheck);
            this.groupThermoPrinter.Controls.Add(this.buttonThermoTest);
            this.groupThermoPrinter.Controls.Add(this.buttonThermoStatus);
            this.groupThermoPrinter.Location = new System.Drawing.Point(394, 173);
            this.groupThermoPrinter.Name = "groupThermoPrinter";
            this.groupThermoPrinter.Size = new System.Drawing.Size(175, 172);
            this.groupThermoPrinter.TabIndex = 16;
            this.groupThermoPrinter.TabStop = false;
            this.groupThermoPrinter.Text = "Термопринтер";
            // 
            // textThermoStatus
            // 
            this.textThermoStatus.Location = new System.Drawing.Point(21, 51);
            this.textThermoStatus.Name = "textThermoStatus";
            this.textThermoStatus.Size = new System.Drawing.Size(132, 20);
            this.textThermoStatus.TabIndex = 13;
            this.textThermoStatus.Text = "Статус";
            // 
            // buttonPrintErrorCheck
            // 
            this.buttonPrintErrorCheck.Location = new System.Drawing.Point(21, 115);
            this.buttonPrintErrorCheck.Name = "buttonPrintErrorCheck";
            this.buttonPrintErrorCheck.Size = new System.Drawing.Size(132, 23);
            this.buttonPrintErrorCheck.TabIndex = 12;
            this.buttonPrintErrorCheck.Text = "Чек ошибки";
            this.buttonPrintErrorCheck.UseVisualStyleBackColor = true;
            this.buttonPrintErrorCheck.Click += new System.EventHandler(this.buttonPrintErrorCheck_Click);
            // 
            // buttonThermoTest
            // 
            this.buttonThermoTest.Location = new System.Drawing.Point(21, 86);
            this.buttonThermoTest.Name = "buttonThermoTest";
            this.buttonThermoTest.Size = new System.Drawing.Size(132, 23);
            this.buttonThermoTest.TabIndex = 12;
            this.buttonThermoTest.Text = "Тест";
            this.buttonThermoTest.UseVisualStyleBackColor = true;
            this.buttonThermoTest.Click += new System.EventHandler(this.buttonThermoTest_Click);
            // 
            // buttonThermoStatus
            // 
            this.buttonThermoStatus.Location = new System.Drawing.Point(21, 21);
            this.buttonThermoStatus.Name = "buttonThermoStatus";
            this.buttonThermoStatus.Size = new System.Drawing.Size(132, 23);
            this.buttonThermoStatus.TabIndex = 12;
            this.buttonThermoStatus.Text = "Обновить статус";
            this.buttonThermoStatus.UseVisualStyleBackColor = true;
            this.buttonThermoStatus.Click += new System.EventHandler(this.buttonThermoStatus_Click);
            // 
            // buttonMaintenance
            // 
            this.buttonMaintenance.Location = new System.Drawing.Point(314, 105);
            this.buttonMaintenance.Name = "buttonMaintenance";
            this.buttonMaintenance.Size = new System.Drawing.Size(233, 23);
            this.buttonMaintenance.TabIndex = 7;
            this.buttonMaintenance.Text = "Обслуживание";
            this.buttonMaintenance.UseVisualStyleBackColor = true;
            this.buttonMaintenance.Click += new System.EventHandler(this.buttonMaintenance_Click);
            // 
            // buttonCustomTest
            // 
            this.buttonCustomTest.Location = new System.Drawing.Point(643, 140);
            this.buttonCustomTest.Name = "buttonCustomTest";
            this.buttonCustomTest.Size = new System.Drawing.Size(158, 23);
            this.buttonCustomTest.TabIndex = 17;
            this.buttonCustomTest.Text = "Хитрый тест";
            this.buttonCustomTest.UseVisualStyleBackColor = true;
            this.buttonCustomTest.Click += new System.EventHandler(this.buttonCustomTest_Click);
            // 
            // textTime
            // 
            this.textTime.Location = new System.Drawing.Point(6, 44);
            this.textTime.Name = "textTime";
            this.textTime.Size = new System.Drawing.Size(67, 20);
            this.textTime.TabIndex = 18;
            this.textTime.Text = "Время";
            this.textTime.TextChanged += new System.EventHandler(this.textTime_TextChanged);
            // 
            // groupCheckCode
            // 
            this.groupCheckCode.Controls.Add(this.button1);
            this.groupCheckCode.Controls.Add(this.textPhone);
            this.groupCheckCode.Controls.Add(this.textCode);
            this.groupCheckCode.Controls.Add(this.textBalanceA);
            this.groupCheckCode.Controls.Add(this.textMoneyIn);
            this.groupCheckCode.Controls.Add(this.textError);
            this.groupCheckCode.Controls.Add(this.textTerminal);
            this.groupCheckCode.Controls.Add(this.textTime);
            this.groupCheckCode.Location = new System.Drawing.Point(586, 179);
            this.groupCheckCode.Name = "groupCheckCode";
            this.groupCheckCode.Size = new System.Drawing.Size(196, 165);
            this.groupCheckCode.TabIndex = 19;
            this.groupCheckCode.TabStop = false;
            this.groupCheckCode.Text = "Проверить код";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(79, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 24);
            this.button1.TabIndex = 19;
            this.button1.Text = "Проверить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textPhone
            // 
            this.textPhone.Location = new System.Drawing.Point(6, 19);
            this.textPhone.Name = "textPhone";
            this.textPhone.Size = new System.Drawing.Size(67, 20);
            this.textPhone.TabIndex = 18;
            this.textPhone.Text = "Телефон";
            // 
            // textCode
            // 
            this.textCode.Location = new System.Drawing.Point(79, 72);
            this.textCode.Name = "textCode";
            this.textCode.Size = new System.Drawing.Size(67, 20);
            this.textCode.TabIndex = 18;
            this.textCode.Text = "Код";
            // 
            // textBalanceA
            // 
            this.textBalanceA.Location = new System.Drawing.Point(79, 44);
            this.textBalanceA.Name = "textBalanceA";
            this.textBalanceA.Size = new System.Drawing.Size(67, 20);
            this.textBalanceA.TabIndex = 18;
            this.textBalanceA.Text = "Баланс";
            // 
            // textMoneyIn
            // 
            this.textMoneyIn.Location = new System.Drawing.Point(79, 19);
            this.textMoneyIn.Name = "textMoneyIn";
            this.textMoneyIn.Size = new System.Drawing.Size(67, 20);
            this.textMoneyIn.TabIndex = 18;
            this.textMoneyIn.Text = "Внесено";
            // 
            // textError
            // 
            this.textError.Location = new System.Drawing.Point(6, 95);
            this.textError.Name = "textError";
            this.textError.Size = new System.Drawing.Size(67, 20);
            this.textError.TabIndex = 18;
            this.textError.Text = "Ошибка";
            this.textError.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textTerminal
            // 
            this.textTerminal.Location = new System.Drawing.Point(6, 69);
            this.textTerminal.Name = "textTerminal";
            this.textTerminal.Size = new System.Drawing.Size(67, 20);
            this.textTerminal.TabIndex = 18;
            this.textTerminal.Text = "Терминал";
            // 
            // buttonError
            // 
            this.buttonError.Location = new System.Drawing.Point(769, 98);
            this.buttonError.Name = "buttonError";
            this.buttonError.Size = new System.Drawing.Size(75, 23);
            this.buttonError.TabIndex = 7;
            this.buttonError.Text = "Ошибка";
            this.buttonError.UseVisualStyleBackColor = true;
            this.buttonError.Click += new System.EventHandler(this.buttonError_Click);
            // 
            // buttonLoadPDF
            // 
            this.buttonLoadPDF.Location = new System.Drawing.Point(463, 364);
            this.buttonLoadPDF.Name = "buttonLoadPDF";
            this.buttonLoadPDF.Size = new System.Drawing.Size(143, 23);
            this.buttonLoadPDF.TabIndex = 0;
            this.buttonLoadPDF.Text = "Загрузить PDF";
            this.buttonLoadPDF.UseVisualStyleBackColor = true;
            this.buttonLoadPDF.Click += new System.EventHandler(this.buttonLoadPDF_Click);
            // 
            // pdfReader
            // 
            this.pdfReader.Enabled = true;
            this.pdfReader.Location = new System.Drawing.Point(665, 364);
            this.pdfReader.Name = "pdfReader";
            this.pdfReader.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pdfReader.OcxState")));
            this.pdfReader.Size = new System.Drawing.Size(192, 192);
            this.pdfReader.TabIndex = 21;
            // 
            // buttonTrySSL
            // 
            this.buttonTrySSL.Location = new System.Drawing.Point(472, 405);
            this.buttonTrySSL.Name = "buttonTrySSL";
            this.buttonTrySSL.Size = new System.Drawing.Size(143, 23);
            this.buttonTrySSL.TabIndex = 0;
            this.buttonTrySSL.Text = "SSL";
            this.buttonTrySSL.UseVisualStyleBackColor = true;
            this.buttonTrySSL.Click += new System.EventHandler(this.buttonTrySSL_Click);
            // 
            // btnHang
            // 
            this.btnHang.Location = new System.Drawing.Point(184, 405);
            this.btnHang.Name = "btnHang";
            this.btnHang.Size = new System.Drawing.Size(79, 24);
            this.btnHang.TabIndex = 19;
            this.btnHang.Text = "Hang";
            this.btnHang.UseVisualStyleBackColor = true;
            this.btnHang.Click += new System.EventHandler(this.btnHang_Click);
            // 
            // btnHideTaskbar
            // 
            this.btnHideTaskbar.Location = new System.Drawing.Point(184, 375);
            this.btnHideTaskbar.Name = "btnHideTaskbar";
            this.btnHideTaskbar.Size = new System.Drawing.Size(79, 24);
            this.btnHideTaskbar.TabIndex = 19;
            this.btnHideTaskbar.Text = "Hide taskbar";
            this.btnHideTaskbar.UseVisualStyleBackColor = true;
            this.btnHideTaskbar.Click += new System.EventHandler(this.btnHideTaskbar_Click);
            // 
            // btnMinus10pages
            // 
            this.btnMinus10pages.Location = new System.Drawing.Point(280, 375);
            this.btnMinus10pages.Name = "btnMinus10pages";
            this.btnMinus10pages.Size = new System.Drawing.Size(79, 24);
            this.btnMinus10pages.TabIndex = 19;
            this.btnMinus10pages.Text = "-10стр";
            this.btnMinus10pages.UseVisualStyleBackColor = true;
            this.btnMinus10pages.Click += new System.EventHandler(this.btnMinus10pages_Click);
            // 
            // ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 657);
            this.Controls.Add(this.btnMinus10pages);
            this.Controls.Add(this.btnHideTaskbar);
            this.Controls.Add(this.btnHang);
            this.Controls.Add(this.pdfReader);
            this.Controls.Add(this.groupCheckCode);
            this.Controls.Add(this.buttonCustomTest);
            this.Controls.Add(this.groupThermoPrinter);
            this.Controls.Add(this.groupBoxCashcode);
            this.Controls.Add(this.groupBoxPrinter);
            this.Controls.Add(this.buttonCloseDrive);
            this.Controls.Add(this.buttonFixNoPaper);
            this.Controls.Add(this.buttonNoPaper);
            this.Controls.Add(this.buttonFixJam);
            this.Controls.Add(this.buttonError);
            this.Controls.Add(this.buttonMessage);
            this.Controls.Add(this.buttonMaintenance);
            this.Controls.Add(this.buttonShowInstruction);
            this.Controls.Add(this.buttonFixErrors);
            this.Controls.Add(this.buttonJamPaper);
            this.Controls.Add(this.textBalance);
            this.Controls.Add(this.checkNewUser);
            this.Controls.Add(this.textPwd);
            this.Controls.Add(this.textUser);
            this.Controls.Add(this.buttonLogin1);
            this.Controls.Add(this.buttonSend10uah);
            this.Controls.Add(this.buttonSend10pages);
            this.Controls.Add(this.buttonSendPing);
            this.Controls.Add(this.pnlCashCode);
            this.Controls.Add(this.buttonOpenDrive);
            this.Controls.Add(this.buttonTrySSL);
            this.Controls.Add(this.buttonLoadPDF);
            this.Controls.Add(this.buttonLoadTestDoc);
            this.Name = "ControlForm";
            this.Text = "Управление";
            this.pnlCashCode.ResumeLayout(false);
            this.groupBoxPrinter.ResumeLayout(false);
            this.groupBoxPrinter.PerformLayout();
            this.groupBoxCashcode.ResumeLayout(false);
            this.groupBoxCashcode.PerformLayout();
            this.groupThermoPrinter.ResumeLayout(false);
            this.groupThermoPrinter.PerformLayout();
            this.groupCheckCode.ResumeLayout(false);
            this.groupCheckCode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pdfReader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoadTestDoc;
        private System.Windows.Forms.Panel pnlCashCode;
        private System.Windows.Forms.Button btn1uah;
        private System.Windows.Forms.Button btn10uah;
        private System.Windows.Forms.Button buttonOpenDrive;
        private System.Windows.Forms.Button buttonSendPing;
        private System.Windows.Forms.Button buttonSend10uah;
        private System.Windows.Forms.Button buttonLogin1;
        private System.Windows.Forms.Button buttonSend10pages;
        private System.Windows.Forms.TextBox textUser;
        private System.Windows.Forms.TextBox textPwd;
        private System.Windows.Forms.CheckBox checkNewUser;
        private System.Windows.Forms.TextBox textBalance;
        private System.Windows.Forms.Button buttonJamPaper;
        private System.Windows.Forms.Button buttonFixErrors;
        private System.Windows.Forms.Button buttonShowInstruction;
        private System.Windows.Forms.Button buttonMessage;
        private System.Windows.Forms.Button buttonFixJam;
        private System.Windows.Forms.Button buttonFixNoPaper;
        private System.Windows.Forms.Button buttonNoPaper;
        private System.Windows.Forms.Button buttonCloseDrive;
        private System.Windows.Forms.Button buttonPrinterStatus;
        private System.Windows.Forms.TextBox textPrinterStatus;
        private System.Windows.Forms.TextBox textPrinterPages;
        private System.Windows.Forms.TextBox textPrinterToner;
        private System.Windows.Forms.GroupBox groupBoxPrinter;
        private System.Windows.Forms.GroupBox groupBoxCashcode;
        private System.Windows.Forms.TextBox textCashCodeStatus;
        private System.Windows.Forms.Button buttonCashcodeReset;
        private System.Windows.Forms.Button buttonCashCodeDisable;
        private System.Windows.Forms.Button buttonCashcodeEnable;
        private System.Windows.Forms.Button buttonPoll;
        private System.Windows.Forms.GroupBox groupThermoPrinter;
        private System.Windows.Forms.TextBox textThermoStatus;
        private System.Windows.Forms.Button buttonThermoStatus;
        private System.Windows.Forms.Button buttonThermoTest;
        private System.Windows.Forms.Button buttonMaintenance;
        private System.Windows.Forms.Button buttonCustomTest;
        private System.Windows.Forms.Button buttonPrintErrorCheck;
        private System.Windows.Forms.TextBox textTime;
        private System.Windows.Forms.GroupBox groupCheckCode;
        private System.Windows.Forms.TextBox textPhone;
        private System.Windows.Forms.TextBox textError;
        private System.Windows.Forms.TextBox textTerminal;
        private System.Windows.Forms.TextBox textBalanceA;
        private System.Windows.Forms.TextBox textMoneyIn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textCode;
        private System.Windows.Forms.Button buttonError;
        private System.Windows.Forms.Button buttonLoadPDF;
        private AxAcroPDFLib.AxAcroPDF pdfReader;
        private System.Windows.Forms.Button buttonTrySSL;
        private System.Windows.Forms.Button buttonPrinterCancelJob;
        private System.Windows.Forms.Button btnHang;
        private System.Windows.Forms.Button btnHideTaskbar;
        private System.Windows.Forms.Button btnMinus10pages;
    }
}

