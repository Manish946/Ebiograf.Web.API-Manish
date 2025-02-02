﻿using AutoMapper;
using Ebiograf.Web.API.Models.Movie;
using Ebiograf.Web.API.ModelsDto.GenreDto;
using EBiograf.Web.Api.Environment;
using EBiograf.Web.Api.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Repository.GenreRepo
{
    public class GenreRepository : IGenreRepository
    {
        private readonly IMapper mapper;
        private EBiografDbContext context;
        public GenreRepository(EBiografDbContext _context, IMapper _mapper) // Dependency Injection
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<Genre> CreateGenre(CreateGenre createGenre)
        {
            var newGenre =  mapper.Map<Genre>(createGenre);
            await context.Genres.AddAsync(newGenre);
            await context.SaveChangesAsync();
            return newGenre;
        }

        public async Task<Genre> DeleteGenre(int GenreID)
        {
            var getMovie = await context.Genres.FindAsync(GenreID);
            if(getMovie != null)
            {
                context.Genres.Remove(getMovie);
                await context.SaveChangesAsync();
            }
            return getMovie;
        }

        public async Task<IEnumerable<GenreDto>> GetGenres()
        {
            var genres = await mapper.ProjectTo<GenreDto>(context.Genres).ToListAsync();
            return genres;
        }

        public async Task<GenreDto> GetGenreByID(int GenreID)
        {
            return await mapper.ProjectTo<GenreDto>(context.Genres).Where(x=>x.GenreID == GenreID).SingleOrDefaultAsync();
        }

        public async Task<Genre> UpdateGenre(GenreDto updateGenre, int GenreID)
        {
            var UpdatedGenreMap = mapper.Map<Genre>(updateGenre);
            var UpdatedGenre = await context.Genres.FirstOrDefaultAsync(g => g.GenreID == GenreID);
            if (UpdatedGenre == null)
            {
                throw new AppException("Genre not found");
            }
            // Update Genere Properties if provided.
            if (!string.IsNullOrWhiteSpace(updateGenre.GenreName))
            {
                UpdatedGenre.GenreName = updateGenre.GenreName;
            }
            context.Genres.Update(UpdatedGenre);
            await context.SaveChangesAsync();
            return UpdatedGenre;
        }
    }
}
