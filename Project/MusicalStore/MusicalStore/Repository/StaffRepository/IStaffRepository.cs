using MusicalStore.Models;

namespace MusicalStore.Repository.StaffRepository
{
    public interface IStaffRepository
    {
        public IEnumerable<Staff> GetAllStaff();
        public Task<IEnumerable<Staff>> AddNewStaff(Staff staff);
        public Task<IEnumerable<Staff>> UpdateStaff(Staff staff);
        public Task<IEnumerable<Staff>> DeleteStaff(string staffId);
        public Staff GetStaffById(string id);
    }
}
