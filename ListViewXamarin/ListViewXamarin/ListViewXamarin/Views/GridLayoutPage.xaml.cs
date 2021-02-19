using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.DataSource;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;

namespace ListViewGridLayout
{
    public partial class GridLayoutPage : ContentPage
    {
        private ListViewGridLayoutViewModel viewModel;
        private TapGestureRecognizer deleteImageTapped;
        private GridLayout gridLayout;
        private double pageWidth = 0;

        public GridLayoutPage()
        {
            InitializeComponent();
            viewModel = new ListViewGridLayoutViewModel();
            listView.ItemsSource = viewModel.Gallerynfo;
            listView.BindingContext = viewModel;
            headerGrid.BindingContext = viewModel;
            listView.SelectionChanged += ListView_SelectionChanged;
            gridLayout = new GridLayout();

            if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
                gridLayout.SpanCount = Device.Idiom == TargetIdiom.Phone ? 2 : 4;
            else if (Device.RuntimePlatform == Device.UWP)
            {
                gridLayout.SpanCount = Device.Idiom == TargetIdiom.Desktop || Device.Idiom == TargetIdiom.Tablet ? 4 : 2;
                listView.ItemSize = Device.Idiom == TargetIdiom.Desktop || Device.Idiom == TargetIdiom.Tablet ? 230 : 140;
            }

            listView.LayoutManager = gridLayout;
            listView.DataSource.GroupDescriptors.Add(new GroupDescriptor() { PropertyName = "CreatedDate" });

            deleteImageTapped = new TapGestureRecognizer() { Command = new Command(DeleteImageTapped) };
            this.deleteImage.GestureRecognizers.Add(deleteImageTapped);
        }

        private void ListView_SelectionChanged(object sender, ItemSelectionChangedEventArgs e)
        {
            for (int i = 0; i < e.AddedItems.Count; i++)
            {
                var item = e.AddedItems[i];
                (item as ListViewGalleryInfo).IsSelected = true;
            }
            for (int i = 0; i < e.RemovedItems.Count; i++)
            {
                var item = e.RemovedItems[i];
                (item as ListViewGalleryInfo).IsSelected = false;
            }
            RefreshSelection();
        }

        private void DeleteImageTapped()
        {
            var galleryInfo = listView.SelectedItems.ToList();

            foreach (ListViewGalleryInfo item in galleryInfo)
            {
                if (viewModel.Gallerynfo.Contains(item))
                    viewModel.Gallerynfo.Remove(item);
            }
            RefreshSelection();
        }

        private void RefreshSelection()
        {
            if (listView.SelectedItems.Count > 0)
            {
                viewModel.TitleInfo = "";
                viewModel.HeaderInfo = listView.SelectedItems.Count == 1 ? listView.SelectedItems.Count + " Photo Selected" : listView.SelectedItems.Count + " Photos Selected";
                viewModel.IsVisible = true;
            }
            else
            {
                viewModel.TitleInfo = "Photos";
                viewModel.HeaderInfo = "";
                viewModel.IsVisible = false;
            }
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            try
            {
                base.OnSizeAllocated(width, height);

                if (width > 0 && pageWidth != width)
                {
                    var size = Application.Current.MainPage.Width / listView.ItemSize;
                    gridLayout.SpanCount = (int)size;
                    listView.LayoutManager = gridLayout;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
