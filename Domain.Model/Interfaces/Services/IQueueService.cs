using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Interfaces.Services
{
    public interface IQueueService
    {
        Task SendAsync(string messageText);
    }
}
