using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PrintBox.Logic.Wrappers;

namespace PrintBoxMain.UserControls
{
    public partial class KeyboardPanel : UserControl
    {
        public delegate void OkButtonHandler(object sender, EventArgs e);
        public delegate void CancelButtonHandler(object sender, EventArgs e);

        public event OkButtonHandler OkButtonClicked;
        public event CancelButtonHandler CancelButtonClicked;

        protected virtual void OnOkButtonClicked()
        {
            if (OkButtonClicked != null)
                OkButtonClicked(this, EventArgs.Empty);
        }

        protected virtual void OnCancelButtonClicked()
        {
            if (CancelButtonClicked != null)
            {
                Reset();
                CancelButtonClicked(this, EventArgs.Empty);
            }
        }

        private bool _IsSecureTextBox;
        private string _LabelText;
        private AlignType _ContentAlign;
        private bool _EnableCancelButton;
        private bool _EnableOkButton;
        private bool _ShowCancelButton;
        private int _LabelRows;
        private int _LabelHeight = 32;
        private ValueType _InputValueType;
        private int _lengthCounter;
        private bool _Enabled;
        private List<ImageButton> _EnabledButtons;

        [DefaultValue(true), CustomAttribute()]
        public bool IsSecureTextBox
        {
            get
            {
                return _IsSecureTextBox;
            }
            set
            {
                _IsSecureTextBox = value;
                txtText.UseSystemPasswordChar = value;
            }
        }

        [DefaultValue("Default text"), CustomAttribute()]
        public string LabelText
        {
            get
            {
                return _LabelText;
            }
            set
            {
                _LabelText = value;
                lblText.Text = value;
            }
        }

        [DefaultValue(AlignType.MiddleCenter), CustomAttribute()]
        public AlignType ContentAlign
        {
            get
            {
                return _ContentAlign;
            }
            set
            {
                _ContentAlign = value;
                SetInnerContentPanelAlignment(value);
            }
        }

        private void SetInnerContentPanelAlignment(AlignType alignment)
        {
            switch (alignment)
            {
                case AlignType.TopLeft:
                    {
                        innerControlPanel.Left = 0;
                        innerControlPanel.Top = 0;
                    }
                    break;
                case AlignType.TopCenter:
                    {
                        innerControlPanel.Left = (this.Width - innerControlPanel.Width) / 2;
                        innerControlPanel.Top = 0;
                    }
                    break;
                case AlignType.TopRight:
                    {
                        innerControlPanel.Left = this.Width - innerControlPanel.Width;
                        innerControlPanel.Top = 0;
                    }
                    break;
                case AlignType.MiddleLeft:
                    {
                        innerControlPanel.Left = 0;
                        innerControlPanel.Top = (this.Height - innerControlPanel.Height) / 2;
                    }
                    break;
                case AlignType.MiddleRight:
                    {
                        innerControlPanel.Left = this.Width - innerControlPanel.Width;
                        innerControlPanel.Top = (this.Height - innerControlPanel.Height) / 2;
                    }
                    break;
                case AlignType.BottomLeft:
                    {
                        innerControlPanel.Left = 0;
                        innerControlPanel.Top = this.Height - innerControlPanel.Height;
                    }
                    break;
                case AlignType.BottomCenter:
                    {
                        innerControlPanel.Left = (this.Width - innerControlPanel.Width) / 2;
                        innerControlPanel.Top = this.Height - innerControlPanel.Height;
                    }
                    break;
                case AlignType.BottomRight:
                    {
                        innerControlPanel.Left = this.Width - innerControlPanel.Width;
                        innerControlPanel.Top = this.Height - innerControlPanel.Height;
                    }
                    break;
                default:
                case AlignType.MiddleCenter:
                    {
                        innerControlPanel.Left = (this.Width - innerControlPanel.Width) / 2;
                        innerControlPanel.Top = (this.Height - innerControlPanel.Height) / 2;
                    }
                    break;
            }
        }

        [DefaultValue(0), CustomAttribute()]
        public int TextBoxMaxLength { get; set; }

        [DefaultValue(true), CustomAttribute()]
        public bool EnableCancelButton
        {
            get
            {
                return _EnableCancelButton;
            }
            set
            {
                _EnableCancelButton = value;
                EnableDisableCancelButton(value);
            }
        }

        [DefaultValue(true), CustomAttribute()]
        public bool ShowCancelButton
        {
            get
            {
                return _ShowCancelButton;
            }
            set
            {
                _ShowCancelButton = value;
                kBtnCancel.Visible = value;
            }
        }

