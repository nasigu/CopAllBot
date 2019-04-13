using System.Windows.Controls;

namespace Supreme.Views
{
    /// <summary>
    /// Логика взаимодействия для ArtListView.xaml
    /// </summary>
    public partial class ArtListView : UserControl
    {
        public ArtListView()
        {
            InitializeComponent();
        }

        //private void Grid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        //{
        //    var Item = (Grid)sender;
        //    var ArtItem = Item.DataContext as ArtList;
        //    if (ArtItem.SoldOut)
        //    {
        //        ArtItem.SoldOutVisibility = Visibility.Visible;
        //    }
        //}

        //private void Grid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        //{
        //    var Item = (Grid)sender;
        //    var ArtItem = Item.DataContext as ArtList;
        //    if (ArtItem.SoldOut)
        //    {
        //        ArtItem.SoldOutVisibility = Visibility.Hidden;
        //    }
        //}

    }
}
