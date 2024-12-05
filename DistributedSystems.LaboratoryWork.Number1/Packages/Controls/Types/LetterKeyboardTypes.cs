using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedSystems.LaboratoryWork.Number1.Packages.Controls.Types
{
    public sealed class LetterKeyboardTypes
    {
        public static class ButtonTags
        {
            public const string Clear = "<";
            public const string ClearAll = "Clear";
            public const string Void = "";
            public const string Enter = "Enter";
            public const string Language = "Lang";
            public const string CapsLock = "Caps";

        }

        public enum Languages
        {
            Blank,
            En,
            Ru
        }
    }
}
