using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

using Synthesizer_PC_control.Controllers;

namespace Synthesizer_PC_control.Model
{
    public class ChargePump : I_UiLinked
    {
        private UInt16 rSet;
        private int currentIndex;
        private int linearityIndex;
        private int testModeIndex;
        private bool fastLockEnabled;
        private bool triStateEnabled;
        private bool cycleSlipReductEnabled;
        private bool isFillCurrentCombobox;
        private string badLinearityMessage = "Warning: In the current synthesizer mode setting, the linearity of the CP is incorrectly selected.";
        private readonly  TextBox ui_Rset;
        private readonly  ComboBox ui_Current;
        private readonly  ComboBox ui_Linearity;
        private readonly  ComboBox ui_Test;
        private readonly  CheckBox ui_FastLock;
        private readonly  CheckBox ui_TriState;
        private readonly  CheckBox ui_CycleSlipReduct;
        private readonly  Label ui_CurrentLabel;
        private readonly  Label ui_LinearityLabel;
        public ChargePump(TextBox ui_Rset, ComboBox ui_Current, ComboBox ui_Linearity,
                          ComboBox ui_Test, CheckBox ui_FastLock, CheckBox ui_TriState, 
                          CheckBox ui_CycleSlipReduct, Label ui_CurrentLabel, Label ui_LinearityLabel)
        {
            this.ui_Rset    = ui_Rset;
            this.ui_Current = ui_Current;
            this.ui_Linearity   = ui_Linearity;
            this.ui_Test        = ui_Test;
            this.ui_FastLock    = ui_FastLock;
            this.ui_TriState    = ui_TriState;
            this.ui_CycleSlipReduct = ui_CycleSlipReduct;
            this.ui_CurrentLabel    = ui_CurrentLabel;
            this.ui_LinearityLabel  = ui_LinearityLabel;
        }

        #region Setters
        public void SetRSetValue(UInt16 value)
        {
            if (value > 10000)
                value = 10000;
            else if (value < 2700)
                value = 2700;

            this.rSet = value;

            FillCurrentItemsFromRSetValue();

            UpdateUiElements();
        }

        public void SetRSetValue(string value)
        {
            SetRSetValue(Convert.ToUInt16(value));
        }

        public void SetCurrentIndex(int value)
        {
            this.currentIndex = value;

            UpdateUiElements();
        }

        public void SetLinearityIndex(int value)
        {
            this.linearityIndex = value;

            UpdateUiElements();
        }
        #endregion

        #region Getters
        public bool isCurrentComboboxFilled()
        {
            return isFillCurrentCombobox;
        }
        public UInt16 GetRSetValue()
        {
            return rSet;
        }

        public int GetCurrentIndex()
        {
            return currentIndex;
        }
        #endregion

        private void FillCurrentItemsFromRSetValue()
        {
            isFillCurrentCombobox = false;

            IList<string> list = new List<string>();
            decimal I_cp;
            for (UInt16 cp = 0; cp < 16; cp++)
            {
                I_cp = (decimal)(1.63*1000)/(decimal)(rSet) * (1 + cp);
                I_cp = Math.Round(I_cp, 3, MidpointRounding.AwayFromZero);
                list.Add(Convert.ToString(I_cp) + " mA");
            }
            ui_Current.DataSource = list;

            isFillCurrentCombobox = true;
        }

        public void CheckIfCorrectLinearityIsSelected(SynthMode synthMode)
        {
            if (synthMode == SynthMode.INTEGER)
            {
                if (linearityIndex != 0)
                {
                    ConsoleController.Console().Write(badLinearityMessage);
                    ui_LinearityLabel.ForeColor = Color.Red;
                }
                else
                {
                    ui_LinearityLabel.ForeColor = Color.Black;
                }
            }
            else
            {
                if (linearityIndex == 0)
                {
                    ConsoleController.Console().Write(badLinearityMessage);
                    ui_LinearityLabel.ForeColor = Color.Red;
                }
                else
                {
                    ui_LinearityLabel.ForeColor = Color.Black;
                }
            }

        }

        public void UpdateUiElements()
        {
            ui_Rset.Text = rSet.ToString();
            ui_Current.SelectedIndex = currentIndex;
            ui_Linearity.SelectedIndex = linearityIndex;
        }
    }
}