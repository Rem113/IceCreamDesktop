using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using IceCreamDesktop.Domain.Interfaces;
using Monad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamDesktop.Data.Repositories
{
    public class IceCreamRepository : IIceCreamRepository
    {
        private readonly KioskContext Kiosk;

        public IceCreamRepository(KioskContext kiosk)
        {
            Kiosk = kiosk;
        }

        public Task<List<IceCream>> GetAllIceCreams()
        {
            if (Kiosk.IceCreams.Any())
                return Task.FromResult(Kiosk.IceCreams.ToList());
            return Task.FromResult(new List<IceCream>());
        }

        public async Task<Either<Failure, IceCream>> AddIceCream(IceCream iceCream)
        {
            try
            {
                Kiosk.IceCreams.Add(iceCream);
                await Kiosk.SaveChangesAsync();
                return () => iceCream;
            } catch (Exception)
            {
                return () => new DataAccessFailure("An error has occured");
            }
        }
    }
}