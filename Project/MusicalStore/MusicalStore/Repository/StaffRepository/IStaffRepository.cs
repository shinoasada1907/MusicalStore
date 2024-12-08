using MusicalStore.Models;

namespace MusicalStore.Repository.StaffRepository
{
    public interface IStaffRepository
    {
        public IEnumerable<Staff> GetAllStaff();
    }
}
