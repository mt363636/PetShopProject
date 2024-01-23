
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShopProject.Repositories;

namespace PetShopProject.Models
{
    public class AdministratorViewModel
    {
        public IEnumerable<Category>? Categories { get; set; }
        public IEnumerable<Animal>? Animals { get; set; }

    }

   
}

