﻿using WeartherServeApi.Model;

namespace WeartherServeApi.Service
{
    public interface IServiceWearther
    {
        Task<ServiceResponse<WeartherNowModel>> GetWeartherService(string city);

        Task<ServiceResponse<WeartherMonthModel>> GetWeartherMonthService(string city);
    }
}
