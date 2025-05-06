using Matrimony.Business.Interface;
using Matrimony.Models;
using Matrimony.Models.ViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Matrimony.Business.Implementation
{
    public class ProfileService : IProfileService
    {
        private readonly MatrimonyContext _mContext;
        public ProfileService(MatrimonyContext matrimonyContext)
        {
            _mContext = matrimonyContext;
        }

        public List<ProfileViewModel> GetProfiles()
        {
            List<Profile> profiles = _mContext.Profiles.ToList();
            List<ProfileViewModel> profileViewModels = new List<ProfileViewModel>();
            foreach (Profile profile in profiles)
            {
                ProfileViewModel profileViewModel = new ProfileViewModel();
                profileViewModel.Name = profile.Name;

                profileViewModels.Add(profileViewModel);
            }
            return profileViewModels;
        }

        public int? CreateProfile(ProfileViewModel profileViewModel)
        {
            int? result = null;
            Profile profile = new Profile
            {
                Name = profileViewModel.Name
            };

            _mContext.Profiles.Add(profile);

            result = _mContext.SaveChanges();
            return result;
        }

        public int? EditProfile(ProfileViewModel profileViewModel)
        {
            var profile = _mContext.Profiles.FirstOrDefault(p => p.ProfileId == profileViewModel.ProfileId);
            int? result = null;
            if (profile != null)
            {
                profile.Name = profileViewModel.Name;
                result = _mContext.SaveChanges();
            }
            return result;
        }
        public int? DeleteProfile(int? id)
        {
            var profile = _mContext.Profiles.FirstOrDefault(p => p.ProfileId == id);
            int? result = null;
            if (profile != null)
            {
                _mContext.Profiles.Remove(profile);
                result = _mContext.SaveChanges();
            }
            return result;
        }
    }
}
