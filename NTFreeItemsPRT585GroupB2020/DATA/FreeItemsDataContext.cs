using System;
using Microsoft.EntityFrameworkCore;
using NTFreeItemsPRT585GroupB2020.Model;

namespace NTFreeItemsPRT585GroupB2020.DATA
{
    public class FreeItemsDataContext: DbContext
    {
        public FreeItemsDataContext(DbContextOptions<FreeItemsDataContext> options)
               : base(options) { }

        public DbSet<CustomerFeedback> CustomerFeedback { get; set; }

    }
}