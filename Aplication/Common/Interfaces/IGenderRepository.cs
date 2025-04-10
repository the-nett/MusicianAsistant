using Domain.Entities;

public interface IGenderRepository
{
    Task<IEnumerable<Gender>> GetAllGenders();
    //Task<Profile> VerifyUser(string userUid);
    //Task AddProfile(Profile profile);
}