        [DefaultValue(false), CustomAttribute()]
        public bool EnableOkButton
        {
            get
            {
                return _EnableOkButton;
            }
            set
            {
                _EnableOkButton = value;
                EnableDisableOkButton(value);
            }
        }

        [DefaultValue(1), CustomAttribute()]
        public int LabelRows
        {
            get
            {
                return _LabelRows;
            }
            set
            {
                _LabelRows = value;
                lblText.Height = _LabelHeight * value;
                pnlText.Top = lblText.Height;
                innerKeyboardPanel.Top = pnlText.Bottom + 26;
                innerControlPanel.Height = innerKeyboardPanel.Top + innerKeyboardPanel.Height;
                this.ContentAlign = this.ContentAlign;
            }
        }

        [DefaultValue(ValueType.None), CustomAttribute()]
        public ValueType InputValueType
        {
            get
            {
                return _InputValueType;
            }
            set
            {
                _InputValueType = value;
                SetDefaultTextForValueType(value);
            }
        }

        [DefaultValue(""), CustomAttribute()]
        public override string Text
        {
            get
            {
                return txtText.Text;
            }
        }

        [DefaultValue(""), CustomAttribute()]
        public long Value
        {
            get
            {
                long retValue = 0;
                switch (InputValueType)
                {
                    case ValueType.PhoneNumber:
                        {
                            string val = txtText.Text;
                            StringBuilder str = new StringBuilder();
                            foreach (char c in val)
                                if (char.IsDigit(c))
                                    str.Append(c);
                            if (str.Length > 0)
                                retValue = Convert.ToInt64(str.ToString());
                        }
                        break;
                    case ValueType.None:
                    default:
                        if (txtText.Text.Length > 0)
                            retValue = Convert.ToInt64(txtText.Text);
                        break;
                }
                return retValue;
            }
        }

        private void SetDefaultTextForValueType(ValueType valType)
        {
            switch (valType)
            {
                case ValueType.PhoneNumber:
                    txtText.Text = "+38 0";
                    break;
                case ValueType.None:
                default:
                    txtText.Text = string.Empty;
                    break;
            }
        }

        public KeyboardPanel()
        {
            InitializeComponent();
            AdditionalInit();
        }

        private void AdditionalInit()
        {
            _Enabled = true;
            SetPropertiesDefaultValues();
        }

        private void SetPropertiesDefaultValues()
        {
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(this))
                if (property.Attributes[typeof(CustomAttribute)] != null)
                    property.ResetValue(this);
        }

        private void kBtn_MouseDown(object sender, MouseEventArgs e)
        {
            string buttonText = ((ImageButton)sender).Text;
            if (TextBoxMaxLength > 0)
            {
                if (buttonText == string.Empty)
                {
                    if (_lengthCounter > 0)
                    {
                        _lengthCounter--;
                        switch (InputValueType)
                        {
                            case ValueType.PhoneNumber:
                                if ((_lengthCounter == 1) || (_lengthCounter == 4) || (_lengthCounter == 6))
                                    txtText.Text = txtText.Text.Substring(0, txtText.Text.Length - 2);
                                else
                                    txtText.Text = txtText.Text.Substring(0, txtText.Text.Length - 1);
                                break;
                            case ValueType.None:
                            default:
                                txtText.Text = txtText.Text.Substring(0, txtText.Text.Length - 1);
                                break;
                        }
                        if (_lengthCounter == TextBoxMaxLength - 1)
                        {
                            EnableDisableKeyboardButtons(true);
                            EnableOkButton = false;
                        }
                    }
                }
                else
                {
                    _lengthCounter++;
                    txtText.Text += buttonText;
                    switch (InputValueType)
                    {
                        case ValueType.PhoneNumber:
                            if (_lengthCounter == 2)
                                txtText.Text += " ";
                            else
                                if ((_lengthCounter == 5) || (_lengthCounter == 7))
                                    txtText.Text += "-";
                            break;
                        case ValueType.None:
                        default:
                            break;
                    }
                    if (_lengthCounter == TextBoxMaxLength)
                    {
                        EnableDisableOkButton(true);
                        kBtnOk.Focus();
                        EnableDisableKeyboardButtons(false);
                    }
                }
            }
        }

        private void EnableDisableOkButton(bool flag)
        {
            WinApi.SuspendDrawing(kBtnOk);
            kBtnOk.Enabled = flag;
            if (flag)
                kBtnOk.NormalImage = ((System.Drawing.Image)(ResourcesMessages.keyboard_ok));
            else
                kBtnOk.NormalImage = ((System.Drawing.Image)(ResourcesMessages.keyboard_ok_disabled));
            WinApi.ResumeDrawing(kBtnOk);
        }

