using DistributedSystems.LaboratoryWork.Number1.Packages.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.CompilerServices;
using DistributedSystems.LaboratoryWork.Nuget.Command;
using System.ComponentModel;

namespace DistributedSystems.LaboratoryWork.Number1.Packages.Controls
{
    /// <summary>
    /// Interaction logic for LetterKeyboard.xaml
    /// 
    ///
    /// </summary>

    public partial class LetterKeyboard : UserControl
    {
        #region Constructors

        public LetterKeyboard()
        {
            InitializeComponent();

            _buttonLanguageCommand = new Lazy<ICommand>(() => new RelayCommand(_ => LanguageCommandExecute()));
            _buttonCapsLockCommand = new Lazy<ICommand>(() => new RelayCommand(_ => CapsLockCommandExecute()));
            if(KeyboardLanguage==LetterKeyboardTypes.Languages.NotSet) KeyboardLanguage = LetterKeyboardTypes.Languages.En;
        }

        #endregion


        #region Fields

        private static readonly Lazy<string[]> _keyboardLayoutRu = new Lazy<string[]>(["Ё", "Й", "Ц", "У", "К", "Е", "Н", "Г", "Ш", "Щ", "З", "Х", LetterKeyboardTypes.ButtonTags.Clear, LetterKeyboardTypes.ButtonTags.CapsLock, "Ф", "Ы", "В", "А", "П", "Р", "О", "Л", "Д", "Ж", "Э", LetterKeyboardTypes.ButtonTags.ClearAll, LetterKeyboardTypes.ButtonTags.Language, "Я", "Ч", "С", "М", "И", "Т", "Ь", "Ъ", "ъ","Б", "Ю", LetterKeyboardTypes.ButtonTags.Enter]);

        private static readonly Lazy<string[]> _keyboardLayoutEn = new Lazy<string[]>([LetterKeyboardTypes.ButtonTags.ClearAll, "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", LetterKeyboardTypes.ButtonTags.CapsLock, "A", "S", "D", "F", "G", "H", "J", "K", "L",  LetterKeyboardTypes.ButtonTags.Clear, LetterKeyboardTypes.ButtonTags.Void, LetterKeyboardTypes.ButtonTags.Language, "Z", "X", "C", "V", "B", "N", "M", LetterKeyboardTypes.ButtonTags.Enter, LetterKeyboardTypes.ButtonTags.Void]);

        #endregion


        #region DependencyProperty

        public LetterKeyboardTypes.Languages KeyboardLanguage
        {
            get =>
                (LetterKeyboardTypes.Languages)GetValue(KeyboardLanguageProperty);

            set =>
                SetValue(KeyboardLanguageProperty, value);
        }

        public static readonly DependencyProperty KeyboardLanguageProperty
            = DependencyProperty.Register(
                nameof(KeyboardLanguage),
                typeof(LetterKeyboardTypes.Languages),
                typeof(LetterKeyboard),
                new PropertyMetadata(LetterKeyboardTypes.Languages.NotSet, KeyboardLanguagePropertyChangedCallback));

        private static void KeyboardLanguagePropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            if (dependencyObject is not LetterKeyboard keyboard)
            {
                throw new ArgumentException(nameof(dependencyObject));
            }

