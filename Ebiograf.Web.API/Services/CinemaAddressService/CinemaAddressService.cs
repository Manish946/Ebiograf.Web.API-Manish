using Ebiograf.Web.API.Models.Cinema;
using Ebiograf.Web.API.ModelsDto.CinemaAddressDto;
using Ebiograf.Web.API.Repository.CinemaAddressRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Services.CinemaAddressService
{
    public class CinemaAddressService: ICinemaAddressService
    {
        public ICinemaAddressRepository addressRepo;
        public CinemaAddressService(ICinemaAddressRepository _addressRepo)
        {
            addressRepo = _addressRepo;
        }

        public async Task<CinemaAddress> CreateCinemaAddress(AddressDto createAddress) => await addressRepo.CreateCinemaAddress(createAddress);

        public async Task<CinemaAddress> DeleteCinemaAddress(int AddressID) => await addressRepo.DeleteCinemaAddress(AddressID);

        public async Task<CinemaAddress> GetCinemaAddressByID(int AddressID) => await addressRepo.GetCinemaAddressByID(AddressID);

        public async Task<IEnumerable<CinemaAddress>> GetCinemaAddresses() => await addressRepo.GetCinemaAddresses();

        public async Task<CinemaAddress> UpdateCinemaAddress(AddressDto updateAddress, int AddressID) => await addressRepo.UpdateCinemaAddress(updateAddress,AddressID);
    }
}
