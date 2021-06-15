using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyWPF.ViewModels
{
    public abstract class VM_BASIC : INotifyPropertyChanged
    {
        #region [ Свойства для конфигурирования интерфейса в зависимости от флагов приложения ]
        /*
         * На формы, для элементов управления, наличие которых зависит от того, какая именно программа запущена
         * или моудли доступны нужно делать:
         * в ресурсах xaml включать конвертер:
         * <Window.Resources>
         *      <BooleanToVisibilityConverter x:Key="BooleanToVisibilityConverter"/>
         * </Window.Resources>
         * в свойствах видимости компонентов:
         * Visibility="{Binding IsApFlagRNSimular, Converter={StaticResource BooleanToVisibilityConverter}}"
         * где "IsApFlagRNSimular" - свойство, говорящее, что доступен модуль РН-Симулар. 
         * Аналогично - для других модулей. Общие для любого приложения элементы - управляются отдельно.
         * 
         */

        #endregion

        /// <summary>
        /// Заглушка для свойства Enabled в Command: TRUE
        /// </summary>
        protected bool _AlwaysTrue() { return true; }

        /// <summary>
        /// Заглушка для свойства Enabled в Command: FALSE
        /// </summary>
        protected bool _AlwaysFalse() { return false; }

        /// <summary>
        /// Объявление свойства из INotifyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