            switch (eventArgs.NewValue)
            {
                case LetterKeyboardTypes.Languages.NotSet:
                    break;
                case LetterKeyboardTypes.Languages.En:
                    keyboard.GridColumnCount = 11;
                    keyboard.KeyboardLayout = _keyboardLayoutEn.Value;
                    break;
                case LetterKeyboardTypes.Languages.Ru:
                    keyboard.GridColumnCount = 13;
                    keyboard.KeyboardLayout = _keyboardLayoutRu.Value;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public bool CapsLockOn
        {
            get =>
                (bool)GetValue(CapsLockOnProperty);

            set =>
                SetValue(CapsLockOnProperty, value);
        }

        public static DependencyProperty CapsLockOnProperty
            = DependencyProperty.Register(
                nameof(CapsLockOn),
                typeof(bool),
                typeof(LetterKeyboard),
                new PropertyMetadata(false));

        #endregion


        #region DependencyProperty Internal

        public int GridColumnCount
        {
            get =>
                (int)GetValue(GridColumnCountProperty.DependencyProperty);

            set =>
                SetValue(GridColumnCountProperty, value);
        }

        public static readonly DependencyPropertyKey GridColumnCountProperty
            = DependencyProperty.RegisterReadOnly(
                nameof(GridColumnCount),
                typeof(int),
                typeof(LetterKeyboard),
                new PropertyMetadata());


        public string[]? KeyboardLayout
        {
            get =>
                (string[]?)GetValue(KeyboardLayoutProperty.DependencyProperty);

            set =>
                SetValue(KeyboardLayoutProperty, value);
        }

        public static readonly DependencyPropertyKey KeyboardLayoutProperty
            = DependencyProperty.RegisterReadOnly(
                nameof(KeyboardLayout),
                typeof(string[]),
                typeof(LetterKeyboard),
                new PropertyMetadata());

        #endregion


        #region DependencyProperty Styles

        public Style ButtonsStyle
        {
            get =>
                (Style)GetValue(ButtonStyleProperty);

            set =>
                SetValue(ButtonStyleProperty, value);
        }

        public static readonly DependencyProperty ButtonStyleProperty
            = DependencyProperty.Register(
                nameof(ButtonsStyle),
                typeof(Style),
                typeof(LetterKeyboard));

        public Style ButtonClearStyle
        {
            get =>
                (Style)GetValue(ButtonClearStyleProperty);

            set =>
                SetValue(ButtonClearStyleProperty, value);
        }

        public static readonly DependencyProperty ButtonClearStyleProperty
            = DependencyProperty.Register(
                nameof(ButtonClearStyle),
                typeof(Style),
                typeof(LetterKeyboard));

        public Style ButtonClearAllStyle
        {
            get =>
                (Style)GetValue(ButtonClearAllStyleProperty);

            set =>
                SetValue(ButtonClearAllStyleProperty, value);
        }

        public static readonly DependencyProperty ButtonClearAllStyleProperty
            = DependencyProperty.Register(
                nameof(ButtonClearAllStyle),
                typeof(Style),
                typeof(LetterKeyboard));

        public Style ButtonEnterStyle
        {
            get =>
                (Style)GetValue(ButtonEnterStyleProperty);

            set =>
                SetValue(ButtonEnterStyleProperty, value);
        }

        public static readonly DependencyProperty ButtonEnterStyleProperty
            = DependencyProperty.Register(
                nameof(ButtonEnterStyle),
                typeof(Style),
                typeof(LetterKeyboard));

        public Style ButtonCapsLockOnStyle
        {
            get =>
                (Style)GetValue(ButtonCapsLockOnStyleProperty);

            set =>
                SetValue(ButtonCapsLockOnStyleProperty, value);
        }

        public static readonly DependencyProperty ButtonCapsLockOnStyleProperty
            = DependencyProperty.Register(
                nameof(ButtonCapsLockOnStyle),
                typeof(Style),
                typeof(LetterKeyboard));

        public Style ButtonCapsLockOffStyle
        {
            get =>
                (Style)GetValue(ButtonCapsLockOffStyleProperty);

            set =>
                SetValue(ButtonCapsLockOffStyleProperty, value);
        }

        public static readonly DependencyProperty ButtonCapsLockOffStyleProperty
            = DependencyProperty.Register(
                nameof(ButtonCapsLockOffStyle),
                typeof(Style),
                typeof(LetterKeyboard));

        public Style ButtonLanguageStyle
        {
            get =>
                (Style)GetValue(ButtonLanguageStyleProperty);

            set =>
                SetValue(ButtonLanguageStyleProperty, value);
        }

        public static readonly DependencyProperty ButtonLanguageStyleProperty
           = DependencyProperty.Register(
               nameof(ButtonLanguageStyle),
               typeof(Style),
               typeof(LetterKeyboard));

        #endregion


        #region DependencyProperty Commands

        public ICommand ButtonsCommand
        {
            get =>
                (ICommand)GetValue(ButtonsCommandProperty);

            set =>
                SetValue(ButtonsCommandProperty, value);
        }

        public static readonly DependencyProperty ButtonsCommandProperty
            = DependencyProperty.Register(
                nameof(ButtonsCommand),
                typeof(ICommand),
                typeof(LetterKeyboard));

        public ICommand ButtonClearCommand
        {
            get =>
                (ICommand)GetValue(ButtonClearCommandProperty);

            set =>
                SetValue(ButtonClearCommandProperty, value);
        }

        public static readonly DependencyProperty ButtonClearCommandProperty
            = DependencyProperty.Register(
                nameof(ButtonClearCommand),
                typeof(ICommand),
                typeof(LetterKeyboard));

        public ICommand ButtonClearAllCommand
        {
            get =>
                (ICommand)GetValue(ButtonClearAllCommandProperty);

            set =>
                SetValue(ButtonClearAllCommandProperty, value);
        }

        public static readonly DependencyProperty ButtonClearAllCommandProperty
            = DependencyProperty.Register(
                nameof(ButtonClearAllCommand),
                typeof(ICommand),
                typeof(LetterKeyboard));

        public ICommand ButtonEnterCommand
        {
            get =>
                (ICommand)GetValue(ButtonEnterCommandProperty);

            set =>
                SetValue(ButtonEnterCommandProperty, value);
        }

        public static readonly DependencyProperty ButtonEnterCommandProperty
            = DependencyProperty.Register(
                nameof(ButtonEnterCommand),
                typeof(ICommand),
                typeof(LetterKeyboard));

        #endregion


        #region Commands

        private readonly Lazy<ICommand> _buttonCapsLockCommand;

        public ICommand ButtonCapsLockCommand
            => _buttonCapsLockCommand.Value;

        private void CapsLockCommandExecute()
        {
            CapsLockOn = !CapsLockOn;
        }


        private readonly Lazy<ICommand> _buttonLanguageCommand;

        public ICommand ButtonLanguageCommand
            => _buttonLanguageCommand.Value;

        private void LanguageCommandExecute()
        {
            KeyboardLanguage = (KeyboardLanguage == LetterKeyboardTypes.Languages.En) ? LetterKeyboardTypes.Languages.Ru : LetterKeyboardTypes.Languages.En;
        }


        #endregion
    }
}
