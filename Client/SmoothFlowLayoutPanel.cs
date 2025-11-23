using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class SmoothFlowLayoutPanel : FlowLayoutPanel
    {
        public int ScrollSpeed { get; set; } = SystemInformation.MouseWheelScrollLines;

        public SmoothFlowLayoutPanel()
        {
            this.DoubleBuffered = true; // reduce flicker
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.AutoScroll = true;
            this.WrapContents = false; // optional: horizontal scroll
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            // Custom smooth scroll
            if (VerticalScroll.Visible)
            {
                int newValue = VerticalScroll.Value - e.Delta;
                newValue = Math.Max(VerticalScroll.Minimum, Math.Min(newValue, VerticalScroll.Maximum));
                VerticalScroll.Value = newValue;
                PerformLayout();
            }
            else if (HorizontalScroll.Visible)
            {
                int newValue = HorizontalScroll.Value - e.Delta;
                newValue = Math.Max(HorizontalScroll.Minimum, Math.Min(newValue, HorizontalScroll.Maximum));
                HorizontalScroll.Value = newValue;
                PerformLayout();
            }
        }
    }
}
