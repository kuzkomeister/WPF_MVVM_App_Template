namespace MyWPF.Models
{
    public class Publisher
    {
        #region Секция полей
        public string Name { set; get; }        // Название издания
        public string Address { set; get; }     // Адрес издания

        #endregion

        #region Секция конструкторов

        public Publisher(string name)
        {
            Name = name;
        }

        public Publisher(string name, string address) : this(name)
        {
            Address = address;
        }
        #endregion

    }
}
