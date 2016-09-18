using System;
using System.Drawing;
using System.Windows.Forms;

namespace AddonManager
{
    public class CustomControls
    {
        public class ActiveCheckedListBox : CheckedListBox
        {
            public static Boolean managingLists = false;

            protected override void OnItemCheck(ItemCheckEventArgs ice)
            {
                if (!managingLists) ice.NewValue = ice.CurrentValue;
                base.OnItemCheck(ice);
            }

            protected override void OnDrawItem(DrawItemEventArgs e)
            {
                DrawItemEventArgs e2 = new DrawItemEventArgs
                   (e.Graphics,
                    e.Font,
                    new Rectangle(e.Bounds.Location, e.Bounds.Size),
                    e.Index,
                    DrawItemState.None,
                    GetItemChecked(e.Index) ? Color.Black : Color.DimGray,
                    this.BackColor);

                base.OnDrawItem(e2);
            }
        }
    }
}