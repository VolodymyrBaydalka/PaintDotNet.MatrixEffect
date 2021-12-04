#region License
/*******************************************************************************
 * Copyright 2013 Volodymyr Baydalka.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *******************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using PaintDotNet;
using PaintDotNet.Effects;

namespace MatrixEffect
{
    public class MatrixEffectConfigDialog : EffectConfigDialog
    {
        #region Members
        private bool m_updating = false;

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.GroupBox groupBoxMatrix;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.Panel panel1;
        private MatrixControl matrixControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMasks;
        private System.Windows.Forms.CheckBox checkBoxB;
        private System.Windows.Forms.CheckBox checkBoxG;
        private System.Windows.Forms.CheckBox checkBoxR;
        private System.Windows.Forms.CheckBox checkBoxA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownRO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownCO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownRC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownCC;
        private System.Windows.Forms.Button buttonCancel;
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public MaskConfigToken MaskConfigToken
        {
            get
            {
                return this.theEffectToken as MaskConfigToken;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public MatrixEffectConfigDialog()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="me"></param>
        public MatrixEffectConfigDialog(MatrixEffect me)
        {
            this.Effect = me;
            this.InitializeComponent();
        }
        #endregion

        #region Implementation
        /// <summary>
        /// 
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBoxMatrix = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.matrixControl = new MatrixControl();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownRO = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownCO = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownRC = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownCC = new System.Windows.Forms.NumericUpDown();
            this.checkBoxB = new System.Windows.Forms.CheckBox();
            this.checkBoxG = new System.Windows.Forms.CheckBox();
            this.checkBoxR = new System.Windows.Forms.CheckBox();
            this.checkBoxA = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMasks = new System.Windows.Forms.ComboBox();
            this.groupBoxMatrix.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCC)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(375, 255);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(91, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(280, 255);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(89, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // groupBoxMatrix
            // 
            this.groupBoxMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxMatrix.Controls.Add(this.panel1);
            this.groupBoxMatrix.Location = new System.Drawing.Point(12, 12);
            this.groupBoxMatrix.Name = "groupBoxMatrix";
            this.groupBoxMatrix.Size = new System.Drawing.Size(262, 237);
            this.groupBoxMatrix.TabIndex = 4;
            this.groupBoxMatrix.TabStop = false;
            this.groupBoxMatrix.Text = "Matrix";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.matrixControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 218);
            this.panel1.TabIndex = 0;
            // 
            // matrixControl
            // 
            this.matrixControl.ColumnsCourt = 0;
            this.matrixControl.Location = new System.Drawing.Point(0, 0);
            this.matrixControl.Name = "matrixControl";
            this.matrixControl.RowsCout = 0;
            this.matrixControl.Size = new System.Drawing.Size(200, 100);
            this.matrixControl.TabIndex = 0;
            this.matrixControl.TabStop = false;
            this.matrixControl.Text = "groupBox1";
            this.matrixControl.MartixChanged += new System.EventHandler(this.UpdateMask);
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSettings.Controls.Add(this.label5);
            this.groupBoxSettings.Controls.Add(this.numericUpDownRO);
            this.groupBoxSettings.Controls.Add(this.label4);
            this.groupBoxSettings.Controls.Add(this.numericUpDownCO);
            this.groupBoxSettings.Controls.Add(this.label3);
            this.groupBoxSettings.Controls.Add(this.numericUpDownRC);
            this.groupBoxSettings.Controls.Add(this.label2);
            this.groupBoxSettings.Controls.Add(this.numericUpDownCC);
            this.groupBoxSettings.Controls.Add(this.checkBoxB);
            this.groupBoxSettings.Controls.Add(this.checkBoxG);
            this.groupBoxSettings.Controls.Add(this.checkBoxR);
            this.groupBoxSettings.Controls.Add(this.checkBoxA);
            this.groupBoxSettings.Controls.Add(this.label1);
            this.groupBoxSettings.Controls.Add(this.comboBoxMasks);
            this.groupBoxSettings.Location = new System.Drawing.Point(280, 12);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(186, 237);
            this.groupBoxSettings.TabIndex = 5;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Rows offset :";
            // 
            // numericUpDownRO
            // 
            this.numericUpDownRO.Location = new System.Drawing.Point(95, 160);
            this.numericUpDownRO.Name = "numericUpDownRO";
            this.numericUpDownRO.Size = new System.Drawing.Size(85, 20);
            this.numericUpDownRO.TabIndex = 9;
            this.numericUpDownRO.ValueChanged += new System.EventHandler(this.UpdateMask);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Columns offset :";
            // 
            // numericUpDownCO
            // 
            this.numericUpDownCO.Location = new System.Drawing.Point(95, 134);
            this.numericUpDownCO.Name = "numericUpDownCO";
            this.numericUpDownCO.Size = new System.Drawing.Size(85, 20);
            this.numericUpDownCO.TabIndex = 7;
            this.numericUpDownCO.ValueChanged += new System.EventHandler(this.UpdateMask);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Rows count :";
            // 
            // numericUpDownRC
            // 
            this.numericUpDownRC.Location = new System.Drawing.Point(95, 108);
            this.numericUpDownRC.Name = "numericUpDownRC";
            this.numericUpDownRC.Size = new System.Drawing.Size(85, 20);
            this.numericUpDownRC.TabIndex = 5;
            this.numericUpDownRC.ValueChanged += new System.EventHandler(this.ResetMask);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Columns count :";
            // 
            // numericUpDownCC
            // 
            this.numericUpDownCC.Location = new System.Drawing.Point(95, 82);
            this.numericUpDownCC.Name = "numericUpDownCC";
            this.numericUpDownCC.Size = new System.Drawing.Size(85, 20);
            this.numericUpDownCC.TabIndex = 3;
            this.numericUpDownCC.ValueChanged += new System.EventHandler(this.ResetMask);
            // 
            // checkBoxB
            // 
            this.checkBoxB.AutoSize = true;
            this.checkBoxB.Location = new System.Drawing.Point(123, 59);
            this.checkBoxB.Name = "checkBoxB";
            this.checkBoxB.Size = new System.Drawing.Size(33, 17);
            this.checkBoxB.TabIndex = 2;
            this.checkBoxB.Text = "B";
            this.checkBoxB.UseVisualStyleBackColor = true;
            this.checkBoxB.CheckedChanged += new System.EventHandler(this.UpdateMask);
            // 
            // checkBoxG
            // 
            this.checkBoxG.AutoSize = true;
            this.checkBoxG.Location = new System.Drawing.Point(84, 59);
            this.checkBoxG.Name = "checkBoxG";
            this.checkBoxG.Size = new System.Drawing.Size(34, 17);
            this.checkBoxG.TabIndex = 2;
            this.checkBoxG.Text = "G";
            this.checkBoxG.UseVisualStyleBackColor = true;
            this.checkBoxG.CheckedChanged += new System.EventHandler(this.UpdateMask);
            // 
            // checkBoxR
            // 
            this.checkBoxR.AutoSize = true;
            this.checkBoxR.Location = new System.Drawing.Point(45, 59);
            this.checkBoxR.Name = "checkBoxR";
            this.checkBoxR.Size = new System.Drawing.Size(34, 17);
            this.checkBoxR.TabIndex = 2;
            this.checkBoxR.Text = "R";
            this.checkBoxR.UseVisualStyleBackColor = true;
            this.checkBoxR.CheckedChanged += new System.EventHandler(this.UpdateMask);
            // 
            // checkBoxA
            // 
            this.checkBoxA.AutoSize = true;
            this.checkBoxA.Location = new System.Drawing.Point(6, 59);
            this.checkBoxA.Name = "checkBoxA";
            this.checkBoxA.Size = new System.Drawing.Size(33, 17);
            this.checkBoxA.TabIndex = 2;
            this.checkBoxA.Text = "A";
            this.checkBoxA.UseVisualStyleBackColor = true;
            this.checkBoxA.CheckedChanged += new System.EventHandler(this.UpdateMask);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mask\'s";
            // 
            // comboBoxMasks
            // 
            this.comboBoxMasks.FormattingEnabled = true;
            this.comboBoxMasks.Location = new System.Drawing.Point(6, 32);
            this.comboBoxMasks.Name = "comboBoxMasks";
            this.comboBoxMasks.Size = new System.Drawing.Size(174, 21);
            this.comboBoxMasks.TabIndex = 0;
            // 
            // MatrixEffectConfigDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(478, 287);
            this.Controls.Add(this.groupBoxSettings);
            this.Controls.Add(this.groupBoxMatrix);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Name = "MatrixEffectConfigDialog";
            this.Controls.SetChildIndex(this.buttonOk, 0);
            this.Controls.SetChildIndex(this.buttonCancel, 0);
            this.Controls.SetChildIndex(this.groupBoxMatrix, 0);
            this.Controls.SetChildIndex(this.groupBoxSettings, 0);
            this.groupBoxMatrix.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCC)).EndInit();
            this.ResumeLayout(false);

        }
        /// <summary>
        /// 
        /// </summary>
        protected override void InitialInitToken()
        {
            this.theEffectToken = new MaskConfigToken();
            base.InitialInitToken();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="effectTokenCopy"></param>
        protected override void InitDialogFromToken(EffectConfigToken effectTokenCopy)
        {
            MaskConfigToken maskConfigToken = effectTokenCopy as MaskConfigToken;

            m_updating = true;
            this.SetMask(maskConfigToken.Mask);
            m_updating = false;

            base.InitDialogFromToken(effectTokenCopy);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Mask GetMask()
        {
            var mask = new Mask((int)numericUpDownCC.Value, (int)numericUpDownRC.Value)
            {
                ColumnOffset = (int)numericUpDownCO.Value,
                RowsOffset = (int)numericUpDownRO.Value,
                Components = ColorComponent.None
            };

            if (checkBoxA.Checked) mask.Components |= ColorComponent.A;
            if (checkBoxR.Checked) mask.Components |= ColorComponent.R;
            if (checkBoxG.Checked) mask.Components |= ColorComponent.G;
            if (checkBoxB.Checked) mask.Components |= ColorComponent.B;

            for (int i = 0; i < mask.Columns; i++)
            {
                for (int j = 0; j < mask.Rows; j++)
                {
                    mask[i, j] = double.Parse(matrixControl.GetText(i, j));
                }
            }

            return mask;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mask"></param>
        private void SetMask(Mask mask)
        {
            numericUpDownCC.Value = mask.Columns;
            matrixControl.ColumnsCourt = mask.Columns;
            numericUpDownCO.Maximum = mask.Columns;
            numericUpDownCO.Value = mask.ColumnOffset;

            numericUpDownRC.Value = mask.Rows;
            matrixControl.RowsCout = mask.Rows;
            numericUpDownRO.Maximum = mask.Rows;
            numericUpDownRO.Value = mask.RowsOffset;

            matrixControl.Refresh();

            checkBoxA.Checked = (mask.Components & ColorComponent.A) == ColorComponent.A;
            checkBoxR.Checked = (mask.Components & ColorComponent.R) == ColorComponent.R;
            checkBoxG.Checked = (mask.Components & ColorComponent.G) == ColorComponent.G;
            checkBoxB.Checked = (mask.Components & ColorComponent.B) == ColorComponent.B;

            for (int i = 0; i < mask.Columns; i++)
            {
                for (int j = 0; j < mask.Rows; j++)
                {
                    matrixControl.SetText(i, j, mask[i, j].ToString());
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateMask(object sender, EventArgs e)
        {
            if (!m_updating)
            {
                this.MaskConfigToken.Mask = this.GetMask();
                this.FinishTokenUpdate();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetMask(object sender, EventArgs e)
        {
            if (!m_updating)
            {
                m_updating = true;
                this.SetMask(new Mask((int)numericUpDownCC.Value, (int)numericUpDownRC.Value));
                m_updating = false;
            }
        }
        #endregion
    }
}
