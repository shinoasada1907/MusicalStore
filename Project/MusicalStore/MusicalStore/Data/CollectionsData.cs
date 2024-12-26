using MusicalStore.Models;

namespace MusicalStore.Data
{
    public class CollectionsData
    {
        public static List<Collections> ListCollections = new List<Collections>
        {
            new Collections
            {
                NameCollection = "Đàn Piano",
                ImageUrl = "KK02.jpg",
                Value = "Piano"
            },
            new Collections
            {
                NameCollection = "Trống Drum",
                ImageUrl = "OF06.jpg",
                Value = "Trống"
            },
            new Collections
            {
                NameCollection = "Đàn Guitar",
                ImageUrl = "FD02.jpg",
                Value = "Guitar"
            },
        };
    }
}
