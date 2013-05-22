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
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using PaintDotNet;
using PaintDotNet.Effects;

namespace MatrixEffect
{
  /// <summary>
  /// 
  /// </summary>
  public unsafe class MatrixEffect : Effect
  {
    #region Constructor
    /// <summary>
    /// 
    /// </summary>
    public MatrixEffect()
      : base(Properties.Resources.MatrixEffectTitle, Properties.Resources.MatrixEffectImage, true)
    {
    }
    #endregion

    #region Implementation
    /// <summary>
    /// 
    /// </summary>
    /// <param name="parameters"></param>
    /// <param name="dstArgs"></param>
    /// <param name="srcArgs"></param>
    /// <param name="rois"></param>
    /// <param name="startIndex"></param>
    /// <param name="length"></param>
    public override unsafe void Render(EffectConfigToken parameters, RenderArgs dstArgs,
      RenderArgs srcArgs, Rectangle[] rois, int startIndex, int length)
    {
      Mask mask = (parameters as MaskConfigToken).Mask;
      int sum = (mask.Sum == 0) ? 1 : (int)mask.Sum;

      bool allowA = (mask.Components & ColorComponent.A) == ColorComponent.A;
      bool allowR = (mask.Components & ColorComponent.R) == ColorComponent.R;
      bool allowG = (mask.Components & ColorComponent.G) == ColorComponent.G;
      bool allowB = (mask.Components & ColorComponent.B) == ColorComponent.B;

      int co = mask.ColumnOffset;
      int ro = mask.RowsOffset;

      Surface isf = srcArgs.Surface;
      Surface osf = dstArgs.Surface;

      Rectangle bounds = srcArgs.Bounds;

      for (int i = startIndex, ci = startIndex + length; i < ci; i++)
      {
        Rectangle rc = rois[i];

        for (int x = rc.Left; x < rc.Right; x++)
        {
          for (int y = rc.Top; y < rc.Bottom; y++)
          {
            #region Compute new color
            int a = 0;
            int r = 0;
            int g = 0;
            int b = 0;

            for (int cl = mask.Columns-1; cl > -1; cl--)
            {
              for (int rw = mask.Rows - 1; rw > -1; rw--)
              {
                int cx = x + cl - co;
                int cy = y + rw - ro;

                if (cx >= bounds.Left && cy >= bounds.Top && cx < bounds.Right && cy < bounds.Bottom)
                {
                  int coef = (int)mask[cl, rw];
                  ColorBgra clr = isf.GetPointUnchecked(cx, cy);

                  a += coef * clr.A;
                  r += coef * clr.R;
                  g += coef * clr.G;
                  b += coef * clr.B;
                }
              }
            }

            ColorBgra* oclr = osf.GetPointAddressUnchecked(x, y);

            if (allowA) oclr->A = (byte)MinMax(a / sum, 0, byte.MaxValue);
            if (allowR) oclr->R = (byte)MinMax(r / sum, 0, byte.MaxValue);
            if (allowG) oclr->G = (byte)MinMax(g / sum, 0, byte.MaxValue);
            if (allowB) oclr->B = (byte)MinMax(b / sum, 0, byte.MaxValue);
            #endregion
          }
        }
      }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override EffectConfigDialog CreateConfigDialog()
    {
      return new MatrixEffectConfigDialog(this);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    private int MinMax(int value, int min, int max)
    {
      return value > min ? (value < max ? value : max) : min;
    }
    #endregion
  }
}
