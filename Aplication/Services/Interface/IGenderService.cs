
using Aplication.DTO.Gender;
using Domain.Entities;

namespace Aplication.Services.Interface
{
    public interface IGenderService
    {
        Task<IEnumerable<GetGenderDto>> GetAllGenders();
        //Task <Profile> VerifyUser(string uid);
        //Task AddProfile(CreateProfileDto dto, string uid);
    }
}
