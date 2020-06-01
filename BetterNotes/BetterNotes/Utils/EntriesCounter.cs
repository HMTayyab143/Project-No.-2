using System;
using System.Collections.Generic;
using System.Text;

namespace BetterNotes.Utils
{
    public static class EntriesCounter
    {

        public static int CountEntries(string text)
        {
            return text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
