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
        private static readonly EffectOptions options = new EffectOptions
        {
            Flags = EffectFlags.Configurable
        };

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public MatrixEffect()
          : base(Properties.Resources.MatrixEffectTitle, Properties.Resources.MatrixEffectImage, null, options)
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
            var mask = (parameters as MaskConfigToken).Mask;
            var sum = (mask.Sum == 0) ? 1 : (int)mask.Sum;

            var allowA = (mask.Components & ColorComponent.A) == ColorComponent.A;
            var allowR = (mask.Components & ColorComponent.R) == ColorComponent.R;
            var allowG = (mask.Components & ColorComponent.G) == ColorComponent.G;
            var allowB = (mask.Components & ColorComponent.B) == ColorComponent.B;

            var co = mask.ColumnOffset;
            var ro = mask.RowsOffset;

            var isf = srcArgs.Surface;
            var osf = dstArgs.Surface;

            var bounds = srcArgs.Bounds;

            for (int i = startIndex, ci = startIndex + length; i < ci; i++)
            {
                var rc = rois[i];

                for (int x = rc.Left; x < rc.Right; x++)
                {
                    for (int y = rc.Top; y < rc.Bottom; y++)
                    {
                        #region Compute new color
                        int a = 0;
                        int r = 0;
                        int g = 0;
                        int b = 0;

                        for (int cl = mask.Columns - 1; cl > -1; cl--)
                        {
                            for (int rw = mask.Rows - 1; rw > -1; rw--)
                            {
                                int cx = x + cl - co;
                                int cy = y + rw - ro;

                                if (cx >= bounds.Left && cy >= bounds.Top && cx < bounds.Right && cy < bounds.Bottom)
                                {
                                    int coef = (int)mask[cl, rw];
                                    var clr = isf.GetPointUnchecked(cx, cy);

                                    a += coef * clr.A;
                                    r += coef * clr.R;
                                    g += coef * clr.G;
                                    b += coef * clr.B;
                                }
                            }
                        }

                        var oclr = osf.GetPointAddressUnchecked(x, y);

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
