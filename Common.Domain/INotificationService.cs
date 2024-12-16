﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public interface INotificationService
    {
        Task SendMessageAsync<T>(string methodName, T message);
    }
}
