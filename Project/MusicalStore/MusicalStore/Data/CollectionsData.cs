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
                ImageUrl = "Guitar/FD02.jpg"
            },
            new Collections
            {
                NameCollection = "Trống Drum",
                ImageUrl = "Piano/KK02.jpg"
            },
            new Collections
            {
                NameCollection = "Đàn Guitar",
                ImageUrl = "Drum/OF06.jpg"
            },
        };
    }
}
