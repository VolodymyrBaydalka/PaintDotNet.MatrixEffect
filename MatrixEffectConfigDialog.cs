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

using PaintDotNet.Effects;
using System;

namespace MatrixEffect
{
    public class MatrixEffectConfigDialog : EffectConfigDialog
    {
        #region Members
        private bool _updating = false;

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.GroupBox groupBoxMatrix;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.Panel matrixPanel;
        private MatrixControl matrixControl;
        private System.Windows.Forms.Label maskLabel;
        private System.Windows.Forms.ComboBox masksComboBox;
        private System.Windows.Forms.CheckBox checkBoxB;
        private System.Windows.Forms.CheckBox checkBoxG;
        private System.Windows.Forms.CheckBox checkBoxR;
        private System.Windows.Forms.CheckBox checkBoxA;
        private System.Windows.Forms.Label rowOffsetLabel;
        private System.Windows.Forms.NumericUpDown rowOffsetNumericUpDown;
        private System.Windows.Forms.Label columnOffsetLabel;
        private System.Windows.Forms.NumericUpDown columnOffsetNumericUpDown;
        private System.Windows.Forms.Label rowsLabel;
        private System.Windows.Forms.NumericUpDown rowsNumericUpDown;
        private System.Windows.Forms.Label columnsLabel;
        private System.Windows.Forms.NumericUpDown columnsNumericUpDown;
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
            this.matrixPanel = new System.Windows.Forms.Panel();
            this.matrixControl = new MatrixControl();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.rowOffsetLabel = new System.Windows.Forms.Label();
            this.rowOffsetNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.columnOffsetLabel = new System.Windows.Forms.Label();
            this.columnOffsetNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.rowsLabel = new System.Windows.Forms.Label();
            this.rowsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.columnsLabel = new System.Windows.Forms.Label();
            this.columnsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.checkBoxB = new System.Windows.Forms.CheckBox();
            this.checkBoxG = new System.Windows.Forms.CheckBox();
            this.checkBoxR = new System.Windows.Forms.CheckBox();
            this.checkBoxA = new System.Windows.Forms.CheckBox();
            this.maskLabel = new System.Windows.Forms.Label();
            this.masksComboBox = new System.Windows.Forms.ComboBox();
            this.groupBoxMatrix.SuspendLayout();
            this.matrixPanel.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rowOffsetNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnOffsetNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnsNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(469, 319);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(114, 29);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(350, 319);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(111, 29);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // groupBoxMatrix
            // 
            this.groupBoxMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxMatrix.Controls.Add(this.matrixPanel);
            this.groupBoxMatrix.Location = new System.Drawing.Point(15, 15);
            this.groupBoxMatrix.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxMatrix.Name = "groupBoxMatrix";
            this.groupBoxMatrix.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxMatrix.Size = new System.Drawing.Size(328, 296);
            this.groupBoxMatrix.TabIndex = 4;
            this.groupBoxMatrix.TabStop = false;
            this.groupBoxMatrix.Text = "Matrix";
            // 
            // matrixPanel
            // 
            this.matrixPanel.AutoScroll = true;
            this.matrixPanel.Controls.Add(this.matrixControl);
            this.matrixPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matrixPanel.Location = new System.Drawing.Point(4, 19);
            this.matrixPanel.Margin = new System.Windows.Forms.Padding(4);
            this.matrixPanel.Name = "matrixPanel";
            this.matrixPanel.Size = new System.Drawing.Size(320, 273);
            this.matrixPanel.TabIndex = 0;
            // 
            // matrixControl
            // 
            this.matrixControl.ColumnsCount = 0;
            this.matrixControl.Location = new System.Drawing.Point(0, 0);
            this.matrixControl.Margin = new System.Windows.Forms.Padding(4);
            this.matrixControl.Name = "matrixControl";
            this.matrixControl.RowsCount = 0;
            this.matrixControl.Size = new System.Drawing.Size(250, 125);
            this.matrixControl.TabIndex = 0;
            this.matrixControl.TabStop = false;
            this.matrixControl.Text = "groupBox1";
            this.matrixControl.MartixChanged += new System.EventHandler(this.UpdateMask);
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSettings.Controls.Add(this.rowOffsetLabel);
            this.groupBoxSettings.Controls.Add(this.rowOffsetNumericUpDown);
            this.groupBoxSettings.Controls.Add(this.columnOffsetLabel);
            this.groupBoxSettings.Controls.Add(this.columnOffsetNumericUpDown);
            this.groupBoxSettings.Controls.Add(this.rowsLabel);
            this.groupBoxSettings.Controls.Add(this.rowsNumericUpDown);
            this.groupBoxSettings.Controls.Add(this.columnsLabel);
            this.groupBoxSettings.Controls.Add(this.columnsNumericUpDown);
            this.groupBoxSettings.Controls.Add(this.checkBoxB);
            this.groupBoxSettings.Controls.Add(this.checkBoxG);
            this.groupBoxSettings.Controls.Add(this.checkBoxR);
            this.groupBoxSettings.Controls.Add(this.checkBoxA);
            this.groupBoxSettings.Controls.Add(this.maskLabel);
            this.groupBoxSettings.Controls.Add(this.masksComboBox);
            this.groupBoxSettings.Location = new System.Drawing.Point(350, 15);
            this.groupBoxSettings.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxSettings.Size = new System.Drawing.Size(232, 296);
            this.groupBoxSettings.TabIndex = 5;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // rowOffsetLabel
            // 
            this.rowOffsetLabel.AutoSize = true;
            this.rowOffsetLabel.Location = new System.Drawing.Point(8, 202);
            this.rowOffsetLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rowOffsetLabel.Name = "rowOffsetLabel";
            this.rowOffsetLabel.Size = new System.Drawing.Size(89, 17);
            this.rowOffsetLabel.TabIndex = 10;
            this.rowOffsetLabel.Text = "Rows offset :";
            // 
            // rowOffsetNumericUpDown
            // 
            this.rowOffsetNumericUpDown.Location = new System.Drawing.Point(119, 200);
            this.rowOffsetNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.rowOffsetNumericUpDown.Name = "rowOffsetNumericUpDown";
            this.rowOffsetNumericUpDown.Size = new System.Drawing.Size(106, 22);
            this.rowOffsetNumericUpDown.TabIndex = 9;
            this.rowOffsetNumericUpDown.ValueChanged += new System.EventHandler(this.UpdateMask);
            // 
            // columnOffsetLabel
            // 
            this.columnOffsetLabel.AutoSize = true;
            this.columnOffsetLabel.Location = new System.Drawing.Point(8, 170);
            this.columnOffsetLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.columnOffsetLabel.Name = "columnOffsetLabel";
            this.columnOffsetLabel.Size = new System.Drawing.Size(109, 17);
            this.columnOffsetLabel.TabIndex = 8;
            this.columnOffsetLabel.Text = "Columns offset :";
            // 
            // columnOffsetNumericUpDown
            // 
            this.columnOffsetNumericUpDown.Location = new System.Drawing.Point(119, 168);
            this.columnOffsetNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.columnOffsetNumericUpDown.Name = "columnOffsetNumericUpDown";
            this.columnOffsetNumericUpDown.Size = new System.Drawing.Size(106, 22);
            this.columnOffsetNumericUpDown.TabIndex = 7;
            this.columnOffsetNumericUpDown.ValueChanged += new System.EventHandler(this.UpdateMask);
            // 
            // rowsLabel
            // 
            this.rowsLabel.AutoSize = true;
            this.rowsLabel.Location = new System.Drawing.Point(8, 138);
            this.rowsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rowsLabel.Name = "rowsLabel";
            this.rowsLabel.Size = new System.Drawing.Size(89, 17);
            this.rowsLabel.TabIndex = 6;
            this.rowsLabel.Text = "Rows count :";
            // 
            // rowsNumericUpDown
            // 
            this.rowsNumericUpDown.Location = new System.Drawing.Point(119, 135);
            this.rowsNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.rowsNumericUpDown.Name = "rowsNumericUpDown";
            this.rowsNumericUpDown.Size = new System.Drawing.Size(106, 22);
            this.rowsNumericUpDown.TabIndex = 5;
            this.rowsNumericUpDown.ValueChanged += new System.EventHandler(this.ResetMask);
            // 
            // columnsLabel
            // 
            this.columnsLabel.AutoSize = true;
            this.columnsLabel.Location = new System.Drawing.Point(8, 105);
            this.columnsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.columnsLabel.Name = "columnsLabel";
            this.columnsLabel.Size = new System.Drawing.Size(109, 17);
            this.columnsLabel.TabIndex = 4;
            this.columnsLabel.Text = "Columns count :";
            // 
            // columnsNumericUpDown
            // 
            this.columnsNumericUpDown.Location = new System.Drawing.Point(119, 102);
            this.columnsNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.columnsNumericUpDown.Name = "columnsNumericUpDown";
            this.columnsNumericUpDown.Size = new System.Drawing.Size(106, 22);
            this.columnsNumericUpDown.TabIndex = 3;
            this.columnsNumericUpDown.ValueChanged += new System.EventHandler(this.ResetMask);
            // 
            // checkBoxB
            // 
            this.checkBoxB.AutoSize = true;
            this.checkBoxB.Location = new System.Drawing.Point(154, 74);
            this.checkBoxB.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxB.Name = "checkBoxB";
            this.checkBoxB.Size = new System.Drawing.Size(39, 21);
            this.checkBoxB.TabIndex = 2;
            this.checkBoxB.Text = "B";
            this.checkBoxB.UseVisualStyleBackColor = true;
            this.checkBoxB.CheckedChanged += new System.EventHandler(this.UpdateMask);
            // 
            // checkBoxG
            // 
            this.checkBoxG.AutoSize = true;
            this.checkBoxG.Location = new System.Drawing.Point(105, 74);
            this.checkBoxG.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxG.Name = "checkBoxG";
            this.checkBoxG.Size = new System.Drawing.Size(41, 21);
            this.checkBoxG.TabIndex = 2;
            this.checkBoxG.Text = "G";
            this.checkBoxG.UseVisualStyleBackColor = true;
            this.checkBoxG.CheckedChanged += new System.EventHandler(this.UpdateMask);
            // 
            // checkBoxR
            // 
            this.checkBoxR.AutoSize = true;
            this.checkBoxR.Location = new System.Drawing.Point(56, 74);
            this.checkBoxR.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxR.Name = "checkBoxR";
            this.checkBoxR.Size = new System.Drawing.Size(40, 21);
            this.checkBoxR.TabIndex = 2;
            this.checkBoxR.Text = "R";
            this.checkBoxR.UseVisualStyleBackColor = true;
            this.checkBoxR.CheckedChanged += new System.EventHandler(this.UpdateMask);
            // 
            // checkBoxA
            // 
            this.checkBoxA.AutoSize = true;
            this.checkBoxA.Location = new System.Drawing.Point(8, 74);
            this.checkBoxA.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxA.Name = "checkBoxA";
            this.checkBoxA.Size = new System.Drawing.Size(39, 21);
            this.checkBoxA.TabIndex = 2;
            this.checkBoxA.Text = "A";
            this.checkBoxA.UseVisualStyleBackColor = true;
            this.checkBoxA.CheckedChanged += new System.EventHandler(this.UpdateMask);
            // 
            // label1
            // 
            this.maskLabel.AutoSize = true;
            this.maskLabel.Location = new System.Drawing.Point(8, 20);
            this.maskLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.maskLabel.Name = "maskLabel";
            this.maskLabel.Size = new System.Drawing.Size(51, 17);
            this.maskLabel.TabIndex = 1;
            this.maskLabel.Text = "Mask\'s";
            // 
            // masksComboBox
            // 
            this.masksComboBox.FormattingEnabled = true;
            this.masksComboBox.Location = new System.Drawing.Point(8, 40);
            this.masksComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.masksComboBox.Name = "masksComboBox";
            this.masksComboBox.Size = new System.Drawing.Size(216, 24);
            this.masksComboBox.TabIndex = 0;
            // 
            // MatrixEffectConfigDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.ClientSize = new System.Drawing.Size(598, 359);
            this.Controls.Add(this.groupBoxSettings);
            this.Controls.Add(this.groupBoxMatrix);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MatrixEffectConfigDialog";
            this.groupBoxMatrix.ResumeLayout(false);
            this.matrixPanel.ResumeLayout(false);
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rowOffsetNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnOffsetNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnsNumericUpDown)).EndInit();
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

            _updating = true;
            this.SetMask(maskConfigToken.Mask);
            _updating = false;

            base.InitDialogFromToken(effectTokenCopy);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Mask GetMask()
        {
            var mask = new Mask((int)columnsNumericUpDown.Value, (int)rowsNumericUpDown.Value)
            {
                ColumnOffset = (int)columnOffsetNumericUpDown.Value,
                RowsOffset = (int)rowOffsetNumericUpDown.Value,
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
            columnsNumericUpDown.Value = mask.Columns;
            matrixControl.ColumnsCount = mask.Columns;
            columnOffsetNumericUpDown.Maximum = mask.Columns;
            columnOffsetNumericUpDown.Value = mask.ColumnOffset;

            rowsNumericUpDown.Value = mask.Rows;
            matrixControl.RowsCount = mask.Rows;
            rowOffsetNumericUpDown.Maximum = mask.Rows;
            rowOffsetNumericUpDown.Value = mask.RowsOffset;

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
            if (!_updating)
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
            if (!_updating)
            {
                _updating = true;
                this.SetMask(new Mask((int)columnsNumericUpDown.Value, (int)rowsNumericUpDown.Value));
                _updating = false;
            }
        }
        #endregion
    }
}
