using Ebiograf.Web.API.Models.Cinema;
using Ebiograf.Web.API.ModelsDto.CinemaAddressDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Repository.CinemaAddressRepo
{
    public interface ICinemaAddressRepository
    {

        public Task<IEnumerable<CinemaAddress>> GetCinemaAddresses();
        public Task<CinemaAddress> GetCinemaAddressByID(int AddressID);
        public Task<CinemaAddress> CreateCinemaAddress(AddressDto createAddress);
        public Task<CinemaAddress> UpdateCinemaAddress(AddressDto updateAddress, int AddressID);
        public Task<CinemaAddress> DeleteCinemaAddress(int AddressID);
    }

}
