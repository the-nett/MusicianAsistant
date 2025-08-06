using Aplication.Common.Interfaces;
using Aplication.DTO.Songs;
using Aplication.Services.Interface;
using AutoMapper;
using Domain.Entities;

namespace Aplication.Services.Implementation
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _songRepository;
        private readonly IMapper _mapper;
        private readonly IProfileRepository _profileRepository;

        public SongService(ISongRepository songRepository, IMapper mapper, IProfileRepository profileRepository)
        {
            _songRepository = songRepository;
            _mapper = mapper;
            _profileRepository = profileRepository;
        }

        public async Task<IEnumerable<SongViewDto>> GetAllSongsAsync()
        {
            var songs = await _songRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SongViewDto>>(songs);
        }

        public async Task<SongViewDto?> GetSongByIdAsync(int id)
        {
            var song = await _songRepository.GetByIdAsync(id);
            return _mapper.Map<SongViewDto>(song);
        }

        public async Task<SongViewDto> CreateSongAsync(CreateSongDto dto, int creatorId)
        {
            var song = _mapper.Map<Song>(dto);
            song.CreatedBy = creatorId; // Set the creator from the authenticated user ID
            await _songRepository.AddAsync(song);

            // To return the full SongViewDto with CreatorName, we need to re-fetch or populate the Creator
            song.Creator = await _profileRepository.GetProfileById(creatorId); // Assuming you have a way to get the profile
            return _mapper.Map<SongViewDto>(song);
        }

        public async Task UpdateSongAsync(UpdateSongDto dto, int updaterId)
        {
            var existingSong = await _songRepository.GetByIdAsync(dto.SongId);

            if (existingSong == null)
            {
                throw new KeyNotFoundException($"Song with ID {dto.SongId} not found.");
            }

            // Authorization check: Only the creator can update the song
            if (existingSong.CreatedBy != updaterId)
            {
                throw new UnauthorizedAccessException("You are not authorized to update this song.");
            }

            _mapper.Map(dto, existingSong);
            await _songRepository.UpdateAsync(existingSong);
        }

        public async Task DeleteSongAsync(int id, int deleterId)
        {
            var existingSong = await _songRepository.GetByIdAsync(id);

            if (existingSong == null)
            {
                throw new KeyNotFoundException($"Song with ID {id} not found.");
            }

            // Authorization check: Only the creator can delete the song
            if (existingSong.CreatedBy != deleterId)
            {
                throw new UnauthorizedAccessException("You are not authorized to delete this song.");
            }

            await _songRepository.DeleteAsync(id);
        }
    }
}
