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
                ImageUrl = "https://firebasestorage.googleapis.com/v0/b/musicalstore-f2c0a.firebasestorage.app/o/MusicalInstument%2FPiano%2FKC03.jpg?alt=media&token=129d9582-d5fc-4185-9703-9ae4a2ae6be0"
            },
            new Collections
            {
                NameCollection = "Trống Drum",
                ImageUrl = "https://firebasestorage.googleapis.com/v0/b/musicalstore-f2c0a.firebasestorage.app/o/MusicalInstument%2FDrum%2FOI04.jpg?alt=media&token=47ad3180-7738-42f5-81c3-c4a74331cde1"
            },
            new Collections
            {
                NameCollection = "Đàn Guitar",
                ImageUrl = "https://firebasestorage.googleapis.com/v0/b/musicalstore-f2c0a.firebasestorage.app/o/MusicalInstument%2FGuitar%2FTG04.jpg?alt=media&token=a49370b1-0398-4a1c-861b-ab636ac9c1e5"
            },
        };
    }
}