        private void EnableDisableCancelButton(bool flag)
        {
            kBtnCancel.Enabled = flag;
            if (flag)
                kBtnCancel.NormalImage = ((System.Drawing.Image)(ResourcesMessages.keyboard_cancel));
            else
                kBtnCancel.NormalImage = ((System.Drawing.Image)(ResourcesMessages.keyboard_cancel_disabled));
        }

        private void EnableDisableKeyboardButtons(bool flag)
        {
            WinApi.SuspendDrawing(innerKeyboardPanel);
            foreach (Control ctrl in innerKeyboardPanel.Controls)
            {
                if (ctrl is ImageButton)
                {
                    ImageButton imb = ctrl as ImageButton;
                    if (imb.Text.Length > 0)
                    {
                        char firstChar = imb.Text[0];
                        if (char.IsDigit(firstChar))
                        {
                            imb.Enabled = flag;
                            if (flag)
                                imb.NormalImage = ((System.Drawing.Image)(ResourcesMessages.keyboard_button));
                            else
                                imb.NormalImage = ((System.Drawing.Image)(ResourcesMessages.keyboard_button_disabled));
                        }
                    }
                }
            }
            WinApi.ResumeDrawing(innerKeyboardPanel);
        }

        private void EnableDisableBackButton(bool flag)
        {
            kBtnBackspace.Enabled = flag;
            if (flag)
                kBtnBackspace.NormalImage = ((System.Drawing.Image)(ResourcesMessages.keyboard_back));
            else
                kBtnBackspace.NormalImage = ((System.Drawing.Image)(ResourcesMessages.keyboard_back_disabled));
        }

        public void Reset()
        {
            _lengthCounter = 0;
            EnableDisableKeyboardButtons(true);
            EnableDisableOkButton(false);
            EnableDisableCancelButton(true);
            SetDefaultTextForValueType(this.InputValueType);
            _Enabled = true;
            _EnabledButtons = null;
        }

        public enum AlignType
        {
            TopLeft,
            TopCenter,
            TopRight,
            MiddleLeft,
            MiddleCenter,
            MiddleRight,
            BottomLeft,
            BottomCenter,
            BottomRight
        }

        public enum ValueType
        {
            None,
            PhoneNumber
        }

        private void KeyboardPanel_SizeChanged(object sender, EventArgs e)
        {
            this.ContentAlign = this.ContentAlign;
        }

        private class CustomAttribute : System.Attribute
        {
            public CustomAttribute() { }
        }

        private void txtText_Enter(object sender, EventArgs e)
        {
            foreach (Control ctrl in innerKeyboardPanel.Controls)
            {
                if ((ctrl.Enabled) && (ctrl is ImageButton))
                    (ctrl as ImageButton).Focus();
            }
        }

        private void kBtnOk_MouseDown(object sender, MouseEventArgs e)
        {
            OnOkButtonClicked();
        }

        private void kBtnCancel_MouseDown(object sender, MouseEventArgs e)
        {
            OnCancelButtonClicked();
        }

        public void EnableDisableAllButtons(bool flag)
        {
            WinApi.SuspendDrawing(innerKeyboardPanel);
            if (!flag)
            {
                if (_Enabled)
                {
                    _Enabled = false;
                    _EnabledButtons = new List<ImageButton>();
                    foreach (Control ctrl in innerKeyboardPanel.Controls)
                    {
                        if (ctrl is ImageButton)
                        {
                            ImageButton imb = ctrl as ImageButton;
                            if (imb.Enabled)
                            {
                                _EnabledButtons.Add(imb);
                                if (imb.Name == kBtnOk.Name)
                                    EnableDisableOkButton(flag);
                                else
                                    if (imb.Name == kBtnCancel.Name)
                                        EnableDisableCancelButton(flag);
                                    else
                                        if (imb.Name == kBtnBackspace.Name)
                                            EnableDisableBackButton(flag);
                            }
                        }
                    }
                    if (_EnabledButtons.Count > 3)
                        EnableDisableKeyboardButtons(flag);
                }
            }
            else
            {
                if (_EnabledButtons != null)
                {
                    foreach (ImageButton imb in _EnabledButtons)
                    {
                        if (imb.Name == kBtnOk.Name)
                            EnableDisableOkButton(flag);
                        else
                            if (imb.Name == kBtnCancel.Name)
                                EnableDisableCancelButton(flag);
                            else
                                if (imb.Name == kBtnBackspace.Name)
                                    EnableDisableBackButton(flag);
                    }
                    if (_EnabledButtons.Count > 3)
                        EnableDisableKeyboardButtons(flag);
                    _EnabledButtons = null;
                    _Enabled = true;
                }
            }
            WinApi.ResumeDrawing(innerKeyboardPanel);
        }
    }
}
