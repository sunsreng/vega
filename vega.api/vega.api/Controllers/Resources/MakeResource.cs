﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace vega.api.Controllers.Resources
{
    public class MakeResource
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ModelResource> Models { get; set; } = new Collection<ModelResource>();
    }
}
