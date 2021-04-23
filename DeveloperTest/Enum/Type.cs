using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace  DeveloperTest.Enum
{
    public enum Type
    {
    [Display(Name = "Large")]
    Large = 1,
        [Display(Name = "Small")]
    Small = 2
    }
}

