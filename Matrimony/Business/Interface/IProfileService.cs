using Matrimony.Models.ViewModel;

namespace Matrimony.Business.Interface
{
    public interface IProfileService
    {
        List<ProfileViewModel> GetProfiles();
        int? CreateProfile(ProfileViewModel profileViewModel);
        int? EditProfile(ProfileViewModel profileViewModel);
        int? DeleteProfile(int? id);
    }
}
