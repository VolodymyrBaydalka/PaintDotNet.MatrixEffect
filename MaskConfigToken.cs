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
using PaintDotNet.Effects;

namespace MatrixEffect
{
  public class MaskConfigToken : EffectConfigToken
  {
    #region Members
    private Mask m_mask = new Mask(3, 3);
    #endregion

    #region Properties
    /// <summary>
    /// 
    /// </summary>
    public Mask Mask
    {
      get { return m_mask; }
      set 
      { 
        m_mask = value; 
      }
    }
    #endregion

    #region Implementation
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override object Clone()
    {
      MaskConfigToken mct = new MaskConfigToken();
      mct.Mask = this.Mask.Clone();
      return mct;
    }
    #endregion
  }
}
