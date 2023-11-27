using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChatAppClient.Models;

namespace ChatAppClient.Data
{
    public class ChatAppClientContext : DbContext
    {
        public ChatAppClientContext (DbContextOptions<ChatAppClientContext> options)
            : base(options)
        {
        }

        public DbSet<ChatAppClient.Models.Message> Message { get; set; } = default!;
        public DbSet<ChatAppClient.Models.User> User { get; set; } = default!;
    }
}
