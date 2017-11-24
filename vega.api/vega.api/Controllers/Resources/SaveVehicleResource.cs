﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace vega.api.Controllers.Resources
{
    public class SaveVehicleResource
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public bool IsRegistered { get; set; }
        public ContactResource Contact { get; set; }
        public ICollection<int> Features { get; set; } = new Collection<int>();
    }
}
