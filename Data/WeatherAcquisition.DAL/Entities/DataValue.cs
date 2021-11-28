﻿using System;
using WeatherAcquisition.DAL.Entities.Base;

namespace WeatherAcquisition.DAL.Entities
{
    public class DataValue : Entity
    {
        //DateTimeOffset хранит время в ЮТС в соответствии с временным смещением
        public DateTimeOffset Time { get; set; } = DateTimeOffset.Now;
        public string Value { get; set; }
        public DataSource Source { get; set; }
        public bool IsFault { get; set; }
    }
}
