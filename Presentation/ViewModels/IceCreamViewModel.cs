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

            Either<IceCreamFailure, List<IceCream>> result = Model.GetAllIceCream();

            if (result.IsLeft())
            {
                Failure = result.Left();
            }
            else
            {
                Failure = null;
                IceCreams = new ObservableCollection<IceCream>();

                foreach (IceCream iceCream in result.Right())
                {
                    IceCreams.Add(new IceCream(iceCream.Id, iceCream.Name, iceCream.Brand, iceCream.ImageUrl));
                }
            }
        }
    }
}
