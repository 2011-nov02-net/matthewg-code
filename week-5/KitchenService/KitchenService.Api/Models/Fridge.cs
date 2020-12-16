using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenService.Api.Models {
    public class Fridge : Appliance {
        private readonly ISet<FridgeItem> _items;

        public IReadOnlySet<FridgeItem> Contents => new HashSet<FridgeItem>(_items);

        public Fridge() {
            _items = new HashSet<FridgeItem> {
                new() { Id = 1, Name = "Juice", WeightOz = 12, Expiration = new DateTime(2021, 1, 10) },
                new() { Id = 2, Name = "Ham", WeightOz = 10, Expiration = new DateTime(2020, 12, 1) },
                new() { Id = 3, Name = "Eggs", WeightOz = 12, Expiration = new DateTime(2020, 12, 30) }
            };
        }

        public bool AddItem(FridgeItem item) {
            if (item.Id == default) {
                item.Id = _items.Max(x => x.Id) + 1;
            }
            if (_items.Any(x => x.Id == item.Id)) {
                return false;
            }
            _items.Add(item);
            return true;
        }

        public ISet<FridgeItem> Clean() {
            var expired = _items.Where(x => x.IsExpired).ToHashSet();
            _items.ExceptWith(expired);
            return expired;
        }
    }
}
