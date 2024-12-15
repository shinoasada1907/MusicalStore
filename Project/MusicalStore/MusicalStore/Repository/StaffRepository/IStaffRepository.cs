using MusicalStore.Models;

namespace MusicalStore.Repository.StaffRepository
{
    public interface IStaffRepository
    {
        public IEnumerable<Staff> GetAllStaff();
        public Task<IEnumerable<Staff>> AddNewStaff(Staff staff);
    }
}
