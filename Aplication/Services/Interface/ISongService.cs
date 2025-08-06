using Aplication.DTO.Songs;

namespace Aplication.Services.Interface
{
    public interface ISongService
    {
        Task<IEnumerable<SongViewDto>> GetAllSongsAsync();
        Task<SongViewDto?> GetSongByIdAsync(int id);
        Task<SongViewDto> CreateSongAsync(CreateSongDto dto, int creatorId);
        Task UpdateSongAsync(UpdateSongDto dto, int updaterId);
        Task DeleteSongAsync(int id, int deleterId);
    }
}
