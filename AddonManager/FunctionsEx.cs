using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AddonManager
{
    public static class FunctionsEx
    {
        // http://stackoverflow.com/a/11720793
        public static IEnumerable<T> OrderNatural<T>(this IEnumerable<T> source, Func<T, string> selector)
        {
            var regex = new Regex(@"\d+", RegexOptions.Compiled);

            int max = source
                .SelectMany(i => regex.Matches(selector(i)).Cast<Match>().Select(m => (int?)m.Value.Length))
                .Max() ?? 0;

            return source.OrderBy(i => regex.Replace(selector(i), m => m.Value.PadLeft(max, '0')));
        }

        public static void addItemsWithNaturalOrder(ref ListBox listBox, List<String> items)
        {
            listBox.Items.Clear();
            listBox.Items.AddRange(items.OrderNatural(s => s).ToArray());
        }
    }
}
