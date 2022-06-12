using Kolokwium.Models;
using Kolokwium.Models.dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Services
{
    public class DbService: IDbService
    {
        private readonly MainDbContext _dbContext;

        public DbService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DtoAlbum?> GetAlbum(int id)
        {
            return await _dbContext.Album
                .Where(e => e.IdAlbum == id)
                .Select(album => new DtoAlbum()
                {
                    Name = album.AlbumName,
                    PublishDate = album.PublishDate,
                    Label = album.MusicLabel.Name,
                    IdAlbum = album.IdAlbum,
                    Tracks = album.Tracks.Select(track => new DtoTrack()
                    {
                        Name = track.TackName,
                        Duration = track.Duration
                    }).ToList()
                }).FirstOrDefaultAsync();
        }

        public async Task<bool> RemoveMusician(int id)
        {
            using(var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try {
                    var musican = await _dbContext.Musician.FirstOrDefaultAsync(e => e.IdMusician == id);
                    foreach(Musican_Track musicanTrack in musican.Musican_Tracks)
                    {
                        if (musicanTrack.Track.Album == null)
                        {
                           await transaction.RollbackAsync();
                           return false;
                        } else
                        {
                            _dbContext.Remove(musicanTrack);
                        }
                    }
                    _dbContext.Remove(musican);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return true;
                } catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
    }
}
