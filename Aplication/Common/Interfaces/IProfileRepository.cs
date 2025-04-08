using Domain.Entities;

public interface IProfileRepository
{
    Task<IEnumerable<Profile>> GetAllProfiles();
    Task<Profile> VerifyUser(string userUid);
    Task AddProfile(Profile profile);
}
