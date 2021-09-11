using Ebiograf.Web.API.Models.Movie;
using Ebiograf.Web.API.ModelsDto.GenreDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Services.GenreService
{
    public interface IGenreService
    {
        public Task<IEnumerable<GenreDto>> GetGenres();
        public  Task<GenreDto> GetGenreByID(int GenreID);
        public Task<Genre> CreateGenre(CreateGenre createGenre);
        public Task<Genre> UpdateGenre(GenreDto updateGenre);
        public Task<Genre> DeleteGenre(int GenreID);

    }
}
