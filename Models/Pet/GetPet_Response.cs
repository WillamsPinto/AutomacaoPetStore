﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoPetStore.Models.Pet
{
    public class GetPet_Response
    {
        public long id { get; set; }
        public Category category { get; set; }
        public string name { get; set; }
        public string[] photoUrls { get; set; }
        public List<Tag> tags { get; set; }
        public string status { get; set; }

    }
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class Tag
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
