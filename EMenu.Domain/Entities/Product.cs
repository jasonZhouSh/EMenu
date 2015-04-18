﻿using EMenu.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMenu.Domain.Entities
{
    public class Product:EntityBase,IAggregateRoot
    {
        public string Name { get; set; }
    }
}
