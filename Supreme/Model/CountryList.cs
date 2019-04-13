using System.Collections.ObjectModel;


namespace Supreme.Model
{
    public class CountryList
    {
        private static ObservableCollection<Country> _Countries = new ObservableCollection<Country>()
        {
            new Country() { Id=1, CountryName = "UK" },
            new Country() { Id=2, CountryName = "UK (N.IRELAND)" },
            new Country() { Id=3, CountryName = "-" },
            new Country() { Id=4, CountryName = "AUSTRIA" },
            new Country() { Id=5, CountryName = "BELARUS" },
            new Country() { Id=6, CountryName = "BELGIUM" },
            new Country() { Id=7, CountryName = "BULGARIA" },
            new Country() { Id=8, CountryName = "CROATIA" },
            new Country() { Id=9, CountryName = "CZECH REPUBLIC" },
            new Country() { Id=10, CountryName = "DENMARK" },
            new Country() { Id=11, CountryName = "ESTONIA" },
            new Country() { Id=12, CountryName = "FINLAND" },
            new Country() { Id=13, CountryName = "FRANCE" },
            new Country() { Id=14, CountryName = "GERMANY" },
            new Country() { Id=15, CountryName = "GREECE" },
            new Country() { Id=16, CountryName = "HUNGARY" },
            new Country() { Id=17, CountryName = "ICELAND" },
            new Country() { Id=18, CountryName = "IRELAND" },
            new Country() { Id=19, CountryName = "ITALY" },
            new Country() { Id=20, CountryName = "LATVIA" },
            new Country() { Id=21, CountryName = "LITHUANIA" },
            new Country() { Id=22, CountryName = "LUXEMBOURG" },
            new Country() { Id=23, CountryName = "MONACO" },
            new Country() { Id=24, CountryName = "NETHERLANDS" },
            new Country() { Id=25, CountryName = "NORWAY" },
            new Country() { Id=26, CountryName = "POLAND" },
            new Country() { Id=27, CountryName = "PORTUGAL" },
            new Country() { Id=28, CountryName = "ROMANIA" },
            new Country() { Id=29, CountryName = "RUSSIA" },
            new Country() { Id=30, CountryName = "SLOVAKIA" },
            new Country() { Id=31, CountryName = "SLOVENIA" },
            new Country() { Id=32, CountryName = "SPAIN" },
            new Country() { Id=33, CountryName = "SWEDEN" },
            new Country() { Id=34, CountryName = "SWITZERLAND" },
            new Country() { Id=35, CountryName = "TURKEY" },
        };

        public ObservableCollection<Country> Countries = _Countries; 
    }
}
