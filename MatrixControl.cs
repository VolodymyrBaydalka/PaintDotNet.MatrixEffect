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
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace MatrixEffect
{
  /// <summary>
  /// 
  /// </summary>
  class MatrixControl : Control
  {
    #region Constants
    private const int c_textBoxWidth = 60;
    private const int c_textBoxHeight = 20;
    #endregion

    #region Events
    public event EventHandler MartixChanged;
    #endregion

    #region Members
    private int m_columnsCount;
    private int m_rowsCount;
    #endregion

    #region Properties
    /// <summary>
    /// 
    /// </summary>
    public int ColumnsCourt
    {
      get { return m_columnsCount; }
      set { m_columnsCount = value; }
    }
    /// <summary>
    /// 
    /// </summary>
    public int RowsCout
    {
      get { return m_rowsCount; }
      set { m_rowsCount = value; }
    }
    #endregion

    #region Public methods
    /// <summary>
    /// 
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <param name="text"></param>
    public void SetText( int i, int j, string text)
    {
      (this.Controls[i + j * m_columnsCount] as TextBox).Text = text;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <returns></returns>
    public string GetText(int i, int j)
    {
      return (this.Controls[i + j * m_columnsCount] as TextBox).Text;
    }
    /// <summary>
    /// 
    /// </summary>
    public override void Refresh()
    {
      this.Controls.Clear();

      this.Size = new Size(m_columnsCount * c_textBoxWidth, m_rowsCount * c_textBoxHeight);

      for (int j = 0; j < m_rowsCount; j++)
      {
        for (int i = 0; i < m_columnsCount; i++)
        {
          TextBox textbox = new TextBox();

          textbox.Text = "0";
          textbox.Size = new Size(c_textBoxWidth, c_textBoxHeight);
          textbox.Location = new Point(i * c_textBoxWidth, j * c_textBoxHeight);
          textbox.Validating += new System.ComponentModel.CancelEventHandler(OnTextboxValidating);
          textbox.Validated += new EventHandler(OnTextboxValidated);

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
      RaiseMartixChanged(this, e);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnTextboxValidating(object sender, CancelEventArgs e)
    {
      double tempResult = double.NaN;
      TextBox textBox = sender as TextBox;

      if (textBox != null)
      {
        e.Cancel = !double.TryParse(textBox.Text, out tempResult);
      }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private void RaiseMartixChanged(object sender, EventArgs args)
    {
      if (MartixChanged != null)
      {
        MartixChanged(sender, args);
      }
    }
    #endregion
  }
}
