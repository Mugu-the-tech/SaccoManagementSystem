﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Model
{
    public interface IPaymentRepository
    {
        void Add(PaymentModel paymentModel);
    }
}
