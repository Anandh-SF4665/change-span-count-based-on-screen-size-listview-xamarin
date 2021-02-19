using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewGridLayout
{
    public class ListViewGalleryInfoRepository
    {
        #region Constructor

        public ListViewGalleryInfoRepository()
        {

        }

        #endregion

        #region GetGalleryInfo

        internal ObservableCollection<ListViewGalleryInfo> GetGalleryInfo()
        {
            var galleryInfo = new ObservableCollection<ListViewGalleryInfo>();
            var random = new Random();

            for (int i = 1; i <= 30; i++)
            {
                var gallery = new ListViewGalleryInfo()
                {
                    Image = ImageSource.FromResource("ListViewXamarin.Images.Image" + i + ".png"),
                    ImageTitle = "IMG_" + random.Next(1242, 5383) + ".jpg",
                    CreatedDate = GetCreatedDate(i),
                };
                galleryInfo.Add(gallery);
            }
            return galleryInfo;
        }

        private string GetCreatedDate(int pos)
        {
            if (pos <= 4)
                return CreatedDates[0];
            else if (pos <= 8)
                return CreatedDates[1];
            else if (pos <= 11)
                return CreatedDates[2];
            else if (pos <= 16)
                return CreatedDates[3];
            else if (pos <= 23)
                return CreatedDates[4];
            return CreatedDates[5];
        }

        #endregion

        #region GelleryInfo

        string[] CreatedDates = new string[] {
            "This Week",
            "Last Week",
            "Two Weeks Ago",
            "Three Weeks Ago",
            "Last Month",
            "Older",
        };

        #endregion
    }
}
