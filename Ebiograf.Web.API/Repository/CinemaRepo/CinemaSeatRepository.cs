using AutoMapper;
using EBiograf.Web.Api.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Repository.CinemaRepo
{
    public class CinemaSeatRepository:ICinemaSeatRepository
    {
        private readonly EBiografDbContext context;
        private IMapper mapper;
        public CinemaSeatRepository(EBiografDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }
    }
}
