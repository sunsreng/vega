﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace vega.api.Controllers.Resources
{
    public class MakeResource : KeyValuePairResource
    {
        public ICollection<KeyValuePairResource> Models { get; set; } = new Collection<KeyValuePairResource>();
    }
}
