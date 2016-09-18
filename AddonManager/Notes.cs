namespace AddonManager
{
    internal sealed class Notes
    {
        /*
         * This class is not to be taken serious.
         * It will be deleted after what has been written here is fixed.
         * Bugs that are currently on my head:
         * 1. Dragging and dropping a new catalog/basket file will NOT update the listbox entry. (Hence make the action useless.)
         * 2. Cannot remove items from baskets listbox.
         * 3. The 255text length can easily be abused and render the information panel useless.
         * --
         * Features that need to be done along with the bugfixes:
         * 1. Colored items for CheckedListBox.
         * 2. Re-size UI? Port over TextWrapping from WPF? I dunno, that 255 bug has to be fixed.
         * 3. ERROR HANDLING. Currently there is minimal handling, and users will (indubitably) manage to hit every error. Get on it.
         * 4. To disable RichTextBox FixedBorder3D or to not disable RichTextBox FixedBorder3D. That is the question.
         */
    }
}