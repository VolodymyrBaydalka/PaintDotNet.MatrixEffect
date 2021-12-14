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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MatrixEffect
{
    /// <summary>
    /// 
    /// </summary>
    public class MatrixControl : Control
    {
        #region Constants
        private static readonly Size textBoxSize = new Size(60, 20);
        #endregion

        #region Events
        public event EventHandler MartixChanged;
        #endregion

        #region Properties
        public int ColumnsCount { get; set; }
        public int RowsCount { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="text"></param>
        public void SetText(int i, int j, string text)
        {
            (this.Controls[i + j * ColumnsCount] as TextBox).Text = text;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public string GetText(int i, int j)
        {
            return (this.Controls[i + j * ColumnsCount] as TextBox).Text;
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Refresh()
        {
            this.Controls.Clear();

            this.Size = new Size(ColumnsCount * textBoxSize.Width, RowsCount * textBoxSize.Height);

            for (int j = 0; j < RowsCount; j++)
            {
                for (int i = 0; i < ColumnsCount; i++)
                {
                    TextBox textbox = new TextBox
                    {
                        Text = "0",
                        Size = textBoxSize,
                        Location = new Point(i * textBoxSize.Width, j * textBoxSize.Height)
                    };
                    textbox.Validating += OnTextboxValidating;
                    textbox.Validated += OnTextboxValidated;

                    this.Controls.Add(textbox);
                }
            }

            base.Refresh();
        }
        #endregion

        #region Implementation
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTextboxValidated(object sender, EventArgs e)
        {
            MartixChanged?.Invoke(sender, e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTextboxValidating(object sender, CancelEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                e.Cancel = !double.TryParse(textBox.Text, out var _);
            }
        }
        #endregion
    }
}
