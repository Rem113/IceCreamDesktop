using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using IceCreamDesktop.Presentation.Models;
using Monad;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamDesktop.Presentation.ViewModels
{
    public class IceCreamViewModel
    {
        private IceCreamModel Model;

        public ObservableCollection<IceCream> IceCreams { get; set; }
        public IceCreamFailure Failure { get; set; }

        public IceCreamViewModel()
        {
            Model = new IceCreamModel();
            IceCreams = new ObservableCollection<IceCream>();

            GetAllIceCream();
        }

        private async void GetAllIceCream()
        {
            Either<Failure, List<IceCream>> result = await Model.GetAllIceCream();

            result.Match(
                Left: failure =>
                {
                    if (failure is IceCreamFailure)
                        Failure = failure as IceCreamFailure;
                },
                Right: iceCreams =>
                {
                    Failure = null;
                    
                    foreach (IceCream iceCream in iceCreams)
                    {
                        IceCreams.Add(new IceCream(id: iceCream.Id, name: iceCream.Name, brand: iceCream.Brand, imageUrl: iceCream.ImageUrl));
                    }
                }
            )();
        }
    }
}
