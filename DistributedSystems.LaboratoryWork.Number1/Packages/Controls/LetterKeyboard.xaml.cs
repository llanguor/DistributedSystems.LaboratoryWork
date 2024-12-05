using DistributedSystems.LaboratoryWork.Number1.Packages.Controls.Types;
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

namespace DistributedSystems.LaboratoryWork.Number1.Packages.Controls
{
    /// <summary>
    /// Interaction logic for LetterKeyboard.xaml
    /// TODO: перенести все во вью модель. ОБЯЗ. ВСЁ ГДЕ НЕ НАДО ДП - ДЕЛАТЬ ПОЛЕМ. Обяз расставить Lazy на поля команд. Добавить приписку DataContext. к CapsLock в разметке. И тд
    ///
    /// </summary>
    public partial class LetterKeyboard : UserControl
    {
        
        public LetterKeyboard()
        {
            InitializeComponent();
            KeyboardLanguage = LetterKeyboardTypes.Languages.En;
            ButtonLanguageCommand =  new RelayCommand(_ => LanguageCommandExecute());
            ButtonCapsLockCommand = new RelayCommand(_ => CapsLockCommandExecute()); 
        }


        private static readonly Lazy<string[]> _keyboardLayoutRu = new Lazy<string[]>(["Ё", "Й", "Ц", "У", "К", "Е", "Н", "Г", "Ш", "Щ", "З", "Х", LetterKeyboardTypes.ButtonTags.Clear, LetterKeyboardTypes.ButtonTags.CapsLock, "Ф", "Ы", "В", "А", "П", "Р", "О", "Л", "Д", "Ж", "Э", LetterKeyboardTypes.ButtonTags.ClearAll, LetterKeyboardTypes.ButtonTags.Language, "Я", "Ч", "С", "М", "И", "Т", "Ь", "Ъ", "ъ","Б", "Ю", LetterKeyboardTypes.ButtonTags.Enter]);

        private static readonly Lazy<string[]> _keyboardLayoutEn = new Lazy<string[]>([LetterKeyboardTypes.ButtonTags.ClearAll, "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", LetterKeyboardTypes.ButtonTags.CapsLock, "A", "S", "D", "F", "G", "H", "J", "K", "L",  LetterKeyboardTypes.ButtonTags.Clear, LetterKeyboardTypes.ButtonTags.Void, LetterKeyboardTypes.ButtonTags.Language, "Z", "X", "C", "V", "B", "N", "M", LetterKeyboardTypes.ButtonTags.Enter, LetterKeyboardTypes.ButtonTags.Void]);

      
        private LetterKeyboardTypes.Languages KeyboardLanguage
        {
            get =>
                (LetterKeyboardTypes.Languages)GetValue(KeyboardLanguageProperty);

            set =>
                SetValue(KeyboardLanguageProperty, value);
        }

        private static readonly DependencyProperty KeyboardLanguageProperty
            = DependencyProperty.Register(
                nameof(KeyboardLanguage),
                typeof(LetterKeyboardTypes.Languages),
                typeof(LetterKeyboard),
                new PropertyMetadata(KeyboardLanguagePropertyChangedCallback));

        private static void KeyboardLanguagePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not LetterKeyboard keyboard)
            {
                throw new ArgumentException(nameof(d));
            }

            switch (e.NewValue)
            {
                case LetterKeyboardTypes.Languages.Blank:
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
                    throw new ArgumentException(nameof(e));

            }
                
        }

        private string[] KeyboardLayout
        {
            get =>
                (string[])GetValue(KeyboardLayoutProperty);

            set =>
                SetValue(KeyboardLayoutProperty, value);
        }

        private static readonly DependencyProperty KeyboardLayoutProperty
            = DependencyProperty.Register(
                nameof(KeyboardLayout),
                typeof(string[]),
                typeof(LetterKeyboard));

        private int GridColumnCount
        {
            get =>
                (int)GetValue(GridColumnCountProperty);

            set =>
                SetValue(GridColumnCountProperty, value);
        }

        private static readonly DependencyProperty GridColumnCountProperty
            = DependencyProperty.Register(
                nameof(GridColumnCount),
                typeof(int),
                typeof(LetterKeyboard));












        #region commands and styles


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

        private ICommand ButtonCapsLockCommand
        {
            get =>
                (ICommand)GetValue(ButtonCapsLockCommandProperty);

            set =>
                SetValue(ButtonCapsLockCommandProperty, value);
        }

        private static readonly DependencyProperty ButtonCapsLockCommandProperty
            = DependencyProperty.Register(
                nameof(ButtonCapsLockCommand),
                typeof(ICommand),
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

        private ICommand ButtonLanguageCommand
        {
            get =>
                (ICommand)GetValue(ButtonLanguageCommandProperty);

            set =>
                SetValue(ButtonLanguageCommandProperty, value);
        }

        private static readonly DependencyProperty ButtonLanguageCommandProperty
            = DependencyProperty.Register(
                nameof(ButtonLanguageCommand),
                typeof(ICommand),
                typeof(LetterKeyboard));

        public bool CapsLockOn
        {
            get =>
                (bool)GetValue(CapsLockOnProperty);

            set =>
                SetValue(CapsLockOnProperty, value);
        }

        public static readonly DependencyProperty CapsLockOnProperty
            = DependencyProperty.Register(
                nameof(CapsLockOn),
                typeof(bool),
                typeof(LetterKeyboard),
                new PropertyMetadata(false));

        #endregion


        #region Commands


        private void CapsLockCommandExecute()
        {
            CapsLockOn = !CapsLockOn;
            if (CapsLockOn)
            {

            }
        }

        private void LanguageCommandExecute()
        {
            KeyboardLanguage = (KeyboardLanguage == LetterKeyboardTypes.Languages.En) ? LetterKeyboardTypes.Languages.Ru : LetterKeyboardTypes.Languages.En;
        }
        #endregion
    }
}
